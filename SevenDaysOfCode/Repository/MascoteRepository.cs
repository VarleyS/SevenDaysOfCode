using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace SevenDaysOfCode.Repository
{
    public class MascoteRepository
    {
        Pokemon newPokemon = new Pokemon();
        private string meusMascotesPath;
        private const string cachePath = "cache.json";

        public MascoteRepository(string fileName)
        {
            meusMascotesPath = fileName;
        }

        public void SalvarMascote(Mascote mascote)
        {
            List<Mascote> meusMascotes = ViewAll();

            meusMascotes.Remove(mascote);
            meusMascotes.Add(mascote);

            SalvaLista(meusMascotes);
        }

        public void AtualizaMascote(Mascote mascote)
        {
            List<Mascote> meusMascotes = ViewAll();

            meusMascotes.Remove(mascote);
            meusMascotes.Add(mascote);

            SalvaLista(meusMascotes);
        }

        public void RemoveMascote(Mascote mascote)
        {
            List<Mascote> meusMascotes = ViewAll();

            meusMascotes.Remove(mascote);

            SalvaLista(meusMascotes);
        }

        public List<Mascote> ViewAll()
        {
            string mascotes = File.ReadAllText(meusMascotesPath);
            List<Mascote> lista = JsonSerializer.Deserialize<List<Mascote>>(mascotes);
            lista.Sort();

            return lista;
        }

        private void SalvaLista(List<Mascote> atualizaLista)
        {
            string meusMascotesUpdate = JsonSerializer.Serialize(atualizaLista.Distinct(), new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(meusMascotesPath, meusMascotesUpdate);
        }

        public Pokemon GetPokemon(string nome)
        {
            if (nome == string.Empty)
                throw new ArgumentException();

            string cache = File.ReadAllText(cachePath);

            List<Pokemon> cachePokemonList = JsonSerializer.Deserialize<List<Pokemon>>(cache).ToList();

            foreach (Pokemon po in cachePokemonList)
            {
                if (po.Equals(nome))
                    return po;
            }

            try
            {
                var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{nome}");
                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request);
                List<Ability> abilidades = new List<Ability>();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Salva Pokemon
                    newPokemon = JsonSerializer.Deserialize<Pokemon>(response.Content);

                    cachePokemonList.Add(newPokemon);

                    string newCache = JsonSerializer.Serialize(cachePokemonList.Distinct(), new JsonSerializerOptions { WriteIndented = true });

                    File.WriteAllText(cachePath, newCache);

                    return newPokemon;

                }
                else
                {
                    Console.WriteLine(response.ErrorMessage);
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newPokemon;
        }
    }
}

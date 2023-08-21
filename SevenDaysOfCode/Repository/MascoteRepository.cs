using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SevenDaysOfCode.Repository
{
    public class MascoteRepository
    {
        public static void GetPokemon(string nome)
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{nome}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            List<Ability> abilidades = new List<Ability>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var tes = JsonSerializer.Deserialize<Mascote>(response.Content);

                Console.WriteLine($"Nome: {tes.Nome.ToUpper()}");
                Console.WriteLine($"Altura: {tes.Altura}");
                Console.WriteLine($"Peso: {tes.Peso}\n");
                Console.WriteLine("Habilidades:");

                foreach (var item in tes.Abilidades)
                {
                    Console.WriteLine($"Nome da habilidade: {item.ability.name.ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
            Console.ReadKey();
        }
    }
}

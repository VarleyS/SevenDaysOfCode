using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace SevenDaysOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InvoqueGet();
        }

        private static void InvoqueGet()
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/charmander");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var tes = JsonSerializer.Deserialize<Mascote>(response.Content);
                List<Ability> abilidades = new List<Ability>();
                Console.WriteLine($"Id do mascote é: {tes.Id}");
                Console.WriteLine($"Nome: {tes.Nome}");
                Console.WriteLine($"Altura: {tes.Altura}");
                Console.WriteLine($"Peso: {tes.Peso}");
                Console.WriteLine("Habilidades:");                

                foreach (var item in tes.abilidades) 
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

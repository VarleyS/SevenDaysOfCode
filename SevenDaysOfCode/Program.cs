using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/bulbasaur");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
            }
            else 
            { 
                Console.WriteLine(response.ErrorMessage); 
            }
            Console.ReadKey();
        }
    }
}

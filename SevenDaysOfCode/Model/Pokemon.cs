using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace SevenDaysOfCode
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonPropertyName("height")]
        public double Altura { get; set; }

        [JsonPropertyName("weight")]
        public double Peso { get; set; }

        [JsonPropertyName("abilities")]
        public List<Ability> Abilidades { get; set; }
    }
}

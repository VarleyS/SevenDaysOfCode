using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SevenDaysOfCode
{
    public class Mascote
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonPropertyName("height")]
        public double Altura { get; set; }

        [JsonPropertyName("weight")]
        public double Peso { get; set; }

        [JsonPropertyName("abilities")]
        public List<Ability> abilidades { get; set; }
    }
}

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
    public class Pokemon : IComparable
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonPropertyName("height")]
        public double Altura { get; set; }

        [JsonPropertyName("weight")]
        public double Peso { get; set; }

        [JsonPropertyName("abilities")]
        public List<Ability> Abilidades { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is string) 
            {
                return this.Nome.CompareTo(obj);
            }

            if (obj is Pokemon)
            {
                return this.Nome.CompareTo((obj as Pokemon).Nome);
            }

            return -1;
        }

        public override bool Equals(Object obj) 
        {
            if (this.CompareTo(obj) == 0)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return this.Nome.GetHashCode();
        }

        public override string ToString()
        {
            var ss = new StringBuilder();

            ss.Append($"Nome: \t{Nome}\n");
            ss.Append($":Altura: \t{Altura}\n");
            ss.Append($"Peso: \t{Peso}\n");
            ss.Append($"Abilidades: \t{Abilidades}\n");

            return ss.ToString();
        }
    }
}

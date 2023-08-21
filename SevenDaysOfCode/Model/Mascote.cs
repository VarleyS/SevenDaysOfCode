using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SevenDaysOfCode
{
    public class Mascote : Pokemon
    {
        public RangeAttribute hungry { get; set; }
        public RangeAttribute sleepy { get; set; }
        public RangeAttribute happiness { get; set; }
        public RangeAttribute tiredness { get; set; }
        public RangeAttribute health { get; set; }

        private void Inicializar()
        {
            hungry = new RangeAttribute(0, 5);
            sleepy = new RangeAttribute(0, 5);
            happiness = new RangeAttribute(0, 5);
            tiredness = new RangeAttribute(0, 5);
            health = new RangeAttribute(0, 5);
        }

        public Mascote()
        {
            Inicializar();
        }

        public Mascote(Pokemon pokemon)
        {
            Inicializar();
            Nome = pokemon.Nome;
            Altura = pokemon.Altura;
            Peso = pokemon.Peso;
            Abilidades = pokemon.Abilidades;
        }
    }
}

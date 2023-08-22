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
    public class Mascote : Pokemon, IComparable<Mascote>
    {
        public Atributos hungry { get; set; }
        public Atributos sleepy { get; set; }
        public Atributos happiness { get; set; }
        public Atributos tiredness { get; set; }
        public Atributos health { get; set; }

        private void Inicializar()
        {
            this.hungry = new Atributos(0, 10, 5);
            this.sleepy = new Atributos(0, 10, 5);
            this.happiness = new Atributos(0, 10, 5);
            this.tiredness = new Atributos(0, 10, 5);
            this.health = new Atributos(0, 10, 5);
        }

        public Mascote()
        {
            Inicializar();
        }

        public Mascote(Pokemon pokemon)
        {
            Inicializar();
            this.Nome = pokemon.Nome;
            this.Altura = pokemon.Altura;
            this.Peso = pokemon.Peso;
            this.Abilidades = pokemon.Abilidades;
        }

        public void Comer()
        {
            if (hungry.Value == 0)
            {
                hungry.Modificar(-1);
            }
            else
            {
                this.hungry.Modificar(-1);
                this.sleepy.Modificar(1);
                this.happiness.Modificar(1);
                this.health.Modificar(1);
            }
        }

        public void Dormir()
        {
            this.sleepy.Modificar(-8);
            this.hungry.Modificar(1);
            this.happiness.Modificar(1);
            this.tiredness.Modificar(-1);
            this.health.Modificar(1);
        }

        public void Jogar()
        {
            if(tiredness.Value == 10) 
            {
                health.Modificar(-1);
            }
            else
            {
                this.hungry.Modificar(1);
                this.sleepy.Modificar(1);
                this.happiness.Modificar(1);
                this.tiredness.Modificar(1);
            }
        }

        public void Medicamento()
        {
            health.Modificar(5);
        }

        public int CompareTo(Mascote outro)
        {
            return this.Nome.CompareTo(outro.Nome);
        }

        public string RetornaSaude()
        {
            if (this.health.Value > 7)
                return "Saudável";
            if (this.health.Value > 5)
                return "Pouco doente";

            return "Doente";
        }

        public string RetornaFome()
        {
            if(this.hungry.Value > 7)
            {
                return "Está com muita fome!";
            }
            if (this.hungry.Value > 5)
            {
                return "Está com fome!";
            }

            return "Não esta com fome.";
        }

        public string RetornaSono()
        {
            if(this.sleepy.Value > 8)
            {
                return "Muito sono!!";
            }
            if (this.sleepy.Value > 6)
            {
                return "Esta com sono!";
            }

            return "Não esta com sono.";
        }

        public string RetornaFelicidade()
        {
            if (this.happiness.Value > 8)
            {
                return "Muito feliz!!!";
            }
            if (this.happiness.Value > 6)
            {
                return "Está feliz!!";
            }

            return "Está triste!!!";
        }

        public string RetornaCanssado()
        {
            if(this.tiredness.Value > 8)
            {
                return "Muito cansado!!!";
            }
            if(this.tiredness.Value > 6)
            {
                return "Está cansado!!";
            }

            return "Não está cansado.";
        }

    }
    public class Atributos
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Value { get; set; }
        public Atributos(int min, int max, int value)
        {
            Min = min;
            Max = max;
            Value = value;
        }

        public void Modificar(int num)
        {
            Value += num;

            if (Value > Max)
            {
                Value = Max;
            }
            else
            {
                if (Value < Min)
                {
                    Value = Min;
                }
            }
        }
    }
}

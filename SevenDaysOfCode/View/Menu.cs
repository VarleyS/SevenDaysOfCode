using SevenDaysOfCode.Controller;
using SevenDaysOfCode.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SevenDaysOfCode
{
    public class Menu
    {
        string nomeJogador;
        string mascote;
        string opcao;
        MascoteRepository repository;
        public void BoasVindas()
        {
            Console.WriteLine(@"
████████╗░█████╗░███╗░░░███╗░█████╗░░██████╗░░█████╗░████████╗░█████╗░██╗░░██╗██╗
╚══██╔══╝██╔══██╗████╗░████║██╔══██╗██╔════╝░██╔══██╗╚══██╔══╝██╔══██╗██║░░██║██║
░░░██║░░░███████║██╔████╔██║███████║██║░░██╗░██║░░██║░░░██║░░░██║░░╚═╝███████║██║
░░░██║░░░██╔══██║██║╚██╔╝██║██╔══██║██║░░╚██╗██║░░██║░░░██║░░░██║░░██╗██╔══██║██║
░░░██║░░░██║░░██║██║░╚═╝░██║██║░░██║╚██████╔╝╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║██║
░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝░╚═════╝░░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝");
            Console.WriteLine();

            Console.WriteLine("Qual o seu nome?");
            nomeJogador = Console.ReadLine().ToUpper();
        }

        public void MenuPrincipal()
        {
            Console.WriteLine("*************************************************Menu Principal*************************************************");
            Console.WriteLine($"\nSeja bem vindo {nomeJogador}!");
            Console.WriteLine($"\n{nomeJogador} qual opção voçê deseja:");
            Console.WriteLine("\n1 - Adotar um mascote virtual");
            Console.WriteLine("\n2 - Ver seus mascotes");
            Console.WriteLine("\n3 - Sair\n");
        }

        public void ListaMascotes()
        {
            Console.WriteLine("*********************************************Lista de mascotes para adoção*********************************************\n");
            Console.WriteLine("Bulbasaur");
            Console.WriteLine("Charmander");
            Console.WriteLine("Squirtle");
            Console.WriteLine("Caterpie");
            Console.WriteLine("Pidgey\n");

            Console.WriteLine("Qual mascote gostaria de adotar?");
        }

        internal static bool OpcaoSimOuNao(string message)
        {
            Console.WriteLine($"\n{message}");

            var opts = new Dictionary<string, string>()
            {
                ["Y"] = "Sim",
                ["N"] = "Não"
            };

            foreach (var item in opts)
            {
                Console.WriteLine(item.Key + "=" + item.Value);
            }

            while (true)
            {
                string opt = Console.ReadLine().ToUpper();

                switch (opt)
                {
                    case "Y": return true;
                        break;
                    case "N": return false;
                        break;
                    default: Console.WriteLine("Opção inválida!!!");
                        break;
                }
            }
        } 

        internal static string ProgressBar(int value, int total = 10)
        {
            if (value > total)
                value = total; 
            
            var ss = new StringBuilder(32);
            ss.Append('|');
            Enumerable.Range(0, value).ToList().ForEach(i => ss.Append("="));
            Enumerable.Range(0, total - value).ToList().ForEach(i => ss.Append("-"));
            ss.Append('|');

            return ss.ToString();
        }

        internal static string MenuView(Dictionary<string, string> option)
        {
            Console.WriteLine("\nEscolha uma opção:");

            foreach (var opt in option)
            {
                Console.WriteLine(opt.Key + " - " + opt.Value);
            }

            while (true)
            {
                string opt = Console.ReadLine();
                if(option.Keys.Contains(opt))
                    return opt;
                Console.WriteLine("Opção inválida, tente novamente");
            }
        } 
    }
}

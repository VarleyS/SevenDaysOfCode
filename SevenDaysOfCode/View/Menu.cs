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

        public void MenuAdocaoMascote()
        {
            int mAdocao = 1;

            while (mAdocao == 1)
            {
                Console.WriteLine("*************************************************Menu de Adoção*************************************************");

                Console.WriteLine($"{nomeJogador} que você deseja: ");
                Console.WriteLine("1 - Lista de mascotes");
                Console.WriteLine($"2 - Saber mais sobre o {mascote}");
                Console.WriteLine($"3 - Adotar o {mascote}");
                Console.WriteLine("4 - Volta ao Menu Principal");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListaMascotes();
                        break;
                    case "2":
                        MascoteRepository.GetPokemon(mascote.ToLower());
                        break;
                    case "3":
                        Console.WriteLine("Adotar mascote");
                        break;
                    case "4":
                        mAdocao = 0;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
        public void VerMascotes()
        {
            Console.WriteLine("acessou menu Ver Mascotes");
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
            mascote = Console.ReadLine();
        }
    }
}

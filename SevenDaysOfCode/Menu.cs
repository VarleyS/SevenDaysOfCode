using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDaysOfCode
{
    public class Menu
    {
        public void ExibeMenu()
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
            var nome = Console.ReadLine();

            Console.WriteLine($"\nSeja bem vindo {nome}!");

            Console.WriteLine("*************************************************MENU*************************************************");
            Console.WriteLine($"\n{nome} qual opção voçê deseja:");
            Console.WriteLine("\n1 - Adotar um mascote virtual");
            Console.WriteLine("\n2 - Ver seus mascotes");
            Console.WriteLine("\n3 - Sair\n");

            var opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: MenuAdocaoMascote();
                    break;
                case 2: Console.WriteLine($"Você digitou a opção: {opcao}");
                    break;
                case 3: Console.WriteLine($"Você digitou a opção: {opcao}");
                    break;
                default: 
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Console.ReadKey();
        }

        public void MenuAdocaoMascote()
        {
            Console.WriteLine("***********Lista de mascotes para adoção***********\n");
            Console.WriteLine("Qual dos mascotes abaixo deseja adotar?\n");
            Console.WriteLine("Bulbasaur");
            Console.WriteLine("Charmander");
            Console.WriteLine("Squirtle");
            Console.WriteLine("Caterpie");
            Console.WriteLine("Pidgey\n");

            var mascote = Console.ReadLine();

            Console.WriteLine("O que você deseja: ");
            Console.WriteLine($"1 - Saber mais sobre o {mascote}");
            Console.WriteLine($"2 - Adotar o {mascote}");
            Console.WriteLine("3 - Volta");

            var opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: GetApi.InvoqueGet(mascote.ToLower());
                    break;
                case 2: Console.WriteLine("Adotado com sucesso, o ovo esta chocando!");
                    break;
                case 3: ExibeMenu();
                    break;
                default:
                    Console.WriteLine("Número inválido!");
                    break;
            }
        }
    }
}

using SevenDaysOfCode.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDaysOfCode.Controller
{
    public class TamagotchiController
    {
        Menu menu = new Menu();
        MascoteRepository repository;
        string opcaoUsuario;
        int jogar = 1;

        public void Jogar()
        {
            menu.BoasVindas();

            while(jogar == 1)
            {
                menu.MenuPrincipal();
                opcaoUsuario = Console.ReadLine();

                switch (opcaoUsuario)
                {
                    case "1": AdotarMascote();
                        break;
                    case "2": menu.VerMascotes();
                        break;
                    case "3": jogar = 0;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private void AdotarMascote()
        {
            while (jogar == 1)
            {
                menu.MenuAdocaoMascote();
                opcaoUsuario = Console.ReadLine();

                switch (opcaoUsuario)
                {
                    case "1":
                        menu.ListaMascotes();
                        break;
                    case "2":
                        repository.GetPokemon(opcaoUsuario.ToLower());
                        break;
                    case "3":
                        Console.WriteLine("Adotar mascote");
                        break;
                    case "4":
                        jogar = 0;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}

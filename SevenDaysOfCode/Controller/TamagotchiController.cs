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
        public void Jogar()
        {
            string opcaoUsuario;
            int jogar = 1;
            menu.BoasVindas();

            while(jogar == 1)
            {
                menu.MenuPrincipal();
                opcaoUsuario = Console.ReadLine();

                switch (opcaoUsuario)
                {
                    case "1": menu.MenuAdocaoMascote();
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

    }
}

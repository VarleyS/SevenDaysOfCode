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
        private MascoteRepository _repository;
        string mascote;
        string opcaoUsuario;
        int jogar = 1;

        public TamagotchiController(MascoteRepository repository)
        {
            _repository = repository;
        }

        public void Jogar()
        {
            menu.BoasVindas();

            while (jogar == 1)
            {
                menu.MenuPrincipal();
                opcaoUsuario = Console.ReadLine();

                switch (opcaoUsuario)
                {
                    case "1":
                        AdotarMascote();
                        break;
                    case "2":
                        VerMascotes();
                        break;
                    case "3":
                        jogar = 0;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private void AdotarMascote()
        {
            Console.WriteLine("Qual o nome do mascote que deseja adotar? ");
            menu.ListaMascotes();
            string nomeMascote = Console.ReadLine();

            try
            {
                Pokemon pokemon = _repository.GetPokemon(nomeMascote.ToLower());
                Console.WriteLine($"Nome: {pokemon.Nome.ToUpper()}");
                Console.WriteLine($"Altura: {pokemon.Altura}");
                Console.WriteLine($"Peso: {pokemon.Peso}\n");
                Console.WriteLine("Habilidades:");

                foreach (var item in pokemon.Abilidades)
                {
                    Console.WriteLine($"Nome da habilidade: {item.ability.name.ToUpper()}");
                }

                Console.WriteLine($"\nTem certeza que quer adotar {pokemon.Nome} ?\n");

                var simOuNao = Console.ReadLine();

                Console.WriteLine();
                if (simOuNao == "sim")
                {
                    _repository.SalvarMascote(new Mascote(pokemon));
                    Console.WriteLine("Mascote adotado com sucesso, o ovo esta chocando!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void VerMascotes()
        {
            List<Mascote> mascotes = _repository.ViewAll();

            if (mascotes.Count > 0)
            {
                Console.WriteLine($"Seus mascotes ({mascotes.Count})");

                var opcao = new Dictionary<string, string>();

                for (int i = 0; i < mascotes.Count; i++)
                {
                    opcao.Add((i + 1).ToString(), $"Nome: {mascotes[i].Nome}\t Saúde: {Menu.ProgressBar(mascotes[i].health.Value)}");
                }
                opcao.Add("q", "Exit");
                string opt = Menu.MenuView(opcao);

                if (opt == "q")
                {
                    return;
                }

                VerDetalhesMascotes(mascotes[int.Parse(opt) - 1]);
            }
        }

        private void VerDetalhesMascotes(Mascote mascote)
        {
            Console.WriteLine($"Mascote: {mascote.Nome.ToUpper()}");

            if (mascote.health.Value == 0)
            {
                Console.WriteLine(@"´´´´´´´´´´´´´´´´´´´ ¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶´´´´´´´´´´´´´´´´´´´`
´´´´´´´´´´´´´´´´´¶¶¶¶¶¶´´´´´´´´´´´´´¶¶¶¶¶¶¶´´´´´´´´´´´´´´´´
´´´´´´´´´´´´´´¶¶¶¶´´´´´´´´´´´´´´´´´´´´´´´¶¶¶¶´´´´´´´´´´´´´´
´´´´´´´´´´´´´¶¶¶´´´´´´´´´´´´´´´´´´´´´´´´´´´´´¶¶´´´´´´´´´´´´
´´´´´´´´´´´´¶¶´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´¶¶´´´´´´´´´´´
´´´´´´´´´´´¶¶´´´´´´´´´´´´´´´´´´´´´`´´´´´´´´´´´¶¶´´´´´´´´´´`
´´´´´´´´´´¶¶´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´¶¶´´´´´´´´´´
´´´´´´´´´´¶¶´¶¶´´´´´´´´´´´´´´´´´´´´´´´´´´´´´¶¶´¶¶´´´´´´´´´´
´´´´´´´´´´¶¶´¶¶´´´´´´´´´´´´´´´´´´´´´´´´´´´´´¶¶´´¶´´´´´´´´´´
´´´´´´´´´´¶¶´¶¶´´´´´´´´´´´´´´´´´´´´´´´´´´´´´¶¶´´¶´´´´´´´´´´
´´´´´´´´´´¶¶´´¶¶´´´´´´´´´´´´´´´´´´´´´´´´´´´´¶¶´¶¶´´´´´´´´´´
´´´´´´´´´´¶¶´´¶¶´´´´´´´´´´´´´´´´´´´´´´´´´´´¶¶´´¶¶´´´´´´´´´´
´´´´´´´´´´´¶¶´¶¶´´´¶¶¶¶¶¶¶¶´´´´´¶¶¶¶¶¶¶¶´´´¶¶´¶¶´´´´´´´´´´´
´´´´´´´´´´´´¶¶¶¶´¶¶¶¶¶¶¶¶¶¶´´´´´¶¶¶¶¶¶¶¶¶¶´¶¶¶¶¶´´´´´´´´´´´
´´´´´´´´´´´´´¶¶¶´¶¶¶¶¶¶¶¶¶¶´´´´´¶¶¶¶¶¶¶¶¶¶´¶¶¶´´´´´´´´´´´´´
´´´´¶¶¶´´´´´´´¶¶´´¶¶¶¶¶¶¶¶´´´´´´´¶¶¶¶¶¶¶¶¶´´¶¶´´´´´´¶¶¶¶´´´
´´´¶¶¶¶¶´´´´´¶¶´´´¶¶¶¶¶¶¶´´´¶¶¶´´´¶¶¶¶¶¶¶´´´¶¶´´´´´¶¶¶¶¶¶´´
´´¶¶´´´¶¶´´´´¶¶´´´´´¶¶¶´´´´¶¶¶¶¶´´´´¶¶¶´´´´´¶¶´´´´¶¶´´´¶¶´´
´¶¶¶´´´´¶¶¶¶´´¶¶´´´´´´´´´´¶¶¶¶¶¶¶´´´´´´´´´´¶¶´´¶¶¶¶´´´´¶¶¶´
¶¶´´´´´´´´´¶¶¶¶¶¶¶¶´´´´´´´¶¶¶¶¶¶¶´´´´´´´¶¶¶¶¶¶¶¶¶´´´´´´´´¶¶
¶¶¶¶¶¶¶¶¶´´´´´¶¶¶¶¶¶¶¶´´´´¶¶¶¶¶¶¶´´´´¶¶¶¶¶¶¶¶´´´´´´¶¶¶¶¶¶¶¶
´´¶¶¶¶´¶¶¶¶¶´´´´´´¶¶¶¶¶´´´´´´´´´´´´´´¶¶¶´¶¶´´´´´¶¶¶¶¶¶´¶¶¶´
´´´´´´´´´´¶¶¶¶¶¶´´¶¶¶´´¶¶´´´´´´´´´´´¶¶´´¶¶¶´´¶¶¶¶¶¶´´´´´´´´
´´´´´´´´´´´´´´¶¶¶¶¶¶´¶¶´¶¶¶¶¶¶¶¶¶¶¶´¶¶´¶¶¶¶¶¶´´´´´´´´´´´´´´
´´´´´´´´´´´´´´´´´´¶¶´¶¶´¶´¶´¶´¶´¶´¶´¶´¶´¶¶´´´´´´´´´´´´´´´´´
´´´´´´´´´´´´´´´´¶¶¶¶´´¶´¶´¶´¶´¶´¶´¶´¶´´´¶¶¶¶¶´´´´´´´´´´´´´´
´´´´´´´´´´´´¶¶¶¶¶´¶¶´´´¶¶¶¶¶¶¶¶¶¶¶¶¶´´´¶¶´¶¶¶¶¶´´´´´´´´´´´´
´´´´¶¶¶¶¶¶¶¶¶¶´´´´´¶¶´´´´´´´´´´´´´´´´´¶¶´´´´´´¶¶¶¶¶¶¶¶¶´´´´
´´´¶¶´´´´´´´´´´´¶¶¶¶¶¶¶´´´´´´´´´´´´´¶¶¶¶¶¶¶¶´´´´´´´´´´¶¶´´´
´´´´¶¶¶´´´´´¶¶¶¶¶´´´´´¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶´´´´´¶¶¶¶¶´´´´´¶¶¶´´´´
´´´´´´¶¶´´´¶¶¶´´´´´´´´´´´¶¶¶¶¶¶¶¶¶´´´´´´´´´´´¶¶¶´´´¶¶´´´´´´
´´´´´´¶¶´´¶¶´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´¶¶´´¶¶´´´´´´
´´´´´´´¶¶¶¶´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´¶¶¶¶´´´´´´´
");
                return;
            }

            Console.WriteLine("\t(=^.^=)\n");

            var options = new Dictionary<string, string>()
            {
                ["1"] = $"Alimentar o {mascote.Nome.ToUpper()}",
                ["2"] = $"Brincar com {mascote.Nome.ToUpper()}",
                ["3"] = $"Colocar {mascote.Nome.ToUpper()} para dormir",
                ["4"] = "Tomar remédio",
                ["5"] = $"Doar {mascote.Nome.ToUpper()}",
                ["q"] = "Exit"
            };

            while (true)
            {
                Console.WriteLine($"Saúde:\t\t{Menu.ProgressBar(mascote.health.Value)}\t{mascote.RetornaSaude()}");
                Console.WriteLine($"Fome:\t\t{Menu.ProgressBar(mascote.hungry.Value)}\t{mascote.RetornaFome()}");
                Console.WriteLine($"Sono:\t\t{Menu.ProgressBar(mascote.sleepy.Value)}\t{mascote.RetornaSono()}");
                Console.WriteLine($"Felicidade:\t\t{Menu.ProgressBar(mascote.happiness.Value)}\t{mascote.RetornaFelicidade()}");
                Console.WriteLine($"Canssado:\t\t{Menu.ProgressBar(mascote.tiredness.Value)}\t{mascote.RetornaCanssado()}");

                switch (Menu.MenuView(options))
                {
                    case "1":
                        mascote.Comer();
                        Console.WriteLine($"{mascote.Nome.ToUpper()} comeu alguma comida.\n");
                        break;
                    case "2": mascote.Jogar();
                        Console.WriteLine($"{mascote.Nome.ToUpper()} está se divertindo!\n");
                        break;
                    case "3": mascote.Dormir();
                        Console.WriteLine($"{mascote.Nome.ToUpper()     } está dormindo. (=^.^=) zzzzzzz");
                        break;
                    case "4": mascote.Medicamento();
                        Console.WriteLine($"{mascote.Nome.ToUpper()} tomou algum remédio.");
                        break;
                    case "5": if ($"Você tem certeza de doar o {mascote.Nome.ToUpper()}" == "sim")
                                Console.WriteLine("Tchau Tchau!!! (=^.^=)");
                        _repository.RemoveMascote(mascote);
                        break;
                    case "q": _repository.AtualizaMascote(mascote);
                        return;
                    default: Console.WriteLine("Opção inválida!");
                        break;
                }
            }

        }
    }
}

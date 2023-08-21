using RestSharp;
using SevenDaysOfCode.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace SevenDaysOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TamagotchiController controller = new TamagotchiController();
            controller.Jogar();
        }
    }
}

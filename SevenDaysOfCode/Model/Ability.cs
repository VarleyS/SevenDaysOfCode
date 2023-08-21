using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SevenDaysOfCode
{
    public class Ability
    {
        public AbilityName ability { get; set; }

        public class AbilityName
        {
            public string name { get; set; }
        }
    }
}

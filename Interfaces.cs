using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console
{
    internal interface ICharacter
    {
        string? Name { get; }
        decimal Power { get; }
        decimal HP { get; set; }
        void Check_Info();
    }
}
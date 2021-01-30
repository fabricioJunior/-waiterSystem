using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waiterSystem.Models
{
    public class Menu
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public bool bebida { get; set; }
    }
}

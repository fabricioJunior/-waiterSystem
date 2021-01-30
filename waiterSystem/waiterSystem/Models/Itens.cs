using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waiterSystem.Models
{
    public class Itens
    {
        public int idPedido { get; set; }
        public int idMenu { get; set; }
        public float valor { get; set; }
        public bool bebida { get; set; }
        public int quantidade { get; set; }
    }
}

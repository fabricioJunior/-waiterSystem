using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waiterSystem.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public int clienteId { get; set; }
        public int garcomId { get; set; }
        public bool fechado { get; set; }
        public bool pago { get; set; }
        public  IList<Itens> Itens { get; set; }
    }
}

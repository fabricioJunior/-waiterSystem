using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using waiterSystemMvc.Banco_de_Dados;

namespace waiterSystemMvc.Controllers
{
    public class PedidoController : ApiController
    {   
        /// <summary>
        /// /api/pedido
        /// </summary>
        /// <param name="novo"></param>
        public async void Post(Pedido novo)
        {
          
            if (novo != null && novo.clienteId != 0 && novo.garcomId != 0) {
                var context = new waiter();
                context.Pedido.Add(novo);
                await context.SaveChangesAsync();
             }
            
        }
        /// <summary>
        /// id => do pedido
        /// api/pedido/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pedido Get(int id) {
            var context = new waiter();
            return context.Pedido.Find(id);
            
        }
     
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity; 
using waiterSystemMvc.Banco_de_Dados;

namespace waiterSystemMvc.Controllers
{
    public class PedidoController : ApiController
    {   
        /// <summary>
        /// /api/pedido
        /// </summary>
        /// <param name="novo"></param>
        public  void Post(Pedido novo)
        {
          
            if (novo != null  && novo.garcomId != 0) {
                try
                {

                    var context = new waiter();
                    context.Pedido.Add(novo);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }             
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
        public IEnumerable<Pedido> Get()
        {
            var context = new waiter();
            var select = context.Pedido.AsEnumerable().Where(x => x.fechado == 0);//Apenas pedidos abertos
           // context = null;
            return select;
        }
       
    }
}
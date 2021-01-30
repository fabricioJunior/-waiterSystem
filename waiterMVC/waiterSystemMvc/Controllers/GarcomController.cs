using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using waiterSystemMvc.Banco_de_Dados;

namespace waiterSystemMvc.Controllers
{
    public class GarcomController : ApiController
    {
        // GET: Garcom
        // api/garcom/id
        public Garcom Get(int id)
        {
            var context = new waiter();
            return context.Garcom.Find(id);

        }

        public IEnumerable<Pedido> Get([FromBody] Garcom garcom)
        {
            var context = new waiter();
            return context.Garcom.Find(garcom).Pedidos;

        }
        // api/garcom 
        public async void Post([FromBody] Garcom novo)
        {
            if (novo != null && novo.nome != null)
            {
                var context = new waiter();
                context.Garcom.Add(novo);
                await context.SaveChangesAsync();

            }
            else
            {
                throw new Exception("O json não esta preenchido com todas as informções nescessárias");
            }

        }


    }
}
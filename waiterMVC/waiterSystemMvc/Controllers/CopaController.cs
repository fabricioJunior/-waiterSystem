using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using waiterSystemMvc.Banco_de_Dados;
using System.Web.Http;
using System.Data.SqlClient;

namespace waiterSystemMvc.Controllers
{
    public class CopaController : ApiController
    {
        public IEnumerable<Itens> Get()
        {
            var context = new waiter();
            var pedidos = context.Pedido.AsEnumerable().ToList();
            var itens = pedidos.Select(x => x.Itens).ToList();
            List<Itens> allItens = new List<Itens>();
            itens.ForEach(a=> { allItens.AddRange(a); });
            return allItens.Where(x => x.bebida == 1 && x.pronto == 0);
        }
        public void Post([FromBody] List<Itens> itens)
        {
            var context = new waiter();
             
            itens.ForEach(x => {
                context.Database.ExecuteSqlCommand("update itens set pronto = 1 where idPedido = @id and idMenu = @idMenu",new SqlParameter("@id",x.idPedido),new SqlParameter("@idMenu",x.idMenu));
            });
           
        }
    }
}
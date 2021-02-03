using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using waiterSystemMvc.Banco_de_Dados;

namespace waiterSystemMvc.Controllers
{
    public class CozinhaController : ApiController
    {
        public IEnumerable<Itens> Get()
        {
            var context = new waiter();
            var pedidos = context.Pedido.AsEnumerable().ToList();
            var itens = pedidos.Select(x => x.Itens).ToList();
            List<Itens> allItens = new List<Itens>();
            itens.ForEach(a => { allItens.AddRange(a); });
            return allItens.Where(x => x.bebida == 0 && x.pronto == 0);
        }
        public void Post([FromBody] List<Itens> itens)
        {
            var context = new waiter();

            itens.ForEach(x => {
                context.Database.ExecuteSqlCommand("update itens set pronto = 1 where idPedido = @id and idMenu = @idMenu", new SqlParameter("@id", x.idPedido), new SqlParameter("@idMenu", x.idMenu));
            });

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using waiterSystemMvc.Banco_de_Dados;

namespace waiterSystemMvc.Controllers
{
    public class MenuController : ApiController
    {
        public IEnumerable<Menu> Get()
        {
            var context = new waiter();
      
         ///   IEnumerable < Menu > dados = context.Menu.AsEnumerable().ToList();
            ///context.Entry(dados).State = System.Data.Entity.EntityState.Detached;
            return context.Menu;
        }
    }
}
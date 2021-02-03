using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using waiterSystemMvc.Banco_de_Dados;
using System.Web.Http;
namespace waiterSystemMvc.Controllers
{
    public class LoginController : ApiController
    {

         /// <summary>
         /// login/id
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
        public Garcom Get(int id)
        {
            var context = new waiter();
            var result = context.Garcom.Where(x => x.senha == "123" && x.login == "fabriciojamescarneiro@gmail.com");
            Array resultado = result.ToArray();
            if (resultado.Length > 0)
            {
                return result.ToArray()[0];
            }
            return null;
        }

        // GET: Login

        public Garcom Post([FromBody] string[] login)
        {
           
            try
            {
                if (login != null)
                {
                    var context = new waiter();
                    
                    Garcom result = context.Garcom.AsEnumerable().ToList().Single(x => x.senha == login[0] && x.login == login[1]);
                    context.Entry(result).State = System.Data.Entity.EntityState.Detached;
                    if (result != null) {


                        return result;
                    }
                }
                
            }
            catch (Exception )
            {

                throw ;
            }
            return null;
           
        }
    }
}
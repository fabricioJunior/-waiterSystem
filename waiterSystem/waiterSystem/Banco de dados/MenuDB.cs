using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using waiterSystem.Models;

namespace waiterSystem.Banco_de_dados
{
    public static class MenuDB
    {
        public static List<Menu> cardapio()
        {
            List<Menu> retorno = new List<Menu>();
            SqlConnection cone = Conexao.connection();
            SqlCommand select = new SqlCommand("select * from menu ",cone);
            cone.Open();
            SqlDataReader read = select.ExecuteReader();
            while (read.Read())
            {
                Menu novo = new Menu();
                novo.id = Convert.ToInt32(read["id"]);
                novo.bebida = Convert.ToBoolean(read["bebida"]);
                novo.descricao = read["descricao"].ToString();
                novo.nome = read["nome"].ToString();
                retorno.Add(novo);
            }
            cone.Close();
            return retorno;
        }
        public static void postMenu(List<Menu> novo)
        {
            DataTable nova = new DataTable();
            nova.Columns.Add("id");
            nova.Columns.Add("nome");
            nova.Columns.Add("descricao");
            nova.Columns.Add("bebida");
            novo.ForEach(dados =>
            {
                nova.Rows.Add(dados.id,dados.nome,dados.descricao,dados.bebida);
            });
            SqlConnection cone = Conexao.connection();
            SqlBulkCopy copy = new SqlBulkCopy(cone);
            copy.DestinationTableName = "menu";
            cone.Open();
            copy.WriteToServer(nova);
            cone.Close();
            
        }
    }
}

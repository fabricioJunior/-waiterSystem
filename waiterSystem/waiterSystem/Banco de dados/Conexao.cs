﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace waiterSystem.Banco_de_dados
{
    public static class Conexao
    {
        public static string cone = "";
        public static SqlConnection connection()
        {
            return new SqlConnection(cone);
        }
    }
}

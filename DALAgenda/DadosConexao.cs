using System;
using System.Collections.Generic;
using System.Text;

namespace DALAgenda
{
     public  class DadosConexao
    {
        public static String servidor = @"LAPTOP-91SB1VL3\SQLEXPRESS";
        public static String banco = "Controle de Estoque";
        public static String usuario = "sa";
        public static String senha = "123";
        public static String StringDeConexao
        {
            get
            {
                return @"Data Source=" + servidor + ";Initial Catalog=" + banco + ";User ID=" + usuario + ";Password=" + senha;
            }
        }
    }
}

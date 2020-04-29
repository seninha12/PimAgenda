using DTOAgenda;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALAgenda
{
    public class DALUsuario
    {
        private DALConexao conexao;
        public DALUsuario(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Cadastrar(UsuarioDTO usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO USUARIOS (REGISTRO_FUNCIONARIO,NOME,EMAIL,TELEFONE,SENHA) " +
                "VALUES (@RFUNC,@NOME,@EMAIL,@TELEFONE,@SENHA)";

            var parametros = new Dictionary<string, object>();

            cmd.Parameters.AddWithValue("@RFUNC", usuario);
            cmd.Parameters.AddWithValue("@NOME", usuario);
            cmd.Parameters.AddWithValue("@EMAIL", usuario);
            cmd.Parameters.AddWithValue("@TELEFONE", usuario);
            cmd.Parameters.AddWithValue("@SENHA", usuario);

           // var retorno = RetornaDtable();


            conexao.Conectar();
            usuario.ID_USUARIO = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Modificar(UsuarioDTO usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE USUARIOS SET REGISTRO_FUNCIONARIO = @RFUNC,NOME = @NOME,EMAIL = @EMAIL" +
                              "TELEFONE = @TELEFONE,SENHA = @SENHA WHERE ID_FUNCIONARIO = @IDFUNC";

            cmd.Parameters.AddWithValue("@RFUNC", usuario);
            cmd.Parameters.AddWithValue("@NOME", usuario);
            cmd.Parameters.AddWithValue("@EMAIL", usuario);
            cmd.Parameters.AddWithValue("@TELEFONE", usuario);
            cmd.Parameters.AddWithValue("@SENHA", usuario);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public DataTable RetornaDtable(string sql,Dictionary<string, object> parametros = null)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            var Tout = cmd.CommandTimeout;
            cmd.CommandTimeout = 0;
            if(parametros != null && parametros.Any())
            {
                var i = 1;
                foreach(var parametro in parametros)
                {
                    if(parametro.Value == null)
                    {
                        cmd.Parameters.AddWithValue(parametro.Key, DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                    }
                }
            }
            var adapt = new SqlDataAdapter(cmd);
            var tabela = new DataTable();
            adapt.Fill(tabela);
            cmd.CommandTimeout = Tout;
            return tabela;
        }

    } 
}

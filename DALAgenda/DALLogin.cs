using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DALAgenda
{
    public class DALLogin
    {
        public string mensagem = "";
        public bool possui = false;
        SqlDataReader leitor;
        private DALConexao conexao;
        public DALLogin(DALConexao cx)
        {
            this.conexao = cx;
        }
        public bool VerificarLog(string funcionario, string senha)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT*FROM USUARIOS WHERE REGISTRO_FUNCIONARIO = @funcionario AND SENHA = @senha";
            cmd.Parameters.AddWithValue(" @funcionario", funcionario);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                conexao.Conectar();
                leitor = cmd.ExecuteReader();
                if (leitor.HasRows)
                {
                    possui = true;
                }
                conexao.Conectar();
                leitor.Close();

            }
            catch (Exception ex)
            {
                this.mensagem = "USUARIO N CADASTRADO";
            }
            conexao.Desconectar();
            leitor.Close();
            return possui;
        }
    }
}

using DTOAgenda;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DALAgenda
{
    public class DALAgendamento
    {
        private DALConexao conexao;
        private object mensagem;

        public DALAgendamento(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Agendar(AgendamentoDTO agendamento)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO AGENDAMENTO (NOME_AUDITORIO,QTDE_AUDITORIO,DATA_AGENDAMENTO) " +
                    "               VALUES (@NOME,@QTDE,@DATA); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@NOME", agendamento.NOME_AUDITORIO);
                cmd.Parameters.AddWithValue("@QTDE", agendamento.QTDE_AUDITORIO);
                cmd.Parameters.AddWithValue("@DATA", agendamento.DATA_AGENDAMENTO);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (Exception ex)
            {
                mensagem = ("ERRO: " + ex);
            }
            conexao.Desconectar();
        }
        public void AlterarAgendamento(AgendamentoDTO Agendamento)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE AGENDAMENTO SET NOME_AUDITORIO = @NOME, " +
                "QTDE_AUDITORIO = @QTDE , DATA_AGENDAMENTO = @DATA " +
                "WHERE ID_AUDITORIO = @IDAUDI;";
            cmd.Parameters.AddWithValue("@IDAUDI", Agendamento.ID_AGENDAMENTO);
            cmd.Parameters.AddWithValue("@NOME", Agendamento.NOME_AUDITORIO);
            cmd.Parameters.AddWithValue("@QTDE", Agendamento.QTDE_AUDITORIO);
            cmd.Parameters.AddWithValue("@DATA", Agendamento.DATA_AGENDAMENTO);
            
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void ExcluirAgendamento(AgendamentoDTO agendamento)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM  AGENDAMENTO " +
                "WHERE ID_AGENDAMENTO = @IDAUDI AND NOME_AUDITORIO = @NOME  ;";
            cmd.Parameters.AddWithValue("@IDAUDI", agendamento.ID_AGENDAMENTO);
            cmd.Parameters.AddWithValue("@NOME", agendamento.NOME_AUDITORIO);
            
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        /*public DataTable ConsultarAgendamentos(int sds)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(
                comcod.ToString(), conexao.StringConexao);
            da.Fill(tabela);
            return tabela;*/
        }

    }


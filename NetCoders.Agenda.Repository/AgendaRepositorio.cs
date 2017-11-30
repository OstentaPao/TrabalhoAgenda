using System;
using System.Collections.Generic;
using Trabalho.Dominio;

namespace Trabalho.AcessoDados
{
    public class AgendaRepositorio
    {
        public List<Agenda> ConsultaAgenda()
        {
            List<Agenda> retornoConsulta = new List<Agenda>();

            string comandoSQL = "SELECT * FROM Agenda;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=BancoTrabalho;Uid=root;Pwd=;"); //Ponte
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoConsulta.Add(new Agenda
                {
                    Codigo = Convert.ToInt32(dr["Codigo"]),
                    Nome = dr["Nome"].ToString(),
                    Endereco = dr["Endereco"].ToString(),
                    Bairro = dr["Bairro"].ToString(),
                    Cidade = dr["Cidade"].ToString(),
                    Telefone = Convert.ToInt32(dr["Telefone"])
                });
            }

            return retornoConsulta;
        }

        public int InserirAgenda(Agenda agenda)
        {
            int codigoGerado = 0;

            string comandoSQL = "Insert into Agenda (Nome, Endereco, Bairro, Cidade, Telefone) values (@Nome, @Endereco, @Bairro, @Cidade, @Telefone);";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=BancoTrabalho;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Nome", agenda.Nome);
            comando.Parameters.AddWithValue("@Endereco", agenda.Endereco);
            comando.Parameters.AddWithValue("@Bairro", agenda.Bairro);
            comando.Parameters.AddWithValue("@Cidade", agenda.Cidade);
            comando.Parameters.AddWithValue("@Telefone", agenda.Telefone);

            conexao.Open();

            comando.ExecuteNonQuery();

            comando = new MySqlCommand("SELECT MAX(Codigo) from Agenda", conexao);

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                codigoGerado = Convert.ToInt32(dr[0]);
            }

            return codigoGerado;
        }

        public void AlterarAgenda(Agenda agenda)
        {
            string comandoSQL = "Update Agenda set Nome=@Nome, Endereco=@Endereco, Bairro=@Bairro, Cidade=@Cidade, Telefone=@Telefone where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=TrabalhoAgenda;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", agenda.Codigo);
            comando.Parameters.AddWithValue("@Nome", agenda.Nome);
            comando.Parameters.AddWithValue("@Endereco", agenda.Endereco);
            comando.Parameters.AddWithValue("@Bairro", agenda.Bairro);
            comando.Parameters.AddWithValue("@Cidade", agenda.Cidade);
            comando.Parameters.AddWithValue("@Telefone", agenda.Telefone);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void ApagarAgenda(int codigoAgenda)
        {
            string comandoSQL = "Delete from Agenda where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=TrabalhoAgenda;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", codigoAgenda);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public Agenda ConsultaAgenda(Int32 codigo)
        {
            Agenda retornoAgenda = new Agenda();

            string comandoSQL = "SELECT * FROM Agenda where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=TrabalhoAgenda;Uid=root;Pwd=;"); //Ponte
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", codigo);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoAgenda = new Agenda
                {
                    Codigo = Convert.ToInt32(dr["Codigo"]),
                    Nome = dr["Nome"].ToString(),
                    Endereco = dr["Endereco"].ToString(),
                    Bairro = dr["Bairro"].ToString(),
                    Cidade = dr["Cidade"].ToString(),
                    Telefone = Convert.ToInt32(dr["Telefone"])
                };
            }

            return retornoConsulta;
        }
    }
    internal class MySqlCommand
    {
    }

    internal class MySqlConnection
    {
    }
}

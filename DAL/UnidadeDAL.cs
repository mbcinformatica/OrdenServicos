using MySql.Data.MySqlClient;
using ProjetoTeste.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ProjetoTeste.DAL
{
    public class UnidadeDAL
    {
        private readonly string connectionString;
        public UnidadeDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<UnidadeInfo> Listar()
        {
            List<UnidadeInfo> UnidadesList = new List<UnidadeInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBUnidades";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UnidadeInfo Unidade = new UnidadeInfo
                        {
                            IDUnidade = Convert.ToInt32(reader["IDUnidade"]),
                            Descricao = reader["Descricao"].ToString()
                        };
                        UnidadesList.Add(Unidade);
                    }
                }
            }
            return UnidadesList;
        }
        public UnidadeInfo GetUnidade(int IDUnidade)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBUnidades WHERE IDUnidade = @IDUnidade";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDUnidade", IDUnidade);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        UnidadeInfo unidade = new UnidadeInfo
                        {
                            IDUnidade = Convert.ToInt32(reader["IDUnidade"]),
                            Descricao = reader["Descricao"].ToString()
                        };
                        return unidade;
                    }
                }
            }
            return null;
        }
        public void AtualizarUnidade(UnidadeInfo unidade)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DBUnidades SET Descricao = @Descricao WHERE IDUnidade = @IDUnidade";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Descricao", unidade.Descricao);
                cmd.Parameters.AddWithValue("@IDUnidade", unidade.IDUnidade); // Adiciona o parâmetro IDUnidade
                cmd.ExecuteNonQuery();
            }
        }
        public void InserirUnidade(UnidadeInfo unidade)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DBUnidades (Descricao) VALUES (@Descricao)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Descricao", unidade.Descricao);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirUnidade(int IDUnidade)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM DBUnidades WHERE IDUnidade = @IDUnidade";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDUnidade", IDUnidade);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

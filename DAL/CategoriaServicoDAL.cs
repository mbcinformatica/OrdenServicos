using MySql.Data.MySqlClient;
using OrdenServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrdenServicos.DAL
{
    public class CategoriaServicoDAL
    {
        private readonly string connectionString;
        public CategoriaServicoDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<CategoriaServicoInfo> Listar()
        {
            List<CategoriaServicoInfo> CategoriaServicosList = new List<CategoriaServicoInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBCategoriaServicos";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CategoriaServicoInfo categoria = new CategoriaServicoInfo
                        {
                            IDCategoriaServico = Convert.ToInt32(reader["IDCategoriaServico"]),
                            Descricao = reader["Descricao"].ToString()
                        };
                        CategoriaServicosList.Add(categoria);
                    }
                }
            }
            return CategoriaServicosList;
        }
        public CategoriaServicoInfo GetCategoriaServico(int idCategoriaServico)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBCategoriaServicos WHERE IDCategoriaServico = @IDCategoriaServico";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDCategoriaServico", idCategoriaServico);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        CategoriaServicoInfo categoria = new CategoriaServicoInfo
                        {
                            IDCategoriaServico = Convert.ToInt32(reader["IDCategoriaServico"]),
                            Descricao = reader["Descricao"].ToString()
                        };
                        return categoria;
                    }
                }
            }
            return null;
        }
        public void AtualizarCategoriaServico(CategoriaServicoInfo categoria)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DBCategoriaServicos SET Descricao = @Descricao WHERE IDCategoriaServico = @IDCategoriaServico";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDCategoriaServico", categoria.IDCategoriaServico); // Adiciona o parâmetro IDCategoriaServico
                cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                cmd.ExecuteNonQuery();
            }
        }
        public void InserirCategoriaServico(CategoriaServicoInfo categoria)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DBCategoriaServicos (Descricao) VALUES (@Descricao)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirCategoriaServico(int IDCategoriaServico)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM DBCategoriaServicos WHERE IDCategoriaServico = @IDCategoriaServico";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDCategoriaServico", IDCategoriaServico);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

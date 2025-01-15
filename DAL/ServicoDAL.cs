using MySql.Data.MySqlClient;
using OrdenServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrdenServicos.DAL
{
    public class ServicoDAL
    {
        private readonly string connectionString;
        public ServicoDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<ServicoInfo> Listar()
        {
            List<ServicoInfo> ServicosList = new List<ServicoInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT s.IDServico, s.IDCodigoBase, cs.Descricao AS Categoria, s.Descricao, s.ValorServico 
            FROM DBServicos s
            JOIN DBCategoriaServicos cs ON s.IDCategoriaServico = cs.IDCategoriaServico";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ServicoInfo Servico = new ServicoInfo
                        {
                            IDServico = Convert.ToInt32(reader["IDServico"]),
                            IDCodigoBase = reader["IDCodigoBase"].ToString(),
                            Categoria = reader["Categoria"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            ValorServico = Convert.ToDecimal(reader["ValorServico"]),

                        };
                        ServicosList.Add(Servico);
                    }
                }
            }
            return ServicosList;
        }
        public ServicoInfo GetServico(int IDServico)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBServicos WHERE IDServico = @IDServico";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDServico", IDServico);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ServicoInfo servico = new ServicoInfo();
                        {
                            servico.IDServico = Convert.ToInt32(reader["IDServico"]);
                            servico.IDCodigoBase = reader["IDCodigoBase"].ToString();
                            servico.IDCategoriaServico = Convert.ToInt32(reader["IDCategoriaServico"]);
                            servico.Descricao = reader["Descricao"].ToString();
                            servico.ValorServico = Convert.ToDecimal(reader["ValorServico"]);

                        };
                        return servico;
                    }
                }
            }
            return null;
        }
        public void AtualizarServico(ServicoInfo servico)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DBServicos SET IDCodigoBase = @IDCodigoBase, IDCategoriaServico = @IDCategoriaServico, " +
                    "Descricao = @Descricao, ValorServico = @ValorServico WHERE IDServico = @IDServico";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDServico", servico.IDServico); // Adiciona o parâmetro IDServico
                cmd.Parameters.AddWithValue("@IDCodigoBase", servico.IDCodigoBase);
                cmd.Parameters.AddWithValue("@IDCategoriaServico", servico.IDCategoriaServico);
                cmd.Parameters.AddWithValue("@Descricao", servico.Descricao);
                cmd.Parameters.AddWithValue("@ValorServico", servico.ValorServico);

                cmd.ExecuteNonQuery();
            }
        }
        public void InserirServico(ServicoInfo servico)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DBServicos (IDCodigoBase, IDCategoriaServico, Descricao, ValorServico)" +
                    "VALUES (@IDCodigoBase, @IDCategoriaServico, @Descricao, @ValorServico)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDCodigoBase", servico.IDCodigoBase);
                cmd.Parameters.AddWithValue("@IDCategoriaServico", servico.IDCategoriaServico);
                cmd.Parameters.AddWithValue("@Descricao", servico.Descricao);
                cmd.Parameters.AddWithValue("@ValorServico", servico.ValorServico);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirServico(int IDServico)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM DBServicos WHERE IDServico = @IDServico";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDServico", IDServico);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using MySql.Data.MySqlClient;
using OrdenServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrdenServicos.DAL
{
    public class MarcaDAL
    {
        private readonly string connectionString;

        public MarcaDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<MarcaInfo> Listar()
        {
            List<MarcaInfo> MarcasList = new List<MarcaInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBMarcas";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MarcaInfo Marca = new MarcaInfo
                        {
                            IDMarca = Convert.ToInt32(reader["IDMarca"]),
                            Descricao = reader["Descricao"].ToString()
                        };
                        MarcasList.Add(Marca);
                    }
                }
            }
            return MarcasList;
        }
        public MarcaInfo GetMarca(int IDMarca)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBMarcas WHERE IDMarca = @IDMarca";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDMarca", IDMarca);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MarcaInfo marca = new MarcaInfo
                        {
                            IDMarca = Convert.ToInt32(reader["IDMarca"]),
                            Descricao = reader["Descricao"].ToString()
                        };
                        return marca;
                    }
                }
            }
            return null;
        }
        public void AtualizarMarca(MarcaInfo marca)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DBMarcas SET Descricao = @Descricao WHERE IDMarca = @IDMarca";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Descricao", marca.Descricao);
                cmd.Parameters.AddWithValue("@IDMarca", marca.IDMarca); // Adiciona o parâmetro IDMarca
                cmd.ExecuteNonQuery();
            }
        }
        public void InserirMarca(MarcaInfo marca)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DBMarcas (Descricao) VALUES (@Descricao)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Descricao", marca.Descricao);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirMarca(int IDMarca)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM DBMarcas WHERE IDMarca = @IDMarca";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDMarca", IDMarca);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

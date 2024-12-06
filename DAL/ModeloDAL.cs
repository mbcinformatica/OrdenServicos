using MySql.Data.MySqlClient;
using ProjetoTeste.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ProjetoTeste.DAL
{
    public class ModeloDAL
    {
        private readonly string connectionString;
        public ModeloDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<ModeloInfo> Listar()
        {
            List<ModeloInfo> ModelosList = new List<ModeloInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT mo.IDModelo, m.Descricao AS Marca, mo.Descricao 
            FROM DBModelos mo
            JOIN DBMarcas m ON mo.IDMarca = m.IDMarca";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ModeloInfo modelo = new ModeloInfo
                        {
                            IDModelo = Convert.ToInt32(reader["IDModelo"]),
                            Marca = reader["Marca"].ToString(), // Nome da marca
                            Descricao = reader["Descricao"].ToString(),
                        };
                        ModelosList.Add(modelo);


                    }
                }
            }
            return ModelosList;
        }
        public List<ModeloInfo> ListarPorMarca(int idMarca)
        {
            List<ModeloInfo> modelosList = new List<ModeloInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT IDModelo, Descricao FROM DBModelos WHERE IDMarca = @IDMarca";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDMarca", idMarca);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ModeloInfo modelo = new ModeloInfo();
                        ;
                        {
                            modelo.IDModelo = Convert.ToInt32(reader["IDModelo"]);
                            modelo.Descricao = reader["Descricao"].ToString();
                        };
                        modelosList.Add(modelo);
                    }
                }
            }
            return modelosList;
        }
        public ModeloInfo GetModelo(int IDModelo)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBModelos WHERE IDModelo = @IDModelo";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDModelo", IDModelo);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ModeloInfo modelo = new ModeloInfo();
                        modelo.IDModelo = Convert.ToInt32(reader["IDModelo"]);
                        modelo.IDMarca = Convert.ToInt32(reader["IDMarca"]);
                        modelo.Descricao = reader["Descricao"].ToString();
                        return modelo;
                    }
                }
            }

            return null;
        }
        public void AtualizarModelo(ModeloInfo modelo)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DBModelos SET IDMarca = @IDMarca, Descricao = @Descricao WHERE IDModelo = @IDModelo";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDMarca", modelo.IDMarca);
                cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                cmd.Parameters.AddWithValue("@IDModelo", modelo.IDModelo);
                cmd.ExecuteNonQuery();
            }
        }
        public void InserirModelo(ModeloInfo modelo)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DBModelos (IDMarca, Descricao)" + "VALUES (@IDMarca, @Descricao)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDMarca", modelo.IDMarca);
                cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirModelo(int IDModelo)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM DBModelos WHERE IDModelo = @IDModelo";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDModelo", IDModelo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
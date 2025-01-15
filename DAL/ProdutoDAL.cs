using MySql.Data.MySqlClient;
using OrdenServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrdenServicos.DAL
{
    public class ProdutoDAL
    {
        private readonly string connectionString;
        public ProdutoDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<ProdutoInfo> Listar()
        {
            List<ProdutoInfo> ProdutosList = new List<ProdutoInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT p.IDProduto, p.IDProdutoInterno, p.IDProdutoFabricante, p.Descricao, 
                   f.Nome_RazaoSocial AS Fornecedor, m.Descricao AS Marca, mo.Descricao AS Modelo, 
                   u.Descricao AS Unidade, p.PrecoCompra, p.PrecoVenda, p.EstoqueAtual, 
                   p.EstoqueMinimo, p.DataUltimaCompra, p.Garantia, p.Imagem
            FROM DBProdutos p
            JOIN DBFornecedores f ON p.IDFornecedor = f.IDFornecedor
            JOIN DBMarcas m ON p.IDMarca = m.IDMarca
            JOIN DBModelos mo ON p.IDModelo = mo.IDModelo
            JOIN DBUnidades u ON p.IDUnidade = u.IDUnidade";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProdutoInfo produto = new ProdutoInfo
                        {
                            IDProduto = Convert.ToInt32(reader["IDProduto"]),
                            IDProdutoInterno = reader["IDProdutoInterno"].ToString(),
                            IDProdutoFabricante = reader["IDProdutoFabricante"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            Fornecedor = reader["Fornecedor"].ToString(), // Nome do fornecedor
                            Marca = reader["Marca"].ToString(), // Nome da marca
                            Modelo = reader["Modelo"].ToString(), // Nome do modelo
                            Unidade = reader["Unidade"].ToString(), // Nome da unidade
                            PrecoCompra = Convert.ToDecimal(reader["PrecoCompra"]),
                            PrecoVenda = Convert.ToDecimal(reader["PrecoVenda"]),
                            EstoqueAtual = Convert.ToDecimal(reader["EstoqueAtual"]),
                            EstoqueMinimo = Convert.ToDecimal(reader["EstoqueMinimo"]),
                            DataUltimaCompra = Convert.ToDateTime(reader["DataUltimaCompra"]),
                            Garantia = reader["Garantia"].ToString(),
                            Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null
                        };
                        ProdutosList.Add(produto);
                    }
                }
            }

            return ProdutosList;
        }
        public List<ProdutoInfo> ListarPorMarca(int idMarca)
        {
            List<ProdutoInfo> produtosList = new List<ProdutoInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT IDProduto, Descricao, Imagem FROM DBProdutos WHERE IDMarca = @IDMarca";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDMarca", idMarca);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProdutoInfo produto = new ProdutoInfo
                        {
                            IDProduto = Convert.ToInt32(reader["IDProduto"]),
                            Descricao = reader["Descricao"].ToString(),
                            Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null
                        };
                        produtosList.Add(produto);
                    }
                }
            }
            return produtosList;
        }
        public ProdutoInfo GetProduto(int idProduto)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBProdutos WHERE idProduto = @IDProduto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDProduto", idProduto);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ProdutoInfo produto = new ProdutoInfo();
                        produto.IDProduto = Convert.ToInt32(reader["IDProduto"]);
                        produto.IDProdutoInterno = reader["IDProdutoInterno"].ToString();
                        produto.IDProdutoFabricante = reader["IDProdutoFabricante"].ToString();
                        produto.Descricao = reader["Descricao"].ToString();
                        produto.IDFornecedor = Convert.ToInt32(reader["IDFornecedor"]);
                        produto.IDMarca = Convert.ToInt32(reader["IDMarca"]);
                        produto.IDModelo = Convert.ToInt32(reader["IDModelo"]);
                        produto.IDUnidade = Convert.ToInt32(reader["IDUnidade"]);
                        produto.PrecoCompra = Convert.ToDecimal(reader["PrecoCompra"]);
                        produto.PrecoVenda = Convert.ToDecimal(reader["PrecoVenda"]);
                        produto.EstoqueAtual = Convert.ToDecimal(reader["EstoqueAtual"]);
                        produto.EstoqueMinimo = Convert.ToDecimal(reader["EstoqueMinimo"]);
                        produto.DataUltimaCompra = Convert.ToDateTime(reader["DataUltimaCompra"]);
                        produto.Garantia = reader["Garantia"].ToString();
                        produto.Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null;

                        return produto;
                    }
                }
            }

            return null;
        }
        public void AtualizarProduto(ProdutoInfo produto)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DBProdutos SET IDProdutoInterno = @IDProdutoInterno, IDProdutoFabricante = @IDProdutoFabricante, Descricao = @Descricao, " +
                               "IDFornecedor = @IDFornecedor, IDMarca = @IDMarca, IDModelo = @IDModelo, IDUnidade = @IDUnidade, PrecoCompra = @PrecoCompra, PrecoVenda = @PrecoVenda, " +
                               "EstoqueAtual = @EstoqueAtual, EstoqueMinimo = @EstoqueMinimo, Garantia = @Garantia, Imagem = @Imagem WHERE IDProduto = @IDProduto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDProdutoInterno", produto.IDProdutoInterno);
                cmd.Parameters.AddWithValue("@IDProdutoFabricante", produto.IDProdutoFabricante);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@IDFornecedor", produto.IDFornecedor);
                cmd.Parameters.AddWithValue("@IDMarca", produto.IDMarca);
                cmd.Parameters.AddWithValue("@IDModelo", produto.IDModelo);
                cmd.Parameters.AddWithValue("@IDUnidade", produto.IDUnidade);
                cmd.Parameters.AddWithValue("@PrecoCompra", produto.PrecoCompra);
                cmd.Parameters.AddWithValue("@PrecoVenda", produto.PrecoVenda);
                cmd.Parameters.AddWithValue("@EstoqueAtual", produto.EstoqueAtual);
                cmd.Parameters.AddWithValue("@EstoqueMinimo", produto.EstoqueMinimo);
                cmd.Parameters.AddWithValue("@Garantia", produto.Garantia);
                cmd.Parameters.AddWithValue("@Imagem", produto.Imagem ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IDProduto", produto.IDProduto);
                cmd.ExecuteNonQuery();
            }
        }
        public void InserirProduto(ProdutoInfo produto)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DBProdutos (IDProdutoInterno, IDProdutoFabricante, Descricao, IDFornecedor, IDMarca, IDModelo, " +
                               "IDUnidade, PrecoCompra, PrecoVenda, EstoqueAtual, EstoqueMinimo, DataUltimaCompra, Garantia, Imagem) " +
                               "VALUES (@IDProdutoInterno, @IDProdutoFabricante, @Descricao, @IDFornecedor, @IDMarca, @IDModelo, @IDUnidade, @PrecoCompra, " +
                               "@PrecoVenda, @EstoqueAtual, @EstoqueMinimo, @DataUltimaCompra, @Garantia, @Imagem)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDProdutoInterno", produto.IDProdutoInterno);
                cmd.Parameters.AddWithValue("@IDProdutoFabricante", produto.IDProdutoFabricante);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@IDFornecedor", produto.IDFornecedor);
                cmd.Parameters.AddWithValue("@IDMarca", produto.IDMarca);
                cmd.Parameters.AddWithValue("@IDModelo", produto.IDModelo);
                cmd.Parameters.AddWithValue("@IDUnidade", produto.IDUnidade);
                cmd.Parameters.AddWithValue("@PrecoCompra", produto.PrecoCompra);
                cmd.Parameters.AddWithValue("@PrecoVenda", produto.PrecoVenda);
                cmd.Parameters.AddWithValue("@EstoqueAtual", produto.EstoqueAtual);
                cmd.Parameters.AddWithValue("@EstoqueMinimo", produto.EstoqueMinimo);
                cmd.Parameters.AddWithValue("@DataUltimaCompra", produto.DataUltimaCompra);
                cmd.Parameters.AddWithValue("@Garantia", produto.Garantia);
                cmd.Parameters.AddWithValue("@Imagem", produto.Imagem ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirProduto(int idProduto)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM DBProdutos WHERE idProduto = @IDProduto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDProduto", idProduto);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
using MySql.Data.MySqlClient;
using ProjetoTeste.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ProjetoTeste.DAL
{
    public class LancamentoServicoDAL
    {
        private readonly string connectionString;
        public LancamentoServicoDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<LancamentoServicoInfo> Listar()
        {
            List<LancamentoServicoInfo> LancamentoServicosList = new List<LancamentoServicoInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
        SELECT ls.IDOrdenServico, ls.DataEmissao, ls.DataConclusao, c.Nome_RazaoSocial AS Cliente, 
            m.Descricao AS Marca, p.Descricao AS Produto, ls.NumeroSerie, ls.DescricaoDefeito,
            ls.ValorTotalServico, ls.ValorTotalMaterial, ls.Imagem 
        FROM DBLancamentoServicos ls
        JOIN DBClientes c ON ls.IDCliente = c.IDCliente
        JOIN DBMarcas m ON ls.IDMarca = m.IDMarca
        JOIN DBProdutos p ON ls.IDProduto = p.IDProduto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LancamentoServicoInfo lancamentoServico = new LancamentoServicoInfo
                        {
                            IDOrdenServico = Convert.ToInt32(reader["IDOrdenServico"]),
                            DataEmissao = reader["DataEmissao"] != DBNull.Value ? Convert.ToDateTime(reader["DataEmissao"]) : DateTime.MinValue,
                            DataConclusao = reader["DataConclusao"] != DBNull.Value ? Convert.ToDateTime(reader["DataConclusao"]) : DateTime.MinValue,
                            Cliente = reader["Cliente"].ToString(), // Nome do cliente
                            Marca = reader["Marca"].ToString(), // Nome da marca
                            Produto = reader["Produto"].ToString(), // Nome do produto
                            NumeroSerie = reader["NumeroSerie"].ToString(),
                            DescricaoDefeito = reader["DescricaoDefeito"].ToString(),
                            ValorTotalServico = Convert.ToDecimal(reader["ValorTotalServico"]),
                            ValorTotalMaterial = Convert.ToDecimal(reader["ValorTotalMaterial"]),
                            Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null
                        };
                        LancamentoServicosList.Add(lancamentoServico);
                    }
                }
            }

            return LancamentoServicosList;
        }
        public LancamentoServicoInfo GetLancamentoServico(int idOrdenServico)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBLancamentoServicos WHERE idOrdenServico = @IDOrdenServico";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDOrdenServico", idOrdenServico);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        LancamentoServicoInfo lancamentoServico = new LancamentoServicoInfo();

                        lancamentoServico.IDOrdenServico = Convert.ToInt32(reader["IDOrdenServico"]);
                        lancamentoServico.DataEmissao = reader["DataEmissao"] != DBNull.Value ? Convert.ToDateTime(reader["DataEmissao"]) : DateTime.MinValue;
                        lancamentoServico.DataConclusao = reader["DataConclusao"] != DBNull.Value ? Convert.ToDateTime(reader["DataConclusao"]) : DateTime.MinValue;
                        lancamentoServico.IDCliente = Convert.ToInt32(reader["IDCliente"]); // Nome do fornecedor
                        lancamentoServico.IDMarca = Convert.ToInt32(reader["IDMarca"]);
                        lancamentoServico.IDProduto = Convert.ToInt32(reader["IDProduto"]); // Nome da unidade
                        lancamentoServico.NumeroSerie = reader["NumeroSerie"].ToString();
                        lancamentoServico.DescricaoDefeito = reader["DescricaoDefeito"].ToString(); lancamentoServico.DescricaoDefeito = reader["DescricaoDefeito"].ToString();
                        lancamentoServico.ValorTotalServico = Convert.ToDecimal(reader["ValorTotalServico"]);
                        lancamentoServico.ValorTotalMaterial = Convert.ToDecimal(reader["ValorTotalMaterial"]);
                        lancamentoServico.Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null;

                        return lancamentoServico;
                    }
                }
            }

            return null;
        }
        public void AtualizarLancamentoServico(LancamentoServicoInfo lancamentoServico)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                        UPDATE DBLancamentoServicos 
                        SET DataEmissao = @DataEmissao,
                            DataConclusao = @DataConclusao, 
                            IDCliente = @IDCliente, 
                            IDMarca = @IDMarca,
                            IDProduto = @IDProduto, 
                            NumeroSerie = @NumeroSerie, 
                            DescricaoDefeito = @DescricaoDefeito,
                            ValorTotalServico = @ValorTotalServico, 
                            ValorTotalMaterial = @ValorTotalMaterial,
                            Imagem = @Imagem 
                        WHERE IDOrdenServico = @IDOrdenServico";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDOrdenServico", lancamentoServico.IDOrdenServico);
                cmd.Parameters.AddWithValue("@DataEmissao", lancamentoServico.DataEmissao);
                cmd.Parameters.AddWithValue("@DataConclusao", lancamentoServico.DataConclusao);
                cmd.Parameters.AddWithValue("@IDCliente", lancamentoServico.IDCliente);
                cmd.Parameters.AddWithValue("@IDMarca", lancamentoServico.IDMarca);
                cmd.Parameters.AddWithValue("@IDProduto", lancamentoServico.IDProduto);
                cmd.Parameters.AddWithValue("@NumeroSerie", lancamentoServico.NumeroSerie);
                cmd.Parameters.AddWithValue("@DescricaoDefeito", lancamentoServico.DescricaoDefeito);
                cmd.Parameters.AddWithValue("@ValorTotalServico", lancamentoServico.ValorTotalServico);
                cmd.Parameters.AddWithValue("@ValorTotalMaterial", lancamentoServico.ValorTotalMaterial);
                cmd.Parameters.AddWithValue("@Imagem", lancamentoServico.Imagem ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void InserirLancamentoServico(LancamentoServicoInfo lancamentoServico)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
        INSERT INTO DBLancamentoServicos 
        (DataEmissao, DataConclusao, IDCliente, IDMarca, IDProduto, NumeroSerie, DescricaoDefeito, ValorTotalServico, ValorTotalMaterial, Imagem)
        VALUES 
        (@DataEmissao, @DataConclusao, @IDCliente, @IDMarca, @IDProduto, @NumeroSerie, @DescricaoDefeito, @ValorTotalServico, @ValorTotalMaterial, @Imagem)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DataEmissao", lancamentoServico.DataEmissao);
                cmd.Parameters.AddWithValue("@DataConclusao", lancamentoServico.DataConclusao);
                cmd.Parameters.AddWithValue("@IDCliente", lancamentoServico.IDCliente);
                cmd.Parameters.AddWithValue("@IDMarca", lancamentoServico.IDMarca);
                cmd.Parameters.AddWithValue("@IDProduto", lancamentoServico.IDProduto);
                cmd.Parameters.AddWithValue("@NumeroSerie", lancamentoServico.NumeroSerie);
                cmd.Parameters.AddWithValue("@DescricaoDefeito", lancamentoServico.DescricaoDefeito);
                cmd.Parameters.AddWithValue("@ValorTotalServico", lancamentoServico.ValorTotalServico);
                cmd.Parameters.AddWithValue("@ValorTotalMaterial", lancamentoServico.ValorTotalMaterial);
                cmd.Parameters.AddWithValue("@Imagem", lancamentoServico.Imagem ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void ExcluirLancamentoServico(int idOrdenServico)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM DBLancamentoServicos WHERE idOrdenServico = @IDOrdenServico";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDOrdenServico", idOrdenServico);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
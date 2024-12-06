using MySql.Data.MySqlClient;
using ProjetoTeste.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ProjetoTeste.DAL
{
    public class FornecedorDAL
    {
        private readonly string connectionString;
        public FornecedorDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<FornecedorInfo> Listar()
        {
            List<FornecedorInfo> FornecedoresList = new List<FornecedorInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBFornecedores";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FornecedorInfo Fornecedor = new FornecedorInfo();
                        Fornecedor.IDFornecedor = Convert.ToInt32(reader["IDFornecedor"]);
                        Fornecedor.TipoPessoa = reader["TipoPessoa"].ToString();
                        Fornecedor.Cpf_Cnpj = reader["Cpf_Cnpj"].ToString();
                        Fornecedor.Nome_RazaoSocial = reader["Nome_RazaoSocial"].ToString();
                        Fornecedor.Endereco = reader["Endereco"].ToString();
                        Fornecedor.Numero = reader["Numero"].ToString();
                        Fornecedor.Bairro = reader["Bairro"].ToString();
                        Fornecedor.Municipio = reader["Municipio"].ToString();
                        Fornecedor.UF = reader["UF"].ToString();
                        Fornecedor.Cep = reader["Cep"].ToString();
                        Fornecedor.Contato = reader["Contato"].ToString();
                        Fornecedor.Fone_1 = reader["Fone_1"].ToString();
                        Fornecedor.Fone_2 = reader["Fone_2"].ToString();
                        Fornecedor.Email = reader["Email"].ToString();
                        Fornecedor.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                        FornecedoresList.Add(Fornecedor);
                    }
                }
            }

            return FornecedoresList;
        }
        public FornecedorInfo GetFornecedor(int IDFornecedor)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBFornecedores WHERE IDFornecedor = @IDFornecedor";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDFornecedor", IDFornecedor);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        FornecedorInfo fornecedor = new FornecedorInfo();
                        fornecedor.IDFornecedor = Convert.ToInt32(reader["IDFornecedor"]);
                        fornecedor.TipoPessoa = reader["TipoPessoa"].ToString();
                        fornecedor.Cpf_Cnpj = reader["Cpf_Cnpj"].ToString();
                        fornecedor.Nome_RazaoSocial = reader["Nome_RazaoSocial"].ToString();
                        fornecedor.Endereco = reader["Endereco"].ToString();
                        fornecedor.Numero = reader["Numero"].ToString();
                        fornecedor.Bairro = reader["Bairro"].ToString();
                        fornecedor.Municipio = reader["Municipio"].ToString();
                        fornecedor.UF = reader["UF"].ToString();
                        fornecedor.Cep = reader["Cep"].ToString();
                        fornecedor.Contato = reader["Contato"].ToString();
                        fornecedor.Fone_1 = reader["Fone_1"].ToString();
                        fornecedor.Fone_2 = reader["Fone_2"].ToString();
                        fornecedor.Email = reader["Email"].ToString();
                        fornecedor.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                        return fornecedor;
                    }
                }
            }

            return null;
        }

        public void AtualizarFornecedor(FornecedorInfo fornecedor)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DBFornecedores SET TipoPessoa = @TipoPessoa, Cpf_Cnpj = @Cpf_Cnpj, Nome_RazaoSocial = @Nome_RazaoSocial, " +
                               "Endereco = @Endereco, Numero = @Numero, Bairro = @Bairro, Municipio = @Municipio, " +
                               "UF = @UF, Cep = @Cep, Contato = @Contato, Fone_1 = @Fone_1, Fone_2 = @Fone_2, " +
                               "Email = @Email WHERE IDFornecedor = @IDFornecedor";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TipoPessoa", fornecedor.TipoPessoa);
                cmd.Parameters.AddWithValue("@Cpf_Cnpj", fornecedor.Cpf_Cnpj);
                cmd.Parameters.AddWithValue("@Nome_RazaoSocial", fornecedor.Nome_RazaoSocial);
                cmd.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);
                cmd.Parameters.AddWithValue("@Numero", fornecedor.Numero);
                cmd.Parameters.AddWithValue("@Bairro", fornecedor.Bairro);
                cmd.Parameters.AddWithValue("@Municipio", fornecedor.Municipio);
                cmd.Parameters.AddWithValue("@UF", fornecedor.UF);
                cmd.Parameters.AddWithValue("@Cep", fornecedor.Cep);
                cmd.Parameters.AddWithValue("@Contato", fornecedor.Contato);
                cmd.Parameters.AddWithValue("@Fone_1", fornecedor.Fone_1);
                cmd.Parameters.AddWithValue("@Fone_2", fornecedor.Fone_2);
                cmd.Parameters.AddWithValue("@Email", fornecedor.Email);
                cmd.Parameters.AddWithValue("@IDFornecedor", fornecedor.IDFornecedor);
                cmd.ExecuteNonQuery();
            }
        }
        public void InserirFornecedor(FornecedorInfo fornecedor)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DBFornecedores (TipoPessoa, Cpf_Cnpj, Nome_RazaoSocial, Endereco, Numero, Bairro, Municipio, UF, Cep, Contato, Fone_1, Fone_2, Email, DataCadastro) " +
                               "VALUES (@TipoPessoa, @Cpf_Cnpj, @Nome_RazaoSocial, @Endereco, @Numero, @Bairro, @Municipio, @UF, @Cep, @Contato, @Fone_1, @Fone_2, @Email, @DataCadastro)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TipoPessoa", fornecedor.TipoPessoa);
                cmd.Parameters.AddWithValue("@Cpf_Cnpj", fornecedor.Cpf_Cnpj);
                cmd.Parameters.AddWithValue("@Nome_RazaoSocial", fornecedor.Nome_RazaoSocial);
                cmd.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);
                cmd.Parameters.AddWithValue("@Numero", fornecedor.Numero);
                cmd.Parameters.AddWithValue("@Bairro", fornecedor.Bairro);
                cmd.Parameters.AddWithValue("@Municipio", fornecedor.Municipio);
                cmd.Parameters.AddWithValue("@UF", fornecedor.UF);
                cmd.Parameters.AddWithValue("@Cep", fornecedor.Cep);
                cmd.Parameters.AddWithValue("@Contato", fornecedor.Contato);
                cmd.Parameters.AddWithValue("@Fone_1", fornecedor.Fone_1);
                cmd.Parameters.AddWithValue("@Fone_2", fornecedor.Fone_2);
                cmd.Parameters.AddWithValue("@Email", fornecedor.Email);
                cmd.Parameters.AddWithValue("@DataCadastro", fornecedor.DataCadastro);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirFornecedor(int IDFornecedor)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM DBFornecedores WHERE IDFornecedor = @IDFornecedor";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDFornecedor", IDFornecedor);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
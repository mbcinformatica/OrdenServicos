using MySql.Data.MySqlClient;
using OrdenServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrdenServicos.DAL
{
    public class ClienteDAL
    {
        private readonly string connectionString;
        public ClienteDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<ClienteInfo> Listar()
        {
            List<ClienteInfo> ClientesList = new List<ClienteInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBClientes";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClienteInfo Cliente = new ClienteInfo();
                        Cliente.IDCliente = Convert.ToInt32(reader["IDCliente"]);
                        Cliente.TipoPessoa = reader["TipoPessoa"].ToString();
                        Cliente.Cpf_Cnpj = reader["Cpf_Cnpj"].ToString();
                        Cliente.Nome_RazaoSocial = reader["Nome_RazaoSocial"].ToString();
                        Cliente.Endereco = reader["Endereco"].ToString();
                        Cliente.Numero = reader["Numero"].ToString();
                        Cliente.Bairro = reader["Bairro"].ToString();
                        Cliente.Municipio = reader["Municipio"].ToString();
                        Cliente.UF = reader["UF"].ToString();
                        Cliente.Cep = reader["Cep"].ToString();
                        Cliente.Contato = reader["Contato"].ToString();
                        Cliente.Fone_1 = reader["Fone_1"].ToString();
                        Cliente.Fone_2 = reader["Fone_2"].ToString();
                        Cliente.Email = reader["Email"].ToString();
                        Cliente.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                        ClientesList.Add(Cliente);
                    }
                }
            }

            return ClientesList;
        }
        public ClienteInfo GetCliente(int IDCliente)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBClientes WHERE IDCliente = @IDCliente";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDCliente", IDCliente);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ClienteInfo cliente = new ClienteInfo();
                        cliente.IDCliente = Convert.ToInt32(reader["IDCliente"]);
                        cliente.TipoPessoa = reader["TipoPessoa"].ToString();
                        cliente.Cpf_Cnpj = reader["Cpf_Cnpj"].ToString();
                        cliente.Nome_RazaoSocial = reader["Nome_RazaoSocial"].ToString();
                        cliente.Endereco = reader["Endereco"].ToString();
                        cliente.Numero = reader["Numero"].ToString();
                        cliente.Bairro = reader["Bairro"].ToString();
                        cliente.Municipio = reader["Municipio"].ToString();
                        cliente.UF = reader["UF"].ToString();
                        cliente.Cep = reader["Cep"].ToString();
                        cliente.Contato = reader["Contato"].ToString();
                        cliente.Fone_1 = reader["Fone_1"].ToString();
                        cliente.Fone_2 = reader["Fone_2"].ToString();
                        cliente.Email = reader["Email"].ToString();
                        cliente.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                        return cliente;
                    }
                }
            }

            return null;
        }
        public void AtualizarCliente(ClienteInfo cliente)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DBClientes SET TipoPessoa = @TipoPessoa, Cpf_Cnpj = @Cpf_Cnpj, Nome_RazaoSocial = @Nome_RazaoSocial, " +
                               "Endereco = @Endereco, Numero = @Numero, Bairro = @Bairro, Municipio = @Municipio, " +
                               "UF = @UF, Cep = @Cep, Contato = @Contato, Fone_1 = @Fone_1, Fone_2 = @Fone_2, " +
                               "Email = @Email WHERE IDCliente = @IDCliente";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TipoPessoa", cliente.TipoPessoa);
                cmd.Parameters.AddWithValue("@Cpf_Cnpj", cliente.Cpf_Cnpj);
                cmd.Parameters.AddWithValue("@Nome_RazaoSocial", cliente.Nome_RazaoSocial);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
                cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@Municipio", cliente.Municipio);
                cmd.Parameters.AddWithValue("@UF", cliente.UF);
                cmd.Parameters.AddWithValue("@Cep", cliente.Cep);
                cmd.Parameters.AddWithValue("@Contato", cliente.Contato);
                cmd.Parameters.AddWithValue("@Fone_1", cliente.Fone_1);
                cmd.Parameters.AddWithValue("@Fone_2", cliente.Fone_2);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@IDCliente", cliente.IDCliente);
                cmd.ExecuteNonQuery();
            }
        }
        public void InserirCliente(ClienteInfo cliente)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DBClientes (TipoPessoa, Cpf_Cnpj, Nome_RazaoSocial, Endereco, Numero, Bairro, Municipio, UF, Cep, Contato, Fone_1, Fone_2, Email, DataCadastro) " +
                               "VALUES (@TipoPessoa, @Cpf_Cnpj, @Nome_RazaoSocial, @Endereco, @Numero, @Bairro, @Municipio, @UF, @Cep, @Contato, @Fone_1, @Fone_2, @Email, @DataCadastro)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TipoPessoa", cliente.TipoPessoa);
                cmd.Parameters.AddWithValue("@Cpf_Cnpj", cliente.Cpf_Cnpj);
                cmd.Parameters.AddWithValue("@Nome_RazaoSocial", cliente.Nome_RazaoSocial);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
                cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@Municipio", cliente.Municipio);
                cmd.Parameters.AddWithValue("@UF", cliente.UF);
                cmd.Parameters.AddWithValue("@Cep", cliente.Cep);
                cmd.Parameters.AddWithValue("@Contato", cliente.Contato);
                cmd.Parameters.AddWithValue("@Fone_1", cliente.Fone_1);
                cmd.Parameters.AddWithValue("@Fone_2", cliente.Fone_2);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@DataCadastro", cliente.DataCadastro);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirCliente(int IDCliente)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM DBClientes WHERE IDCliente = @IDCliente";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDCliente", IDCliente);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
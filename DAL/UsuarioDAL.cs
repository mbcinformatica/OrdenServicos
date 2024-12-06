using MySql.Data.MySqlClient;
using ProjetoTeste.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ProjetoTeste.DAL
{
    public class UsuarioDAL
    {
        private readonly string connectionString;
        public UsuarioDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<UsuarioInfo> Listar()
        {
            List<UsuarioInfo> UsuariosList = new List<UsuarioInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBUsuarios";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UsuarioInfo usuario = new UsuarioInfo();
                        usuario.IDUsuario = Convert.ToInt32(reader["IDUsuario"]);
                        usuario.Nome = reader["Nome"].ToString();
                        usuario.Login = reader["Login"].ToString();
                        usuario.Endereco = reader["Endereco"].ToString();
                        usuario.Numero = reader["Numero"].ToString();
                        usuario.Bairro = reader["Bairro"].ToString();
                        usuario.Municipio = reader["Municipio"].ToString();
                        usuario.UF = reader["UF"].ToString();
                        usuario.Cep = reader["Cep"].ToString();
                        usuario.Fone_1 = reader["Fone_1"].ToString();
                        usuario.Fone_2 = reader["Fone_2"].ToString();
                        usuario.Email = reader["Email"].ToString();
                        usuario.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                        usuario.Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null;
                        UsuariosList.Add(usuario);

                    }
                }
            }
            return UsuariosList;
        }
        public UsuarioInfo GetUsuario(int IDUsuario)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DBUsuarios WHERE IDUsuario = @IDUsuario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDUsuario", IDUsuario);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        UsuarioInfo usuario = new UsuarioInfo();
                        usuario.IDUsuario = Convert.ToInt32(reader["IDUsuario"]);
                        usuario.Nome = reader["Nome"].ToString();
                        usuario.Login = reader["Login"].ToString();
                        usuario.Endereco = reader["Endereco"].ToString();
                        usuario.Numero = reader["Numero"].ToString();
                        usuario.Bairro = reader["Bairro"].ToString();
                        usuario.Municipio = reader["Municipio"].ToString();
                        usuario.UF = reader["UF"].ToString();
                        usuario.Cep = reader["Cep"].ToString();
                        usuario.Fone_1 = reader["Fone_1"].ToString();
                        usuario.Fone_2 = reader["Fone_2"].ToString();
                        usuario.Email = reader["Email"].ToString();
                        usuario.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                        usuario.Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null;
                        return usuario;
                    }
                }
            }
            return null;
        }
        public void AtualizarUsuario(UsuarioInfo usuario)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE DBUsuarios SET Nome = @Nome, Login = @Login, " +
                               "Endereco = @Endereco, Numero = @Numero, Bairro = @Bairro, Municipio = @Municipio, " +
                               "UF = @UF, Cep = @Cep, Fone_1 = @Fone_1, Fone_2 = @Fone_2, " +
                               "Email = @Email, Imagem = @Imagem WHERE IDUsuario = @IDUsuario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Login", usuario.Login);
                cmd.Parameters.AddWithValue("@Endereco", usuario.Endereco);
                cmd.Parameters.AddWithValue("@Numero", usuario.Numero);
                cmd.Parameters.AddWithValue("@Bairro", usuario.Bairro);
                cmd.Parameters.AddWithValue("@Municipio", usuario.Municipio);
                cmd.Parameters.AddWithValue("@UF", usuario.UF);
                cmd.Parameters.AddWithValue("@Cep", usuario.Cep);
                cmd.Parameters.AddWithValue("@Fone_1", usuario.Fone_1);
                cmd.Parameters.AddWithValue("@Fone_2", usuario.Fone_2);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Imagem", usuario.Imagem ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IDUsuario", usuario.IDUsuario);
                cmd.ExecuteNonQuery();
            }
        }
        public void InserirUsuario(UsuarioInfo usuario)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO DBUsuarios (Nome, Login, Senha, Endereco, Numero, Bairro, Municipio, UF, Cep, Fone_1, Fone_2, Email, DataCadastro, Imagem) " +
                               "VALUES (@Nome, @Login, @Senha, @Endereco, @Numero, @Bairro, @Municipio, @UF, @Cep, @Fone_1, @Fone_2, @Email, @DataCadastro, @Imagem)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Login", usuario.Login);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@Endereco", usuario.Endereco);
                cmd.Parameters.AddWithValue("@Numero", usuario.Numero);
                cmd.Parameters.AddWithValue("@Bairro", usuario.Bairro);
                cmd.Parameters.AddWithValue("@Municipio", usuario.Municipio);
                cmd.Parameters.AddWithValue("@UF", usuario.UF);
                cmd.Parameters.AddWithValue("@Cep", usuario.Cep);
                cmd.Parameters.AddWithValue("@Fone_1", usuario.Fone_1);
                cmd.Parameters.AddWithValue("@Fone_2", usuario.Fone_2);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@DataCadastro", usuario.DataCadastro);
                cmd.Parameters.AddWithValue("@Imagem", usuario.Imagem ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirUsuario(int IDUsuario)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM DBUsuarios WHERE IDUsuario = @IDUsuario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDUsuario", IDUsuario);
                cmd.ExecuteNonQuery();
            }
        }
        public bool IsUsuariosEmpty()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM DBUsuarios";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
            }
        }
    }
}

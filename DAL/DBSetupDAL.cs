using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ProjetoTeste.DAL
{
    public class DBSetupDAL
    {
        private readonly string connectionString;
        private readonly string connectionStringWithoutDatabase;

        public DBSetupDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            connectionStringWithoutDatabase = ConfigurationManager.AppSettings["ConnectionStringWithoutDatabase"];
        }

        public bool CheckAndSetupDatabase()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionStringWithoutDatabase))
            {
                try
                {
                    connection.Open();

                    // Verifica se o banco de dados existe
                    var checkDbQuery = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'DBOrdenServicos'";
                    using (var checkDbCommand = new MySqlCommand(checkDbQuery, connection))
                    {
                        var dbExists = checkDbCommand.ExecuteScalar() != null;
                        if (!dbExists)
                        {
                            // Cria o banco de dados
                            var createDbQuery = "CREATE DATABASE DBOrdenServicos;";
                            using (var createDbCommand = new MySqlCommand(createDbQuery, connection))
                            {
                                createDbCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    // Usa o banco de dados
                    var useDbQuery = "USE DBOrdenServicos;";
                    using (var useDbCommand = new MySqlCommand(useDbQuery, connection))
                    {
                        useDbCommand.ExecuteNonQuery();
                    }

                    // Verifica e cria tabelas e colunas
                    VerifyAndCreateTables(connection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
        }
        private void VerifyAndCreateTables(MySqlConnection connection)
        {
            // Verifica e cria a tabela DBClientes
            VerifyAndCreateTable(connection, "DBClientes", new string[]
            {
                "IDCliente int NOT NULL AUTO_INCREMENT",
                "TipoPessoa varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "Cpf_Cnpj varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "Nome_RazaoSocial varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "Endereco varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Numero varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Bairro varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Municipio varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "UF varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Cep varchar(8) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Contato varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Fone_1 varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Fone_2 varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Email varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "DataCadastro datetime NOT NULL DEFAULT CURRENT_TIMESTAMP",
                "PRIMARY KEY (IDCliente)",
                "UNIQUE KEY Cpf_Cnpj_UNIQUE (Cpf_Cnpj)"
            });

            // Verifica e cria a tabela DBFornecedores
            VerifyAndCreateTable(connection, "DBFornecedores", new string[]
            {
                "IDFornecedor int NOT NULL AUTO_INCREMENT",
                "TipoPessoa varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "Cpf_Cnpj varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "Nome_RazaoSocial varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "Endereco varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Numero varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Bairro varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Municipio varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "UF varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Cep varchar(8) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Contato varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Fone_1 varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Fone_2 varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Email varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "DataCadastro datetime NOT NULL DEFAULT CURRENT_TIMESTAMP",
                "PRIMARY KEY (IDFornecedor)",
                "UNIQUE KEY Cpf_Cnpj_UNIQUE (Cpf_Cnpj)"
            });

            // Verifica e cria a tabela DBMarcas
            VerifyAndCreateTable(connection, "DBMarcas", new string[]
            {
                "IDMarca int NOT NULL AUTO_INCREMENT",
                "Descricao varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "PRIMARY KEY (IDMarca)",
                "UNIQUE KEY Descricao_UNIQUE (Descricao)"

            });

            // Verifica e cria a tabela DBModelos
            VerifyAndCreateTable(connection, "DBModelos", new string[]
            {
                "IDModelo int NOT NULL AUTO_INCREMENT",
                "IDMarca int NOT NULL",
                "Descricao varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "PRIMARY KEY (IDModelo)",
                "UNIQUE KEY Descricao_UNIQUE (Descricao)"

            });

            // Verifica e cria a tabela DBProdutos
            VerifyAndCreateTable(connection, "DBProdutos", new string[]
            {
                "IDProduto int NOT NULL AUTO_INCREMENT",
                "IDProdutoInterno varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "IDProdutoFabricante varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "Descricao varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "IDFornecedor int DEFAULT NULL",
                "IDMarca int DEFAULT NULL",
                "IDModelo int DEFAULT NULL",
                "IDUnidade int DEFAULT NULL",
                "PrecoCompra decimal(10,2) DEFAULT NULL",
                "PrecoVenda decimal(10,2) DEFAULT NULL",
                "EstoqueAtual decimal(10,4) DEFAULT NULL",
                "EstoqueMinimo decimal(10,4) DEFAULT NULL",
                "DataUltimaCompra datetime DEFAULT NULL",
                "Garantia varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Imagem longblob",
                "PRIMARY KEY (IDProduto)",
                "UNIQUE KEY CodInternoProduto_UNIQUE (IDProdutoInterno)",
                "UNIQUE KEY CodProdutoFabricante_UNIQUE (IDProdutoFabricante)",
                "UNIQUE KEY Descricao_UNIQUE (Descricao)"

            });

            // Verifica e cria a tabela DBUnidades
            VerifyAndCreateTable(connection, "DBUnidades", new string[]
            {
                "IDUnidade int NOT NULL AUTO_INCREMENT",
                "Descricao varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "PRIMARY KEY (IDUnidade)",
                "UNIQUE KEY Descricao_UNIQUE (Descricao)"

            });

            // Verifica e cria a tabela DBUsuarios
            VerifyAndCreateTable(connection, "DBUsuarios", new string[]
            {
                "IDUsuario int NOT NULL AUTO_INCREMENT",
                "Nome varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "Login varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "Senha varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "Endereco varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Numero varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Bairro varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Municipio varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "UF varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Cep varchar(8) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Fone_1 varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Fone_2 varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "Email varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "DataCadastro datetime NOT NULL DEFAULT CURRENT_TIMESTAMP",
                "Imagem longblob",
                "PRIMARY KEY (IDUsuario)",
                "UNIQUE KEY Nome_UNIQUE (Nome)",
                "UNIQUE KEY Login_UNIQUE (Login)"
            });

            // Verifica e cria a tabela DBServiços
            VerifyAndCreateTable(connection, "DBServicos", new string[]
            {
                "IDServico int NOT NULL AUTO_INCREMENT",
                "IDCodigoBase varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "IDCategoriaServico int NOT NULL",
                "Descricao varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "ValorServico decimal(10,2) DEFAULT NULL",
                "PRIMARY KEY (IDServico)",
                "UNIQUE KEY IDCodigoBase_UNIQUE (IDCodigoBase)",
                "UNIQUE KEY Descricao_UNIQUE (Descricao)"
            });

            // Verifica e cria a tabela DBCategoriaServicos
            VerifyAndCreateTable(connection, "DBCategoriaServicos", new string[]
            {
                "IDCategoriaServico int NOT NULL AUTO_INCREMENT",
                "Descricao varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL",
                "PRIMARY KEY (IDCategoria)",
                "UNIQUE KEY Descricao_UNIQUE (Descricao)"
            });

            // Verifica e cria a tabela DBLancamentoServicos
            VerifyAndCreateTable(connection, "DBLancamentoServicos", new string[]
            {
                "IDOrdenServico int NOT NULL AUTO_INCREMENT",
                "DataEmissao datetime DEFAULT NULL",
                "DataConclusao datetime DEFAULT NULL",
                "IDCliente int DEFAULT NULL",
                "IDMarca int DEFAULT NULL",
                "IDProduto int DEFAULT NULL",
                "NumeroSerie varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "DescricaoDefeito text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "GarantiaServico varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "GarantiaMaterial varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL",
                "ValorTotalServico decimal(10,2) DEFAULT NULL",
                "ValorTotalMaterial decimal(10,2) DEFAULT NULL",
                "Imagem longblob",
                "PRIMARY KEY (IDOrdenServico)"
            });
        }
        private void VerifyAndCreateTable(MySqlConnection connection, string tableName, string[] columns)
        {
            // Verifica se a tabela existe
            var checkTableQuery = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'DBOrdenServicos' AND TABLE_NAME = '{tableName}'";
            using (var checkTableCommand = new MySqlCommand(checkTableQuery, connection))
            {
                var tableExists = Convert.ToInt32(checkTableCommand.ExecuteScalar()) > 0;
                if (!tableExists)
                {
                    // Cria a tabela se não existir
                    var createTableQuery = $"CREATE TABLE {tableName} ({string.Join(", ", columns)}) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";
                    using (var createTableCommand = new MySqlCommand(createTableQuery, connection))
                    {
                        createTableCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Verifica e adiciona colunas faltantes
                    foreach (var column in columns)
                    {
                        // Ignora PRIMARY KEY e UNIQUE KEY
                        if (column.StartsWith("PRIMARY KEY") || column.StartsWith("UNIQUE KEY"))
                        {
                            continue;
                        }

                        var columnName = column.Split(' ')[0];
                        var checkColumnQuery = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'DBOrdenServicos' AND TABLE_NAME = '{tableName}' AND COLUMN_NAME = '{columnName}'";
                        using (var checkColumnCommand = new MySqlCommand(checkColumnQuery, connection))
                        {
                            var columnExists = Convert.ToInt32(checkColumnCommand.ExecuteScalar()) > 0;
                            if (!columnExists)
                            {
                                var addColumnQuery = $"ALTER TABLE {tableName} ADD COLUMN {column}";
                                using (var addColumnCommand = new MySqlCommand(addColumnQuery, connection))
                                {
                                    addColumnCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
        }
        public bool VerificarSeCadastrado(object valor, string tabela, string coluna)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT COUNT(*) FROM {tabela} WHERE {coluna} = @valor";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@valor", valor.ToString());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}

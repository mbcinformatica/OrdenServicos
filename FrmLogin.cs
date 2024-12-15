using MySql.Data.MySqlClient;
using ProjetoTeste.BLL;
using ProjetoTeste.Forms;
using ProjetoTeste.Model;
using ProjetoTeste.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoTeste
{
    public partial class frmLogin : BaseForm
    {
        private static readonly string connectionString = "Server=192.168.1.198;Port=3306;Database=DBOrdenServicos;User ID=root;Password=password;";
        private (Control, string)[] camposObrigatorios;
        private int nTentativasLogin = 0;
        private List<Control> controlesKeyPress = new List<Control>();
        private List<Control> controlesLeave = new List<Control>();
        private List<Control> controlesEnter = new List<Control>();
        private List<Control> controlesMouseDown = new List<Control>();
        private List<Control> controlesBotoes = new List<Control>();
        private List<Control> controlesKeyDown = new List<Control>();

        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Tag = new string[] { "alinhar", "azul" };

            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new PaintEventHandler(BaseForm_Paint);
            erpProvider = new ErrorProvider();
            ConfigurarTextBox();
            CarregaKey();
            LimparCampos();
        }
        private void CarregaKey()
        {
            // Adicionar controles às listas específicas com base no tipo de evento
            controlesKeyPress.AddRange(new Control[] {});
            controlesEnter.AddRange(new Control[] { });
            controlesMouseDown.AddRange(new Control[] {});
            controlesLeave.AddRange(new Control[] {
                txtLogin,
                txtSenha
            });
            controlesKeyDown.AddRange(new Control[] {
                txtLogin,
                txtSenha
            });
            controlesBotoes.AddRange(new Control[] {
                btnLogin,
                btnSair
            });

             this.Tag = "frmLogin";

            TabControl tabControl = null;
            TabPage tabPage = null;

            EventosUtils.InicializarEventos(Controls, controlesKeyPress, controlesLeave, controlesEnter, controlesMouseDown, controlesKeyDown, controlesBotoes, this, tabControl, tabPage);
        }
        public override void VerificaTextBox(TextBox textBox)
        {
            if (textBox == txtLogin)
            {
                if (ValidaUsuario(txtLogin.Text) && !string.IsNullOrWhiteSpace(txtLogin.Text))
                {
                    MessageBox.Show("Usuário não Cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    return;
                }
                else
                {
                    imgCadeadoAberto.Visible = true;
                    imgCadeadoFechado.Visible = false;
                    PegaSenhaHansDB();
                }
            }
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
  //              (txtLogin, "Login"),
  //              (txtSenha, "Senha"),
            };

            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
        }
        private void LimparCampos()
        {
            txtLogin.Clear();
            txtSenha.Clear();
            txtSenhaHash.Clear();
            txtLogin.Focus();
            imgCadeadoAberto.Visible = false;
            imgCadeadoFechado.Visible = true;
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidarCredenciais())
            {
                Close();
                return;
            }
            nTentativasLogin++;
            if (nTentativasLogin >= 4)
            {
                MessageBox.Show("Número Máximo de Tentativas Atingido. O Programa Será Fechado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Senha Inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCampos();

            }
        }
        private bool ValidarCredenciais()
        {
            bool isValid = BCrypt.Net.BCrypt.Verify(txtSenha.Text, txtSenhaHash.Text);
            return isValid;
        }
        private bool ValidaUsuario(string Login)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM DBUsuarios WHERE Login = @Login";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Login", Login);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
            }
        }
        private void PegaSenhaHansDB()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Senha FROM DBUsuarios WHERE Login = @Login";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Login", txtLogin.Text);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtSenhaHash.Text = reader["Senha"].ToString();
                    }
                    else
                    {
                        txtSenhaHash.Text = "";
                    }
                }
            }

        }
    }
}


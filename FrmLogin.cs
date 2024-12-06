using MySql.Data.MySqlClient;
using ProjetoTeste.Forms;
using System;
using System.Windows.Forms;

namespace ProjetoTeste
{
    public partial class frmLogin : BaseForm
    {
        private static readonly string connectionString = "Server=192.168.1.198;Port=3306;Database=DBOrdenServicos;User ID=root;Password=password;";
        private (Control, string)[] camposObrigatorios;
        private int nTentativasLogin = 0;
        private bool escPressed = false; // Reseta a variável de controle

        public frmLogin()
        {
            InitializeComponent();

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
            txtLogin.KeyDown += TextBox_KeyDown;
            txtSenha.KeyDown += TextBox_KeyDown;

            txtLogin.Leave += TextBox_Leave;
            txtSenha.Leave += TextBox_Leave;

            // Adiciona eventos de mouse aos botões
            btnLogin.MouseEnter += Button_MouseEnter;
            btnLogin.MouseLeave += Button_MouseLeave;
            btnSair.MouseEnter += Button_MouseEnter;
            btnSair.MouseLeave += Button_MouseLeave;

        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                button.BackColor = buttonFontColor; // Cor de fundo ao passar o mouse
                button.ForeColor = buttonBackgroundColor; // Cor da fonte ao passar o mouse
            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                button.BackColor = buttonBackgroundColor; // Cor de fundo original
                button.ForeColor = buttonFontColor; // Cor da fonte original
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Impede o som de "beep"

                if (sender == txtLogin)
                {
                    if (ValidaUsuario(txtLogin.Text))
                    {
                        MessageBox.Show("Usuário não Cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                    else
                    {
                        imgCadeadoAberto.Visible = true;
                        imgCadeadoFechado.Visible = false;
                        PegaSenhaHansDB();
                    }
                }
                this.SelectNextControl((Control)sender, true, true, true, true);

            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.AutoValidate = AutoValidate.Disable;
                escPressed = true; // Reseta a variável de controle
            }
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (escPressed)
            {
                escPressed = false; // Reseta a variável de controle
                Application.Exit();

            }
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
                (txtLogin, "Login"),
                (txtSenha, "Senha"),
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
            escPressed = true;
            Application.Exit(); // Fecha o programa inteiro
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidarCredenciais())
            {
                this.Close();
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


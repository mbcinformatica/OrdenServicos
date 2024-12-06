cpnexao
static string connectionString = "Server=192.168.1.198;Port=3306;Database=dbsys;User ID=root;Password=password;";
Codigo Principal
frmTelaPrincipal
ao executar o codigo antes de abrir a tela de login o codigo verefica 
se o banco de Usuarios esta vazio se sim executa o codigo cadastro de usuarios
apos cadastrar e fechar o fornulario executa o login
using MySql.Data.MySqlClient;
using ProjetoTeste.BLL;
using ProjetoTeste.DAL;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace ProjetoTeste
{
public partial class frmTelaPrincipal : Form
{
static string connectionString = "Server=192.168.1.198;Port=3306;Database=dbsys;User ID=root;Password=password;";
public frmTelaPrincipal()
{
using (MySqlConnection conn = new MySqlConnection(connectionString))
{
try { }
catch (MySqlException ex)
{
MessageBox.Show("Erro de MySQL: " + ex.Message);
}
catch (Exception ex)
{
MessageBox.Show("Erro: " + ex.Message);
}
}
InitializeComponent();
this.Load += frmTelaPrincipal_Load;
this.Paint += new PaintEventHandler(frmTelaPrincipal_Paint); // Adiciona o evento Paint
UsuarioBLL usuarioBLL = new UsuarioBLL();
if (usuarioBLL.IsUsuariosEmpty());
{
string mensagem = "Não existe Usuário Cadastrado.\n\nAntes de continuar a usar o sistema, \nFavor Cadastrar um Usuario com Direitos Administrativo.\n\nCadastre um novo usuário.";
MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
AbrirFormularioUsuarios();
Application.Exit(); 
}
AbrirFormularioLogin();
}
private void frmTelaPrincipal_Paint(object sender, PaintEventArgs e)
{
using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.DarkCyan, Color.LightCyan, 45F))
{
e.Graphics.FillRectangle(brush, this.ClientRectangle);
}
}
private void frmTelaPrincipal_Load(object sender, EventArgs e)
{
// Define o tamanho do formulário para 80% da largura e altura da tela
this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.8);
this.Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8);
// Centraliza o formulário na tela
this.StartPosition = FormStartPosition.Manual;
this.Location = new Point(
(Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
(Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
);
}
private void AbrirFormularioLogin()
{
frmLogin formularioLogin = new frmLogin();
// Define o tamanho do formulário de fornecedores para 90% da largura e 90% da altura da tela principal
formularioLogin.Width = (int)(this.Width * 0.9);
formularioLogin.Height = (int)(this.Height * 0.8);
// Ajusta a localização para ficar abaixo do menu do formulário principal
formularioLogin.StartPosition = FormStartPosition.Manual;
formularioLogin.Location = new Point(
this.Location.X + (this.Width - formularioLogin.Width) / 2,
this.Location.Y + (this.Height - formularioLogin.Height) / 2);
formularioLogin.ShowDialog();
}
private void toolStripMenuItem2_Click(object sender, EventArgs e)
{
Application.Exit(); // Fecha o programa inteiro
}
private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
{
AbrirFormularioClientes();
}
private void AbrirFormularioClientes()
{
frmClientes formularioClientes = new frmClientes();
// Define o tamanho do formulário de clientes para 90% da largura e 90% da altura da tela principal
formularioClientes.Width = (int)(this.Width * 0.9);
formularioClientes.Height = (int)(this.Height * 0.8);
// Ajusta a localização para ficar abaixo do menu do formulário principal
formularioClientes.StartPosition = FormStartPosition.Manual;
formularioClientes.Location = new Point(
this.Location.X + (this.Width - formularioClientes.Width) / 2,
this.Location.Y + (this.Height - formularioClientes.Height) / 2);
formularioClientes.ShowDialog();
}
private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
{
AbrirFormularioUsuarios();
}
private void AbrirFormularioUsuarios()
{
frmUsuarios formularioUsuarios = new frmUsuarios();
// Define o tamanho do formulário de clientes para 90% da largura e 90% da altura da tela principal
formularioUsuarios.Width = (int)(this.Width * 0.9);
formularioUsuarios.Height = (int)(this.Height * 0.8);
// Ajusta a localização para ficar abaixo do menu do formulário principal
formularioUsuarios.StartPosition = FormStartPosition.Manual;
formularioUsuarios.Location = new Point(
this.Location.X + (this.Width - formularioUsuarios.Width) / 2,
this.Location.Y + (this.Height - formularioUsuarios.Height) / 2);
formularioUsuarios.ShowDialog();
}
private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
{
AbrirformularioFornecedores();
}
private void AbrirformularioFornecedores()
{
frmFornecedores formularioFornecedores = new frmFornecedores();
// Define o tamanho do formulário de fornecedores para 90% da largura e 90% da altura da tela principal
formularioFornecedores.Width = (int)(this.Width * 0.9);
formularioFornecedores.Height = (int)(this.Height * 0.8);
// Ajusta a localização para ficar abaixo do menu do formulário principal
formularioFornecedores.StartPosition = FormStartPosition.Manual;
formularioFornecedores.Location = new Point(
this.Location.X + (this.Width - formularioFornecedores.Width) / 2,
this.Location.Y + (this.Height - formularioFornecedores.Height) / 2);
formularioFornecedores.ShowDialog();
}
private void cadastroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
{
AbrirRelatorioClientes();
}
private void AbrirRelatorioClientes()
{
Relatorios.FrmRelClientes relatorioClientes = new Relatorios.FrmRelClientes();
relatorioClientes.Width = (int)(this.Width * 0.9);
relatorioClientes.Height = (int)(this.Height * 0.8);
relatorioClientes.StartPosition = FormStartPosition.Manual;
relatorioClientes.Location = new Point(
this.Location.X + (this.Width - relatorioClientes.Width) / 2,
this.Location.Y + (this.Height - relatorioClientes.Height) / 2);
relatorioClientes.ShowDialog();
}
private void cadastroDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
{
AbrirRelatorioFornecedores();
}
private void AbrirRelatorioFornecedores()
{
Relatorios.FrmRelFornecedores relatorioFornecedores = new Relatorios.FrmRelFornecedores();
relatorioFornecedores.Width = (int)(this.Width * 0.9);
relatorioFornecedores.Height = (int)(this.Height * 0.8);
relatorioFornecedores.StartPosition = FormStartPosition.Manual;
relatorioFornecedores.Location = new Point(
this.Location.X + (this.Width - relatorioFornecedores.Width) / 2,
this.Location.Y + (this.Height - relatorioFornecedores.Height) / 2);
relatorioFornecedores.ShowDialog();
}
}
}
#########################################################################
using MySql.Data.MySqlClient;
using ProjetoTeste.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using BCrypt.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
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
public UsuarioInfo GetUsuario(int IDUsuario)
public void AtualizarUsuario(UsuarioInfo usuario)
public void InserirUsuario(UsuarioInfo usuario)
public void ExcluirUsuario(int IDUsuario)
public bool VerificaUsuario(string login)
{
using (MySqlConnection conn = new MySqlConnection(connectionString))
{
conn.Open();
string query = "SELECT COUNT(*) FROM DBUsuarios WHERE login = @login";
MySqlCommand cmd = new MySqlCommand(query, conn);
cmd.Parameters.AddWithValue("@login", login);
int count = Convert.ToInt32(cmd.ExecuteScalar());
return count > 0;
}
}
public bool IsUsuariosEmpty()
{
bool isEmpty = true;
using (MySqlConnection conn = new MySqlConnection(connectionString))
{
conn.Open();
string query = "SELECT COUNT(*) FROM DBUsuarios";
MySqlCommand cmd = new MySqlCommand(query, conn);
int count = Convert.ToInt32(cmd.ExecuteScalar());
isEmpty = count == 0;
}
return isEmpty;
}
}
}
#########################################################################
using MySql.Data.MySqlClient;
using ProjetoTeste.DAL;
using ProjetoTeste.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using System.Windows.Forms;
namespace ProjetoTeste.BLL
{
public class UsuarioBLL
{
public List<UsuarioInfo> Listar()
public UsuarioInfo GetUsuario(int IDUsuario)
public void AtualizarUsuario(UsuarioInfo Usuario)
public void InserirUsuario(UsuarioInfo Usuario)  
public void ExcluirUsuario(int IdUsuario)
public bool VerificaUsuario(string login)
{
UsuarioDAL usuarioDAL = new UsuarioDAL();
return usuarioDAL.VerificaUsuario(login);
}
public bool IsUsuariosEmpty()
{
UsuarioDAL usuarioDAL = new UsuarioDAL();
return usuarioDAL.IsUsuariosEmpty();
}
}
}
#########################################################################
using MySql.Data.MySqlClient;
using ProjetoTeste.BLL;
using ProjetoTeste.DAL;
using ProjetoTeste.Model;
using ProjetoTeste.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using BCrypt.Net;
using ProjetoTeste.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ProjetoTeste
{
public partial class frmLogin : BaseForm
{
private (Control, string)[] camposObrigatorios;
private int nTentativasLogin = 0;
public frmLogin()
{
InitializeComponent();
errorProvider1 = new System.Windows.Forms.ErrorProvider();
int nTentativasLogin = 0;
ConfigurarTextBox();
CarregaKey();
LimparCampos();
}
private void CarregaKey()
{
txtLogin.KeyDown += TextBox_KeyDown;
txtSenha.KeyDown += TextBox_KeyDown;
}
private void ConfigurarTextBox()
{
camposObrigatorios = new (Control, string)[]
{
(txtLogin, "Login"),
(txtSenha, "Senha"),
};
AdicionarValidacao(errorProvider1, camposObrigatorios);
}
private void LimparCampos()
{
txtLogin.Clear();
txtSenha.Clear();
txtSenhaHash.Clear();
txtLogin.Focus();
}
private void TextBox_KeyDown(object sender, KeyEventArgs e)
{
if (e.KeyCode == Keys.Enter)
{
e.SuppressKeyPress = true; // Impede o som de "beep"
if (sender == txtLogin)
{
UsuarioBLL usuarioBLL = new UsuarioBLL();
if (!usuarioBLL.ValidaUsuario(txtLogin.Text))
{
MessageBox.Show("Usuário não Cadastrado. Favor verificar!");
LimparCampos();
return;
}
}
this.SelectNextControl((Control)sender, true, true, true, true);
}
else if (e.KeyCode == Keys.Escape)
{
this.AutoValidate = AutoValidate.Disable;
Application.Exit(); // Fecha o programa inteiro
this.AutoValidate = AutoValidate.EnablePreventFocusChange;
}
}
private void btnSair_Click(object sender, EventArgs e)
{
Application.Exit(); // Fecha o programa inteiro
}
private void btnLogin_Click(object sender, EventArgs e)
{
if (ValidarCredenciais())
{
this.Close();
}
nTentativasLogin++;
if (nTentativasLogin >= 4)
{
MessageBox.Show("Número Máximo de Tentativas Atingido. O Programa Será Fechado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
Application.Exit();
}
else
{
MessageBox.Show("Senha Invalida!.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
LimparCampos();
}
}
private bool ValidarCredenciais()
{
bool isValid = BCrypt.Net.BCrypt.Verify(txtSenha.Text, txtSenhaHash.Text);
return isValid;
}
}
}
#########################################################################
using MySql.Data.MySqlClient;
using ProjetoTeste.BLL;
using ProjetoTeste.DAL;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace ProjetoTeste
{
public partial class frmTelaPrincipal : Form
{
static string connectionString = "Server=192.168.1.198;Port=3306;Database=dbsys;User ID=root;Password=password;";
public frmTelaPrincipal()
{
using (MySqlConnection conn = new MySqlConnection(connectionString))
{
try { }
catch (MySqlException ex)
{
MessageBox.Show("Erro de MySQL: " + ex.Message);
}
catch (Exception ex)
{
MessageBox.Show("Erro: " + ex.Message);
}
}
InitializeComponent();
this.Load += frmTelaPrincipal_Load;
this.Paint += new PaintEventHandler(frmTelaPrincipal_Paint); // Adiciona o evento Paint
UsuarioBLL usuarioBLL = new UsuarioBLL();
if (usuarioBLL.IsUsuariosEmpty());
{
string mensagem = "Não existe Usuário Cadastrado.\n\nAntes de continuar a usar o sistema, \nFavor Cadastrar um Usuario com Direitos Administrativo.\n\nCadastre um novo usuário.";
MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
AbrirFormularioUsuarios();
Application.Exit(); 
}
AbrirFormularioLogin();
}
private void frmTelaPrincipal_Paint(object sender, PaintEventArgs e)
private void frmTelaPrincipal_Load(object sender, EventArgs e)  
private void AbrirFormularioLogin()
private void toolStripMenuItem2_Click(object sender, EventArgs e)
private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
private void AbrirFormularioClientes()    
private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
private void AbrirFormularioUsuarios() 
private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
private void AbrirformularioFornecedores()
private void cadastroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
private void AbrirRelatorioClientes()
private void cadastroDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
private void AbrirRelatorioFornecedores()
}
}
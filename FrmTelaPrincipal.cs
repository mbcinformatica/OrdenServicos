using ProjetoTeste.BLL;
using ProjetoTeste.Forms;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetoTeste
{
    public partial class frmTelaPrincipal : BaseForm
    {
        private readonly string connectionString;
        public frmTelaPrincipal()
        {
            InitializeComponent();

            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new PaintEventHandler(BaseForm_Paint);
            Load += frmTelaPrincipal_Load;

            connectionString = ConfigurationManager.AppSettings["ConnectionStringWithoutDatabase"];
            DBSetupBLL dbsetupBLL = new DBSetupBLL();
            if (dbsetupBLL.CheckAndSetupDatabase())
            {

                try
                {
                    UsuarioBLL usuarioBLL = new UsuarioBLL();
                    if (usuarioBLL.IsUsuariosEmpty())
                    {
                        string mensagem = "Não existe Usuário Cadastrado.\n\nAntes de continuar a usar o sistema, \nFavor Cadastrar um Usuario com Direitos Administrativo.\n\nCadastre um novo usuário.";
                        MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AbrirFormularioUsuarios();
                        Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: ", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void frmTelaPrincipal_Load(object sender, EventArgs e)
        {
            // Define o tamanho do formulário para 80% da largura e altura da tela
            Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.8);
            Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8);

            // Centraliza o formulário na tela
            StartPosition = FormStartPosition.Manual;
            Location = new Point(
               (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2,
               (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);
            AbrirFormularioLogin();
        }
        private void AbrirFormularioLogin()
        {
            frmLogin FrmLogin = new frmLogin();
            frmLogin formularioLogin = FrmLogin;

            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioLogin.StartPosition = FormStartPosition.CenterScreen;

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
            frmClientes FrmClientes = new frmClientes();
            frmClientes formularioClientes = FrmClientes;

            // Define o tamanho do formulário de clientes para 90% da largura e 90% da altura da tela principal
            formularioClientes.Width = (int)(Width * 0.9);
            formularioClientes.Height = (int)(Height * 0.8);

            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioClientes.StartPosition = FormStartPosition.Manual;
            formularioClientes.Location = new Point(
                Location.X + (Width - formularioClientes.Width) / 2,
                Location.Y + (Height - formularioClientes.Height) / 2);

            formularioClientes.ShowDialog();
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioUsuarios();
        }
        private void AbrirFormularioUsuarios()
        {
            frmUsuarios FrmUsuarios = new frmUsuarios();
            frmUsuarios formularioUsuarios = FrmUsuarios;

            // Define o tamanho do formulário de clientes para 90% da largura e 90% da altura da tela principal
            formularioUsuarios.Width = (int)(Width * 0.9);
            formularioUsuarios.Height = (int)(Height * 0.8);

            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioUsuarios.StartPosition = FormStartPosition.Manual;
            formularioUsuarios.Location = new Point(
                Location.X + (Width - formularioUsuarios.Width) / 2,
                Location.Y + (Height - formularioUsuarios.Height) / 2);

            formularioUsuarios.ShowDialog();
        }
        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioFornecedores();
        }
        private void AbrirformularioFornecedores()
        {
            frmFornecedores FrmFornecedores = new frmFornecedores();
            frmFornecedores formularioFornecedores = FrmFornecedores;

            // Define o tamanho do formulário de fornecedores para 90% da largura e 90% da altura da tela principal
            formularioFornecedores.Width = (int)(Width * 0.9);
            formularioFornecedores.Height = (int)(Height * 0.8);

            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioFornecedores.StartPosition = FormStartPosition.Manual;
            formularioFornecedores.Location = new Point(
                Location.X + (Width - formularioFornecedores.Width) / 2,
                Location.Y + (Height - formularioFornecedores.Height) / 2);

            formularioFornecedores.ShowDialog();
        }
        private void categoriaDeServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioCategoriaServicos();
        }
        private void AbrirformularioCategoriaServicos()
        {
            frmCategoriaServicos FrmCategoriaServicos = new frmCategoriaServicos();
            frmCategoriaServicos formularioCategoriaServicos = FrmCategoriaServicos;
            formularioCategoriaServicos.ShowDialog();
        }
        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioMarcas();
        }
        private void AbrirformularioMarcas()
        {
            frmMarcas FrmMarcas = new frmMarcas();
            frmMarcas formularioMarcas = FrmMarcas;
            formularioMarcas.ShowDialog();
        }
        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioModelos();

        }
        private void AbrirformularioModelos()
        {
            frmModelos FrmModelos = new frmModelos();
            frmModelos formularioModelos = FrmModelos;
            formularioModelos.ShowDialog();
        }
        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioUnidades();

        }
        private void AbrirformularioUnidades()
        {
            frmUnidades FrmUnidades = new frmUnidades();
            frmUnidades formularioUnidades = FrmUnidades;
            formularioUnidades.ShowDialog();
        }
        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioServicos();

        }
        private void AbrirformularioServicos()
        {
            frmServicos FrmServicos = new frmServicos();
            frmServicos formularioServicos = FrmServicos;
            formularioServicos.ShowDialog();
        }
        private void cadastroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirRelatorioClientes();

        }
        private void AbrirRelatorioClientes()
        {
            // Defina o caminho base onde o relatório será salvo
            string caminhoBase = @"D:\ProjetoCSharp\ProjetoTeste\RelatorioPDF\RelatorioClientes.pdf"; // Você pode ajustar este caminho conforme necessário
            string caminhoArquivo = caminhoBase;

            // Verifique se o arquivo já existe e gere um novo nome se necessário
            int contador = 1;
            while (File.Exists(caminhoArquivo))
            {
                string diretorio = Path.GetDirectoryName(caminhoBase);
                string nomeArquivoSemExtensao = Path.GetFileNameWithoutExtension(caminhoBase);
                string extensao = Path.GetExtension(caminhoBase);
                caminhoArquivo = Path.Combine(diretorio, $"{nomeArquivoSemExtensao}_{contador}{extensao}");
                contador++;
            }

            // Crie uma instância da classe RelatorioClientes
            RelatorioClientes relatorio = new RelatorioClientes();

            // Gere o relatório
            relatorio.GerarRelatorioClientes(caminhoArquivo);

            // Exiba uma mensagem de confirmação
            MessageBox.Show("Relatório gerado com sucesso em " + caminhoArquivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void cadastroDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirRelatorioFornecedores();

        }
        private void AbrirRelatorioFornecedores()
        {
            // Defina o caminho base onde o relatório será salvo
            string caminhoBase = @"D:\ProjetoCSharp\ProjetoTeste\RelatorioPDF\RelatorioFornecedores.pdf"; // Você pode ajustar este caminho conforme necessário
            string caminhoArquivo = caminhoBase;

            // Verifique se o arquivo já existe e gere um novo nome se necessário
            int contador = 1;
            while (File.Exists(caminhoArquivo))
            {
                string diretorio = Path.GetDirectoryName(caminhoBase);
                string nomeArquivoSemExtensao = Path.GetFileNameWithoutExtension(caminhoBase);
                string extensao = Path.GetExtension(caminhoBase);
                caminhoArquivo = Path.Combine(diretorio, $"{nomeArquivoSemExtensao}_{contador}{extensao}");
                contador++;
            }

            // Crie uma instância da classe RelatorioClientes
            RelatorioFornecedores relatorio = new RelatorioFornecedores();

            // Gere o relatório
            relatorio.GerarRelatorioFornecedores(caminhoArquivo);

            // Exiba uma mensagem de confirmação
            MessageBox.Show("Relatório gerado com sucesso em " + caminhoArquivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioProdutos();
        }
        private void AbrirFormularioProdutos()
        {
            frmProdutos FrmProdutos = new frmProdutos();
            frmProdutos formularioProdutos = FrmProdutos;

            // Define o tamanho do formulário de clientes para 90% da largura e 90% da altura da tela principal
            formularioProdutos.Width = (int)(Width * 0.9);
            formularioProdutos.Height = (int)(Height * 0.8);

            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioProdutos.StartPosition = FormStartPosition.Manual;
            formularioProdutos.Location = new Point(
                Location.X + (Width - formularioProdutos.Width) / 2,
                Location.Y + (Height - formularioProdutos.Height) / 2);

            formularioProdutos.ShowDialog();
        }
        private void cadastroDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirRelatorioUsuarios();
        }
        private void AbrirRelatorioUsuarios()
        {
            // Defina o caminho base onde o relatório será salvo
            string caminhoBase = @"D:\ProjetoCSharp\ProjetoTeste\RelatorioPDF\RelatorioUsuarios.pdf"; // Você pode ajustar este caminho conforme necessário
            string caminhoArquivo = caminhoBase;

            // Verifique se o arquivo já existe e gere um novo nome se necessário
            int contador = 1;
            while (File.Exists(caminhoArquivo))
            {
                string diretorio = Path.GetDirectoryName(caminhoBase);
                string nomeArquivoSemExtensao = Path.GetFileNameWithoutExtension(caminhoBase);
                string extensao = Path.GetExtension(caminhoBase);
                caminhoArquivo = Path.Combine(diretorio, $"{nomeArquivoSemExtensao}_{contador}{extensao}");
                contador++;
            }

            // Crie uma instância da classe RelatorioClientes
            RelatorioUsuarios relatorio = new RelatorioUsuarios();

            // Gere o relatório
            relatorio.GerarRelatorioUsuarios(caminhoArquivo);

            // Exiba uma mensagem de confirmação
            MessageBox.Show("Relatório gerado com sucesso em " + caminhoArquivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void formularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirConfiguracaoFormulaio();
        }
        private void AbrirConfiguracaoFormulaio()
        {
            frmConfigFormulario FrmConfigFormulario = new frmConfigFormulario();
            frmConfigFormulario formularioConfigFormulario = FrmConfigFormulario;

            // Define o tamanho do formulário de ConfigFormulario para 90% da largura e 90% da altura da tela principal
            formularioConfigFormulario.Width = (int)(Width * 0.9);
            formularioConfigFormulario.Height = (int)(Height * 0.8);

            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioConfigFormulario.StartPosition = FormStartPosition.Manual;
            formularioConfigFormulario.Location = new Point(
                Location.X + (Width - formularioConfigFormulario.Width) / 2,
                Location.Y + (Height - formularioConfigFormulario.Height) / 2);

            formularioConfigFormulario.ShowDialog();
        }
        private void serviçosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulaioLancamentoServicos();
        }
        private void AbrirFormulaioLancamentoServicos()
        {
            frmLancamentoServicos FrmLancamentoServicos = new frmLancamentoServicos();
            frmLancamentoServicos formularioLancamentoServicos = FrmLancamentoServicos;

            // Define o tamanho do formulário de ConfigFormulario para 90% da largura e 90% da altura da tela principal
            formularioLancamentoServicos.Width = (int)(Width * 0.9);
            formularioLancamentoServicos.Height = (int)(Height * 0.8);

            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioLancamentoServicos.StartPosition = FormStartPosition.Manual;
            formularioLancamentoServicos.Location = new Point(
                Location.X + (Width - formularioLancamentoServicos.Width) / 2,
                Location.Y + (Height - formularioLancamentoServicos.Height) / 2);

            formularioLancamentoServicos.ShowDialog();
        }
    }
}
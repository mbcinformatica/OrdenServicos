using AForge.Video.DirectShow;
using Newtonsoft.Json.Linq;
using ProjetoTeste.BLL;
using ProjetoTeste.Forms;
using ProjetoTeste.Model;
using ProjetoTeste.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoTeste
{
    public partial class frmUsuarios : BaseForm
    {
        private int sortColumn = 1; // Coluna "Nome" por padrão
        private bool sortAscending = true;
        private Color defaultHeaderBackColor = Color.DarkTurquoise;
        private Color clickedHeaderBackColor = Color.CadetBlue;
        private List<ListViewItem> listaOriginalItens = new List<ListViewItem>();
        private (Control, string)[] camposObrigatorios;
        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;
        private List<Control> controlesKeyPress = new List<Control>();
        private List<Control> controlesLeave = new List<Control>();
        private List<Control> controlesEnter = new List<Control>();
        private List<Control> controlesMouseDown = new List<Control>();
        private List<Control> controlesBotoes = new List<Control>();
        private List<Control> controlesKeyDown = new List<Control>();
        private EventArgs e;


        public frmUsuarios()
        {
            InitializeComponent();
            LoadConfig();
            Paint += new PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlUsuarios);
            erpProvider = new ErrorProvider();
            ConfigurarTextBox();
            CarregaKey();
            ConfigurarTabIndexControles();
            CarregarRegistros();
        }
        private void InitializeListView()
        {

            // Configurar a ListView
            listViewUsuario.View = View.Details;
            listViewUsuario.FullRowSelect = true;
            listViewUsuario.OwnerDraw = true; // Permitir desenho personalizado
            listViewUsuario.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewUsuario_DrawColumnHeader);
            listViewUsuario.DrawItem += new DrawListViewItemEventHandler(listViewUsuario_DrawItem);
            listViewUsuario.DrawSubItem += new DrawListViewSubItemEventHandler(listViewUsuario_DrawSubItem);

            // Adicionar colunas
            listViewUsuario.Columns.Add("  ID", 50, HorizontalAlignment.Right);
            listViewUsuario.Columns.Add("  NOME", 300, HorizontalAlignment.Left);
            listViewUsuario.Columns.Add("  LOGIN", 200, HorizontalAlignment.Left);
            listViewUsuario.Columns.Add("  ENDEREÇO", 200, HorizontalAlignment.Left);
            listViewUsuario.Columns.Add("  NUMERO", 200, HorizontalAlignment.Right);
            listViewUsuario.Columns.Add("  BAIRRO", 150, HorizontalAlignment.Left);
            listViewUsuario.Columns.Add("  MUNICIPIO", 200, HorizontalAlignment.Left);
            listViewUsuario.Columns.Add("  UF", 50, HorizontalAlignment.Center);
            listViewUsuario.Columns.Add("  CEP", 70, HorizontalAlignment.Center);
            listViewUsuario.Columns.Add("  CELULAR", 100, HorizontalAlignment.Right);
            listViewUsuario.Columns.Add("  FIXO", 100, HorizontalAlignment.Right);
            listViewUsuario.Columns.Add("  EMAIL", 300, HorizontalAlignment.Left);
            listViewUsuario.Columns.Add("  DATA CADASTRO", 150, HorizontalAlignment.Right);

            // Adicionar evento de clique no cabeçalho da coluna
            listViewUsuario.ColumnClick += new ColumnClickEventHandler(ListViewUsuarios_ColumnClick);
            listViewUsuario.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewUsuario.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


        }
        private void ListViewUsuarios_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Permitir apenas cliques na coluna "NOME" (index 1)
            if (e.Column != 1)
            {
                return; // Ignorar cliques em outras colunas
            }

            // Alternar ordem se a mesma coluna for clicada
            if (e.Column == sortColumn)
            {
                sortAscending = !sortAscending;
            }
            else
            {
                sortColumn = e.Column;
                sortAscending = true;
            }

            listViewUsuario.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewUsuario.Sort();
            listViewUsuario.Columns[sortColumn].Width = listViewUsuario.Columns[sortColumn].Width;
            listViewUsuario.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
            txtPesquisaListView.Focus();
        }
        public class ListViewItemComparer : IComparer
        {
            private int col;
            private bool ascending;

            public ListViewItemComparer(int column, bool ascending)
            {
                this.col = column;
                this.ascending = ascending;
            }
            public int Compare(object x, object y)
            {
                // Comparar valores das subitens
                int returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                              ((ListViewItem)y).SubItems[col].Text);
                return ascending ? returnVal : -returnVal; // Ordem crescente ou decrescente
            }
        }
        private void txtPesquisaListView_TextChanged(object sender, EventArgs e)
        {
            PesquisarListView(txtPesquisaListView.Text, listViewUsuario, sortColumn);
        }
        private void PesquisarListView(string texto, ListView listView, int coluna)
        {
            listView.BeginUpdate();
            var itemsVisiveis = new List<ListViewItem>();
            foreach (ListViewItem item in listaOriginalItens)
            {
                if (item.SubItems[coluna].Text.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    itemsVisiveis.Add(item);
                }
            }
            listView.Items.Clear();
            listView.Items.AddRange(itemsVisiveis.ToArray());
            listView.EndUpdate();
            listView.Invalidate(); // Redesenha a ListView para refletir as mudanças
        }
        private void listViewUsuario_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {

            Color headerBackColor = e.ColumnIndex == sortColumn ? clickedHeaderBackColor : defaultHeaderBackColor;

            using (SolidBrush backBrush = new SolidBrush(headerBackColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }
            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.NoWrap;

                if (e.Header.Text == "  ID"
                    || e.Header.Text == "  UF"
                    || e.Header.Text == "  CEP"
                    || e.Header.Text == "  NUMERO"
                    || e.Header.Text == "  CELULAR"
                    || e.Header.Text == "  FIXO")
                {
                    sf.Alignment = StringAlignment.Center;
                }
                else
                {
                    sf.Alignment = StringAlignment.Near;
                }
                sf.LineAlignment = StringAlignment.Center;
                // Definir a fonte em negrito
                using (Font headerFont = new Font(e.Font, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds, sf);
                }

                using (Pen gridLinePen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawRectangle(gridLinePen, e.Bounds);
                }
            }
        }
        private void listViewUsuario_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Alternar cores das linhas
            if (e.ItemIndex % 2 == 0)
            {
                e.Item.BackColor = Color.White;
            }
            else
            {
                e.Item.BackColor = Color.LightBlue;
            }
            e.DrawDefault = true;
        }
        private void listViewUsuario_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewUsuario.Columns[e.ColumnIndex].Text == "  ID" ||
                    listViewUsuario.Columns[e.ColumnIndex].Text == "  UF" ||
                    listViewUsuario.Columns[e.ColumnIndex].Text == "  CEP" ||
                    listViewUsuario.Columns[e.ColumnIndex].Text == "  NUMERO" ||
                    listViewUsuario.Columns[e.ColumnIndex].Text == "  CELULAR" ||
                    listViewUsuario.Columns[e.ColumnIndex].Text == "  FIXO")
                {
                    sf.Alignment = StringAlignment.Far; // Alinhar conteúdo numérico à direita
                }
                else
                {
                    sf.Alignment = StringAlignment.Near; // Alinhar conteúdo de texto à esquerda
                }
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, Brushes.Black, e.Bounds, sf);
            }
        }
        private void CarregaKey()
        {
            controlesKeyPress.AddRange(new Control[] {
                txtCep,
                txtFone_1,
                txtFone_2
            });

            controlesEnter.AddRange(new Control[] {
                txtNome,
                txtLogin,
                txtSenha,
                txtConfirmaSenha,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtFone_1,
                txtFone_2,
                txtEmail
            });

            controlesMouseDown.AddRange(new Control[] { });

            controlesLeave.AddRange(new Control[] {
                txtNome,
                txtLogin,
                txtSenha,
                txtConfirmaSenha,
                txtNumero,
                txtCep,
                txtFone_1,
                txtFone_2,
                txtEmail
            });

            controlesKeyDown.AddRange(new Control[] {
                txtNome,
                txtLogin,
                txtSenha,
                txtConfirmaSenha,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtFone_1,
                txtFone_2,
                txtEmail,
                txtPesquisaListView,
                listViewUsuario
            });

            controlesBotoes.AddRange(new Control[] {
                btnSalvar,
                btnAlterar,
                btnExcluir,
                btnFechar,
                btnCancelar,
                btnNovo,
                btnPesquisaCep,
                btnInserirImagem,
                btnExcluirImagem
            });

            this.Tag = "frmCadastroUsuarios";

            txtCep.Tag = new BaseForm { TagFormato = "FormataCep", TagMaxDigito = 8 }; 
            txtFone_1.Tag = new BaseForm { TagFormato = "FormataFone", TagMaxDigito = 11 };
            txtFone_2.Tag = new BaseForm { TagFormato = "FormataFone", TagMaxDigito = 10 };
            txtEmail.Tag = new BaseForm { TagAction = "TabPage" };

            var tabControl = Controls.Find("tabControlUsuarios", true).FirstOrDefault() as TabControl;
            var tabPage = tabControl?.TabPages["tabInformacoesAdicionais"];

            EventosUtils.InicializarEventos(Controls, controlesKeyPress, controlesLeave, controlesEnter,
                                            controlesMouseDown, controlesKeyDown, controlesBotoes, this, tabControl, tabPage);

            listViewUsuario.Click += ListViewUsuarios_Click;
            txtPesquisaListView.Focus();
            AdicionarToolTipsAosControles();
        }
        private void AdicionarToolTipsAosControles()
        {
            List<ControlToolTipPair> controlToolTipPairs = new List<ControlToolTipPair>
            {
                new ControlToolTipPair { Control = txtNome, ToolTipText = "Informe o Nome do Usuário" },
                new ControlToolTipPair { Control = txtLogin, ToolTipText = "Informe um Login para o Usuário" },
                new ControlToolTipPair { Control = txtSenha, ToolTipText = "Cadastre uma Senha pra o Usuário" },
                new ControlToolTipPair { Control = txtConfirmaSenha, ToolTipText = "Confirme a Senha" },
                new ControlToolTipPair { Control = txtEndereco, ToolTipText = "Informe o Endereço do Usuário" },
                new ControlToolTipPair { Control = txtNumero, ToolTipText = "Informe o Numero do Endereço" },
                new ControlToolTipPair { Control = txtBairro, ToolTipText = "Informe o Bairro" },
                new ControlToolTipPair { Control = txtMunicipio, ToolTipText = "Informe o Municipio" },
                new ControlToolTipPair { Control = txtUF, ToolTipText = "Informe o Estado" },
                new ControlToolTipPair { Control = txtCep, ToolTipText = "Informe o CEP" },
                new ControlToolTipPair { Control = txtFone_1, ToolTipText = "Informe o Celular de Contato " },
                new ControlToolTipPair { Control = txtFone_2, ToolTipText = "Informe o Fixo de Contato" },
                new ControlToolTipPair { Control = txtEmail, ToolTipText = "Informe um E-Mail de Contato" },
                new ControlToolTipPair { Control = txtPesquisaListView, ToolTipText = "Inserir Informações para Pesquisa" } 
            };
            EventosUtils.AdicionarToolTips(this, controlToolTipPairs, tlpDicas);
        }
        public override void ExecutaFuncaoEvento(Control control)
        {
            if (control == txtNome && bNovo)
            {
                DBSetupBLL dbSetupBLL = new DBSetupBLL();
                string nome = txtNome.Text;
                if (dbSetupBLL.VerificarSeCadastrado(nome, "DBUsuarios", "Nome"))
                {
                    MessageBox.Show("Usuário já cadastrado. Favor verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.Clear();
                    txtNome.Focus();
                    return;
                }
            }
            else if (control == txtSenha && bNovo)
            {
                string senha = control.Text;
                if (senha.Length < 6)
                {
                    MessageBox.Show("A Senha deve Conter no Mínimo Seis Caracter. Favor verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSenha.Clear();
                    txtSenha.Focus();
                    return;
                }
            }

            else if (control == txtLogin && bNovo)
            {
                DBSetupBLL dbSetupBLL = new DBSetupBLL();
                string login = txtLogin.Text;
                // Verifica se o Login já está cadastrado
                if (dbSetupBLL.VerificarSeCadastrado(login, "DBUsuarios", "Login"))
                {
                    MessageBox.Show("Login já cadastrado. Favor verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLogin.Clear();
                    txtLogin.Focus();
                    return;
                }
            }
            else if (control == txtNumero)
            {
                if (string.IsNullOrEmpty(txtNumero.Text))
                {
                    txtNumero.Text = "S/N";
                }
            }
            else if (control == txtConfirmaSenha)
            {
                if (txtSenha.Text != txtConfirmaSenha.Text)
                {
                    MessageBox.Show("As senhas não Coincidem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmaSenha.Focus();
                }
            }
            else if (control == txtCep && !string.IsNullOrEmpty(txtCep.Text))
            {
                btnPesquisaCep_Click(control, e);
                control.Text = StringUtils.SemFormatacao(control.Text);
                control.Text = StringUtils.FormatCEP(control.Text);
            }
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
            (txtNome, "Nome"),
            (txtLogin, "Login"),
            (txtFone_1, "Celular"),
            };

            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
        }
        private void ConfigurarTabIndexControles()
        {
            txtNome.TabIndex = 0;
            txtLogin.TabIndex = 1;
            txtSenha.TabIndex = 2;
            txtConfirmaSenha.TabIndex = 3;
            txtCep.TabIndex = 4;
            txtEndereco.TabIndex = 5;
            txtNumero.TabIndex = 6;
            txtBairro.TabIndex = 7;
            txtMunicipio.TabIndex = 8;
            txtUF.TabIndex = 9;
            txtFone_1.TabIndex = 10;
            txtFone_2.TabIndex = 11;
            txtEmail.TabIndex = 12;
            btnSalvar.TabIndex = 13;
        }
        public override void CarregarRegistros()
        {
            DesabilitarCamposDoFormulario();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
            listViewUsuario.Items.Clear();
            listViewUsuario.Columns.Clear();
            InitializeListView(); // Adicionar colunas novamente, caso necessário

            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                List<UsuarioInfo> usuarios = usuarioBLL.Listar();
                foreach (UsuarioInfo usuario in usuarios)
                {
                    ListViewItem item = new ListViewItem(usuario.IDUsuario.ToString());
                    item.SubItems.Add(usuario.Nome);
                    item.SubItems.Add(usuario.Login);
                    item.SubItems.Add(usuario.Endereco);
                    item.SubItems.Add(usuario.Numero);
                    item.SubItems.Add(usuario.Bairro);
                    item.SubItems.Add(usuario.Municipio);
                    item.SubItems.Add(usuario.UF);
                    item.SubItems.Add(StringUtils.FormatCEP(usuario.Cep));
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(usuario.Fone_1));
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(usuario.Fone_2));
                    item.SubItems.Add(usuario.Email);
                    item.SubItems.Add(usuario.DataCadastro.ToString("dd/MM/yyyy"));

                    if (usuario.Imagem != null && usuario.Imagem.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(usuario.Imagem))
                        {
                            Image imgImagemUsuario = Image.FromStream(ms);
                        }
                    }
                    listViewUsuario.Items.Add(item);
                }

                listaOriginalItens = listViewUsuario.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros..:  " + listViewUsuario.Items.Count;
                sortColumn = 1;
                sortAscending = true;
                listViewUsuario.Sort();
                listViewUsuario.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                ajustaLarguraCabecalho(listViewUsuario);
                tabControlUsuarios.SelectedTab = tabDadosUsuario;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar registros: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListViewUsuarios_Click(object sender, EventArgs e)
        {
            escPressed = false;
            if (listViewUsuario.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewUsuario.SelectedItems[0];
                txtIDUsuario.Text = item.SubItems[0].Text;
                txtNome.Text = item.SubItems[1].Text;
                txtLogin.Text = item.SubItems[2].Text;
                txtEndereco.Text = item.SubItems[3].Text;
                txtNumero.Text = item.SubItems[4].Text;
                txtBairro.Text = item.SubItems[5].Text;
                txtMunicipio.Text = item.SubItems[6].Text;
                txtUF.Text = item.SubItems[7].Text;
                txtCep.Text = item.SubItems[8].Text;
                txtFone_1.Text = item.SubItems[9].Text;
                txtFone_2.Text = item.SubItems[10].Text;
                txtEmail.Text = item.SubItems[11].Text;
                txtDataCadastro.Text = item.SubItems[12].Text;
                // Exibir a imagem no PictureBox
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                UsuarioInfo usuario = usuarioBLL.GetUsuario(Convert.ToInt32(item.SubItems[0].Text));
                if (usuario.Imagem != null && usuario.Imagem.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(usuario.Imagem))
                    {
                        imgImagemUsuario.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    imgImagemUsuario.Image = null;
                }
                EventosUtils.AcaoBotoes("HabilitarBotoesAlterarExcluir", this);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            txtIDUsuario.Enabled = false;
            txtIDUsuario.Text = "0";
            bNovo = true;
            HabilitarCamposDoFormulario("Novo");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            UsuarioBLL usuarioBLL = new UsuarioBLL();

            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool isAtualizacao = false;

            if (!string.IsNullOrEmpty(txtIDUsuario.Text))
            {
                int idUsuario = Convert.ToInt32(txtIDUsuario.Text);
                isAtualizacao = usuarioBLL.GetUsuario(idUsuario) != null;
            }

            if (!isAtualizacao)
            {

                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Esse Usuario?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UsuarioInfo usuario = new UsuarioInfo
                    {
                        Nome = txtNome.Text,
                        Login = txtLogin.Text,
                        Senha = BCrypt.Net.BCrypt.HashPassword(txtSenha.Text),
                        Endereco = txtEndereco.Text,
                        Numero = txtNumero.Text,
                        Bairro = txtBairro.Text,
                        Municipio = txtMunicipio.Text,
                        UF = txtUF.Text,
                        Cep = StringUtils.SemFormatacao(txtCep.Text),
                        Fone_1 = StringUtils.SemFormatacao(txtFone_1.Text),
                        Fone_2 = StringUtils.SemFormatacao(txtFone_2.Text),
                        Email = txtEmail.Text,
                        DataCadastro = DateTime.Now,
                        Imagem = ImageToByteArray(imgImagemUsuario.Image)

                    };
                    InserirUsuario(usuario);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Ralizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    UsuarioInfo usuario = new UsuarioInfo
                    {
                        IDUsuario = int.Parse(txtIDUsuario.Text),
                        Nome = txtNome.Text,
                        Login = txtLogin.Text,
                        Endereco = txtEndereco.Text,
                        Numero = txtNumero.Text,
                        Bairro = txtBairro.Text,
                        Municipio = txtMunicipio.Text,
                        UF = txtUF.Text,
                        Cep = StringUtils.SemFormatacao(txtCep.Text),
                        Fone_1 = StringUtils.SemFormatacao(txtFone_1.Text),
                        Fone_2 = StringUtils.SemFormatacao(txtFone_2.Text),
                        Email = txtEmail.Text,
                        Imagem = ImageToByteArray(imgImagemUsuario.Image)
                    };
                    AtualizarUsuario(usuario);
                }
            }

            CarregarRegistros();
            LimparCampos();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            HabilitarCamposDoFormulario("Alterar");
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDUsuario.Text, out int usuarioID))
                {
                    ExcluirUsuario(usuarioID);
                }
                else
                {
                    MessageBox.Show("ID inválido. Por favor, insira um número inteiro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CarregarRegistros();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
            LimparCampos();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            if (usuarioBLL.IsUsuariosEmpty())
            {
                MessageBox.Show("É Obrigatório Cadastrar um Usuário!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CarregarRegistros();
            LimparCampos();
        }
        private void DesabilitarCamposDoFormulario()
        {
            List<Control> controlesDesabilitar = new List<Control>
            {
                txtNome,
                txtLogin,
                txtSenha,
                txtConfirmaSenha,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtFone_1,
                txtFone_2,
                txtEmail,
                btnPesquisaCep,
                btnInserirImagem,
                btnExcluirImagem
            };

            EventosUtils.DesabilitarControles(controlesDesabilitar, this);
            listViewUsuario.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCamposDoFormulario(string buttonPressed)
        {
            listViewUsuario.Enabled = false;
            txtPesquisaListView.Enabled = false;
            List<Control> controlesHabilitar = new List<Control>
            {
                txtNome,
                txtLogin,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtFone_1,
                txtFone_2,
                txtEmail,
                btnInserirImagem,
                btnExcluirImagem
            };

            EventosUtils.HabilitarControles(controlesHabilitar, this);
            switch (buttonPressed)
            {
                case "Novo":
                    List<Control> controlesHabilitarNovo = new List<Control>
                     {
                        txtSenha,
                        txtConfirmaSenha
                     };
                    EventosUtils.HabilitarControles(controlesHabilitarNovo, this);
                    txtDataCadastro.Text = DateTime.Now.ToString();
                    txtNome.Focus(); // Focar no rdbCpf para 
                    break;
                case "Alterar":
                    txtNome.Focus();
                    break;
            }
        }
        public override void LimparCampos()
        {
            txtIDUsuario.Clear();
            txtNome.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtConfirmaSenha.Clear();
            txtEndereco.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtMunicipio.Clear();
            txtUF.Clear();
            txtCep.Clear();
            txtFone_1.Clear();
            txtFone_2.Clear();
            txtEmail.Clear();
            txtDataCadastro.Clear();
            imgImagemUsuario.Image = null;
            txtPesquisaListView.Clear();
            bNovo = false;
        }
        static void InserirUsuario(UsuarioInfo Usuario)
        {
            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                usuarioBLL.InserirUsuario(Usuario);
                MessageBox.Show("Usuário inserido com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarUsuario(UsuarioInfo Usuario)
        {
            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                usuarioBLL.AtualizarUsuario(Usuario);
                MessageBox.Show("Usuário atualizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirUsuario(int idUsuario)
        {
            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                usuarioBLL.ExcluirUsuario(idUsuario);
                MessageBox.Show("Usuário excluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void btnPesquisaCep_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCep.Text))
            {
                string cep = StringUtils.SemFormatacao(txtCep.Text); 
                var resultado = await StringUtils.BuscarCEP(cep);

                if (!string.IsNullOrEmpty(resultado))
                {
                    dynamic dados = JObject.Parse(resultado);
                    txtEndereco.Text = dados.logradouro ?? "";
                    if (string.IsNullOrEmpty(txtNumero.Text))
                    {
                        txtNumero.Clear();
                    }
                    txtBairro.Text = dados.bairro ?? "";
                    txtMunicipio.Text = dados.localidade ?? "";
                    txtUF.Text = dados.uf ?? "";
                }
                else
                {
                    MessageBox.Show("CEP não encontrado ou erro ao buscar o CEP.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            txtEndereco.Focus();
        }
        private void btnInserirImagem_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                // Remover a barra de título
                form.Size = new Size(380, 186);
                form.FormBorderStyle = FormBorderStyle.None;

                // Evento de pintura para aplicar o gradiente no formulário
                form.Paint += new PaintEventHandler(BaseForm_Paint);

                // Centralizar e alinhar componentes
                int formWidth = form.ClientSize.Width;
                int formHeight = form.ClientSize.Height;

                // Definindo a Label
                var labelTitle = new Label
                {
                    Text = "Escolha uma opção",
                    Font = new Font("Times New Roman", 16, FontStyle.Bold),
                    Size = new Size(230, 26),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent, // Definindo fundo transparente
                    Location = new Point((formWidth - 230) / 2, 26)
                };
                form.Controls.Add(labelTitle);

                // Definindo os Botões
                var btnLocal = new Button
                {
                    Text = "Local",
                    Font = new Font("Times New Roman", 12, FontStyle.Bold),
                    Size = new Size(98, 40),
                    BackColor = buttonBackgroundColor,
                    ForeColor = buttonFontColor
                };
                var btnWebcam = new Button
                {
                    Text = "WebCam",
                    Font = new Font("Times New Roman", 12, FontStyle.Bold),
                    Size = new Size(98, 40),
                    BackColor = buttonBackgroundColor,
                    ForeColor = buttonFontColor
                };
                var btnFechar = new Button
                {
                    Text = "Fechar",
                    Font = new Font("Times New Roman", 12, FontStyle.Bold),
                    Size = new Size(98, 40),
                    BackColor = buttonBackgroundColor,
                    ForeColor = buttonFontColor
                };

                // Adicionando eventos de mouse aos botões
                btnLocal.MouseEnter += Button_MouseEnterImg;
                btnLocal.MouseLeave += Button_MouseLeaveImg;
                btnWebcam.MouseEnter += Button_MouseEnterImg;
                btnWebcam.MouseLeave += Button_MouseLeaveImg;
                btnFechar.MouseEnter += Button_MouseEnterImg;
                btnFechar.MouseLeave += Button_MouseLeaveImg;

                // Calculando a posição inicial para centralizar os botões
                int totalButtonWidth = 3 * 98 + 20; // 3 botões de 98px cada e 10px de espaço entre eles
                int startX = (formWidth - totalButtonWidth) / 2;
                int buttonY = (formHeight / 2) + 20;

                // Posicionando os botões
                btnLocal.Location = new Point(startX, buttonY);
                btnWebcam.Location = new Point(startX + 98 + 10, buttonY); // 10px de espaço entre os botões
                btnFechar.Location = new Point(startX + 2 * 98 + 20, buttonY); // 20px de espaço entre os botões

                // Adicionando eventos aos botões
                btnLocal.Click += BtnLocal_Click;
                btnWebcam.Click += BtnWebcam_Click;
                btnFechar.Click += (s, ee) => form.Close();

                // Adicionando botões ao formulário
                form.Controls.Add(btnLocal);
                form.Controls.Add(btnWebcam);
                form.Controls.Add(btnFechar);

                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }
        private void Button_MouseEnterImg(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = buttonFontColor; // Cor de fundo ao passar o mouse
                button.ForeColor = buttonBackgroundColor; // Cor da fonte ao passar o mouse
            }
        }
        private void Button_MouseLeaveImg(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = buttonBackgroundColor; // Cor de fundo original
                button.ForeColor = buttonFontColor; // Cor da fonte original
            }
        }
        private void BtnLocal_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obter o caminho do arquivo selecionado
                    string filePath = openFileDialog.FileName;
                    // Exibir a imagem no PictureBox
                    imgImagemUsuario.Image = Image.FromFile(filePath);
                    imgImagemUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
        private void BtnWebcam_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Webcam";
                form.Size = new Size(640, 480);

                var pictureBoxWebcam = new PictureBox
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(pictureBoxWebcam);

                try
                {
                    if (videoDevices == null || videoDevices.Count == 0)
                    {
                        videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    }

                    if (videoDevices.Count == 0)
                    {
                        MessageBox.Show("Nenhum dispositivo de vídeo encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    videoSource = new VideoCaptureDevice(videoDevices[1].MonikerString);
                    videoSource.NewFrame += (s, eFrame) =>
                    {
                        pictureBoxWebcam.Image = (Bitmap)eFrame.Frame.Clone();
                    };
                    videoSource.Start();

                    var btnCapture = new Button
                    {
                        Text = "Capturar",
                        Dock = DockStyle.Bottom
                    };
                    btnCapture.Click += (s, eCapture) =>
                    {
                        using (var ms = new MemoryStream())
                        {
                            pictureBoxWebcam.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] imageBytes = ms.ToArray();

                            using (var pngImage = new MemoryStream(imageBytes))
                                imgImagemUsuario.Image = Image.FromStream(pngImage);
                        }

                        imgImagemUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
                        videoSource.SignalToStop();
                        form.Close();
                    };
                    form.Controls.Add(btnCapture);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao acessar dispositivos de vídeo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                form.StartPosition = FormStartPosition.CenterParent;
                form.FormClosing += (s, eClosing) =>
                {
                    if (videoSource != null && videoSource.IsRunning)
                    {
                        videoSource.SignalToStop();
                    }
                };
                form.ShowDialog(this);
            }
        }
        private void btnExcluirImagem_Click(object sender, EventArgs e)
        {
            // Limpar a imagem do PictureBox
            imgImagemUsuario.Image = null;
        }
    }
}

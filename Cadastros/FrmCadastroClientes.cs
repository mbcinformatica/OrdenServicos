using Newtonsoft.Json.Linq;
using ProjetoTeste.BLL;
using ProjetoTeste.Forms;
using ProjetoTeste.Model;
using ProjetoTeste.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static ProjetoTeste.DAL.PesquisaWebDAL;
using static ProjetoTeste.Model.PesquisaWebInfo;

namespace ProjetoTeste
{
    public partial class frmClientes : BaseForm
    {
        private int sortColumn = -1;
        private bool sortAscending = true;
        private Color defaultHeaderBackColor = Color.DarkTurquoise;
        private Color clickedHeaderBackColor = Color.CadetBlue;
        private int previousSortColumn = -1;
        private (Control, string)[] camposObrigatorios;
        private List<ListViewItem> listaOriginalItens = new List<ListViewItem>();
        private bool escPressed = false;

        public frmClientes()
        {

            InitializeComponent();

            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlClientes); // Chama o método para inicializar o TabControl
            erpProvider = new ErrorProvider();
            // Configurar eventos dos TextBoxes para maiúsculas
            ConfigurarTextBox();
            // Configurando os Key para os TextBox
            CarregaKey();
            CarregarRegistros();

        }
        private void InitializeListView()
        {
            // Configurar a ListView
            listViewClientes.View = View.Details;
            listViewClientes.FullRowSelect = true;
            listViewClientes.OwnerDraw = true; // Permitir desenho personalizado
            listViewClientes.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewClientes_DrawColumnHeader);
            listViewClientes.DrawItem += new DrawListViewItemEventHandler(listViewClientes_DrawItem);
            listViewClientes.DrawSubItem += new DrawListViewSubItemEventHandler(listViewClientes_DrawSubItem);

            // Adicionar colunas
            listViewClientes.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("PESSOA", 80, HorizontalAlignment.Center);
            listViewClientes.Columns.Add("CPF/CNPJ", 120, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("  NOME/RAZÃO SOCIAL", 300, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("  ENDEREÇO", 200, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("NUMERO", 70, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("  BAIRRO", 150, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("  MUNICIPIO", 200, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("UF", 30, HorizontalAlignment.Center);
            listViewClientes.Columns.Add("CEP", 70, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("  CONTATO", 150, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("CELULAR", 100, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("FIXO", 100, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("  EMAIL", 300, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("DATA CADASTRO",-1, HorizontalAlignment.Right);

            listViewClientes.ColumnClick += new ColumnClickEventHandler(ListViewClientes_ColumnClick);

        }
        private void ListViewClientes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Permitir apenas cliques nas colunas "CPF/CNPJ" (index 2) e "NOME/RAZÃO SOCIAL" (index 3)
            if (e.Column != 2 && e.Column != 3)
            {
                return; // Ignorar cliques em outras colunas
            }

            // Atualizar a coluna anteriormente ordenada antes de mudar a coluna atual
            int oldSortColumn = sortColumn;
            if (e.Column == sortColumn)
            {
                // Alternar ordem se a mesma coluna for clicada
                sortAscending = !sortAscending;
            }
            else
            {
                // Nova coluna clicada
                sortColumn = e.Column;
                sortAscending = true;
            }

            // Forçar redesenho da coluna anterior
            if (oldSortColumn != -1)
            {
                listViewClientes.Columns[oldSortColumn].Width = listViewClientes.Columns[oldSortColumn].Width;
            }

            listViewClientes.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewClientes.Sort();

            // Forçar redesenho da nova coluna
            listViewClientes.Columns[sortColumn].Width = listViewClientes.Columns[sortColumn].Width;
            listViewClientes.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
            PesquisarListView(txtPesquisaListView.Text, listViewClientes, sortColumn);
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
        private void listViewClientes_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            string[] centerColumnList = new string[] { "ID", "PESSOA", "CPF/CNPJ", "UF", "CEP", "NUMERO", "CELULAR", "FIXO", "DATA CADASTRO" };
            Color headerBackColor = e.ColumnIndex == sortColumn ? clickedHeaderBackColor : defaultHeaderBackColor;

            using (SolidBrush backBrush = new SolidBrush(headerBackColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.NoWrap; // Adiciona esta linha para evitar quebra de linha

                if (centerColumnList.Contains(e.Header.Text))
                {
                    sf.Alignment = StringAlignment.Center; // Alinhar cabeçalhos numéricos no centro
                }
                else
                {
                    sf.Alignment = StringAlignment.Near; // Alinhar cabeçalhos de texto à esquerda
                }

                // Definir a fonte em negrito
                using (Font headerFont = new Font(e.Font, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds, sf);
                }

                using (Pen gridLinePen = new Pen(Color.Black, 2)) // Define a cor e a espessura das linhas do cabeçalho
                {
                    e.Graphics.DrawRectangle(gridLinePen, e.Bounds);
                }
            }
        }
        private void listViewClientes_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewClientes_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewClientes.Columns[e.ColumnIndex].Text == "ID" || listViewClientes.Columns[e.ColumnIndex].Text == "PESSOA" ||
                    listViewClientes.Columns[e.ColumnIndex].Text == "CPF/CNPJ" || listViewClientes.Columns[e.ColumnIndex].Text == "UF" ||
                    listViewClientes.Columns[e.ColumnIndex].Text == "CEP" || listViewClientes.Columns[e.ColumnIndex].Text == "NUMERO" ||
                    listViewClientes.Columns[e.ColumnIndex].Text == "CELULAR" || listViewClientes.Columns[e.ColumnIndex].Text == "FIXO" ||
                    listViewClientes.Columns[e.ColumnIndex].Text == "DATA CADASTRO")
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
            txtCpfCnpj.KeyDown += Evento_KeyDown;
            txtNomeRazaoSocial.KeyDown += Evento_KeyDown;
            txtEndereco.KeyDown += Evento_KeyDown;
            txtNumero.KeyDown += Evento_KeyDown;
            txtBairro.KeyDown += Evento_KeyDown;
            txtMunicipio.KeyDown += Evento_KeyDown;
            txtUF.KeyDown += Evento_KeyDown;
            txtCep.KeyDown += Evento_KeyDown;
            txtContato.KeyDown += Evento_KeyDown;
            txtFone_1.KeyDown += Evento_KeyDown;
            txtFone_2.KeyDown += Evento_KeyDown;
            txtEmail.KeyDown += Evento_KeyDown;
            rdbCpf.KeyDown += Evento_KeyDown;
            rdbCnpj.KeyDown += Evento_KeyDown;
            txtPesquisaListView.KeyDown += Evento_KeyDown;
            listViewClientes.KeyDown += Evento_KeyDown;

            txtCpfCnpj.KeyPress += Evento_KeyPress;
            txtCep.KeyPress += Evento_KeyPress;
            txtFone_1.KeyPress += Evento_KeyPress;
            txtFone_2.KeyPress += Evento_KeyPress;

            txtCpfCnpj.Leave += Evento_Leave;
            txtCep.Leave += Evento_Leave;
            txtFone_1.Leave += Evento_Leave;
            txtFone_2.Leave += Evento_Leave;
            txtEmail.Leave += Evento_Leave;

            // Adiciona eventos de mouse aos botões
            btnSalvar.MouseEnter += Button_MouseEnter;
            btnSalvar.MouseLeave += Button_MouseLeave;
            btnAlterar.MouseEnter += Button_MouseEnter;
            btnAlterar.MouseLeave += Button_MouseLeave;
            btnExcluir.MouseEnter += Button_MouseEnter;
            btnExcluir.MouseLeave += Button_MouseLeave;
            btnFechar.MouseEnter += Button_MouseEnter;
            btnFechar.MouseLeave += Button_MouseLeave;
            btnNovo.MouseEnter += Button_MouseEnter;
            btnNovo.MouseLeave += Button_MouseLeave;
            btnPesquisaCep.MouseEnter += Button_MouseEnter;
            btnPesquisaCep.MouseLeave += Button_MouseLeave;
            btnPesquisarCnpj.MouseEnter += Button_MouseEnter;
            btnPesquisarCnpj.MouseLeave += Button_MouseLeave;

            listViewClientes.Click += ListViewClientes_Click;
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
        private void Evento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas dígitos e controle (como backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Evento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Impede o som de "beep"

                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                escPressed = true;
                this.AutoValidate = AutoValidate.Disable;
                CarregarRegistros();
                LimparCampos();
                this.AutoValidate = AutoValidate.EnablePreventFocusChange;
            }
        }
        private void Evento_Leave(object sender, EventArgs e)
        {
            if (escPressed)
            {
                return; // Sai do método sem fazer verificações
            }
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (sender == txtEmail)
                {
                    tabControlClientes.SelectedTab = tabInformacoesAdicionais;
                }
                else if (sender == txtFone_1)
                {
                    txtFone_1.Text = StringUtils.FormatPhoneNumber(txtFone_1.Text);
                }
                else if (sender == txtFone_2)
                {
                    txtFone_2.Text = StringUtils.FormatPhoneNumber(txtFone_2.Text);
                }
                else if (sender == txtCep)
                {
                    txtCep.Text = StringUtils.SemFormatacao(txtCep.Text);
                    txtCep.Text = StringUtils.FormatCEP(txtCep.Text);
                }
                else if (sender == txtCpfCnpj)
                {


                    if (rdbCpf.Checked)
                    {
                        txtCpfCnpj.Text = StringUtils.FormatCPF(txtCpfCnpj.Text);
                    }
                    else if (rdbCnpj.Checked)
                    {
                        txtCpfCnpj.Text = StringUtils.FormatCNPJ(txtCpfCnpj.Text);
                    }
                }
            }
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
            (txtNomeRazaoSocial, "Nome"),
            (txtCep, "Cep"),
            (txtFone_1, "Celular"),
            };

            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
        }
        private void CarregarRegistros()
        {
            DesabilitarCampos();
            DesabilitarBotoesAcoes();
            listViewClientes.Items.Clear();
            listViewClientes.Columns.Clear();
            InitializeListView(); // Adicionar colunas novamente, caso necessário

            try
            {
                ClienteBLL clienteBLL = new ClienteBLL();
                List<ClienteInfo> clientes = clienteBLL.Listar();
                foreach (ClienteInfo cliente in clientes)
                {
                    ListViewItem item = new ListViewItem(cliente.IDCliente.ToString());
                    item.SubItems.Add(cliente.TipoPessoa);
                    if (cliente.TipoPessoa == "FÍSICA")
                    {
                        item.SubItems.Add(StringUtils.FormatCPF(cliente.Cpf_Cnpj));
                    }
                    else if (cliente.TipoPessoa == "JURÍDICA")
                    {
                        item.SubItems.Add(StringUtils.FormatCNPJ(cliente.Cpf_Cnpj));
                    }
                    item.SubItems.Add(cliente.Nome_RazaoSocial);
                    item.SubItems.Add(cliente.Endereco);
                    item.SubItems.Add(cliente.Numero);
                    item.SubItems.Add(cliente.Bairro);
                    item.SubItems.Add(cliente.Municipio);
                    item.SubItems.Add(cliente.UF);
                    item.SubItems.Add(StringUtils.FormatCEP(cliente.Cep));
                    item.SubItems.Add(cliente.Contato);
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(cliente.Fone_1));
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(cliente.Fone_2));
                    item.SubItems.Add(cliente.Email);
                    item.SubItems.Add(cliente.DataCadastro.ToString("dd/MM/yyyy"));
                    listViewClientes.Items.Add(item);
                }


                // Manter uma cópia dos itens originais
                listaOriginalItens = listViewClientes.Items.Cast<ListViewItem>().ToList();

                // Atualizar o Label com o total de registros
                lbTotalRegistros.Text = "Total de Registros..:  " + listViewClientes.Items.Count;

                // Ordenar pela coluna "NOME/RAZÃO SOCIAL" (index 3) em ordem crescente
                sortColumn = 3;
                sortAscending = true;
                listViewClientes.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                listViewClientes.Sort();
                ajustaLarguraCabecalho();
                tabControlClientes.SelectedTab = tabDadosClientes;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar registros: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListViewClientes_Click(object sender, EventArgs e)
        {
            escPressed = false;
            if (listViewClientes.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewClientes.SelectedItems[0];
                txtIDCliente.Text = item.SubItems[0].Text;
                // Carregar os RadioButton com base no valor do campo TipoPessoa
                rdbCpf.Checked = item.SubItems[1].Text == "FÍSICA";
                rdbCnpj.Checked = item.SubItems[1].Text == "JURÍDICA";
                txtCpfCnpj.Text = item.SubItems[2].Text;
                txtNomeRazaoSocial.Text = item.SubItems[3].Text;
                txtEndereco.Text = item.SubItems[4].Text;
                txtNumero.Text = item.SubItems[5].Text;
                txtBairro.Text = item.SubItems[6].Text;
                txtMunicipio.Text = item.SubItems[7].Text;
                txtUF.Text = item.SubItems[8].Text;
                txtCep.Text = item.SubItems[9].Text;
                txtContato.Text = item.SubItems[10].Text;
                txtFone_1.Text = item.SubItems[11].Text;
                txtFone_2.Text = item.SubItems[12].Text;
                txtEmail.Text = item.SubItems[13].Text;
                txtDataCadastro.Text = item.SubItems[14].Text;
                HabilitarBotoesAlterarExcluir();
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            HabilitarBotaoSalvar();
            txtIDCliente.Enabled = false;
            txtIDCliente.Text = "0";
            HabilitarCampos("Novo");

        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            ClienteBLL clienteBLL = new ClienteBLL();

            // Verificar se algum campo obrigatório está vazio
            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            bool isAtualizacao = false;

            if (!string.IsNullOrEmpty(txtIDCliente.Text))
            {
                int idCliente = Convert.ToInt32(txtIDCliente.Text);
                isAtualizacao = clienteBLL.GetCliente(idCliente) != null;
            }

            if (!isAtualizacao)
            {
                string cpfcnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text);
                DBSetupBLL dbSetupBLL = new DBSetupBLL();
                // Verifica se o CPF/CNPJ já está cadastrado
                if (dbSetupBLL.VerificarSeCadastrado(cpfcnpj, "DBClientes", "Cpf_Cnpj"))
                {
                    MessageBox.Show("Cliente já cadastrado. Favor verificar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCpfCnpj.Clear();
                    txtCpfCnpj.Focus();
                    return;
                }
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Esse Cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    ClienteInfo cliente = new ClienteInfo
                    {

                        TipoPessoa = rdbCpf.Checked ? "FÍSICA" : "JURÍDICA", // Define o valor do RadioButton
                        Cpf_Cnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text),
                        Nome_RazaoSocial = txtNomeRazaoSocial.Text,
                        Endereco = txtEndereco.Text,
                        Numero = txtNumero.Text,
                        Bairro = txtBairro.Text,
                        Municipio = txtMunicipio.Text,
                        UF = txtUF.Text,
                        Cep = StringUtils.SemFormatacao(txtCep.Text),
                        Contato = txtContato.Text,
                        Fone_1 = StringUtils.SemFormatacao(txtFone_1.Text),
                        Fone_2 = StringUtils.SemFormatacao(txtFone_2.Text),
                        Email = txtEmail.Text,
                        DataCadastro = DateTime.Now

                    };
                    InserirCliente(cliente);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Ralizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ClienteInfo cliente = new ClienteInfo
                    {
                        IDCliente = int.Parse(txtIDCliente.Text),
                        TipoPessoa = rdbCpf.Checked ? "FÍSICA" : "JURÍDICA", // Define o valor do RadioButton
                        Cpf_Cnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text),
                        Nome_RazaoSocial = txtNomeRazaoSocial.Text,
                        Endereco = txtEndereco.Text,
                        Numero = txtNumero.Text,
                        Bairro = txtBairro.Text,
                        Municipio = txtMunicipio.Text,
                        UF = txtUF.Text,
                        Cep = StringUtils.SemFormatacao(txtCep.Text),
                        Contato = txtContato.Text,
                        Fone_1 = StringUtils.SemFormatacao(txtFone_1.Text),
                        Fone_2 = StringUtils.SemFormatacao(txtFone_2.Text),
                        Email = txtEmail.Text,
                    };
                    AtualizarCliente(cliente);
                }
            }

            CarregarRegistros();
            LimparCampos();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            HabilitarBotaoSalvar();
            HabilitarCampos("Alterar");

        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDCliente.Text, out int clienteID))
                {
                    ExcluirCliente(clienteID);
                }
                else
                {
                    MessageBox.Show("ID inválido. Por favor, insira um número inteiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CarregarRegistros();
            DesabilitarBotoesAcoes();
            LimparCampos();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DesabilitarCampos()
        {
            txtCpfCnpj.Enabled = false;
            txtNomeRazaoSocial.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtMunicipio.Enabled = false;
            txtUF.Enabled = false;
            txtCep.Enabled = false;
            txtContato.Enabled = false;
            txtFone_1.Enabled = false;
            txtFone_2.Enabled = false;
            txtEmail.Enabled = false;
            rdbCpf.Enabled = false;
            rdbCnpj.Enabled = false;
            btnPesquisarCnpj.Enabled = false;
            btnPesquisaCep.Enabled = false;
            listViewClientes.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCampos(string buttonPressed)
        {

            txtNomeRazaoSocial.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtMunicipio.Enabled = true;
            txtUF.Enabled = true;
            txtCep.Enabled = true;
            txtContato.Enabled = true;
            txtFone_1.Enabled = true;
            txtFone_2.Enabled = true;
            txtEmail.Enabled = true;
            btnPesquisaCep.Enabled = true;
            listViewClientes.Enabled = false;
            txtPesquisaListView.Enabled = false;
            btnPesquisarCnpj.Enabled = false;
            switch (buttonPressed)
            {
                case "Novo":
                    rdbCpf.Enabled = true;
                    rdbCnpj.Enabled = true;
                    rdbCpf.Checked = false;
                    rdbCnpj.Checked = false;
                    txtCpfCnpj.Enabled = true;
                    txtDataCadastro.Text = DateTime.Now.ToString();
                    btnPesquisarCnpj.Enabled = true;
                    rdbCpf.Focus(); // Focar no rdbCpf para "Novo"
                    break;
                case "Salvar":
                    // Adicionar ações específicas para "Salvar" se necessário
                    break;
                case "Alterar":
                    // Adicionar ações específicas para "Alterar" se necessário
                    rdbCpf.Enabled = false;
                    rdbCnpj.Enabled = false;
                    txtCpfCnpj.Enabled = false;
                    txtNomeRazaoSocial.Focus(); // Focar no rdbCpf para "Novo"
                    break;
                case "Excluir":
                    // Adicionar ações específicas para "Excluir" se necessário
                    break;
                default:
                    break;
            }

        }
        private void DesabilitarBotoesAcoes()
        {
            btnSalvar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnFechar.Enabled = true;
            btnNovo.Enabled = true;
            btnNovo.Focus();
        }
        private void HabilitarBotaoSalvar()
        {
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnFechar.Enabled = false;
            btnNovo.Enabled = false;
        }
        private void HabilitarBotoesAlterarExcluir()
        {
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            btnFechar.Enabled = true;
            btnNovo.Enabled = true;

        }
        private void LimparCampos()
        {
            txtIDCliente.Clear();
            txtCpfCnpj.Clear();
            txtNomeRazaoSocial.Clear();
            txtEndereco.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtMunicipio.Clear();
            txtUF.Clear();
            txtCep.Clear();
            txtContato.Clear();
            txtFone_1.Clear();
            txtFone_2.Clear();
            txtEmail.Clear();
            txtDataCadastro.Clear();
            txtPesquisaListView.Clear();
            rdbCpf.Checked = true;
            rdbCnpj.Checked = false;
        }
        static void InserirCliente(ClienteInfo Cliente)
        {
            try
            {
                ClienteBLL clienteBLL = new ClienteBLL();
                clienteBLL.InserirCliente(Cliente);
                MessageBox.Show("Cliente inserido com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarCliente(ClienteInfo Cliente)
        {
            try
            {
                ClienteBLL clienteBLL = new ClienteBLL();
                clienteBLL.AtualizarCliente(Cliente);
                MessageBox.Show("Cliente atualizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirCliente(int idCliente)
        {
            try
            {
                ClienteBLL clienteBLL = new ClienteBLL();
                clienteBLL.ExcluirCliente(idCliente);
                MessageBox.Show("Cliente excluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void btnPesquisarCnpj_Click(object sender, EventArgs e)
        {
            string cnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text);
            DBSetupBLL dbSetupBLL = new DBSetupBLL();
            string cpfCnpj = txtCpfCnpj.Text;
            // Verifica se o CPF/CNPJ já está cadastrado
            if (dbSetupBLL.VerificarSeCadastrado(cnpj, "DBClientes", "Cpf_Cnpj"))
            {
                MessageBox.Show("Cliente já cadastrado. Favor verificar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCpfCnpj.Clear();
                txtCpfCnpj.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cnpj))
            {
                MessageBox.Show("Favor, Insira um CNPJ.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidaCnpj(cnpj))
            {
                MessageBox.Show("CNPJ Informado esta Incorreto. Favor Verificar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfCnpj.Clear();
                txtCpfCnpj.Focus();
                return;
            }
            try
            {

                Cursor.Current = Cursors.WaitCursor; // Mudar o cursor para ocupado
                CnpjInfo info = await ReceitaFederalApi.PesquisarCnpjAsync(cnpj);

                if (info != null)
                {
                    txtCpfCnpj.Text = info.Cpf_Cnpj;
                    txtNomeRazaoSocial.Text = info.Nome_RazaoSocial;
                    //    txtNomeFantasia.Text = info.Nome_Fantasia;
                    txtEndereco.Text = info.Endereco;
                    txtNumero.Text = info.Numero;
                    txtBairro.Text = info.Bairro;
                    txtMunicipio.Text = info.Municipio;
                    txtUF.Text = info.UF;
                    txtCep.Text = info.Cep;
                    txtContato.Text = info.Contato;
                    txtFone_1.Text = info.Fone_1;
                    txtFone_2.Text = info.Fone_2;
                    txtEmail.Text = info.Email;
                    txtDataCadastro.Text = info.DataCadastro;
                    // txtNatJuridica.Text = info.Nat_Juridica;
                    // Atualize outros campos conforme necessário
                    txtNomeRazaoSocial.Focus();
                }
                else
                {
                    MessageBox.Show("CNPJ não encontrado ou erro na pesquisa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default; // Restaurar o cursor padrão
            }
            txtNomeRazaoSocial.Focus(); // Focar no rdbCpf para "Novo"
        }
        private async void btnPesquisaCep_Click(object sender, EventArgs e)
        {
            string cep = StringUtils.SemFormatacao(txtCep.Text);  // Supondo que o CEP é lido de um TextBox chamado txtCep
            var resultado = await StringUtils.BuscarCEP(cep);

            if (!string.IsNullOrEmpty(resultado))
            {
                dynamic dados = JObject.Parse(resultado);
                txtEndereco.Text = dados.logradouro ?? "";
                txtNumero.Text = ""; // ViaCEP não fornece número
                txtBairro.Text = dados.bairro ?? "";
                txtMunicipio.Text = dados.localidade ?? "";
                txtUF.Text = dados.uf ?? "";
            }
            else
            {
                MessageBox.Show("CEP não encontrado ou erro ao buscar o CEP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ajustaLarguraCabecalho()
        {
            for (int i = 0; i < listViewClientes.Columns.Count; i++)
            {
                listViewClientes.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                int larguraConteudo = listViewClientes.Columns[i].Width;

                listViewClientes.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
                int larguraCabecalho = listViewClientes.Columns[i].Width;

                listViewClientes.Columns[i].Width = Math.Max(larguraConteudo, larguraCabecalho);
            }

            listViewClientes.Columns[listViewClientes.Columns.Count - 1].Width = -2;
        }
    }
}

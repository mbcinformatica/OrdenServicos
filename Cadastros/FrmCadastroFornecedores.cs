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
    public partial class frmFornecedores : BaseForm
    {
        private int sortColumn = -1;
        private bool sortAscending = true;
        private Color defaultHeaderBackColor = Color.DarkTurquoise;
        private Color clickedHeaderBackColor = Color.CadetBlue;
        private int previousSortColumn = -1;
        private (Control, string)[] camposObrigatorios;
        private bool escPressed = false;
        private List<ListViewItem> listaOriginalItens = new List<ListViewItem>();
        public frmFornecedores()
        {

            InitializeComponent();

            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new System.Windows.Forms.PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlFornecedores); // Chama o método para inicializar o TabControl

            erpProvider = new System.Windows.Forms.ErrorProvider();
            CarregarRegistros();

            // Configurar eventos dos TextBoxes para maiúsculas
            ConfigurarTextBox();
            // Configurando os Key para os TextBox
            CarregaKey();
        }
        private void InitializeListView()
        {
            // Configurar a ListView
            listViewFornecedores.View = View.Details;
            listViewFornecedores.FullRowSelect = true;
            listViewFornecedores.OwnerDraw = true; // Permitir desenho personalizado
            listViewFornecedores.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewFornecedores_DrawColumnHeader);
            listViewFornecedores.DrawItem += new DrawListViewItemEventHandler(listViewFornecedores_DrawItem);
            listViewFornecedores.DrawSubItem += new DrawListViewSubItemEventHandler(listViewFornecedores_DrawSubItem);

            // Adicionar colunas
            listViewFornecedores.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("PESSOA", 80, HorizontalAlignment.Center);
            listViewFornecedores.Columns.Add("CPF/CNPJ", 120, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("  NOME/RAZÃO SOCIAL", 300, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("  ENDEREÇO", 200, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("NUMERO", 70, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("  BAIRRO", 150, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("  MUNICIPIO", 200, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("UF", 30, HorizontalAlignment.Center);
            listViewFornecedores.Columns.Add("CEP", 70, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("  CONTATO", 150, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("CELULAR", 100, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("FIXO", 100, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("  EMAIL", 300, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("DATA CADASTRO", 150, HorizontalAlignment.Right);

            listViewFornecedores.ColumnClick += new ColumnClickEventHandler(ListViewFornecedores_ColumnClick);
            listViewFornecedores.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewFornecedores.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
        private void ListViewFornecedores_ColumnClick(object sender, ColumnClickEventArgs e)
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
                listViewFornecedores.Columns[oldSortColumn].Width = listViewFornecedores.Columns[oldSortColumn].Width;
            }

            listViewFornecedores.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewFornecedores.Sort();

            // Forçar redesenho da nova coluna
            listViewFornecedores.Columns[sortColumn].Width = listViewFornecedores.Columns[sortColumn].Width;
            listViewFornecedores.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
            PesquisarListView(txtPesquisaListView.Text, listViewFornecedores, sortColumn);
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
        private void listViewFornecedores_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color headerBackColor = e.ColumnIndex == sortColumn ? clickedHeaderBackColor : defaultHeaderBackColor;

            using (SolidBrush backBrush = new SolidBrush(headerBackColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.NoWrap; // Adiciona esta linha para evitar quebra de linha

                if (e.Header.Text == "ID" || e.Header.Text == "PESSOA" || e.Header.Text == "CPF/CNPJ" ||
                    e.Header.Text == "UF" || e.Header.Text == "CEP" || e.Header.Text == "NUMERO" ||
                    e.Header.Text == "CELULAR" || e.Header.Text == "FIXO" || e.Header.Text == "DATA CADASTRO")
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
        private void listViewFornecedores_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewFornecedores_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewFornecedores.Columns[e.ColumnIndex].Text == "ID" || listViewFornecedores.Columns[e.ColumnIndex].Text == "PESSOA" ||
                    listViewFornecedores.Columns[e.ColumnIndex].Text == "CPF/CNPJ" || listViewFornecedores.Columns[e.ColumnIndex].Text == "UF" ||
                    listViewFornecedores.Columns[e.ColumnIndex].Text == "CEP" || listViewFornecedores.Columns[e.ColumnIndex].Text == "NUMERO" ||
                    listViewFornecedores.Columns[e.ColumnIndex].Text == "CELULAR" || listViewFornecedores.Columns[e.ColumnIndex].Text == "FIXO" ||
                    listViewFornecedores.Columns[e.ColumnIndex].Text == "DATA CADASTRO")
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
            listViewFornecedores.KeyDown += Evento_KeyDown;

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

            listViewFornecedores.Click += ListViewFornecedores_Click;
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

                if (sender == txtCpfCnpj)
                {
                    string cpfcnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text);
                    DBSetupBLL dbSetupBLL = new DBSetupBLL();
                    string cpfCnpj = txtCpfCnpj.Text;
                    // Verifica se o CPF/CNPJ já está cadastrado
                    if (dbSetupBLL.VerificarSeCadastrado(cpfcnpj, "DBFornecedores", "Cpf_Cnpj"))
                    {
                        MessageBox.Show("Fornecedor já cadastrado. Favor verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpfCnpj.Clear();
                        txtCpfCnpj.Focus();
                        return;
                    }
                    if (rdbCpf.Checked)
                    {
                        if (!ValidaCpf(cpfCnpj))
                        {
                            MessageBox.Show("CPF informado está incorreto. Favor verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCpfCnpj.Clear();
                            txtCpfCnpj.Focus();
                            return;
                        }
                    }
                    else if (rdbCnpj.Checked)
                    {
                        if (!ValidaCnpj(cpfCnpj))
                        {
                            MessageBox.Show("CNPJ informado está incorreto. Favor verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCpfCnpj.Clear();
                            txtCpfCnpj.Focus();
                            return;
                        }
                        else
                        {
                            // Executa a pesquisa do CNPJ após validação
                            btnPesquisarCnpj_Click(sender, e);
                        }
                    }
                }
                if (sender == txtNumero)
                {
                    if (string.IsNullOrWhiteSpace(txtNumero.Text))
                    {
                        txtNumero.Text = "S/N";
                    }
                }

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
                    tabControlFornecedores.SelectedTab = tabInformacoesAdicionais;
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
            (txtEndereco, "Endereço"),
            (txtBairro, "Bairro"),
            (txtMunicipio, "Município"),
            (txtUF, "UF"),
            (txtContato, "Contato"),
            (txtFone_1, "Telefone 1"),
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
            listViewFornecedores.Items.Clear();
            listViewFornecedores.Columns.Clear();
            InitializeListView(); // Adicionar colunas novamente, caso necessário

            try
            {
                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                List<FornecedorInfo> fornecedores = fornecedorBLL.Listar();
                foreach (FornecedorInfo fornecedor in fornecedores)
                {
                    ListViewItem item = new ListViewItem(fornecedor.IDFornecedor.ToString());
                    item.SubItems.Add(fornecedor.TipoPessoa);
                    if (fornecedor.TipoPessoa == "FÍSICA")
                    {
                        item.SubItems.Add(StringUtils.FormatCPF(fornecedor.Cpf_Cnpj));
                    }
                    else if (fornecedor.TipoPessoa == "JURÍDICA")
                    {
                        item.SubItems.Add(StringUtils.FormatCNPJ(fornecedor.Cpf_Cnpj));
                    }
                    item.SubItems.Add(fornecedor.Nome_RazaoSocial);
                    item.SubItems.Add(fornecedor.Endereco);
                    item.SubItems.Add(fornecedor.Numero);
                    item.SubItems.Add(fornecedor.Bairro);
                    item.SubItems.Add(fornecedor.Municipio);
                    item.SubItems.Add(fornecedor.UF);
                    item.SubItems.Add(StringUtils.FormatCEP(fornecedor.Cep));
                    item.SubItems.Add(fornecedor.Contato);
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(fornecedor.Fone_1));
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(fornecedor.Fone_2));
                    item.SubItems.Add(fornecedor.Email);
                    item.SubItems.Add(fornecedor.DataCadastro.ToString("dd/MM/yyyy"));
                    listViewFornecedores.Items.Add(item);
                }

                // Ajustar automaticamente o tamanho das colunas ao conteúdo, mas não menor que o cabeçalho
                foreach (ColumnHeader column in listViewFornecedores.Columns)
                {
                    column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize); // Ajusta a largura ao cabeçalho primeiro
                    int headerWidth = TextRenderer.MeasureText(column.Text, listViewFornecedores.Font).Width + 20; // Adiciona uma margem

                    column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); // Ajusta a largura ao conteúdo
                    if (column.Width < headerWidth)
                    {
                        column.Width = headerWidth; // Garantir que a largura não fique menor que o cabeçalho
                    }
                }

                // Manter uma cópia dos itens originais
                listaOriginalItens = listViewFornecedores.Items.Cast<ListViewItem>().ToList();

                // Atualizar o Label com o total de registros
                lbTotalRegistros.Text = "Total de Registros..:  " + listViewFornecedores.Items.Count;

                // Ordenar pela coluna "NOME/RAZÃO SOCIAL" (index 3) em ordem crescente
                sortColumn = 3;
                sortAscending = true;
                listViewFornecedores.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                listViewFornecedores.Sort();
                listViewFornecedores.Columns[sortColumn].Width = listViewFornecedores.Columns[sortColumn].Width;
                tabControlFornecedores.SelectedTab = tabDadosFornecedor;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar registros: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListViewFornecedores_Click(object sender, EventArgs e)
        {
            escPressed = false;
            if (listViewFornecedores.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewFornecedores.SelectedItems[0];
                txtIDFornecedor.Text = item.SubItems[0].Text;
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
            txtIDFornecedor.Enabled = false;
            txtIDFornecedor.Text = "0";
            HabilitarCampos("Novo");

        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            FornecedorBLL fornecedorBLL = new FornecedorBLL();

            // Verificar se algum campo obrigatório está vazio
            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isAtualizacao = false;

            if (!string.IsNullOrEmpty(txtIDFornecedor.Text))
            {
                int idFornecedor = Convert.ToInt32(txtIDFornecedor.Text);
                isAtualizacao = fornecedorBLL.GetFornecedor(idFornecedor) != null;
            }

            if (!isAtualizacao)
            {
                string cpfcnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text);
                DBSetupBLL dbSetupBLL = new DBSetupBLL();
                // Verifica se o CPF/CNPJ já está cadastrado
                if (dbSetupBLL.VerificarSeCadastrado(cpfcnpj, "DBFornecedores", "Cpf_Cnpj"))
                {
                    MessageBox.Show("Fornecedor já cadastrado. Favor verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCpfCnpj.Clear();
                    txtCpfCnpj.Focus();
                    return;
                }
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Esse Fornecedor?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    FornecedorInfo fornecedor = new FornecedorInfo
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
                    InserirFornecedor(fornecedor);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Ralizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    FornecedorInfo fornecedor = new FornecedorInfo
                    {
                        IDFornecedor = int.Parse(txtIDFornecedor.Text),
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
                    AtualizarFornecedor(fornecedor);
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
                if (int.TryParse(txtIDFornecedor.Text, out int fornecedorID))
                {
                    ExcluirFornecedor(fornecedorID);
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CarregarRegistros();
            LimparCampos();
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
            listViewFornecedores.Enabled = true;
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
            listViewFornecedores.Enabled = false;
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
            txtIDFornecedor.Clear();
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
        static void InserirFornecedor(FornecedorInfo Fornecedor)
        {
            try
            {
                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                fornecedorBLL.InserirFornecedor(Fornecedor);
                MessageBox.Show("Fornecedor inserido com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarFornecedor(FornecedorInfo Fornecedor)
        {
            try
            {
                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                fornecedorBLL.AtualizarFornecedor(Fornecedor);
                MessageBox.Show("Fornecedor atualizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirFornecedor(int idFornecedor)
        {
            try
            {
                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                fornecedorBLL.ExcluirFornecedor(idFornecedor);
                MessageBox.Show("Fornecedor excluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void btnPesquisarCnpj_Click(object sender, EventArgs e)
        {
            string cpfcnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text);
            DBSetupBLL dbSetupBLL = new DBSetupBLL();
            // Verifica se o CPF/CNPJ já está cadastrado
            if (dbSetupBLL.VerificarSeCadastrado(cpfcnpj, "DBFornecedores", "Cpf_Cnpj"))
            {
                MessageBox.Show("Fornecedor já cadastrado. Favor verificar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfCnpj.Clear();
                txtCpfCnpj.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cpfcnpj))
            {
                MessageBox.Show("Favor, Insira um CNPJ.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidaCnpj(cpfcnpj))
            {
                MessageBox.Show("CNPJ Informado esta Incorreto. Favor Verificar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfCnpj.Clear();
                txtCpfCnpj.Focus();
                return;
            }
            try
            {

                Cursor.Current = Cursors.WaitCursor; // Mudar o cursor para ocupado
                CnpjInfo info = await ReceitaFederalApi.PesquisarCnpjAsync(cpfcnpj);

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
                    MessageBox.Show("CNPJ não encontrado ou erro na pesquisa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("CEP não encontrado ou erro ao buscar o CEP.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

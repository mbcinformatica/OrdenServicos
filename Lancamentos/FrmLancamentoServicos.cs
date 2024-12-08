using ProjetoTeste.BLL;
using ProjetoTeste.DAL;
using ProjetoTeste.Forms;
using ProjetoTeste.Model;
using ProjetoTeste.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoTeste
{
    public partial class frmLancamentoServicos : BaseForm
    {
        private int sortColumn = -1;
        private bool sortAscending = true;
        private bool bNovo;
        private Color defaultHeaderBackColor = Color.DarkTurquoise;
        private Color clickedHeaderBackColor = Color.CadetBlue;
        private int previousSortColumn = -1;
        private (Control, string)[] camposObrigatorios;
        private List<ListViewItem> listaOriginalItens = new List<ListViewItem>();
        private bool escPressed = false;
        private Control ControleAnterior;

        public frmLancamentoServicos()
        {
            InitializeComponent();
            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new System.Windows.Forms.PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlOrdenServico); // Chama o método para inicializar o TabControl
            erpProvider = new ErrorProvider();
            ConfigurarComboBoxMarcas();
            ConfigurarComboBoxClientes();
            ConfigurarComboBoxProdutos();
            CarregarRegistros();
            // Configurar eventos dos TextBoxes para maiúsculas
            ConfigurarTextBox();
            // Configurar TabIndex dos Controles
            ConfigurarTabIndexControles();
            // Configurando os Key para os TextBox
            CarregaKey();
        }
        private void InitializeListView()
        {
            // Configurar a ListView
            listViewLancamentoServicos.View = View.Details;
            listViewLancamentoServicos.FullRowSelect = true;
            listViewLancamentoServicos.OwnerDraw = true; // Permitir desenho personalizado
            listViewLancamentoServicos.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewLancamentoServicos_DrawColumnHeader);
            listViewLancamentoServicos.DrawItem += new DrawListViewItemEventHandler(listViewLancamentoServicos_DrawItem);
            listViewLancamentoServicos.DrawSubItem += new DrawListViewSubItemEventHandler(listViewLancamentoServicos_DrawSubItem);
            // Adicionar colunas
            listViewLancamentoServicos.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewLancamentoServicos.Columns.Add("  DATA EMISSÃO", 120, HorizontalAlignment.Center);
            listViewLancamentoServicos.Columns.Add("  DATA PREVISTA CONCLUÇÃO", 120, HorizontalAlignment.Center);
            listViewLancamentoServicos.Columns.Add("  CLIENTE", 120, HorizontalAlignment.Left);
            listViewLancamentoServicos.Columns.Add("  MARCA", 200, HorizontalAlignment.Left);
            listViewLancamentoServicos.Columns.Add("  PRODUTO", 150, HorizontalAlignment.Left);
            listViewLancamentoServicos.Columns.Add("  NUMERO DE SÉRIE", 200, HorizontalAlignment.Right);
            listViewLancamentoServicos.Columns.Add("  DESCRIÇÃO DO DEFEITO", 200, HorizontalAlignment.Left);
            listViewLancamentoServicos.Columns.Add("  VALOR TOTAL SERVIÇO", 200, HorizontalAlignment.Right);
            listViewLancamentoServicos.Columns.Add("  VALOR TOTAL MATERIAIS", 200, HorizontalAlignment.Right);

            // Adicionar evento de clique no cabeçalho da coluna
            listViewLancamentoServicos.ColumnClick += new ColumnClickEventHandler(ListViewLancamentoServico_ColumnClick);
            listViewLancamentoServicos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewLancamentoServicos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void ListViewLancamentoServico_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            if (e.Column == 0) // && e.Column != 2 && e.Column != 3)
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
                LimparCampos();
                // Nova coluna clicada
                sortColumn = e.Column;
                sortAscending = true;
            }
            // Forçar redesenho da coluna anterior
            if (oldSortColumn != -1)
            {
                listViewLancamentoServicos.Columns[oldSortColumn].Width = listViewLancamentoServicos.Columns[oldSortColumn].Width;
            }
            listViewLancamentoServicos.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewLancamentoServicos.Sort();
            // Forçar redesenho da nova coluna
            listViewLancamentoServicos.Columns[sortColumn].Width = listViewLancamentoServicos.Columns[sortColumn].Width;
            listViewLancamentoServicos.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
        private void listViewLancamentoServicos_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
                if (e.Header.Text == "ID")

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
        private void listViewLancamentoServicos_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewLancamentoServicos_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewLancamentoServicos.Columns[e.ColumnIndex].Text == "ID")
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
        private void txtPesquisaListView_TextChanged(object sender, EventArgs e)
        {
            PesquisarListView(txtPesquisaListView.Text, listViewLancamentoServicos, sortColumn);
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
        private void CarregaKey()
        {
            txtIDOrdenServico.KeyPress += Evento_KeyPress;
            txtValorTotalServico.KeyPress += Evento_KeyPress;
            txtValorTotalMaterial.KeyPress += Evento_KeyPress;

            txtDataEmissao.KeyDown += Evento_KeyDown;
            txtDataConclucao.KeyDown += Evento_KeyDown;
            cmbCliente.KeyDown += Evento_KeyDown;
            cmbMarca.KeyDown += Evento_KeyDown;
            cmbProduto.KeyDown += Evento_KeyDown;
            txtNumeroSerie.KeyDown += Evento_KeyDown;
            txtDescricaoDefeito.KeyDown += Evento_KeyDown;
            txtValorTotalServico.KeyDown += Evento_KeyDown;
            txtValorTotalMaterial.KeyDown += Evento_KeyDown;
            txtPesquisaListView.KeyDown += Evento_KeyDown;
            listViewLancamentoServicos.KeyDown += Evento_KeyDown;

            // Associar eventos Leave e Enter aos controles relevantes
            txtValorTotalServico.Leave += Evento_Leave;
            txtValorTotalMaterial.Leave += Evento_Leave;
            txtDataEmissao.Leave += Evento_Leave;
            txtDataConclucao.Leave += Evento_Leave;
            cmbCliente.Leave += Evento_Leave;
            cmbMarca.Leave += Evento_Leave;
            cmbProduto.Leave += Evento_Leave;

            txtValorTotalServico.Enter += Evento_Enter;
            txtValorTotalMaterial.Enter += Evento_Enter;
            cmbCliente.Enter += Evento_Enter;
            cmbMarca.Enter += Evento_Enter;
            cmbProduto.Enter += Evento_Enter;
            txtNumeroSerie.Enter += Evento_Enter;
            txtDescricaoDefeito.Enter += Evento_Enter;
            txtPesquisaListView.Enter += Evento_Enter;
            txtIDOrdenServico.Enter += Evento_Enter;

            // Adiciona eventos de mouse aos botões
            txtIDOrdenServico.MouseDown += (sender, e) => EventosUtils.Evento_MouseDown(sender, e, txtIDOrdenServico, ControleAnterior);

            btnSalvar.MouseEnter += (sender, e) => EventosUtils.Button_MouseEnter(sender, e, this);
            btnSalvar.MouseLeave += (sender, e) => EventosUtils.Button_MouseLeave(sender, e, this);
            btnAlterar.MouseEnter += (sender, e) => EventosUtils.Button_MouseEnter(sender, e, this);
            btnAlterar.MouseLeave += (sender, e) => EventosUtils.Button_MouseLeave(sender, e, this);
            btnExcluir.MouseEnter += (sender, e) => EventosUtils.Button_MouseEnter(sender, e, this);
            btnExcluir.MouseLeave += (sender, e) => EventosUtils.Button_MouseLeave(sender, e, this);
            btnFechar.MouseEnter += (sender, e) => EventosUtils.Button_MouseEnter(sender, e, this);
            btnFechar.MouseLeave += (sender, e) => EventosUtils.Button_MouseLeave(sender, e, this);
            btnNovo.MouseEnter += (sender, e) => EventosUtils.Button_MouseEnter(sender, e, this);
            btnNovo.MouseLeave += (sender, e) => EventosUtils.Button_MouseLeave(sender, e, this);

            cmbProduto.SelectedIndexChanged += cmbProduto_SelectedIndexChanged;
            cmbMarca.SelectedIndexChanged += CmbMarca_SelectedIndexChanged;
            listViewLancamentoServicos.Click += ListViewLancamentoServicos_Click;
        }
        private void Evento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is MaskedTextBox maskedTextBox)
            {
                // Permitir somente números, vírgula e controle (como backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
                // Permitir somente uma vírgula decimal
                if (e.KeyChar == ',' && maskedTextBox.Text.IndexOf(',') > -1)
                {
                    e.Handled = true;
                }
            }
            else if (sender is TextBox textBox && textBox.Name == "txtIDOrdenServico")
            {
                // Bloqueia qualquer entrada de caractere para txtIDOrdenServico
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
                AutoValidate = AutoValidate.Disable;
                CarregarRegistros();
                LimparCampos();
                AutoValidate = AutoValidate.EnablePreventFocusChange;
            }
        }
        private void Evento_Leave(object sender, EventArgs e)
        {
            if (escPressed)
            {
                return; // Sai do método sem fazer verificações
            }
            MaskedTextBox maskedTextBox = sender as MaskedTextBox;
            if (maskedTextBox != null)
            {
                if (sender == txtValorTotalServico || sender == txtValorTotalMaterial)
                {
                    maskedTextBox.Text = StringUtils.FormatValorMoeda(maskedTextBox.Text);
                }
                if (sender == txtValorTotalMaterial)
                {
                    tabControlOrdenServico.SelectedTab = tabDadosCliente;
                }
            }
            DateTimePicker dateTimePicker = sender as DateTimePicker;
            if (dateTimePicker != null)
            {
                DateTime selectedDate = dateTimePicker.Value;
                if (sender == txtDataEmissao)
                {
                    txtDataConclucao.Value = selectedDate.AddDays(15);
                }
                dateTimePicker.Value = new DateTime(selectedDate.Year, selectedDate.Month,
                    selectedDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                dateTimePicker.CustomFormat = "dd/MM/yyyy";
                dateTimePicker.Format = DateTimePickerFormat.Custom;
            }
            ComboBox combobox = sender as ComboBox;
            if (combobox != null)
            {
                if (sender == cmbCliente)
                {
                    string clienteDigitado = cmbCliente.Text.ToUpper(); // Converte para maiúsculas
                    cmbCliente.Text = clienteDigitado; // Atualiza o texto no ComboBox
                    if (!ClienteExiste(clienteDigitado) && !string.IsNullOrEmpty(clienteDigitado))
                    {
                        try
                        {
                            DialogResult result = MessageBox.Show($"Cliente '{clienteDigitado}' não Cadastrado", "Cliente não Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {
                                // Abre o formulário frmMarcas
                                frmClientes frm = new frmClientes();
                                frm.ShowDialog();
                                ClienteBLL clienteBLL = new ClienteBLL();
                                // Recarregar as marcas no ComboBox
                                List<ClienteInfo> clientes = clienteBLL.Listar();
                                // Ordenar a lista de marcas em ordem alfabética
                                clientes = clientes.OrderBy(c => c.Nome_RazaoSocial).ToList();
                                // Definir a fonte de dados do ComboBox
                                cmbCliente.DataSource = clientes;
                                cmbCliente.DisplayMember = "Nome_RazaoSocial";
                                cmbCliente.ValueMember = "IDCliente";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        cmbCliente.Text = string.Empty;
                        cmbCliente.Focus();
                    }
                    if (string.IsNullOrEmpty(clienteDigitado))
                    {
                        cmbCliente.Focus();
                    }
                }
                if (sender == cmbMarca)
                {
                    string marcaDigitada = cmbMarca.Text.ToUpper(); // Converte para maiúsculas
                    cmbMarca.Text = marcaDigitada; // Atualiza o texto no ComboBox
                    if (!MarcaExiste(marcaDigitada) && !string.IsNullOrEmpty(marcaDigitada))
                    {
                        try
                        {
                            DialogResult result = MessageBox.Show($"A Marca '{marcaDigitada}' não Existe. Deseja Cadastrá-la?", "Marca não Encontrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {
                                // Abre o formulário frmMarcas
                                frmMarcas frm = new frmMarcas();
                                frm.ShowDialog();
                                MarcaBLL marcaBLL = new MarcaBLL();
                                // Recarregar as marcas no ComboBox
                                List<MarcaInfo> marcas = marcaBLL.Listar();
                                // Ordenar a lista de marcas em ordem alfabética
                                marcas = marcas.OrderBy(m => m.Descricao).ToList();
                                // Definir a fonte de dados do ComboBox
                                cmbMarca.DataSource = marcas;
                                cmbMarca.DisplayMember = "Descricao";
                                cmbMarca.ValueMember = "IDMarca";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        cmbMarca.Text = string.Empty;
                        cmbMarca.Focus();
                    }
                    if (string.IsNullOrEmpty(marcaDigitada))
                    {
                        cmbMarca.Focus();
                    }
                }
                if (sender == cmbProduto)
                {
                    string produtoDigitado = cmbProduto.Text.ToUpper(); // Converte para maiúsculas
                    cmbProduto.Text = produtoDigitado; // Atualiza o texto no ComboBox
                    int idMarca = Convert.ToInt32(cmbMarca.SelectedValue); // Método para obter o ID da Marca selecionada
                    if (!ProdutoExiste(idMarca, produtoDigitado) && produtoDigitado != string.Empty && idMarca != 0)
                    {
                        try
                        {
                            DialogResult result = MessageBox.Show($"O Produto '{produtoDigitado}' não Existe para a Marca Selecionada. Deseja Cadastrá-lo?", "Produto não Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {
                                // Abre o formulário frmMarcas
                                frmProdutos frm = new frmProdutos();
                                frm.ShowDialog();
                                if (cmbMarca.SelectedValue != null)
                                {
                                    int idmarca = Convert.ToInt32(cmbMarca.SelectedValue);
                                    CarregarProdutosPorMarca(idmarca);
                                }
                            }
                            else
                            {
                                cmbProduto.Text = string.Empty;
                                cmbProduto.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (produtoDigitado == string.Empty || idMarca == 0)
                    {
                        cmbProduto.Focus();
                    }
                }
            }
        }
        private void Evento_Enter(object sender, EventArgs e)
        {

            if (sender is MaskedTextBox maskedTextBox)
            {
                maskedTextBox.SelectAll();
            }
            else if (sender is TextBox textBox)
            {
                if (sender == txtIDOrdenServico)
                {
                    ControleAnterior = cmbCliente;
                    ControleAnterior.Focus();
                }
                textBox.SelectAll();
            }
            else if (sender is ComboBox comboBox)
            {
                // comboBox.Select();
            }
            else if (sender is DateTimePicker dateTimePicker)
            {
                // dateTimePicker.Select();
            }
        }
        private Control GetNextControl(Control current, bool forward)
        {
            Control parent = current.Parent;
            if (parent == null)
            {
                return null;
            }
            List<Control> controls = parent.Controls.Cast<Control>().Where(ct => ct.TabStop).OrderBy(ct => ct.TabIndex).ToList();
            int currentIndex = controls.IndexOf(current);
            int nextIndex = (currentIndex + (forward ? 1 : -1) + controls.Count) % controls.Count;
            return controls[nextIndex];
        }
        private void ConfigurarTabIndexControles()
        {
            txtDataEmissao.TabIndex = 0;
            txtDataConclucao.TabIndex = 1;
            cmbCliente.TabIndex = 2;
            cmbMarca.TabIndex = 3;
            cmbProduto.TabIndex = 4;
            txtNumeroSerie.TabIndex = 5;
            txtDescricaoDefeito.TabIndex = 6;
            txtValorTotalServico.TabIndex = 7;
            txtValorTotalMaterial.TabIndex = 8;
            btnSalvar.TabIndex = 9;
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
                (txtDataEmissao, "DataEmissao"),
                (txtDataConclucao, "DataConclucao"),
                (cmbCliente, "IDCliente"),
                (cmbMarca, "IDmarca"),
                (cmbProduto, "IDProduto")
            };
            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
        }
        private void CarregarRegistros()
        {
            DesabilitarCampos();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes",this);
            listViewLancamentoServicos.Items.Clear();
            listViewLancamentoServicos.Columns.Clear();
            InitializeListView();
            try
            {
                LancamentoServicoBLL lancamentoServicoBLL = new LancamentoServicoBLL();
                List<LancamentoServicoInfo> lancamentoServicos = lancamentoServicoBLL.Listar();
                foreach (LancamentoServicoInfo lancamentoServico in lancamentoServicos)
                {
                    ListViewItem item = new ListViewItem(lancamentoServico.IDOrdenServico.ToString());
                    item.SubItems.Add(lancamentoServico.DataEmissao.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(lancamentoServico.DataConclucao.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(lancamentoServico.Cliente); // Usar o nome do cliente
                    item.SubItems.Add(lancamentoServico.Marca); // Usar o nome da marca
                    item.SubItems.Add(lancamentoServico.Produto); // Usar o nome da produto
                    item.SubItems.Add(lancamentoServico.NumeroSerie);
                    item.SubItems.Add(lancamentoServico.DescricaoDefeito);
                    item.SubItems.Add(StringUtils.FormatValorMoeda(lancamentoServico.ValorTotalServico.ToString()));
                    item.SubItems.Add(StringUtils.FormatValorMoeda(lancamentoServico.ValorTotalMaterial.ToString()));
                    // Carregar a imagem (sem exibir na ListView)
                    if (lancamentoServico.Imagem != null && lancamentoServico.Imagem.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(lancamentoServico.Imagem))
                        {
                            Image imgImagemProduto = Image.FromStream(ms);
                            // A imagem é carregada, mas não exibida na ListView
                        }
                    }
                    listViewLancamentoServicos.Items.Add(item);
                }
                // Ajustar automaticamente o tamanho das colunas ao conteúdo, mas não menor que o cabeçalho
                foreach (ColumnHeader column in listViewLancamentoServicos.Columns)
                {
                    if (column.Text == "  DESCRIÇÃO DO DEFEITO")
                    {
                        column.Width = 400; // Ignorar cliques em outras colunas
                    }
                    else
                    {
                        column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize); // Ajusta a largura ao cabeçalho primeiro
                        int headerWidth = TextRenderer.MeasureText(column.Text, listViewLancamentoServicos.Font).Width + 20; // Adiciona uma margem
                        column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); // Ajusta a largura ao conteúdo
                        if (column.Width < headerWidth)
                        {
                            column.Width = headerWidth; // Garantir que a largura não fique menor que o cabeçalho
                        }
                    }
                }
                listaOriginalItens = listViewLancamentoServicos.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros: " + listViewLancamentoServicos.Items.Count;
                sortColumn = 3;
                sortAscending = true;
                listViewLancamentoServicos.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                listViewLancamentoServicos.Sort();
                listViewLancamentoServicos.Columns[sortColumn].Width = listViewLancamentoServicos.Columns[sortColumn].Width;
                tabControlOrdenServico.SelectedTab = tabDadosOrdenServico;


                // Carregar clientes no ComboBox
                ClienteBLL clienteBLL = new ClienteBLL();
                List<ClienteInfo> clientes = clienteBLL.Listar();
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "Nome_RazaoSocial";
                cmbCliente.ValueMember = "IDCliente";

                // Carregar marcas no ComboBox
                MarcaBLL marcaBLL = new MarcaBLL();
                List<MarcaInfo> marcas = marcaBLL.Listar();
                cmbMarca.DataSource = marcas;
                cmbMarca.DisplayMember = "Descricao";
                cmbMarca.ValueMember = "IDMarca";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListViewLancamentoServicos_Click(object sender, EventArgs e)
        {
            escPressed = false; // Reseta a variável de controle
            if (listViewLancamentoServicos.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewLancamentoServicos.SelectedItems[0];
                txtIDOrdenServico.Text = item.SubItems[0].Text;
                txtDataEmissao.Text = item.SubItems[1].Text;
                txtDataConclucao.Text = item.SubItems[2].Text;
                string clienteNome = item.SubItems[3].Text;
                ClienteBLL clienteBLL = new ClienteBLL();
                List<ClienteInfo> clientes = clienteBLL.Listar();
                ClienteInfo cliente = clientes.FirstOrDefault(c => c.Nome_RazaoSocial == clienteNome);
                if (cliente != null)
                {
                    cmbCliente.SelectedValue = cliente.IDCliente;
                }
                string marcaNome = item.SubItems[4].Text; // Índice da coluna da marca
                MarcaBLL marcaBLL = new MarcaBLL();
                List<MarcaInfo> marcas = marcaBLL.Listar();
                MarcaInfo marca = marcas.FirstOrDefault(m => m.Descricao == marcaNome);
                if (marca != null)
                {
                    cmbMarca.SelectedValue = marca.IDMarca;
                }

                string produtoNome = item.SubItems[5].Text; // Índice da coluna da marca
                ProdutoBLL produtoBLL = new ProdutoBLL();
                List<ProdutoInfo> produtos = produtoBLL.Listar();
                ProdutoInfo produto = produtos.FirstOrDefault(p => p.Descricao == produtoNome);
                if (produto != null)
                {
                    cmbProduto.SelectedValue = produto.IDProduto;
                }
                txtNumeroSerie.Text = item.SubItems[6].Text;
                txtDescricaoDefeito.Text = item.SubItems[7].Text;
                txtValorTotalServico.Text = item.SubItems[8].Text;
                txtValorTotalMaterial.Text = item.SubItems[9].Text;

                // Exibir a imagem no PictureBox
                LancamentoServicoBLL lancamentoServicoBLL = new LancamentoServicoBLL();
                LancamentoServicoInfo lancamentoServico = lancamentoServicoBLL.GetLancamentoServico(Convert.ToInt32(item.SubItems[0].Text));
                if (lancamentoServico.Imagem != null && lancamentoServico.Imagem.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(lancamentoServico.Imagem))
                    {
                        imgImagemProduto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    imgImagemProduto.Image = null;
                }
                EventosUtils.AcaoBotoes("HabilitarBotoesAlterarExcluir",this);
            }
        }
        private void ConfigurarComboBoxClientes()
        {
            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ConfigurarComboBoxMarcas()
        {
            cmbMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMarca.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ConfigurarComboBoxProdutos()
        {
            cmbProduto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProduto.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void CmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedValue != null)
            {
                int idMarca = Convert.ToInt32(cmbMarca.SelectedValue);
                CarregarProdutosPorMarca(idMarca);
            }
        }
        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduto.SelectedValue != null)
            {
                ProdutoInfo produtoSelecionado = cmbProduto.SelectedItem as ProdutoInfo;
                if (produtoSelecionado != null)
                {
                    if (produtoSelecionado.Imagem != null)
                    {
                        using (var ms = new System.IO.MemoryStream(produtoSelecionado.Imagem))
                        {
                            imgImagemProduto.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        imgImagemProduto.Image = null;
                    }
                }
            }
        }
        private bool ClienteExiste(string nome_RazaoSocial)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            List<ClienteInfo> clientes = clienteBLL.Listar();
            return clientes.Any(c => c.Nome_RazaoSocial.Equals(nome_RazaoSocial, StringComparison.OrdinalIgnoreCase));
        }
        private bool ProdutoExiste(int idMarca, string descricao)
        {
            ProdutoDAL produtoDAL = new ProdutoDAL();
            List<ProdutoInfo> produtos = produtoDAL.ListarPorMarca(idMarca);
            return produtos.Any(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }
        private bool MarcaExiste(string descricao)
        {
            MarcaBLL marcaBLL = new MarcaBLL();
            List<MarcaInfo> marcas = marcaBLL.Listar();
            return marcas.Any(m => m.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }
        private void CarregarProdutosPorMarca(int idMarca)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();
            List<ProdutoInfo> produtos = produtoBLL.ListarPorMarca(idMarca);
            if (produtos.Count > 0)
            {
                cmbProduto.DataSource = produtos;
                cmbProduto.DisplayMember = "Descricao";
                cmbProduto.ValueMember = "IDProduto";
            }
            else
            {
                cmbProduto.DataSource = null;
                cmbProduto.Items.Clear();
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar",this);
            txtIDOrdenServico.Text = "0";
            bNovo = true;
            HabilitarCampos("Novo");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            LancamentoServicoBLL lancamentoServicoBLL = new LancamentoServicoBLL();

            // Verificar se algum campo obrigatório está vazio
            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool isAtualizacao = false;
            if (!string.IsNullOrEmpty(txtIDOrdenServico.Text))
            {
                int idOrdenServico = Convert.ToInt32(txtIDOrdenServico.Text);
                isAtualizacao = lancamentoServicoBLL.GetLancamentoServico(idOrdenServico) != null;
            }
            if (!isAtualizacao)
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Esse Produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    LancamentoServicoInfo lancamentoServico = new LancamentoServicoInfo
                    {
                        DataEmissao = txtDataEmissao.Value,
                        DataConclucao = txtDataConclucao.Value,
                        IDCliente = Convert.ToInt32(cmbCliente.SelectedValue),
                        IDMarca = Convert.ToInt32(cmbMarca.SelectedValue),
                        IDProduto = Convert.ToInt32(cmbProduto.SelectedValue),
                        NumeroSerie = txtNumeroSerie.Text,
                        DescricaoDefeito = txtDescricaoDefeito.Text,
                        ValorTotalServico = Convert.ToDecimal(StringUtils.SemFormatacao(txtValorTotalServico.Text)),
                        ValorTotalMaterial = Convert.ToDecimal(StringUtils.SemFormatacao(txtValorTotalMaterial.Text)),
                        Imagem = ImageToByteArray(imgImagemProduto.Image)
                    };
                    InserirLancamentoServico(lancamentoServico);

                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Realizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    LancamentoServicoInfo lancamentoServico = new LancamentoServicoInfo
                    {
                        IDOrdenServico = int.Parse(txtIDOrdenServico.Text),
                        DataEmissao = txtDataEmissao.Value,
                        DataConclucao = txtDataConclucao.Value,
                        IDCliente = Convert.ToInt32(cmbCliente.SelectedValue),
                        IDMarca = Convert.ToInt32(cmbMarca.SelectedValue),
                        IDProduto = Convert.ToInt32(cmbProduto.SelectedValue),
                        NumeroSerie = txtNumeroSerie.Text,
                        DescricaoDefeito = txtDescricaoDefeito.Text,
                        ValorTotalServico = Convert.ToDecimal(StringUtils.SemFormatacao(txtValorTotalServico.Text)),
                        ValorTotalMaterial = Convert.ToDecimal(StringUtils.SemFormatacao(txtValorTotalMaterial.Text)),
                        Imagem = ImageToByteArray(imgImagemProduto.Image)
                    };
                    AtualizarLancamentoServico(lancamentoServico);

                }
            }
            CarregarRegistros();
            LimparCampos();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            HabilitarCampos("Alterar");
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDOrdenServico.Text, out int ordenServicoID))
                {
                    ExcluirLancamentoServico(ordenServicoID);
                }
                else
                {
                    MessageBox.Show("ID inválido. Por favor, insira um número inteiro.", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            CarregarRegistros();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
            LimparCampos();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DesabilitarCampos()
        {
            txtDataEmissao.Enabled = false;
            txtDataConclucao.Enabled = false;
            cmbCliente.Enabled = false;
            cmbMarca.Enabled = false;
            cmbProduto.Enabled = false;
            txtNumeroSerie.Enabled = false;
            txtDescricaoDefeito.Enabled = false;
            txtValorTotalServico.Enabled = false;
            txtValorTotalMaterial.Enabled = false;
            listViewLancamentoServicos.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCampos(string buttonPressed)
        {
            txtDescricaoDefeito.Enabled = true;
            txtDataConclucao.Enabled = true;
            txtValorTotalServico.Enabled = true;
            txtValorTotalMaterial.Enabled = true;
            listViewLancamentoServicos.Enabled = false;
            txtPesquisaListView.Enabled = false;
            switch (buttonPressed)
            {
                case "Novo":
                    txtDataEmissao.Enabled = true;
                    cmbCliente.Enabled = true;
                    cmbMarca.Enabled = true;
                    cmbProduto.Enabled = true;
                    txtNumeroSerie.Enabled = true;
                    txtIDOrdenServico.Text = "0";
                    txtDataEmissao.Text = DateTime.Now.ToString();
                    txtDataConclucao.Text = DateTime.Now.ToString();
                    txtDataEmissao.Focus();

                    break;
                case "Salvar":
                    // Adicionar ações específicas para "Salvar" se necessário
                    break;
                case "Alterar":
                    txtDataConclucao.Focus();
                    break;
                case "Excluir":
                    // Adicionar ações específicas para "Excluir" se necessário
                    break;
                default:
                    break;
            }
        }
        private void LimparCampos()
        {
            txtIDOrdenServico.Clear();
            txtDataEmissao.Value = DateTime.Now;
            txtDataConclucao.Value = DateTime.Now;
            cmbCliente.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            cmbProduto.SelectedIndex = -1;
            txtNumeroSerie.Clear();
            txtDescricaoDefeito.Clear();
            txtValorTotalServico.Text = "0";
            txtValorTotalMaterial.Text = "0";
            txtValorTotalServico.Text = StringUtils.FormatValorMoeda(txtValorTotalServico.Text.ToString());
            txtValorTotalMaterial.Text = StringUtils.FormatValorMoeda(txtValorTotalMaterial.Text.ToString());
            imgImagemProduto.Image = null;
            txtPesquisaListView.Clear();
            bNovo = false;
        }
        static void InserirLancamentoServico(LancamentoServicoInfo lancamentoServico)
        {
            try
            {
                LancamentoServicoBLL lancamentoServicoBLL = new LancamentoServicoBLL();
                lancamentoServicoBLL.InserirLancamentoServico(lancamentoServico);
                MessageBox.Show("Orden de Serviço Inserido com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarLancamentoServico(LancamentoServicoInfo lancamentoServico)
        {
            try
            {
                LancamentoServicoBLL lancamentoServicoBLL = new LancamentoServicoBLL();
                lancamentoServicoBLL.AtualizarLancamentoServico(lancamentoServico);
                MessageBox.Show("Orden de Serviço Atualizado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirLancamentoServico(int idOrdenServico)
        {
            try
            {
                LancamentoServicoBLL lancamentoServicoBLL = new LancamentoServicoBLL();
                lancamentoServicoBLL.ExcluirLancamentoServico(idOrdenServico); ;
                MessageBox.Show("Orden de Serviço Excluído com Sucesso!", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

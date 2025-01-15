using AForge.Video.DirectShow;
using OrdenServicos.BLL;
using OrdenServicos.DAL;
using OrdenServicos.Forms;
using OrdenServicos.Model;
using OrdenServicos.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OrdenServicos

{
    public partial class frmProdutos : BaseForm
    {
        private int sortColumn = -1;
        private bool sortAscending = true;

        private Color defaultHeaderBackColor = Color.DarkTurquoise;
        private Color clickedHeaderBackColor = Color.CadetBlue;

        private (Control, string)[] camposObrigatorios;
        private List<ListViewItem> listaOriginalItens = new List<ListViewItem>();

        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;

        public frmProdutos()
        {
            InitializeComponent();
            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new System.Windows.Forms.PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlProdutos); // Chama o método para inicializar o TabControl
            erpProvider = new ErrorProvider();
            ConfigurarcmbFornecedores();
            ConfigurarComboBoxMarcas();
            ConfigurarComboBoxModelos();
            ConfigurarComboBoxUnidades();
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
            listViewProdutos.View = View.Details;
            listViewProdutos.FullRowSelect = true;
            listViewProdutos.OwnerDraw = true; // Permitir desenho personalizado
            listViewProdutos.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewProdutos_DrawColumnHeader);
            listViewProdutos.DrawItem += new DrawListViewItemEventHandler(listViewProdutos_DrawItem);
            listViewProdutos.DrawSubItem += new DrawListViewSubItemEventHandler(listViewProdutos_DrawSubItem);
            // Adicionar colunas
            listViewProdutos.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("CÓD. INTERNO", 120, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("CÓD. FABRICANTE", 120, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("  DESCRIÇÃO", 120, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("  FORNECEDOR", 300, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("  MARCA", 200, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("  MODELO", 200, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("  UNIDADE", 150, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("PREÇO COMPRA", 200, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("PREÇO VENDA", 200, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("ESTOQUE ATUAL", 200, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("ESTOQUE MINIMO", 200, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("ULTIMA COMPRA", 100, HorizontalAlignment.Center);
            listViewProdutos.Columns.Add("  GARANTIA", 100, HorizontalAlignment.Left);
            // Adicionar evento de clique no cabeçalho da coluna
            listViewProdutos.ColumnClick += new ColumnClickEventHandler(ListViewProdutos_ColumnClick);
            listViewProdutos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewProdutos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void ListViewProdutos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != 1 && e.Column != 2 && e.Column != 3)
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
                listViewProdutos.Columns[oldSortColumn].Width = listViewProdutos.Columns[oldSortColumn].Width;
            }
            listViewProdutos.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewProdutos.Sort();
            // Forçar redesenho da nova coluna
            listViewProdutos.Columns[sortColumn].Width = listViewProdutos.Columns[sortColumn].Width;
            listViewProdutos.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
            PesquisarListView(txtPesquisaListView.Text, listViewProdutos, sortColumn);
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
        private void listViewProdutos_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
                if (e.Header.Text == "ID" || e.Header.Text == "CÓD. INTERNO" || e.Header.Text == "CÓD. FABRICANTE" || e.Header.Text == "PREÇO COMPRA" || e.Header.Text == "PREÇO VENDA" || e.Header.Text == "ESTOQUE ATUAL" || e.Header.Text == "ESTOQUE MINIMO")
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
        private void listViewProdutos_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewProdutos_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewProdutos.Columns[e.ColumnIndex].Text == "ID" || listViewProdutos.Columns[e.ColumnIndex].Text == "CÓD. INTERNO" || listViewProdutos.Columns[e.ColumnIndex].Text == "CÓD. FABRICANTE" || listViewProdutos.Columns[e.ColumnIndex].Text == "PREÇO COMPRA" || listViewProdutos.Columns[e.ColumnIndex].Text == "PREÇO VENDA" || listViewProdutos.Columns[e.ColumnIndex].Text == "ESTOQUE ATUAL"
                     || listViewProdutos.Columns[e.ColumnIndex].Text == "ESTOQUE MINIMO")
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
            txtIDProdutoInterno.KeyDown += Evento_KeyDown;
            txtIDProdutoFabricante.KeyDown += Evento_KeyDown;
            txtDescricao.KeyDown += Evento_KeyDown;
            cmbFornecedor.KeyDown += Evento_KeyDown;
            cmbMarca.KeyDown += Evento_KeyDown;
            cmbModelo.KeyDown += Evento_KeyDown;
            cmbUnidade.KeyDown += Evento_KeyDown;
            txtPrecoCompra.KeyDown += Evento_KeyDown;
            txtPrecoVenda.KeyDown += Evento_KeyDown;
            txtEstoqueAtual.KeyDown += Evento_KeyDown;
            txtEstoqueMinimo.KeyDown += Evento_KeyDown;
            txtDataUltimaCompra.KeyDown += Evento_KeyDown;
            txtGarantia.KeyDown += Evento_KeyDown;
            txtPesquisaListView.KeyDown += Evento_KeyDown;
            listViewProdutos.KeyDown += Evento_KeyDown;

            txtPrecoCompra.KeyPress += Evento_KeyPress;
            txtPrecoVenda.KeyPress += Evento_KeyPress;
            txtEstoqueAtual.KeyPress += Evento_KeyPress;
            txtEstoqueMinimo.KeyPress += Evento_KeyPress;

            txtPrecoCompra.Leave += Evento_Leave;
            txtPrecoVenda.Leave += Evento_Leave;
            txtEstoqueAtual.Leave += Evento_Leave;
            txtEstoqueMinimo.Leave += Evento_Leave;

            txtGarantia.Leave += Evento_Leave;

            cmbFornecedor.Leave += Evento_Leave; // Adiciona o evento Leave
            cmbMarca.Leave += Evento_Leave; // Adiciona o evento Leave
            cmbModelo.Leave += Evento_Leave; // Adiciona o evento Leave
            cmbUnidade.Leave += Evento_Leave; // Adiciona o evento Leave

            // Adiciona eventos de mouse aos botões
            btnSalvar.MouseEnter += Button_MouseEnter;
            btnSalvar.MouseLeave += Button_MouseLeave;
            btnAlterar.MouseEnter += Button_MouseEnter;
            btnAlterar.MouseLeave += Button_MouseLeave;
            btnExcluir.MouseEnter += Button_MouseEnter;
            btnExcluir.MouseLeave += Button_MouseLeave;
            btnInserirImagem.MouseEnter += Button_MouseEnter;
            btnInserirImagem.MouseLeave += Button_MouseLeave;
            btnExcluirImagem.MouseEnter += Button_MouseEnter;
            btnExcluirImagem.MouseLeave += Button_MouseLeave;
            btnFechar.MouseEnter += Button_MouseEnter;
            btnFechar.MouseLeave += Button_MouseLeave;
            btnNovo.MouseEnter += Button_MouseEnter;
            btnNovo.MouseLeave += Button_MouseLeave;


            cmbMarca.SelectedIndexChanged += CmbMarca_SelectedIndexChanged;
            listViewProdutos.Click += ListViewProdutos_Click;
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
        private void Evento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Impede o som de "beep"
                DBSetupBLL dbSetupBLL = new DBSetupBLL();

                if (sender == txtIDProdutoInterno && bNovo)
                {
                    string idProdutoInterno = txtIDProdutoInterno.Text;
                    if (dbSetupBLL.VerificarSeCadastrado(idProdutoInterno, "DBProdutos", "IDProdutoInterno"))
                    {
                        MessageBox.Show("Código Produto Interno já cadastrado. Favor verificar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIDProdutoInterno.Clear();
                        txtIDProdutoInterno.Focus();
                        return;
                    }
                }
                else if (sender == txtIDProdutoFabricante && bNovo)
                {
                    string idProdutoFabricante = txtIDProdutoFabricante.Text;
                    if (dbSetupBLL.VerificarSeCadastrado(idProdutoFabricante, "DBProdutos", "IDProdutoFabricante"))
                    {
                        MessageBox.Show("Código Produto Fabricante já cadastrado. Favor verificar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIDProdutoFabricante.Clear();
                        txtIDProdutoFabricante.Focus();
                        return;
                    }
                }

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
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (sender == txtGarantia)
                {
                    tabControlProdutos.SelectedTab = tabInformacoesAdicionais;
                }
            }
            MaskedTextBox maskedTextBox = sender as MaskedTextBox;
            if (maskedTextBox != null)
            {
                if (sender == txtPrecoCompra || sender == txtPrecoVenda)
                {
                    maskedTextBox.Text = StringUtils.FormatValorMoeda(maskedTextBox.Text);
                }
                else if (sender == txtEstoqueAtual || sender == txtEstoqueMinimo)
                {
                    maskedTextBox.Text = StringUtils.FormatValorUnidade(maskedTextBox.Text);
                }
            }
            ComboBox combobox = sender as ComboBox;
            if (combobox != null)
            {
                if (sender == cmbFornecedor)
                {
                    string fornecedorDigitado = cmbFornecedor.Text.ToUpper(); // Converte para maiúsculas
                    cmbFornecedor.Text = fornecedorDigitado; // Atualiza o texto no ComboBox
                    if (!FornecedorExiste(fornecedorDigitado) && !string.IsNullOrEmpty(fornecedorDigitado))
                    {
                        try
                        {
                            DialogResult result = MessageBox.Show($"Fornecedor '{fornecedorDigitado}' não Cadastrado", "Fornecedor não Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {
                                // Abre o formulário frmMarcas
                                frmFornecedores frm = new frmFornecedores();
                                frm.ShowDialog();
                                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                                // Recarregar as marcas no ComboBox
                                List<FornecedorInfo> fornecedores = fornecedorBLL.Listar();
                                // Ordenar a lista de marcas em ordem alfabética
                                fornecedores = fornecedores.OrderBy(m => m.Nome_RazaoSocial).ToList();
                                // Definir a fonte de dados do ComboBox
                                cmbFornecedor.DataSource = fornecedores;
                                cmbFornecedor.DisplayMember = "Nome_RazaoSocial";
                                cmbFornecedor.ValueMember = "IDFornecedor";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        cmbFornecedor.Text = string.Empty;
                        cmbFornecedor.Focus();
                    }
                    if (string.IsNullOrEmpty(fornecedorDigitado))
                    {
                        MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbFornecedor.Focus();
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
                        cmbModelo.Text = string.Empty;
                        cmbMarca.Text = string.Empty;
                        cmbMarca.Focus();
                    }
                    else if (string.IsNullOrEmpty(marcaDigitada))
                    {
                        MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbMarca.Focus();
                    }
                }
                if (sender == cmbModelo)
                {
                    string modeloDigitado = cmbModelo.Text.ToUpper(); // Converte para maiúsculas
                    cmbModelo.Text = modeloDigitado; // Atualiza o texto no ComboBox
                    int idMarca = Convert.ToInt32(cmbMarca.SelectedValue); // Método para obter o ID da marca selecionada
                    if (!ModeloExiste(idMarca, modeloDigitado) && modeloDigitado != string.Empty && idMarca != 0)
                    {
                        try
                        {
                            DialogResult result = MessageBox.Show($"O Modelo '{modeloDigitado}' não Existe para a Marca Selecionada. Deseja Cadastrá-lo?", "Modelo não Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {
                                // Abre o formulário frmMarcas
                                frmModelos frm = new frmModelos();
                                frm.ShowDialog();
                                if (cmbMarca.SelectedValue != null)
                                {
                                    int idmarca = Convert.ToInt32(cmbMarca.SelectedValue);
                                    CarregarModelosPorMarca(idmarca);
                                }
                            }
                            else
                            {
                                cmbModelo.Text = string.Empty;
                                cmbModelo.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (modeloDigitado == string.Empty || idMarca == 0)
                    {
                        MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbModelo.Focus();
                    }
                }
                if (sender == cmbUnidade)
                {
                    string unidadeDigitado = cmbUnidade.Text.ToUpper(); // Converte para maiúsculas
                    cmbUnidade.Text = unidadeDigitado; // Atualiza o texto no ComboBox
                    if (unidadeDigitado == string.Empty)
                    {
                        MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbUnidade.Focus();
                    }
                }
            }
        }
        private void Evento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir somente números, ponto e controle (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            // Permitir somente um ponto decimal
            if (e.KeyChar == ',' && (sender as MaskedTextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
                (txtIDProduto, "IDProduto"),
                (txtIDProdutoInterno, "IDProdutoInterno"),
                (txtIDProdutoFabricante, "IDProdutoFabricante"),
                (txtDescricao, "Descricao"),
                (cmbFornecedor, "IDFornecedor"),
                (cmbMarca, "IDMarca"),
                (cmbModelo, "IDModelo"),
                (cmbUnidade, "IDUnidade"),
                (txtPrecoCompra, "PrecoCompra"),
                (txtPrecoVenda, "PrecoVenda"),
                (txtEstoqueAtual, "EstoqueAtual"),
            };
            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
        }
        private void ConfigurarTabIndexControles()
        {
            txtIDProdutoInterno.TabIndex = 0;
            txtIDProdutoFabricante.TabIndex = 1;
            txtDescricao.TabIndex = 2;
            cmbFornecedor.TabIndex = 3;
            cmbMarca.TabIndex = 4;
            cmbModelo.TabIndex = 5;
            cmbUnidade.TabIndex = 6;
            txtPrecoCompra.TabIndex = 7;
            txtPrecoVenda.TabIndex = 8;
            txtEstoqueAtual.TabIndex = 9;
            txtEstoqueMinimo.TabIndex = 10;
            txtGarantia.TabIndex = 11;
            btnSalvar.TabIndex = 12;
        }
        private new void CarregarRegistros()
        {
            DesabilitarCampos();
            DesabilitarBotoesAcoes();
            listViewProdutos.Items.Clear();
            listViewProdutos.Columns.Clear();
            InitializeListView();
            try
            {
                ProdutoBLL produtoBLL = new ProdutoBLL();
                List<ProdutoInfo> produtos = produtoBLL.Listar();
                foreach (ProdutoInfo produto in produtos)
                {
                    ListViewItem item = new ListViewItem(produto.IDProduto.ToString());
                    item.SubItems.Add(produto.IDProdutoInterno);
                    item.SubItems.Add(produto.IDProdutoFabricante);
                    item.SubItems.Add(produto.Descricao);
                    item.SubItems.Add(produto.Fornecedor); // Usar o nome do fornecedor
                    item.SubItems.Add(produto.Marca); // Usar o nome da marca
                    item.SubItems.Add(produto.Modelo); // Usar o nome do modelo
                    item.SubItems.Add(produto.Unidade); // Usar o nome da unidade
                    item.SubItems.Add(StringUtils.FormatValorMoeda(produto.PrecoCompra.ToString()));
                    item.SubItems.Add(StringUtils.FormatValorMoeda(produto.PrecoVenda.ToString()));
                    item.SubItems.Add(StringUtils.FormatValorUnidade(produto.EstoqueAtual.ToString()));
                    item.SubItems.Add(StringUtils.FormatValorUnidade(produto.EstoqueMinimo.ToString()));
                    item.SubItems.Add(produto.DataUltimaCompra.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(produto.Garantia);
                    // Carregar a imagem (sem exibir na ListView)
                    if (produto.Imagem != null && produto.Imagem.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(produto.Imagem))
                        {
                            Image imgImagemProduto = Image.FromStream(ms);
                            // A imagem é carregada, mas não exibida na ListView
                        }
                    }
                    listViewProdutos.Items.Add(item);
                }
                // Ajustar automaticamente o tamanho das colunas ao conteúdo, mas não menor que o cabeçalho
                foreach (ColumnHeader column in listViewProdutos.Columns)
                {
                    column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize); // Ajusta a largura ao cabeçalho primeiro
                    int headerWidth = TextRenderer.MeasureText(column.Text, listViewProdutos.Font).Width + 20; // Adiciona uma margem
                    column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); // Ajusta a largura ao conteúdo
                    if (column.Width < headerWidth)
                    {
                        column.Width = headerWidth; // Garantir que a largura não fique menor que o cabeçalho
                    }
                }
                listaOriginalItens = listViewProdutos.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros: " + listViewProdutos.Items.Count;
                sortColumn = 3;
                sortAscending = true;
                listViewProdutos.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                listViewProdutos.Sort();
                listViewProdutos.Columns[sortColumn].Width = listViewProdutos.Columns[sortColumn].Width;
                // Carregar fornecedores no ComboBox
                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                List<FornecedorInfo> fornecedores = fornecedorBLL.Listar();
                cmbFornecedor.DataSource = fornecedores;
                cmbFornecedor.DisplayMember = "Nome_RazaoSocial";
                cmbFornecedor.ValueMember = "IDFornecedor";
                // Carregar marcas no ComboBox
                MarcaBLL marcaBLL = new MarcaBLL();
                List<MarcaInfo> marcas = marcaBLL.Listar();
                cmbMarca.DataSource = marcas;
                cmbMarca.DisplayMember = "Descricao";
                cmbMarca.ValueMember = "IDMarca";
                // Carregar unidades no ComboBox
                UnidadeBLL unidadeBLL = new UnidadeBLL();
                List<UnidadeInfo> unidades = unidadeBLL.Listar();
                cmbUnidade.DataSource = unidades;
                cmbUnidade.DisplayMember = "Descricao";
                cmbUnidade.ValueMember = "IDUnidade";
                tabControlProdutos.SelectedTab = tabDadosProduto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarcmbFornecedores()
        {
            cmbFornecedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFornecedor.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ConfigurarComboBoxMarcas()
        {
            cmbMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMarca.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ConfigurarComboBoxModelos()
        {
            cmbModelo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbModelo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ConfigurarComboBoxUnidades()
        {
            cmbUnidade.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUnidade.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void CmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedValue != null)
            {
                int idMarca = Convert.ToInt32(cmbMarca.SelectedValue);
                CarregarModelosPorMarca(idMarca);
            }
        }
        private bool FornecedorExiste(string nome_RazaoSocial)
        {
            FornecedorBLL fornecedorBLL = new FornecedorBLL();
            List<FornecedorInfo> fornecedores = fornecedorBLL.Listar();
            return fornecedores.Any(f => f.Nome_RazaoSocial.Equals(nome_RazaoSocial, StringComparison.OrdinalIgnoreCase));
        }
        private bool MarcaExiste(string descricao)
        {
            MarcaBLL marcaBLL = new MarcaBLL();
            List<MarcaInfo> marcas = marcaBLL.Listar();
            return marcas.Any(m => m.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }
        private bool ModeloExiste(int idMarca, string descricao)
        {
            ModeloDAL modeloDAL = new ModeloDAL();
            List<ModeloInfo> modelos = modeloDAL.ListarPorMarca(idMarca);
            return modelos.Any(mo => mo.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }
        private void CarregarModelosPorMarca(int idMarca)
        {
            ModeloBLL modeloBLL = new ModeloBLL();
            List<ModeloInfo> modelos = modeloBLL.ListarPorMarca(idMarca);
            if (modelos.Count > 0)
            {
                cmbModelo.DataSource = modelos;
                cmbModelo.DisplayMember = "Descricao";
                cmbModelo.ValueMember = "IDModelo";
            }
            else
            {
                cmbModelo.DataSource = null;
                cmbModelo.Items.Clear();
            }
        }
        private void ListViewProdutos_Click(object sender, EventArgs e)
        {
            escPressed = false; // Reseta a variável de controle
            if (listViewProdutos.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewProdutos.SelectedItems[0];
                txtIDProduto.Text = item.SubItems[0].Text;
                txtIDProdutoInterno.Text = item.SubItems[1].Text;
                txtIDProdutoFabricante.Text = item.SubItems[2].Text;
                txtDescricao.Text = item.SubItems[3].Text;
                string fornecedorNome = item.SubItems[4].Text;
                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                List<FornecedorInfo> fornecedores = fornecedorBLL.Listar();
                FornecedorInfo fornecedor = fornecedores.FirstOrDefault(f => f.Nome_RazaoSocial == fornecedorNome);
                if (fornecedor != null)
                {
                    cmbFornecedor.SelectedValue = fornecedor.IDFornecedor;
                }
                string marcaNome = item.SubItems[5].Text; // Índice da coluna da marca
                MarcaBLL marcaBLL = new MarcaBLL();
                List<MarcaInfo> marcas = marcaBLL.Listar();
                MarcaInfo marca = marcas.FirstOrDefault(m => m.Descricao == marcaNome);
                if (marca != null)
                {
                    cmbMarca.SelectedValue = marca.IDMarca;
                }
                string modeloNome = item.SubItems[6].Text; // Índice da coluna da marca
                ModeloBLL modeloBLL = new ModeloBLL();
                List<ModeloInfo> modelos = modeloBLL.Listar();
                ModeloInfo modelo = modelos.FirstOrDefault(mo => mo.Descricao == modeloNome);
                if (modelo != null)
                {
                    cmbModelo.SelectedValue = modelo.IDModelo;
                }
                string unidadeNome = item.SubItems[7].Text; // Índice da coluna da marca
                UnidadeBLL unidadeBLL = new UnidadeBLL();
                List<UnidadeInfo> unidades = unidadeBLL.Listar();
                UnidadeInfo unidade = unidades.FirstOrDefault(u => u.Descricao == unidadeNome);
                if (unidade != null)
                {
                    cmbUnidade.SelectedValue = unidade.IDUnidade;
                }
                txtPrecoCompra.Text = item.SubItems[8].Text;
                txtPrecoVenda.Text = item.SubItems[9].Text;
                txtEstoqueAtual.Text = item.SubItems[10].Text;
                txtEstoqueMinimo.Text = item.SubItems[11].Text;
                txtDataUltimaCompra.Text = item.SubItems[12].Text;
                txtGarantia.Text = item.SubItems[13].Text;
                // Exibir a imagem no PictureBox
                ProdutoBLL produtoBLL = new ProdutoBLL();
                ProdutoInfo produto = produtoBLL.GetProduto(Convert.ToInt32(item.SubItems[0].Text));
                if (produto.Imagem != null && produto.Imagem.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(produto.Imagem))
                    {
                        imgImagemProduto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    imgImagemProduto.Image = null;
                }
                HabilitarBotoesAlterarExcluir();
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            HabilitarBotaoSalvar();
            txtIDProduto.Text = "0";
            bNovo = true;
            HabilitarCampos("Novo");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DBSetupBLL dbSetupBLL = new DBSetupBLL();
            ProdutoBLL produtoBLL = new ProdutoBLL();

            // Verificar se algum campo obrigatório está vazio
            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool isAtualizacao = false;
            if (!string.IsNullOrEmpty(txtIDProduto.Text))
            {
                int idProduto = Convert.ToInt32(txtIDProduto.Text);
                isAtualizacao = produtoBLL.GetProduto(idProduto) != null;
            }
            if (!isAtualizacao)
            {
                string idProdutoInterno = txtIDProdutoInterno.Text;
                if (dbSetupBLL.VerificarSeCadastrado(idProdutoInterno, "DBProdutos", "IDProdutoInterno"))
                {
                    MessageBox.Show("Código de Produto Interno já cadastrado. Favor verificar!", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string idProdutoFabricante = txtIDProdutoFabricante.Text;
                if (dbSetupBLL.VerificarSeCadastrado(idProdutoFabricante, "DBProdutos", "IDProdutoFabricante"))
                {
                    MessageBox.Show("Código de Produto do Fabricante já cadastrado. Favor verificar!", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Esse Produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ProdutoInfo produto = new ProdutoInfo
                    {
                        IDProdutoInterno = txtIDProdutoInterno.Text,
                        IDProdutoFabricante = txtIDProdutoFabricante.Text,
                        Descricao = txtDescricao.Text,
                        IDFornecedor = Convert.ToInt32(cmbFornecedor.SelectedValue),
                        IDMarca = Convert.ToInt32(cmbMarca.SelectedValue),
                        IDModelo = Convert.ToInt32(cmbModelo.SelectedValue),
                        IDUnidade = Convert.ToInt32(cmbUnidade.SelectedValue),
                        PrecoCompra = Convert.ToDecimal(StringUtils.SemFormatacao(txtPrecoCompra.Text)),
                        PrecoVenda = Convert.ToDecimal(StringUtils.SemFormatacao(txtPrecoVenda.Text)),
                        EstoqueAtual = Convert.ToDecimal(StringUtils.SemFormatacao(txtEstoqueAtual.Text)),
                        EstoqueMinimo = Convert.ToDecimal(StringUtils.SemFormatacao(txtEstoqueMinimo.Text)),
                        DataUltimaCompra = DateTime.Now,
                        Garantia = txtGarantia.Text,
                        Imagem = ImageToByteArray(imgImagemProduto.Image)
                    };
                    InserirProduto(produto);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Realizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ProdutoInfo produto = new ProdutoInfo
                    {
                        IDProduto = int.Parse(txtIDProduto.Text),
                        IDProdutoInterno = txtIDProdutoInterno.Text,
                        IDProdutoFabricante = txtIDProdutoFabricante.Text,
                        Descricao = txtDescricao.Text,
                        IDFornecedor = Convert.ToInt32(cmbFornecedor.SelectedValue),
                        IDMarca = Convert.ToInt32(cmbMarca.SelectedValue),
                        IDModelo = Convert.ToInt32(cmbModelo.SelectedValue),
                        IDUnidade = Convert.ToInt32(cmbUnidade.SelectedValue),
                        PrecoCompra = Convert.ToDecimal(StringUtils.SemFormatacao(txtPrecoCompra.Text)),
                        PrecoVenda = Convert.ToDecimal(StringUtils.SemFormatacao(txtPrecoVenda.Text)),
                        EstoqueAtual = Convert.ToDecimal(StringUtils.SemFormatacao(txtEstoqueAtual.Text)),
                        EstoqueMinimo = Convert.ToDecimal(StringUtils.SemFormatacao(txtEstoqueMinimo.Text)),
                        Garantia = txtGarantia.Text,
                        Imagem = ImageToByteArray(imgImagemProduto.Image)
                    };
                    AtualizarProduto(produto);
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
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDProduto.Text, out int produtoID))
                {
                    ExcluirProduto(produtoID);
                }
                else
                {
                    MessageBox.Show("ID inválido. Por favor, insira um número inteiro.", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtIDProdutoInterno.Enabled = false;
            txtIDProdutoFabricante.Enabled = false;
            txtDescricao.Enabled = false;
            cmbFornecedor.Enabled = false;
            cmbMarca.Enabled = false;
            cmbModelo.Enabled = false;
            cmbUnidade.Enabled = false;
            txtPrecoCompra.Enabled = false;
            txtPrecoVenda.Enabled = false;
            txtEstoqueAtual.Enabled = false;
            txtEstoqueMinimo.Enabled = false;
            txtDataUltimaCompra.Enabled = false;
            txtGarantia.Enabled = false;
            listViewProdutos.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCampos(string buttonPressed)
        {
            txtIDProdutoFabricante.Enabled = true;
            txtDescricao.Enabled = true;
            cmbFornecedor.Enabled = true;
            cmbMarca.Enabled = true;
            cmbModelo.Enabled = true;
            cmbUnidade.Enabled = true;
            txtPrecoCompra.Enabled = true;
            txtPrecoVenda.Enabled = true;
            txtEstoqueAtual.Enabled = true;
            txtEstoqueMinimo.Enabled = true;
            txtGarantia.Enabled = true;
            listViewProdutos.Enabled = false;
            txtPesquisaListView.Enabled = false;
            switch (buttonPressed)
            {
                case "Novo":
                    txtDataUltimaCompra.Text = DateTime.Now.ToString();
                    txtIDProdutoInterno.Enabled = true;
                    txtIDProdutoInterno.Focus();
                    break;
                case "Salvar":
                    // Adicionar ações específicas para "Salvar" se necessário
                    break;
                case "Alterar":
                    txtIDProdutoFabricante.Focus();
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
            btnInserirImagem.Enabled = false;
            btnExcluirImagem.Enabled = false;
            btnFechar.Enabled = true;
            btnNovo.Enabled = true;
            btnNovo.Focus();
        }
        private void HabilitarBotaoSalvar()
        {
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnInserirImagem.Enabled = true;
            btnExcluirImagem.Enabled = true;
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
        private new void LimparCampos()
        {
            txtIDProdutoInterno.Clear();
            txtIDProdutoFabricante.Clear();
            txtDescricao.Clear();
			cmbFornecedor.SelectedIndex = -1;
			cmbMarca.SelectedIndex = -1;
			cmbModelo.SelectedIndex = -1;
			cmbUnidade.SelectedIndex = -1;
			txtPrecoCompra.Clear();
            txtPrecoVenda.Clear();
            txtEstoqueAtual.Clear();
            txtEstoqueMinimo.Clear();
            txtDataUltimaCompra.Clear();
            txtGarantia.Clear();
            imgImagemProduto.Image = null;
            txtPesquisaListView.Clear();
            bNovo = false;
        }
        static void InserirProduto(ProdutoInfo Produto)
        {
            try
            {
                ProdutoBLL ProdutoBLL = new ProdutoBLL();
                ProdutoBLL.InserirProduto(Produto);
                MessageBox.Show("Produto Inserido com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarProduto(ProdutoInfo Produto)
        {
            try
            {
                ProdutoBLL ProdutoBLL = new ProdutoBLL();
                ProdutoBLL.AtualizarProduto(Produto);
                MessageBox.Show("Produto Atualizado com Sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirProduto(int idProduto)
        {
            try
            {
                ProdutoBLL ProdutoBLL = new ProdutoBLL();
                ProdutoBLL.ExcluirProduto(idProduto);
                MessageBox.Show("Produto Excluído com Sucesso!", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                btnLocal.MouseEnter += Button_MouseEnter;
                btnLocal.MouseLeave += Button_MouseLeave;
                btnWebcam.MouseEnter += Button_MouseEnter;
                btnWebcam.MouseLeave += Button_MouseLeave;
                btnFechar.MouseEnter += Button_MouseEnter;
                btnFechar.MouseLeave += Button_MouseLeave;

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
                    imgImagemProduto.Image = Image.FromFile(filePath);
                    imgImagemProduto.SizeMode = PictureBoxSizeMode.StretchImage;
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
                                imgImagemProduto.Image = Image.FromStream(pngImage);
                        }

                        imgImagemProduto.SizeMode = PictureBoxSizeMode.StretchImage;
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
            imgImagemProduto.Image = null;
        }
        private void imgImagemProduto_Click(object sender, EventArgs e)
        {
            imgImagemProduto.Cursor = Cursors.AppStarting;
            // Obtém o objeto selecionado no ComboBox
            var modeloInfo = cmbModelo.SelectedItem as ModeloInfo;
            if (modeloInfo != null)
            {
                // Obtém a descrição completa do modelo
                string modelo = modeloInfo.Descricao;
                // Codifica a descrição para ser usada na URL
                string encodedModelo = Uri.EscapeDataString(modelo);
                // Cria a URL de pesquisa no Google
                string url = $"https://www.google.com/search?q={encodedModelo}";
                // Abre o navegador padrão com a URL de pesquisa
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            else
            {
                MessageBox.Show("Por favor, selecione um modelo.", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            imgImagemProduto.Cursor = Cursors.Hand;
        }
    }
}

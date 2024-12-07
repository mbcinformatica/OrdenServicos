using ProjetoTeste.BLL;
using ProjetoTeste.Forms;
using ProjetoTeste.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoTeste
{
    public partial class frmModelos : BaseForm
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
        public frmModelos()
        {
            InitializeComponent();
            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new System.Windows.Forms.PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlModelos); // Chama o método para inicializar o TabControl
            erpProvider = new ErrorProvider();
            ConfigurarComboBoxMarcas();
            // Configurar eventos dos TextBoxes para maiúsculas
            ConfigurarTextBox();
            // Configurar TabIndex dos Controles
            ConfigurarTabIndexControles();
            // Configurando os Key para os TextBox
            CarregaKey();
            CarregarRegistros();

        }
        private void InitializeListView()
        {
            // Configurar a ListView
            listViewModelos.View = View.Details;
            listViewModelos.FullRowSelect = true;
            listViewModelos.OwnerDraw = true; // Permitir desenho personalizado
            listViewModelos.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewModelos_DrawColumnHeader);
            listViewModelos.DrawItem += new DrawListViewItemEventHandler(listViewModelos_DrawItem);
            listViewModelos.DrawSubItem += new DrawListViewSubItemEventHandler(listViewModelos_DrawSubItem);
            // Adicionar colunas
            listViewModelos.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewModelos.Columns.Add("  MARCA", 250, HorizontalAlignment.Left);
            listViewModelos.Columns.Add("  DESCRIÇÃO", -1, HorizontalAlignment.Left);
            // Adicionar evento de clique no cabeçalho da coluna
            listViewModelos.ColumnClick += new ColumnClickEventHandler(ListViewModelos_ColumnClick);
        }
        private void ListViewModelos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != 1 && e.Column != 2)
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
                listViewModelos.Columns[oldSortColumn].Width = listViewModelos.Columns[oldSortColumn].Width;
            }
            listViewModelos.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewModelos.Sort();
            // Forçar redesenho da nova coluna
            listViewModelos.Columns[sortColumn].Width = listViewModelos.Columns[sortColumn].Width;
            listViewModelos.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
            PesquisarListView(txtPesquisaListView.Text, listViewModelos, sortColumn);
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
        private void listViewModelos_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
        private void listViewModelos_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewModelos_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewModelos.Columns[e.ColumnIndex].Text == "ID")
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
            txtDescricao.KeyDown += Evento_KeyDown;
            txtPesquisaListView.KeyDown += Evento_KeyDown;
            cmbMarca.KeyDown += Evento_KeyDown;
            listViewModelos.KeyDown += Evento_KeyDown;

            cmbMarca.Leave += Evento_Leave; // Adiciona o evento Leave
            txtDescricao.Leave += Evento_Leave;

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

            listViewModelos.Click += ListViewModelos_Click;
        }
        private void ConfigurarTabIndexControles()
        {

            cmbMarca.TabIndex = 0;
            txtDescricao.TabIndex = 1;
            btnSalvar.TabIndex = 2;
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
        private bool MarcaExiste(string descricao)
        {
            MarcaBLL marcaBLL = new MarcaBLL();
            List<MarcaInfo> marcas = marcaBLL.Listar();
            return marcas.Any(m => m.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }
        private void ConfigurarComboBoxMarcas()
        {
            cmbMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMarca.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Evento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Impede o som de "beep"
                SelectNextControl((Control)sender, true, true, true, true);
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
                if (sender == txtDescricao && !string.IsNullOrEmpty(txtDescricao.Text))
                {
                    tabControlModelos.SelectedTab = tabInformacoesAdicionais;
                }
            }
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
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
                else if (string.IsNullOrEmpty(marcaDigitada))
                {
                    cmbMarca.Focus();
                }


            }
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
                 (cmbMarca, "IDMarca"),
                 (txtDescricao, "Descricao"),
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
            listViewModelos.Items.Clear();
            listViewModelos.Columns.Clear();
            InitializeListView();
            try
            {
                ModeloBLL modeloBLL = new ModeloBLL();
                List<ModeloInfo> modelos = modeloBLL.Listar();
                foreach (ModeloInfo modelo in modelos)
                {
                    ListViewItem item = new ListViewItem(modelo.IDModelo.ToString());
                    item.SubItems.Add(modelo.Marca); // Usar o nome da marca
                    item.SubItems.Add(modelo.Descricao);
                    listViewModelos.Items.Add(item);
                }

                listaOriginalItens = listViewModelos.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros: " + listViewModelos.Items.Count;
                sortColumn = 2;
                sortAscending = true;
                listViewModelos.Sort();
                listViewModelos.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
       //         listViewModelos.Columns[sortColumn].Width = listViewModelos.Columns[sortColumn].Width;
                ajustaLarguraCabecalho(listViewModelos);
                MarcaBLL marcaBLL = new MarcaBLL();
                List<MarcaInfo> marcas = marcaBLL.Listar();
                cmbMarca.DataSource = marcas;
                cmbMarca.DisplayMember = "Descricao";
                cmbMarca.ValueMember = "IDMarca";
                tabControlModelos.SelectedTab = tabDadosModelo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LimparCampos();
        }
        private void ListViewModelos_Click(object sender, EventArgs e)
        {
            escPressed = false; // Reseta a variável de controle
            try
            {
                if (listViewModelos.SelectedItems.Count > 0)
                {
                    ListViewItem item = listViewModelos.SelectedItems[0];
                    txtIDModelo.Text = item.SubItems[0].Text;
                    string marcaNome = item.SubItems[1].Text; // Índice da coluna da marca
                    MarcaBLL marcaBLL = new MarcaBLL();
                    List<MarcaInfo> marcas = marcaBLL.Listar();
                    MarcaInfo marca = marcas.FirstOrDefault(m => m.Descricao == marcaNome);
                    if (marca != null)
                    {
                        cmbMarca.SelectedValue = marca.IDMarca;
                    }
                    txtDescricao.Text = item.SubItems[2].Text;
                    HabilitarBotoesAlterarExcluir();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            HabilitarBotaoSalvar();
            txtIDModelo.Text = "0";
            bNovo = true;
            HabilitarCampos("Novo");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ModeloBLL modeloBLL = new ModeloBLL();
            // Verificar se algum campo obrigatório está vazio
            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            bool isAtualizacao = false;
            if (!string.IsNullOrEmpty(txtIDModelo.Text))
            {
                int idModelo = Convert.ToInt32(txtIDModelo.Text);
                isAtualizacao = modeloBLL.GetModelo(idModelo) != null;
            }
            if (!isAtualizacao)
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Esse Modelo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ModeloInfo modelo = new ModeloInfo
                    {
                        IDMarca = Convert.ToInt32(cmbMarca.SelectedValue),
                        Descricao = txtDescricao.Text,
                    };
                    InserirModelo(modelo);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Realizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ModeloInfo modelo = new ModeloInfo
                    {
                        IDModelo = int.Parse(txtIDModelo.Text),
                        IDMarca = Convert.ToInt32(cmbMarca.SelectedValue),
                        Descricao = txtDescricao.Text,
                    };
                    AtualizarModelo(modelo);
                }
            }
            CarregarRegistros();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            HabilitarBotaoSalvar();
            HabilitarCampos("Alterar");
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Modelo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDModelo.Text, out int modeloID))
                {
                    ExcluirModelo(modeloID);
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
            Close();
        }
        private void DesabilitarCampos()
        {
            cmbMarca.Enabled = false;
            txtDescricao.Enabled = false;
            listViewModelos.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCampos(string buttonPressed)
        {
            cmbMarca.Enabled = true;
            txtDescricao.Enabled = true;
            listViewModelos.Enabled = false;
            txtPesquisaListView.Enabled = false;
            switch (buttonPressed)
            {
                case "Novo":
                    cmbMarca.Focus();
                    break;
                case "Salvar":
                    // Adicionar ações específicas para "Salvar" se necessário
                    break;
                case "Alterar":
                    cmbMarca.Focus();
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
            txtIDModelo.Clear();
            cmbMarca.Text = "";
            txtDescricao.Clear();
            txtPesquisaListView.Clear();
            bNovo = false;
        }
        static void InserirModelo(ModeloInfo Modelo)
        {
            try
            {
                ModeloBLL ModeloBLL = new ModeloBLL();
                ModeloBLL.InserirModelo(Modelo);
                MessageBox.Show("Modelo Inserido com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarModelo(ModeloInfo Modelo)
        {
            try
            {
                ModeloBLL ModeloBLL = new ModeloBLL();
                ModeloBLL.AtualizarModelo(Modelo);
                MessageBox.Show("Modelo Atualizado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirModelo(int idModelo)
        {
            try
            {
                ModeloBLL ModeloBLL = new ModeloBLL();
                ModeloBLL.ExcluirModelo(idModelo);
                MessageBox.Show("Modelo Excluído com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
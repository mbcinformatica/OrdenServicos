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
    public partial class frmMarcas : BaseForm
    {

        private int sortColumn = -1;
        private bool sortAscending = true;
        private Color defaultHeaderBackColor = Color.DarkTurquoise;
        private Color clickedHeaderBackColor = Color.CadetBlue;
        private (Control, string)[] camposObrigatorios;
        private List<ListViewItem> listaOriginalItens = new List<ListViewItem>();

        public frmMarcas()
        {
            InitializeComponent();
            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new System.Windows.Forms.PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlMarcas); // Chama o método para inicializar o TabControl
            erpProvider = new ErrorProvider();
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
            listViewMarcas.View = View.Details;
            listViewMarcas.FullRowSelect = true;
            listViewMarcas.OwnerDraw = true; // Permitir desenho personalizado
            listViewMarcas.DrawColumnHeader += listViewMarcas_DrawColumnHeader;
            listViewMarcas.DrawItem += listViewMarcas_DrawItem;
            listViewMarcas.DrawSubItem += listViewMarcas_DrawSubItem;
            listViewMarcas.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewMarcas.Columns.Add("DESCRIÇÃO", 120, HorizontalAlignment.Left);
            listViewMarcas.ColumnClick += ListViewMarcas_ColumnClick;
            listViewMarcas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewMarcas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void ListViewMarcas_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != 1)
                return; // Ignorar cliques em outras colunas

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
            listViewMarcas.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewMarcas.Sort();

            listViewMarcas.Columns[sortColumn].Width = listViewMarcas.Columns[sortColumn].Width;
            listViewMarcas.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
            PesquisarListView(txtPesquisaListView.Text, listViewMarcas, sortColumn);
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
        // Método para desenhar cabeçalhos das colunas da ListView
        private void listViewMarcas_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
            }
            using (Pen gridLinePen = new Pen(Color.Black, 2)) // Define a cor e a espessura das linhas do cabeçalho
            {
                e.Graphics.DrawRectangle(gridLinePen, e.Bounds);
            }
        }
        private void listViewMarcas_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewMarcas_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewMarcas.Columns[e.ColumnIndex].Text == "ID")
                {
                    sf.Alignment = StringAlignment.Center; // Alinhar subitens numéricos no centro
                }
                else
                {
                    sf.Alignment = StringAlignment.Near; // Alinhar subitens de texto à esquerda
                }
                e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, Brushes.Black, e.Bounds, sf);
            }
        }
        private void CarregaKey()
        {
            txtDescricao.KeyDown += Evento_KeyDown;
            txtPesquisaListView.KeyDown += Evento_KeyDown;
            listViewMarcas.KeyDown += Evento_KeyDown;

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
            listViewMarcas.Click += ListViewMarcas_Click;
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
                if (sender == txtDescricao && !string.IsNullOrEmpty(txtDescricao.Text))
                {
                    tabControlMarcas.SelectedTab = tabInformacoesAdicionais;
                }
            }
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
                 (txtDescricao, "Descricao"),
            };
            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
        }
        private void ConfigurarTabIndexControles()
        {
            txtDescricao.TabIndex = 0;
            btnSalvar.TabIndex = 1;
        }
        private void CarregarRegistros()
        {
            DesabilitarCampos();
            DesabilitarBotoesAcoes();
            listViewMarcas.Items.Clear();
            listViewMarcas.Columns.Clear();
            InitializeListView();
            try
            {
                MarcaBLL marcaBLL = new MarcaBLL();
                List<MarcaInfo> marcas = marcaBLL.Listar();
                foreach (MarcaInfo marca in marcas)
                {
                    ListViewItem item = new ListViewItem(marca.IDMarca.ToString());
                    item.SubItems.Add(marca.Descricao);
                    listViewMarcas.Items.Add(item);
                }
                // Ajusta a largura das colunas
                foreach (ColumnHeader column in listViewMarcas.Columns)
                {
                    {
                        if (column.Text == "ID")
                        {
                            column.Width = 50; // Ignorar cliques em outras colunas
                        }
                        else
                        {
                            column.Width = 700; // Ignorar cliques em outras colunas
                        }
                    }
                }
                listaOriginalItens = listViewMarcas.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros: " + listViewMarcas.Items.Count;
                sortColumn = 1;
                sortAscending = true;

                listViewMarcas.Sort();
                listViewMarcas.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                listViewMarcas.Columns[sortColumn].Width = listViewMarcas.Columns[sortColumn].Width;
                tabControlMarcas.SelectedTab = tabDadosMarca;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListViewMarcas_Click(object sender, EventArgs e)
        {
            escPressed = false;
            if (listViewMarcas.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewMarcas.SelectedItems[0];
                txtIDMarca.Text = item.SubItems[0].Text;
                txtDescricao.Text = item.SubItems[1].Text;
                HabilitarBotoesAlterarExcluir();
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            HabilitarBotaoSalvar();
            txtIDMarca.Text = "0";
            bNovo = true;
            HabilitarCampos("Novo");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            MarcaBLL marcaBLL = new MarcaBLL();
            // Verificar se algum campo obrigatório está vazio
            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            bool isAtualizacao = false;
            if (!string.IsNullOrEmpty(txtIDMarca.Text))
            {
                int idMarca = Convert.ToInt32(txtIDMarca.Text);
                isAtualizacao = marcaBLL.GetMarca(idMarca) != null;
            }
            if (!isAtualizacao)
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Esse Marca?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MarcaInfo marca = new MarcaInfo
                    {
                        Descricao = txtDescricao.Text,
                    };
                    InserirMarca(marca);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Realizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MarcaInfo marca = new MarcaInfo
                    {
                        IDMarca = int.Parse(txtIDMarca.Text),
                        Descricao = txtDescricao.Text,
                    };
                    AtualizarMarca(marca);
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
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Marca?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDMarca.Text, out int marcaID))
                {
                    ExcluirMarca(marcaID);
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
            txtDescricao.Enabled = false;
            listViewMarcas.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCampos(string buttonPressed)
        {
            txtDescricao.Enabled = true;
            listViewMarcas.Enabled = false;
            txtPesquisaListView.Enabled = false;
            switch (buttonPressed)
            {
                case "Novo":
                    txtDescricao.Focus();
                    break;
                case "Salvar":
                    // Adicionar ações específicas para "Salvar" se necessário
                    break;
                case "Alterar":
                    txtDescricao.Focus();
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
            txtIDMarca.Clear();
            txtDescricao.Clear();
            txtPesquisaListView.Clear();
            bNovo = false;
        }
        static void InserirMarca(MarcaInfo Marca)
        {
            try
            {
                MarcaBLL MarcaBLL = new MarcaBLL();
                MarcaBLL.InserirMarca(Marca);
                MessageBox.Show("Marca Inserido com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarMarca(MarcaInfo Marca)
        {
            try
            {
                MarcaBLL MarcaBLL = new MarcaBLL();
                MarcaBLL.AtualizarMarca(Marca);
                MessageBox.Show("Marca Atualizado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirMarca(int idMarca)
        {
            try
            {
                MarcaBLL MarcaBLL = new MarcaBLL();
                MarcaBLL.ExcluirMarca(idMarca);
                MessageBox.Show("Marca Excluído com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
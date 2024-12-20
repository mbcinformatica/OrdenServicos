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
    public partial class frmUnidades : BaseForm
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
        public frmUnidades()
        {
            InitializeComponent();
            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new System.Windows.Forms.PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlUnidades); // Chama o método para inicializar o TabControl
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
            // Configurar a ListView
            listViewUnidades.View = View.Details;
            listViewUnidades.FullRowSelect = true;
            listViewUnidades.OwnerDraw = true; // Permitir desenho personalizado
            listViewUnidades.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewUnidades_DrawColumnHeader);
            listViewUnidades.DrawItem += new DrawListViewItemEventHandler(listViewUnidades_DrawItem);
            listViewUnidades.DrawSubItem += new DrawListViewSubItemEventHandler(listViewUnidades_DrawSubItem);
            // Adicionar colunas
            listViewUnidades.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewUnidades.Columns.Add("  DESCRIÇÃO", 120, HorizontalAlignment.Left);
            // Adicionar evento de clique no cabeçalho da coluna
            listViewUnidades.ColumnClick += new ColumnClickEventHandler(ListViewUnidades_ColumnClick);
            listViewUnidades.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewUnidades.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void ListViewUnidades_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != 1)
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

            listViewUnidades.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewUnidades.Sort();
            // Forçar redesenho da nova coluna
            listViewUnidades.Columns[sortColumn].Width = listViewUnidades.Columns[sortColumn].Width;
            listViewUnidades.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
            PesquisarListView(txtPesquisaListView.Text, listViewUnidades, sortColumn);
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
        private void listViewUnidades_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
        private void listViewUnidades_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewUnidades_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewUnidades.Columns[e.ColumnIndex].Text == "ID")
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
            listViewUnidades.KeyDown += Evento_KeyDown;

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
            listViewUnidades.Click += ListViewUnidades_Click;
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
                    tabControlUnidades.SelectedTab = tabInformacoesAdicionais;
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
            listViewUnidades.Items.Clear();
            listViewUnidades.Columns.Clear();
            InitializeListView();
            try
            {
                UnidadeBLL marcaBLL = new UnidadeBLL();
                List<UnidadeInfo> unidades = marcaBLL.Listar();
                foreach (UnidadeInfo marca in unidades)
                {
                    ListViewItem item = new ListViewItem(marca.IDUnidade.ToString());
                    item.SubItems.Add(marca.Descricao);
                    listViewUnidades.Items.Add(item);
                }
                // Ajusta a largura das colunas
                foreach (ColumnHeader column in listViewUnidades.Columns)
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
                listaOriginalItens = listViewUnidades.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros: " + listViewUnidades.Items.Count;
                sortColumn = 1;
                sortAscending = true;

                listViewUnidades.Sort();
                listViewUnidades.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                listViewUnidades.Columns[sortColumn].Width = listViewUnidades.Columns[sortColumn].Width;
                tabControlUnidades.SelectedTab = tabDadosUnidade;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListViewUnidades_Click(object sender, EventArgs e)
        {
            escPressed = false;
            if (listViewUnidades.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewUnidades.SelectedItems[0];
                txtIDUnidade.Text = item.SubItems[0].Text;
                txtDescricao.Text = item.SubItems[1].Text;
                HabilitarBotoesAlterarExcluir();
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            HabilitarBotaoSalvar();
            txtIDUnidade.Text = "0";
            bNovo = true;
            HabilitarCampos("Novo");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            UnidadeBLL marcaBLL = new UnidadeBLL();
            // Verificar se algum campo obrigatório está vazio
            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            bool isAtualizacao = false;
            if (!string.IsNullOrEmpty(txtIDUnidade.Text))
            {
                int idUnidade = Convert.ToInt32(txtIDUnidade.Text);
                isAtualizacao = marcaBLL.GetUnidade(idUnidade) != null;
            }
            if (!isAtualizacao)
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Esse Unidade?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UnidadeInfo marca = new UnidadeInfo
                    {
                        Descricao = txtDescricao.Text,
                    };
                    InserirUnidade(marca);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Realizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UnidadeInfo marca = new UnidadeInfo
                    {
                        IDUnidade = int.Parse(txtIDUnidade.Text),
                        Descricao = txtDescricao.Text,
                    };
                    AtualizarUnidade(marca);
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
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Unidade?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDUnidade.Text, out int marcaID))
                {
                    ExcluirUnidade(marcaID);
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
            listViewUnidades.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCampos(string buttonPressed)
        {
            txtDescricao.Enabled = true;
            listViewUnidades.Enabled = false;
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
            txtIDUnidade.Clear();
            txtDescricao.Clear();
            txtPesquisaListView.Clear();
            bNovo = false;
        }
        static void InserirUnidade(UnidadeInfo Unidade)
        {
            try
            {
                UnidadeBLL UnidadeBLL = new UnidadeBLL();
                UnidadeBLL.InserirUnidade(Unidade);
                MessageBox.Show("Unidade Inserido com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarUnidade(UnidadeInfo Unidade)
        {
            try
            {
                UnidadeBLL UnidadeBLL = new UnidadeBLL();
                UnidadeBLL.AtualizarUnidade(Unidade);
                MessageBox.Show("Unidade Atualizado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirUnidade(int idUnidade)
        {
            try
            {
                UnidadeBLL UnidadeBLL = new UnidadeBLL();
                UnidadeBLL.ExcluirUnidade(idUnidade);
                MessageBox.Show("Unidade Excluído com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
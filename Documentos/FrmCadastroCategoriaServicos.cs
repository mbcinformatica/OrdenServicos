using System;
using System.Drawing;
using System.Windows.Forms;
using ProjetoTeste.Model;
using ProjetoTeste.BLL;
using System.Collections.Generic;
using ProjetoTeste.Forms;
using System.Linq;
using System.Collections;
namespace ProjetoTeste
{
    public partial class frmCategoriaCategoriaServicos : BaseForm
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
        public frmCategoriaCategoriaServicos()
        {
            InitializeComponent();
            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new System.Windows.Forms.PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlCategoriaCategoriaServicos); // Chama o método para inicializar o TabControl
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
            listViewCategoriaServico.View = View.Details;
            listViewCategoriaServico.FullRowSelect = true;
            listViewCategoriaServico.OwnerDraw = true; // Permitir desenho personalizado
            listViewCategoriaServico.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewCategoriaServico_DrawColumnHeader);
            listViewCategoriaServico.DrawItem += new DrawListViewItemEventHandler(listViewCategoriaServico_DrawItem);
            listViewCategoriaServico.DrawSubItem += new DrawListViewSubItemEventHandler(listViewCategoriaServico_DrawSubItem);
            // Adicionar colunas
            listViewCategoriaServico.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewCategoriaServico.Columns.Add("  DESCRIÇÃO", 120, HorizontalAlignment.Left);
            // Adicionar evento de clique no cabeçalho da coluna
            listViewCategoriaServico.ColumnClick += new ColumnClickEventHandler(ListViewCategoriaServico_ColumnClick);
            listViewCategoriaServico.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewCategoriaServico.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void ListViewCategoriaServico_ColumnClick(object sender, ColumnClickEventArgs e)
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

            listViewCategoriaServico.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewCategoriaServico.Sort();
            // Forçar redesenho da nova coluna
            listViewCategoriaServico.Columns[sortColumn].Width = listViewCategoriaServico.Columns[sortColumn].Width;
            listViewCategoriaServico.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
            PesquisarListView(txtPesquisaListView.Text, listViewCategoriaServico, sortColumn);
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
        private void listViewCategoriaServico_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
        private void listViewCategoriaServico_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewCategoriaServico_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewCategoriaServico.Columns[e.ColumnIndex].Text == "ID")
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
            listViewCategoriaServico.KeyDown += Evento_KeyDown;

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
            listViewCategoriaServico.Click += ListViewCategoriaServico_Click;
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
                    tabControlCategoriaServico.SelectedTab = tabInformacoesAdicionais;
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
            listViewCategoriaServico.Items.Clear();
            listViewCategoriaServico.Columns.Clear();
            InitializeListView();
            try
            {
                CategoriaServicoBLL categoriaCategoriaServicoBLL = new CategoriaServicoBLL();
                List<CategoriaServicoInfo> categoriaCategoriaServicos = categoriaCategoriaServicoBLL.Listar();
                foreach (CategoriaServicoInfo categoriaCategoriaServico in categoriaCategoriaServicos)
                {
                    ListViewItem item = new ListViewItem(categoriaCategoriaServico.IDCategoriaServico.ToString());
                    item.SubItems.Add(categoriaCategoriaServico.Descricao);
                    listViewCategoriaServico.Items.Add(item);
                }
                // Ajusta a largura das colunas
                foreach (ColumnHeader column in listViewCategoriaServico.Columns)
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
                listaOriginalItens = listViewCategoriaServico.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros: " + listViewCategoriaServico.Items.Count;
                sortColumn = 1;
                sortAscending = true;

                listViewCategoriaServico.Sort();
                listViewCategoriaServico.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                listViewCategoriaServico.Columns[sortColumn].Width = listViewCategoriaServico.Columns[sortColumn].Width;
                tabControlCategoriaServico.SelectedTab = tabDadosCategoriaServico;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListViewCategoriaServico_Click(object sender, EventArgs e)
        {
            escPressed = false;
            if (listViewCategoriaServico.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewCategoriaServico.SelectedItems[0];
                txtIDCategoriaServico.Text = item.SubItems[0].Text;
                txtDescricao.Text = item.SubItems[1].Text;
                HabilitarBotoesAlterarExcluir();
                txtPesquisaListView.Focus();
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            HabilitarBotaoSalvar();
            txtIDCategoriaServico.Text = "0";
            bNovo = true;
            HabilitarCampos("Novo");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CategoriaServicoBLL categoriaCategoriaServicoBLL = new CategoriaServicoBLL();
            // Verificar se algum campo obrigatório está vazio
            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            bool isAtualizacao = false;
            if (!string.IsNullOrEmpty(txtIDCategoriaServico.Text))
            {
                int idCategoriaServico = Convert.ToInt32(txtIDCategoriaServico.Text);
                isAtualizacao = categoriaCategoriaServicoBLL.GetCategoriaServico(idCategoriaServico) != null;
            }
            if (!isAtualizacao)
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Essa Categoria de Servico?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    CategoriaServicoInfo categoriaCategoriaServico = new CategoriaServicoInfo
                    {
                        Descricao = txtDescricao.Text,
                    };
                    InserirCategoriaServico(categoriaCategoriaServico);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Realizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    CategoriaServicoInfo categoriaCategoriaServico = new CategoriaServicoInfo
                    {
                        IDCategoriaServico = int.Parse(txtIDCategoriaServico.Text),
                        Descricao = txtDescricao.Text,
                    };
                    AtualizarCategoriaServico(categoriaCategoriaServico);
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
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Essa Categoria de Servico?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDCategoriaServico.Text, out int categoriaCategoriaServicoID))
                {
                    ExcluirCategoriaServico(categoriaCategoriaServicoID);
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
            txtDescricao.Enabled = false;
            listViewCategoriaServico.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCampos(string buttonPressed)
        {
            txtDescricao.Enabled = true;
            listViewCategoriaServico.Enabled = false;
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
            txtIDCategoriaServico.Clear();
            txtDescricao.Clear();
            txtPesquisaListView.Clear();
            bNovo = false;
        }
        static void InserirCategoriaServico(CategoriaServicoInfo CategoriaServico)
        {
            try
            {
                CategoriaServicoBLL CategoriaServicoBLL = new CategoriaServicoBLL();
                CategoriaServicoBLL.InserirCategoriaServico(CategoriaServico);
                MessageBox.Show("Categoria de Servicos Inserido com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarCategoriaServico(CategoriaServicoInfo CategoriaServico)
        {
            try
            {
                CategoriaServicoBLL CategoriaServicoBLL = new CategoriaServicoBLL();
                CategoriaServicoBLL.AtualizarCategoriaServico(CategoriaServico);
                MessageBox.Show("Categoria de Servicos Atualizado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirCategoriaServico(int idCategoriaServico)
        {
            try
            {
                CategoriaServicoBLL CategoriaServicoBLL = new CategoriaServicoBLL();
                CategoriaServicoBLL.ExcluirCategoriaServico(idCategoriaServico);
                MessageBox.Show("Categoria de Servicos Excluído com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
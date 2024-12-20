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
namespace ProjetoTeste
{
    public partial class frmCategoriaServicos : BaseForm
    {
        private int sortColumn = -1;
        private bool sortAscending = true;
        private Color defaultHeaderBackColor = Color.DarkTurquoise;
        private Color clickedHeaderBackColor = Color.CadetBlue;
        private int previousSortColumn = -1;
        private (Control, string)[] camposObrigatorios;
        private List<ListViewItem> listaOriginalItens = new List<ListViewItem>();
        private List<Control> controlesKeyPress = new List<Control>();
        private List<Control> controlesLeave = new List<Control>();
        private List<Control> controlesEnter = new List<Control>();
        private List<Control> controlesMouseDown = new List<Control>();
        private List<Control> controlesBotoes = new List<Control>();
        private List<Control> controlesKeyDown = new List<Control>();

        public frmCategoriaServicos()
        {
            InitializeComponent();
            // Chama o método LoadConfig() para aplicar as configurações
            LoadConfig();
            Paint += new System.Windows.Forms.PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlCategoriaServicos); // Chama o método para inicializar o TabControl
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
            // Adicionar controles às listas específicas com base no tipo de evento
            controlesKeyPress.AddRange(new Control[] { });

            controlesLeave.AddRange(new Control[] {
                txtDescricao
            });

            controlesEnter.AddRange(new Control[] {
                txtDescricao,
                txtPesquisaListView
            });

            controlesMouseDown.AddRange(new Control[] { });

            controlesKeyDown.AddRange(new Control[] {
                txtDescricao,
                txtPesquisaListView,
                listViewCategoriaServico
            });

            controlesBotoes.AddRange(new Control[] {
                btnSalvar,
                btnAlterar,
                btnExcluir,
                btnFechar,
                btnCancelar,
                btnNovo
            });

            // Definir a propriedade Tag para comportamentos específicos
            this.Tag = "frmCategoriaServicos";

            txtDescricao.Tag = new BaseForm { TagAction = "TabPage" }; // Permitir somente letras


            // Localizar o TabControl e a TabPage
            var tabControl = Controls.Find("tabControlCategoriaServicos", true).FirstOrDefault() as TabControl;
            var tabPage = tabControl?.TabPages["tabInformacoesAdicionais"];

            // Inicializar eventos para os controles
            EventosUtils.InicializarEventos(Controls, controlesKeyPress, controlesLeave, controlesEnter, controlesMouseDown, controlesKeyDown, controlesBotoes, this, tabControl, tabPage);

            listViewCategoriaServico.Click += ListViewCategoriaServico_Click;

            // Focar no btnNovo ao iniciar
            txtPesquisaListView.Focus();
        }
        public override void ExecutaFuncaoEvento(Control control)
        {
            if (control == txtDescricao)
            {
                if (string.IsNullOrEmpty(txtDescricao.Text))
                {
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
        public override void CarregarRegistros()
        {
            DesabilitarCamposDoFormulario();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
            listViewCategoriaServico.Items.Clear();
            listViewCategoriaServico.Columns.Clear();
            InitializeListView();
            try
            {
                CategoriaServicoBLL categoriaCategoriaServicoBLL = new CategoriaServicoBLL();
                List<CategoriaServicoInfo> categoriaCategoriaServicos = categoriaCategoriaServicoBLL.Listar();
                foreach (CategoriaServicoInfo categoriaServico in categoriaCategoriaServicos)
                {
                    ListViewItem item = new ListViewItem(categoriaServico.IDCategoriaServico.ToString());
                    item.SubItems.Add(categoriaServico.Descricao);
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
                            column.Width = 720; // Ignorar cliques em outras colunas
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
                tabControlCategoriaServicos.SelectedTab = tabDadosCategoriaServico;

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
                EventosUtils.AcaoBotoes("HabilitarBotoesAlterarExcluir", this);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            txtIDCategoriaServico.Text = "0";
            bNovo = true;
            HabilitarCamposDoFormulario("Novo");
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
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Essa Categoria de Serviço?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    CategoriaServicoInfo categoriaServico = new CategoriaServicoInfo
                    {
                        Descricao = txtDescricao.Text,
                    };
                    InserirCategoriaServico(categoriaServico);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Realizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    CategoriaServicoInfo categoriaServico = new CategoriaServicoInfo
                    {
                        IDCategoriaServico = int.Parse(txtIDCategoriaServico.Text),
                        Descricao = txtDescricao.Text,
                    };
                    AtualizarCategoriaServico(categoriaServico);
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
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Essa Categoria de Serviço?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
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
        private void DesabilitarCamposDoFormulario()
        {
            List<Control> controlesDesabilitar = new List<Control>
            {
                txtDescricao
            };

            EventosUtils.DesabilitarControles(controlesDesabilitar, this);
            listViewCategoriaServico.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCamposDoFormulario(string buttonPressed)
        {
            listViewCategoriaServico.Enabled = false;
            txtPesquisaListView.Enabled = false;

            List<Control> controlesHabilitar = new List<Control>
            {
                txtDescricao
            };
            EventosUtils.HabilitarControles(controlesHabilitar, this);
            switch (buttonPressed)
            {
                case "Novo":

                    txtDescricao.Focus();

                    break;
                case "Alterar":
                    txtDescricao.Focus();
                    break;
            }
        }
        public override void LimparCampos()
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
using OrdenServicos.BLL;
using OrdenServicos.Forms;
using OrdenServicos.Model;
using OrdenServicos.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace OrdenServicos
{
	public partial class frmUnidades : BaseForm
	{
		private int sortColumn = -1;
		private bool sortAscending = true;
		private Color defaultHeaderBackColor = Color.DarkTurquoise;
		private Color clickedHeaderBackColor = Color.CadetBlue;

		private (Control, string)[] camposObrigatorios;
		private List<ListViewItem> listaOriginalItens = new List<ListViewItem>();
		private List<Control> controlesKeyPress = new List<Control>();
		private List<Control> controlesLeave = new List<Control>();
		private List<Control> controlesEnter = new List<Control>();
		private List<Control> controlesMouseDown = new List<Control>();
		private List<Control> controlesBotoes = new List<Control>();
		private List<Control> controlesKeyDown = new List<Control>();

		public frmUnidades()
		{

			InitializeComponent();
			LoadConfig();
			Paint += new PaintEventHandler(BaseForm_Paint);
			InitializeTabControl(tabControlUnidades);
			erpProvider = new ErrorProvider();
			ConfigurarTextBox();
			CarregaKey();
			ConfigurarTabIndexControles();
			CarregarRegistros();

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
		private void ListViewUnidades_ColumnClick( object sender, ColumnClickEventArgs e )
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

			public ListViewItemComparer( int column, bool ascending )
			{
				this.col = column;
				this.ascending = ascending;
			}
			public int Compare( object x, object y )
			{
				// Comparar valores das subitens
				int returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
											  ((ListViewItem)y).SubItems[col].Text);
				return ascending ? returnVal : -returnVal; // Ordem crescente ou decrescente
			}
		}
		private void txtPesquisaListView_TextChanged( object sender, EventArgs e )
		{
			PesquisarListView(txtPesquisaListView.Text, listViewUnidades, sortColumn);
		}
		private void PesquisarListView( string texto, ListView listView, int coluna )
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
		private void listViewUnidades_DrawColumnHeader( object sender, DrawListViewColumnHeaderEventArgs e )
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
		private void listViewUnidades_DrawItem( object sender, DrawListViewItemEventArgs e )
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
		private void listViewUnidades_DrawSubItem( object sender, DrawListViewSubItemEventArgs e )
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
				listViewUnidades
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
			this.Tag = "frmUnidades";

			txtDescricao.Tag = new BaseForm { TagAction = "TabPage" }; // Permitir somente letras


			// Localizar o TabControl e a TabPage
			var tabControl = Controls.Find("tabControlUnidades", true).FirstOrDefault() as TabControl;
			var tabPage = tabControl?.TabPages["tabInformacoesAdicionais"];

			// Inicializar eventos para os controles
			EventosUtils.InicializarEventos(Controls, controlesKeyPress, controlesLeave, controlesEnter, controlesMouseDown, controlesKeyDown, controlesBotoes, this, tabControl, tabPage);

			listViewUnidades.Click += ListViewUnidades_Click;

			// Focar no btnNovo ao iniciar
			txtPesquisaListView.Focus();

		}
		public override void ExecutaFuncaoEvento( Control control )
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
		private void ListViewUnidades_Click( object sender, EventArgs e )
		{
			escPressed = false;
			if (listViewUnidades.SelectedItems.Count > 0)
			{
				ListViewItem item = listViewUnidades.SelectedItems[0];
				txtIDUnidade.Text = item.SubItems[0].Text;
				txtDescricao.Text = item.SubItems[1].Text;
				EventosUtils.AcaoBotoes("HabilitarBotoesAlterarExcluir", this);
			}
		}
		private void btnNovo_Click( object sender, EventArgs e )
		{
			LimparCampos();
			EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
			txtIDUnidade.Text = "0";
			bNovo = true;
			HabilitarCamposDoFormulario("Novo");
		}
		private void btnSalvar_Click( object sender, EventArgs e )
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
		private void btnAlterar_Click( object sender, EventArgs e )
		{
			EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
			HabilitarCamposDoFormulario("Alterar");
		}
		private void btnExcluir_Click( object sender, EventArgs e )
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
			EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
			LimparCampos();
		}
		private void btnFechar_Click( object sender, EventArgs e )
		{
			this.Close();
		}
		private void btnCancelar_Click( object sender, EventArgs e )
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
			listViewUnidades.Enabled = true;
			txtPesquisaListView.Enabled = true;
		}
		private void HabilitarCamposDoFormulario( string buttonPressed )
		{
			listViewUnidades.Enabled = false;
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
			txtIDUnidade.Clear();
			txtDescricao.Clear();
			txtPesquisaListView.Clear();
			bNovo = false;
		}


		static void InserirUnidade( UnidadeInfo Unidade )
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
		static void AtualizarUnidade( UnidadeInfo Unidade )
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
		static void ExcluirUnidade( int idUnidade )
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

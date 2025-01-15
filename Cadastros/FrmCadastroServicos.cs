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
	public partial class frmServicos : BaseForm
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

		public frmServicos()
		{
			InitializeComponent();
			LoadConfig();
			Paint += new PaintEventHandler(BaseForm_Paint);
			InitializeTabControl(tabControlServicos);
			erpProvider = new ErrorProvider();
			ConfigurarTextBox();
			CarregaKey();
			ConfigurarTabIndexControles();
			ConfigurarComboBoxCategoriaServicos();
			CarregarRegistros();
		}
		private void InitializeListView()
		{
			// Configurar a ListView
			listViewServicos.View = View.Details;
			listViewServicos.FullRowSelect = true;
			listViewServicos.OwnerDraw = true; // Permitir desenho personalizado
			listViewServicos.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewServicos_DrawColumnHeader);
			listViewServicos.DrawItem += new DrawListViewItemEventHandler(listViewServicos_DrawItem);
			listViewServicos.DrawSubItem += new DrawListViewSubItemEventHandler(listViewServicos_DrawSubItem);
			// Adicionar colunas
			listViewServicos.Columns.Add("ID", 50, HorizontalAlignment.Right);
			listViewServicos.Columns.Add("  CÓDIGO BASE", 250, HorizontalAlignment.Right);
			listViewServicos.Columns.Add("  CATEGORIA", 450, HorizontalAlignment.Left);
			listViewServicos.Columns.Add("  DESCRIÇÃO", 450, HorizontalAlignment.Left);
			listViewServicos.Columns.Add("VALOR DO SERVIÇO", 200, HorizontalAlignment.Right);
			// Adicionar evento de clique no cabeçalho da coluna
			listViewServicos.ColumnClick += new ColumnClickEventHandler(ListViewServicos_ColumnClick);
			listViewServicos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			listViewServicos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
		private void ListViewServicos_ColumnClick( object sender, ColumnClickEventArgs e )
		{
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
				listViewServicos.Columns[oldSortColumn].Width = listViewServicos.Columns[oldSortColumn].Width;
			}

			listViewServicos.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
			listViewServicos.Sort();

			// Forçar redesenho da nova coluna
			listViewServicos.Columns[sortColumn].Width = listViewServicos.Columns[sortColumn].Width;
			//          listViewServicos.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
			listViewServicos.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
			PesquisarListView(txtPesquisaListView.Text, listViewServicos, sortColumn);
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
		private void listViewServicos_DrawColumnHeader( object sender, DrawListViewColumnHeaderEventArgs e )
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
				if (e.Header.Text == "ID" || e.Header.Text == "VALOR DO SERVIÇO")

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
		private void listViewServicos_DrawItem( object sender, DrawListViewItemEventArgs e )
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
		private void listViewServicos_DrawSubItem( object sender, DrawListViewSubItemEventArgs e )
		{
			using (StringFormat sf = new StringFormat())
			{
				if (listViewServicos.Columns[e.ColumnIndex].Text == "ID" || listViewServicos.Columns[e.ColumnIndex].Text == "VALOR DO SERVIÇO")
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
			controlesKeyPress.AddRange(new Control[] {
				txtValorServico
			});

			controlesLeave.AddRange(new Control[] {
				txtDescricao,
				cmbCategoriaServico,
				txtIDCodigoBase,
				txtValorServico
			});

			controlesEnter.AddRange(new Control[] {
				txtDescricao,
				cmbCategoriaServico,
				txtIDCodigoBase,
				txtValorServico,
				txtPesquisaListView,
				listViewServicos
			});

			controlesMouseDown.AddRange(new Control[] { });

			controlesKeyDown.AddRange(new Control[] {
				txtDescricao,
				cmbCategoriaServico,
				txtIDCodigoBase,
				txtValorServico,
				txtPesquisaListView,
				listViewServicos
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
			this.Tag = "frmServicos";

			txtDescricao.Tag = new BaseForm { TagAction = "TabPage" }; // Permitir somente letras

			// Localizar o TabControl e a TabPage
			var tabControl = Controls.Find("tabControlServicos", true).FirstOrDefault() as TabControl;
			var tabPage = tabControl?.TabPages["tabInformacoesAdicionais"];

			// Inicializar eventos para os controles
			EventosUtils.InicializarEventos(Controls, controlesKeyPress, controlesLeave, controlesEnter, controlesMouseDown, controlesKeyDown, controlesBotoes, this, tabControl, tabPage);

			listViewServicos.Click += ListViewServicos_Click;

			// Focar no btnNovo ao iniciar
			txtPesquisaListView.Focus();
		}
		public override void ExecutaFuncaoEvento( Control control )
		{
			if (control == cmbCategoriaServico)
			{
				string categoriaServicoDigitada = cmbCategoriaServico.Text.ToUpper(); // Converte para maiúsculas
				cmbCategoriaServico.Text = categoriaServicoDigitada; // Atualiza o texto no ComboBox
				if (!CategoriaServicoExiste(categoriaServicoDigitada) && !string.IsNullOrEmpty(categoriaServicoDigitada))
				{
					try
					{
						DialogResult result = MessageBox.Show($"A Categoria de Serviço '{categoriaServicoDigitada}' não Existe. Deseja Cadastrá-la?", "Categoria de Serviço não Encontrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
						if (result == DialogResult.Yes)
						{
							// Abre o formulário frmCategoriaServicos
							frmCategoriaServicos frm = new frmCategoriaServicos();
							frm.ShowDialog();
							CategoriaServicoBLL categoriaServicoBLL = new CategoriaServicoBLL();
							// Recarregar as categoriaServicos no ComboBox
							List<CategoriaServicoInfo> categoriaServicos = categoriaServicoBLL.Listar();
							// Ordenar a lista de categoriaServicos em ordem alfabética
							categoriaServicos = categoriaServicos.OrderBy(m => m.Descricao).ToList();
							// Definir a fonte de dados do ComboBox
							cmbCategoriaServico.DataSource = categoriaServicos;
							cmbCategoriaServico.DisplayMember = "Descricao";
							cmbCategoriaServico.ValueMember = "IDCategoriaServico";
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					cmbCategoriaServico.Text = string.Empty;
					cmbCategoriaServico.Focus();
				}
				else if (string.IsNullOrEmpty(categoriaServicoDigitada))
				{
					MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
					cmbCategoriaServico.Focus();
				}
			}
		}
		private bool CategoriaServicoExiste( string descricao )
		{
			CategoriaServicoBLL categoriaServicoBLL = new CategoriaServicoBLL();
			List<CategoriaServicoInfo> categoriaServicos = categoriaServicoBLL.Listar();
			return categoriaServicos.Any(m => m.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
		}
		private void ConfigurarComboBoxCategoriaServicos()
		{
			cmbCategoriaServico.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cmbCategoriaServico.AutoCompleteSource = AutoCompleteSource.ListItems;
		}
		private void ConfigurarTextBox()
		{
			camposObrigatorios = new (Control, string)[]
			{
				 (txtIDCodigoBase, "IDCodigoBase"),
				 (cmbCategoriaServico, "IDCategoriaServico"),
				 (txtDescricao, "Descricao"),

			};
			AdicionarValidacao(
				erpProvider,
				camposObrigatorios
			);
		}
		private void ConfigurarTabIndexControles()
		{
			txtIDCodigoBase.TabIndex = 0;
			cmbCategoriaServico.TabIndex = 1;
			txtDescricao.TabIndex = 2;
			btnSalvar.TabIndex = 3;
		}
		public override void CarregarRegistros()
		{
			DesabilitarCamposDoFormulario();
			EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
			listViewServicos.Items.Clear();
			listViewServicos.Columns.Clear();
			InitializeListView();
			try
			{
				ServicoBLL servicoBLL = new ServicoBLL();
				List<ServicoInfo> servicos = servicoBLL.Listar();
				foreach (ServicoInfo servico in servicos)
				{
					ListViewItem item = new ListViewItem(servico.IDServico.ToString());
					item.SubItems.Add(servico.IDCodigoBase);
					item.SubItems.Add(servico.Categoria);
					item.SubItems.Add(servico.Descricao);
					item.SubItems.Add(StringUtils.FormatValorMoeda(servico.ValorServico.ToString()));
					listViewServicos.Items.Add(item);
				}
				// Ajusta a largura das colunas
		
				listaOriginalItens = listViewServicos.Items.Cast<ListViewItem>().ToList();
				lbTotalRegistros.Text = "Total de Registros: " + listViewServicos.Items.Count;
				sortColumn = 3;
				sortAscending = true;
				listViewServicos.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
				listViewServicos.Sort();
				listViewServicos.Columns[sortColumn].Width = listViewServicos.Columns[sortColumn].Width;
				ajustaLarguraCabecalho(listViewServicos);
				tabControlServicos.SelectedTab = tabDadosServico;

				CategoriaServicoBLL categoriaServicoBLL = new CategoriaServicoBLL();
				List<CategoriaServicoInfo> categoriaServico = categoriaServicoBLL.Listar();
				cmbCategoriaServico.DataSource = categoriaServico;
				cmbCategoriaServico.DisplayMember = "Descricao";
				cmbCategoriaServico.ValueMember = "IDCategoriaServico";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void ListViewServicos_Click( object sender, EventArgs e )
		{
			escPressed = false;
			if (listViewServicos.SelectedItems.Count > 0)
			{
				ListViewItem item = listViewServicos.SelectedItems[0];
				txtIDServico.Text = item.SubItems[0].Text;
				txtIDCodigoBase.Text = item.SubItems[1].Text;
				string categoriaServicoNome = item.SubItems[2].Text; // Índice da coluna da categoriaServico
				CategoriaServicoBLL categoriaServicoBLL = new CategoriaServicoBLL();
				List<CategoriaServicoInfo> categoriaServicos = categoriaServicoBLL.Listar();
				CategoriaServicoInfo categoriaServico = categoriaServicos.FirstOrDefault(cs => cs.Descricao == categoriaServicoNome);
				if (categoriaServico != null)
				{
					cmbCategoriaServico.SelectedValue = categoriaServico.IDCategoriaServico;
				}
				txtDescricao.Text = item.SubItems[3].Text;
				txtValorServico.Text = item.SubItems[4].Text;
				EventosUtils.AcaoBotoes("HabilitarBotoesAlterarExcluir", this);
			}
		}
		private void btnNovo_Click( object sender, EventArgs e )
		{
			LimparCampos();
			EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
			txtIDServico.Text = "0";
			bNovo = true;
			HabilitarCamposDoFormulario("Novo");
		}
		private void btnSalvar_Click( object sender, EventArgs e )
		{
			ServicoBLL servicoBLL = new ServicoBLL();
			// Verificar se algum campo obrigatório está vazio
			if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
			{
				MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			bool isAtualizacao = false;
			if (!string.IsNullOrEmpty(txtIDServico.Text))
			{
				int idServico = Convert.ToInt32(txtIDServico.Text);
				isAtualizacao = servicoBLL.GetServico(idServico) != null;
			}

			if (!isAtualizacao)
			{
				DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Esse Serviço?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					ServicoInfo servico = new ServicoInfo
					{
						IDCodigoBase = txtIDCodigoBase.Text,
						IDCategoriaServico = Convert.ToInt32(cmbCategoriaServico.SelectedValue),
						Descricao = txtDescricao.Text,
						ValorServico = Convert.ToDecimal(StringUtils.SemFormatacao(txtValorServico.Text)),
					};
					InserirServico(servico);
				}
			}
			else
			{
				DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Realizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					ServicoInfo servico = new ServicoInfo
					{
						IDServico = int.Parse(txtIDServico.Text),
						IDCodigoBase = txtIDCodigoBase.Text,
						IDCategoriaServico = Convert.ToInt32(cmbCategoriaServico.SelectedValue),
						Descricao = txtDescricao.Text,
						ValorServico = Convert.ToDecimal(StringUtils.SemFormatacao(txtValorServico.Text)),
					};
					AtualizarServico(servico);
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
			DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Serviço?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				if (int.TryParse(txtIDServico.Text, out int servicoID))
				{
					ExcluirServico(servicoID);
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
			txtIDCodigoBase,
			cmbCategoriaServico,
			txtDescricao,
			txtValorServico
		};
			EventosUtils.DesabilitarControles(controlesDesabilitar, this);
			listViewServicos.Enabled = true;
			txtPesquisaListView.Enabled = true;

		}
		private void HabilitarCamposDoFormulario( string buttonPressed )
		{

			listViewServicos.Enabled = false;
			txtPesquisaListView.Enabled = false;

			List<Control> controlesHabilitar = new List<Control>
			{
			txtIDCodigoBase,
			cmbCategoriaServico,
			txtDescricao,
			txtValorServico
			};
			EventosUtils.HabilitarControles(controlesHabilitar, this);
			switch (buttonPressed)
			{
				case "Novo":
					txtIDCodigoBase.Focus();
					break;
				case "Alterar":
					txtIDCodigoBase.Focus();
					break;
			}
		}
		public override void LimparCampos()
		{
			txtIDServico.Clear();
			txtIDCodigoBase.Clear();
			cmbCategoriaServico.SelectedIndex = -1;
			txtDescricao.Clear();
			txtPesquisaListView.Clear();
			bNovo = false;
		}
		static void InserirServico( ServicoInfo Servico )
		{
			try
			{
				ServicoBLL servicoBLL = new ServicoBLL();
				servicoBLL.InserirServico(Servico);
				MessageBox.Show("Serviço Inserido com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		static void AtualizarServico( ServicoInfo Servico )
		{
			try
			{
				ServicoBLL servicoBLL = new ServicoBLL();
				servicoBLL.AtualizarServico(Servico);
				MessageBox.Show("Serviço Atualizado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		static void ExcluirServico( int idServico )
		{
			try
			{
				ServicoBLL servicoBLL = new ServicoBLL();
				servicoBLL.ExcluirServico(idServico);
				MessageBox.Show("Serviço Excluído com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}

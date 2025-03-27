using Newtonsoft.Json.Linq;
using OrdenServicos.BLL;
using OrdenServicos.Forms;
using OrdenServicos.Model;
using OrdenServicos.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OrdenServicos.DAL.PesquisaWebDAL;
using static OrdenServicos.Model.PesquisaWebInfo;

namespace OrdenServicos
{
    public partial class frmClientes : BaseForm
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
        private readonly EventArgs e = new EventArgs();

        public frmClientes()
        {
            InitializeComponent();
            LoadConfig();
            Paint += new PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlClientes);
            erpProvider = new ErrorProvider();
            ConfigurarTextBox();
            CarregaKey();
            ConfigurarTabIndexControles();
            CarregarRegistros();
        }
        private void InitializeListView()
        {
            // Configurar a ListView
            listViewClientes.View = View.Details;
            listViewClientes.FullRowSelect = true;
            listViewClientes.OwnerDraw = true; // Permitir desenho personalizado
            listViewClientes.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewClientes_DrawColumnHeader);
            listViewClientes.DrawItem += new DrawListViewItemEventHandler(listViewClientes_DrawItem);
            listViewClientes.DrawSubItem += new DrawListViewSubItemEventHandler(listViewClientes_DrawSubItem);

            // Adicionar colunas
            listViewClientes.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("PESSOA", 80, HorizontalAlignment.Center);
            listViewClientes.Columns.Add("CPF/CNPJ", 120, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("  NOME/RAZÃO SOCIAL", 300, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("  ENDEREÇO", 200, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("NUMERO", 70, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("  BAIRRO", 150, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("  MUNICIPIO", 200, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("UF", 30, HorizontalAlignment.Center);
            listViewClientes.Columns.Add("CEP", 70, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("  CONTATO", 150, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("CELULAR", 100, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("FIXO", 100, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("  EMAIL", 300, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("DATA CADASTRO", -1, HorizontalAlignment.Right);

            listViewClientes.ColumnClick += new ColumnClickEventHandler(ListViewClientes_ColumnClick);

        }
        private void ListViewClientes_ColumnClick(object sender, ColumnClickEventArgs e)
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
                listViewClientes.Columns[oldSortColumn].Width = listViewClientes.Columns[oldSortColumn].Width;
            }

            listViewClientes.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewClientes.Sort();

            // Forçar redesenho da nova coluna
            listViewClientes.Columns[sortColumn].Width = listViewClientes.Columns[sortColumn].Width;
            listViewClientes.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
            PesquisarListView(txtPesquisaListView.Text, listViewClientes, sortColumn);
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
        private void listViewClientes_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            string[] centerColumnList = new string[] { "ID", "PESSOA", "CPF/CNPJ", "UF", "CEP", "NUMERO", "CELULAR", "FIXO", "DATA CADASTRO" };
            Color headerBackColor = e.ColumnIndex == sortColumn ? clickedHeaderBackColor : defaultHeaderBackColor;

            using (SolidBrush backBrush = new SolidBrush(headerBackColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.NoWrap; // Adiciona esta linha para evitar quebra de linha

                if (centerColumnList.Contains(e.Header.Text))
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
        private void listViewClientes_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewClientes_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewClientes.Columns[e.ColumnIndex].Text == "ID" || listViewClientes.Columns[e.ColumnIndex].Text == "PESSOA" ||
                    listViewClientes.Columns[e.ColumnIndex].Text == "CPF/CNPJ" || listViewClientes.Columns[e.ColumnIndex].Text == "UF" ||
                    listViewClientes.Columns[e.ColumnIndex].Text == "CEP" || listViewClientes.Columns[e.ColumnIndex].Text == "NUMERO" ||
                    listViewClientes.Columns[e.ColumnIndex].Text == "CELULAR" || listViewClientes.Columns[e.ColumnIndex].Text == "FIXO" ||
                    listViewClientes.Columns[e.ColumnIndex].Text == "DATA CADASTRO")
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
            controlesKeyPress.AddRange(new Control[] {
                txtCpfCnpj,
                txtCep,
                txtFone_1,
                txtFone_2
            });

            controlesLeave.AddRange(new Control[] {
                txtCpfCnpj,
                txtCep,
                txtNumero,
                txtFone_1,
                txtFone_2
            });

            controlesEnter.AddRange(new Control[] {
                txtCpfCnpj,
                txtNomeRazaoSocial,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtContato,
                txtFone_1,
                txtFone_2,
                txtEmail,
                rdbCpf,
                rdbCnpj,
                txtPesquisaListView,
                listViewClientes
            });

            controlesMouseDown.AddRange(new Control[] { });

            controlesKeyDown.AddRange(new Control[] {
                txtCpfCnpj,
                txtNomeRazaoSocial,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtContato,
                txtFone_1,
                txtFone_2,
                txtEmail,
                rdbCpf,
                rdbCnpj,
                txtPesquisaListView,
                listViewClientes
            });

            controlesBotoes.AddRange(new Control[] {
                btnSalvar,
                btnAlterar,
                btnExcluir,
                btnFechar,
                btnCancelar,
                btnNovo,
                btnPesquisaCep,
                btnPesquisarCnpj
            });

            this.Tag = "frmClientes";

            txtCep.Tag = new BaseForm { TagFormato = "FormataCep", TagMaxDigito = 8 };
            txtFone_1.Tag = new BaseForm { TagFormato = "FormataFone", TagMaxDigito = 11 };
            txtFone_2.Tag = new BaseForm { TagFormato = "FormataFone", TagMaxDigito = 10 };
            txtCpfCnpj.Tag = new BaseForm { TagFormato = "FormataCpfCnpj", TagMaxDigito = 14 };

            txtEmail.Tag = new BaseForm { TagAction = "FocaBotaoSalvar" };

            var tabControl = Controls.Find("tabControlClientes", true).FirstOrDefault() as TabControl;
            var tabPage = tabControl?.TabPages["tabInformacoesAdicionais"];

            EventosUtils.InicializarEventos(Controls, controlesKeyPress, controlesLeave,
                                            controlesEnter, controlesMouseDown, controlesKeyDown,
                                            controlesBotoes, this, tabControl, tabPage);

            listViewClientes.Click += ListViewClientes_Click;
            txtPesquisaListView.Focus();
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
   //             (txtCpfCnpj, "Cpf_Cnpj"),
    //            (txtNomeRazaoSocial, "Nome"),
    //            (txtCep, "Cep"),
    //            (txtFone_1, "Celular"),
            };

            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
        }
        private void ConfigurarTabIndexControles()
        {
            rdbCpf.TabIndex = 0;
            rdbCnpj.TabIndex = 1;
            txtCpfCnpj.TabIndex = 2;
            txtNomeRazaoSocial.TabIndex = 4;
            txtCep.TabIndex = 5;
            txtEndereco.TabIndex = 6;
            txtNumero.TabIndex = 7;
            txtBairro.TabIndex = 8;
            txtMunicipio.TabIndex = 9;
            txtUF.TabIndex = 10;
            txtContato.TabIndex = 11;
            txtFone_1.TabIndex = 12;
            txtFone_2.TabIndex = 13;
            txtEmail.TabIndex = 14;
            btnSalvar.TabIndex = 15;
        }
        public override void CarregarRegistros()
        {
            DesabilitarCamposDoFormulario();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
            listViewClientes.Items.Clear();
            listViewClientes.Columns.Clear();
            InitializeListView(); // Adicionar colunas novamente, caso necessário
            try
            {
                ClienteBLL clienteBLL = new ClienteBLL();
                List<ClienteInfo> clientes = clienteBLL.Listar();
                foreach (ClienteInfo cliente in clientes)
                {
                    ListViewItem item = new ListViewItem(cliente.IDCliente.ToString());
                    item.SubItems.Add(cliente.TipoPessoa);
                    if (cliente.TipoPessoa == "FÍSICA")
                    {
                        item.SubItems.Add(StringUtils.FormatCPF(cliente.Cpf_Cnpj));
                    }
                    else if (cliente.TipoPessoa == "JURÍDICA")
                    {
                        item.SubItems.Add(StringUtils.FormatCNPJ(cliente.Cpf_Cnpj));
                    }
                    item.SubItems.Add(cliente.Nome_RazaoSocial);
                    item.SubItems.Add(cliente.Endereco);
                    item.SubItems.Add(cliente.Numero);
                    item.SubItems.Add(cliente.Bairro);
                    item.SubItems.Add(cliente.Municipio);
                    item.SubItems.Add(cliente.UF);
                    item.SubItems.Add(StringUtils.FormatCEP(cliente.Cep));
                    item.SubItems.Add(cliente.Contato);
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(cliente.Fone_1));
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(cliente.Fone_2));
                    item.SubItems.Add(cliente.Email);
                    item.SubItems.Add(cliente.DataCadastro.ToString("dd/MM/yyyy"));
                    listViewClientes.Items.Add(item);
                }
                listaOriginalItens = listViewClientes.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros..:  " + listViewClientes.Items.Count;
                sortColumn = 3;
                sortAscending = true;
                listViewClientes.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                listViewClientes.Sort();
                ajustaLarguraCabecalho(listViewClientes);
                tabControlClientes.SelectedTab = tabDadosClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar registros: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListViewClientes_Click(object sender, EventArgs e)
        {
            escPressed = false;
            if (listViewClientes.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewClientes.SelectedItems[0];
                txtIDCliente.Text = item.SubItems[0].Text;
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
                EventosUtils.AcaoBotoes("HabilitarBotoesAlterarExcluir", this);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            txtIDCliente.Enabled = false;
            txtIDCliente.Text = "0";
            bNovo = true;
            HabilitarCamposDoFormulario("Novo");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            ClienteBLL clienteBLL = new ClienteBLL();
/*
            // Verificar se algum campo obrigatório está vazio
            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
*/
            bool isAtualizacao = false;

            if (!string.IsNullOrEmpty(txtIDCliente.Text))
            {
                int idCliente = Convert.ToInt32(txtIDCliente.Text);
                isAtualizacao = clienteBLL.GetCliente(idCliente) != null;
            }

            if (!isAtualizacao)
            {
                
                string cpfcnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text);
                DBSetupBLL dbSetupBLL = new DBSetupBLL();
                /* Verifica se o CPF/CNPJ já está cadastrado
                if (dbSetupBLL.VerificarSeCadastrado(cpfcnpj, "DBClientes", "Cpf_Cnpj"))
                {
                    MessageBox.Show("Cliente já cadastrado. Favor verificar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCpfCnpj.Clear();
                    txtCpfCnpj.Focus();
                    return;
                }
                */
                DialogResult result = DialogResult.Yes; // MessageBox.Show("Tem Certeza que Deseja Incluir Esse Cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    ClienteInfo cliente = new ClienteInfo
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
                    InserirCliente(cliente);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Ralizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ClienteInfo cliente = new ClienteInfo
                    {
                        IDCliente = int.Parse(txtIDCliente.Text),
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
                    AtualizarCliente(cliente);
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
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDCliente.Text, out int clienteID))
                {
                    ExcluirCliente(clienteID);
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
        public override void ExecutaFuncaoEvento(Control control)
        {
            if (control == txtCpfCnpj && !string.IsNullOrEmpty(txtCpfCnpj.Text))
            {
                string cpfcnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text);
                DBSetupBLL dbSetupBLL = new DBSetupBLL();
                string cpfCnpj = txtCpfCnpj.Text;
                if (dbSetupBLL.VerificarSeCadastrado(cpfcnpj, "DBClientes", "Cpf_Cnpj"))
                {
                    MessageBox.Show("Cliente já Cadastrado. Favor Verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCpfCnpj.Clear();
                    txtCpfCnpj.Focus();
                    return;
                }
                if (rdbCpf.Checked)
                {
                    if (!ValidaCpf(cpfCnpj))
                    {
                        MessageBox.Show("CPF Informado está Incorreto. Favor Verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpfCnpj.Clear();
                        txtCpfCnpj.Focus();
                        return;
                    }
                    else
                    {
                        PesquisarCpf(cpfcnpj);
                    }
                    control.Text = StringUtils.FormatCPF(cpfCnpj);
                }
                else if (rdbCnpj.Checked)
                {
                    if (!ValidaCnpj(cpfCnpj))
                    {
                        MessageBox.Show("CNPJ Informado está Incorreto. Favor Verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpfCnpj.Clear();
                        txtCpfCnpj.Focus();
                        return;
                    }
                    else
                    {
                        PesquisarCnpj(cpfcnpj);
                    }
                    control.Text = StringUtils.FormatCNPJ(cpfCnpj);
                }
            }
            else if (control == txtNumero)
            {
                if (string.IsNullOrEmpty(txtNumero.Text))
                {
                    txtNumero.Text = "S/N";
                }
            }
            else if (control == txtCep && !string.IsNullOrEmpty(txtCep.Text))
            {
                btnPesquisaCep_Click(control, e);
                control.Text = StringUtils.SemFormatacao(control.Text);
                control.Text = StringUtils.FormatCEP(control.Text);
            }
        }
        private void DesabilitarCamposDoFormulario()
        {
            List<Control> controlesDesabilitar = new List<Control>
            {
                txtCpfCnpj,
                txtNomeRazaoSocial,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtContato,
                txtFone_1,
                txtFone_2,
                txtEmail,
                rdbCpf,
                rdbCnpj,
                btnPesquisaCep,
                btnPesquisarCnpj
            };
            EventosUtils.DesabilitarControles(controlesDesabilitar, this);
            listViewClientes.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCamposDoFormulario(string buttonPressed)
        {
            List<Control> controlesHabilitar = new List<Control>
            {
                txtNomeRazaoSocial,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtContato,
                txtFone_1,
                txtFone_2,
                txtEmail
            };
            EventosUtils.HabilitarControles(controlesHabilitar, this);
            listViewClientes.Enabled = false;
            txtPesquisaListView.Enabled = false;
            switch (buttonPressed)
            {
                case "Novo":
                    List<Control> controlesHabilitarNovo = new List<Control>
                     {
                        rdbCpf,
                        rdbCnpj,
                        txtCpfCnpj
                     };
                    EventosUtils.HabilitarControles(controlesHabilitarNovo, this);
                    rdbCpf.Checked = false;
                    rdbCnpj.Checked = false;
                    txtDataCadastro.Text = DateTime.Now.ToString();
                    rdbCpf.Focus();
                    break;
                case "Alterar":
                    rdbCpf.Enabled = false;
                    rdbCnpj.Enabled = false;
                    txtCpfCnpj.Enabled = false;
                    txtNomeRazaoSocial.Focus();
                    break;
            }
        }
        public override void LimparCampos()
        {
            txtIDCliente.Clear();
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
            escPressed = false;
        }
        static void InserirCliente(ClienteInfo Cliente)
        {
            try
            {
                ClienteBLL clienteBLL = new ClienteBLL();
                clienteBLL.InserirCliente(Cliente);
           //     MessageBox.Show("Cliente inserido com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarCliente(ClienteInfo Cliente)
        {
            try
            {
                ClienteBLL clienteBLL = new ClienteBLL();
                clienteBLL.AtualizarCliente(Cliente);
                MessageBox.Show("Cliente atualizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirCliente(int idCliente)
        {
            try
            {
                ClienteBLL clienteBLL = new ClienteBLL();
                clienteBLL.ExcluirCliente(idCliente);
                MessageBox.Show("Cliente excluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void PesquisarCnpj(String cnpj)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CnpjInfo info = await ReceitaFederalApi.PesquisarCnpjAsync(cnpj);
                if (info != null)
                {
                    txtCpfCnpj.Text = info.Cpf_Cnpj;
                    txtNomeRazaoSocial.Text = info.Nome_RazaoSocial;
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
                    txtNomeRazaoSocial.Focus();
                }
                else
                {
                    MessageBox.Show(cnpj + "CNPJ não encontrado ou erro na pesquisa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default; // Restaurar o cursor padrão
            }
        }
        private async void PesquisarCpf(String cpf)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // Mudar o cursor para ocupado
                CpfInfo info = await ReceitaFederalApi.PesquisarCpfAsync(cpf);
                if (info != null)
                {
                    txtCpfCnpj.Text = info.Cpf_Cnpj;
                    txtNomeRazaoSocial.Text = info.Nome_RazaoSocial;
                    txtEndereco.Text = info.Endereco;
                    txtBairro.Text = info.Bairro;
                    txtMunicipio.Text = info.Municipio;
                    txtUF.Text = info.UF;
                    txtCep.Text = info.Cep;
                    txtContato.Text = info.Contato;
                    txtEmail.Text = info.Email;
                    txtNomeRazaoSocial.Focus();
                }
                else
                {
                    MessageBox.Show("CPF não encontrado ou erro na pesquisa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private async void btnPesquisaCep_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCep.Text))
            {
                string cep = StringUtils.SemFormatacao(txtCep.Text);
                var resultado = await StringUtils.BuscarCEP(cep);

                if (!string.IsNullOrEmpty(resultado))
                {
                    dynamic dados = JObject.Parse(resultado);
                    txtEndereco.Text = dados.logradouro ?? "";
                    if (string.IsNullOrEmpty(txtNumero.Text))
                    {
                        txtNumero.Clear();
                    }
                    txtBairro.Text = dados.bairro ?? "";
                    txtMunicipio.Text = dados.localidade ?? "";
                    txtUF.Text = dados.uf ?? "";
                }
                else
                {
                    MessageBox.Show("CEP não encontrado ou erro ao buscar o CEP.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            txtEndereco.Focus();
        }

        private async void btnCarregaArquivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "E:\\ProjetosCSharp\\OrdenServiços\\Documentos";
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtenha o caminho completo do arquivo selecionado
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Ler todas as linhas do arquivo
                        string[] lines = System.IO.File.ReadAllLines(filePath);

                        foreach (string line in lines)
                        {
                            txtCpfCnpj.Text = line.Trim();
                            if (!string.IsNullOrEmpty(txtCpfCnpj.Text))
                            {
                                ExecutaCarregaArquivo();
                                Task.Delay(1000); // Pausa de 1 segundo entre as pesquisas
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao ler o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void ExecutaCarregaArquivo()
        {

            string cpfcnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text);
            DBSetupBLL dbSetupBLL = new DBSetupBLL();
            string cpfCnpj = txtCpfCnpj.Text;
            if (dbSetupBLL.VerificarSeCadastrado(cpfcnpj, "DBClientes", "Cpf_Cnpj"))
            {
                return;
            }
            else
            {
                if (!ValidaCnpj(cpfCnpj))
                {
                    return;
                }
                else
                {

                    try
                    {

                        Cursor.Current = Cursors.WaitCursor;
                        CnpjInfo info = await ReceitaFederalApi.PesquisarCnpjAsync(cpfcnpj);
                        if (info != null)
                        {
                            txtCpfCnpj.Text = info.Cpf_Cnpj;
                            txtNomeRazaoSocial.Text = info.Nome_RazaoSocial;
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
                            txtIDCliente.Text = "0";
                            rdbCnpj.Checked = true;
                            rdbCpf.Checked = false;

                            btnSalvar_Click(this, e);
                        }
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default; // Restaurar o cursor padrão
                    }


                }

            }
        }
    }
}

namespace ProjetoTeste
{
    partial class frmFornecedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFornecedores));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.listViewFornecedores = new System.Windows.Forms.ListView();
            this.btnNovo = new System.Windows.Forms.Button();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtIDFornecedor = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.tabControlFornecedores = new System.Windows.Forms.TabControl();
            this.tabDadosFornecedor = new System.Windows.Forms.TabPage();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lbContato = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbUF = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.lbMunicipio = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lbBairro = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lbNumero = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lbEndereco = new System.Windows.Forms.Label();
            this.btnPesquisarCnpj = new System.Windows.Forms.Button();
            this.btnPesquisaCep = new System.Windows.Forms.Button();
            this.rdbCnpj = new System.Windows.Forms.RadioButton();
            this.rdbCpf = new System.Windows.Forms.RadioButton();
            this.txtFone_2 = new System.Windows.Forms.MaskedTextBox();
            this.lbFone_2 = new System.Windows.Forms.Label();
            this.txtFone_1 = new System.Windows.Forms.MaskedTextBox();
            this.lbFone_1 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.lbCep = new System.Windows.Forms.Label();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.lbDataCadastro = new System.Windows.Forms.Label();
            this.txtNomeRazaoSocial = new System.Windows.Forms.TextBox();
            this.lbNomeRazaoSocial = new System.Windows.Forms.Label();
            this.txtCpfCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lbCpfCnpj = new System.Windows.Forms.Label();
            this.tabInformacoesAdicionais = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.tabControlFornecedores.SuspendLayout();
            this.tabDadosFornecedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::ProjetoTeste.Properties.Resources.Salvar24x24;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(764, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(98, 40);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "      Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = global::ProjetoTeste.Properties.Resources.Editar24x24;
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(660, 2);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(98, 40);
            this.btnAlterar.TabIndex = 15;
            this.btnAlterar.Tag = "";
            this.btnAlterar.Text = "       Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = true;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::ProjetoTeste.Properties.Resources.Excluir24x24;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(868, 2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(98, 40);
            this.btnExcluir.TabIndex = 17;
            this.btnExcluir.Text = "     Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AutoSize = true;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = global::ProjetoTeste.Properties.Resources.Sair24x24;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(972, 2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(98, 40);
            this.btnFechar.TabIndex = 18;
            this.btnFechar.Text = "     Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // listViewFornecedores
            // 
            this.listViewFornecedores.CausesValidation = false;
            this.listViewFornecedores.FullRowSelect = true;
            this.listViewFornecedores.GridLines = true;
            this.listViewFornecedores.HideSelection = false;
            this.listViewFornecedores.Location = new System.Drawing.Point(14, 229);
            this.listViewFornecedores.Name = "listViewFornecedores";
            this.listViewFornecedores.Size = new System.Drawing.Size(1108, 219);
            this.listViewFornecedores.TabIndex = 18;
            this.listViewFornecedores.UseCompatibleStateImageBehavior = false;
            this.listViewFornecedores.View = System.Windows.Forms.View.Details;
            // 
            // btnNovo
            // 
            this.btnNovo.AutoSize = true;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = global::ProjetoTeste.Properties.Resources.Novo24x24;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(556, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(98, 40);
            this.btnNovo.TabIndex = 14;
            this.btnNovo.Text = "     Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // txtIDFornecedor
            // 
            this.txtIDFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDFornecedor.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDFornecedor.Location = new System.Drawing.Point(1060, 166);
            this.txtIDFornecedor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDFornecedor.Name = "txtIDFornecedor";
            this.txtIDFornecedor.Size = new System.Drawing.Size(23, 22);
            this.txtIDFornecedor.TabIndex = 13;
            this.txtIDFornecedor.Text = " ";
            this.txtIDFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIDFornecedor.Visible = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotoes.Controls.Add(this.lbTotalRegistros);
            this.pnlBotoes.Controls.Add(this.btnFechar);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Location = new System.Drawing.Point(14, 452);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(1108, 49);
            this.pnlBotoes.TabIndex = 97;
            // 
            // lbTotalRegistros
            // 
            this.lbTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTotalRegistros.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTotalRegistros.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRegistros.Location = new System.Drawing.Point(8, 6);
            this.lbTotalRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalRegistros.Name = "lbTotalRegistros";
            this.lbTotalRegistros.Size = new System.Drawing.Size(312, 33);
            this.lbTotalRegistros.TabIndex = 58;
            this.lbTotalRegistros.Tag = "\"naoAplicar\"";
            this.lbTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControlFornecedores
            // 
            this.tabControlFornecedores.Controls.Add(this.tabDadosFornecedor);
            this.tabControlFornecedores.Controls.Add(this.tabInformacoesAdicionais);
            this.tabControlFornecedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlFornecedores.ItemSize = new System.Drawing.Size(109, 20);
            this.tabControlFornecedores.Location = new System.Drawing.Point(14, 3);
            this.tabControlFornecedores.Multiline = true;
            this.tabControlFornecedores.Name = "tabControlFornecedores";
            this.tabControlFornecedores.SelectedIndex = 0;
            this.tabControlFornecedores.Size = new System.Drawing.Size(1108, 222);
            this.tabControlFornecedores.TabIndex = 98;
            // 
            // tabDadosFornecedor
            // 
            this.tabDadosFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosFornecedor.Controls.Add(this.lblEmail);
            this.tabDadosFornecedor.Controls.Add(this.txtIDFornecedor);
            this.tabDadosFornecedor.Controls.Add(this.txtPesquisaListView);
            this.tabDadosFornecedor.Controls.Add(this.lbContato);
            this.tabDadosFornecedor.Controls.Add(this.txtUF);
            this.tabDadosFornecedor.Controls.Add(this.txtContato);
            this.tabDadosFornecedor.Controls.Add(this.lblPesquisaListView);
            this.tabDadosFornecedor.Controls.Add(this.txtEmail);
            this.tabDadosFornecedor.Controls.Add(this.lbUF);
            this.tabDadosFornecedor.Controls.Add(this.txtMunicipio);
            this.tabDadosFornecedor.Controls.Add(this.lbMunicipio);
            this.tabDadosFornecedor.Controls.Add(this.txtBairro);
            this.tabDadosFornecedor.Controls.Add(this.lbBairro);
            this.tabDadosFornecedor.Controls.Add(this.txtNumero);
            this.tabDadosFornecedor.Controls.Add(this.lbNumero);
            this.tabDadosFornecedor.Controls.Add(this.txtEndereco);
            this.tabDadosFornecedor.Controls.Add(this.lbEndereco);
            this.tabDadosFornecedor.Controls.Add(this.btnPesquisarCnpj);
            this.tabDadosFornecedor.Controls.Add(this.btnPesquisaCep);
            this.tabDadosFornecedor.Controls.Add(this.rdbCnpj);
            this.tabDadosFornecedor.Controls.Add(this.rdbCpf);
            this.tabDadosFornecedor.Controls.Add(this.txtFone_2);
            this.tabDadosFornecedor.Controls.Add(this.lbFone_2);
            this.tabDadosFornecedor.Controls.Add(this.txtFone_1);
            this.tabDadosFornecedor.Controls.Add(this.lbFone_1);
            this.tabDadosFornecedor.Controls.Add(this.txtCep);
            this.tabDadosFornecedor.Controls.Add(this.lbCep);
            this.tabDadosFornecedor.Controls.Add(this.txtDataCadastro);
            this.tabDadosFornecedor.Controls.Add(this.lbDataCadastro);
            this.tabDadosFornecedor.Controls.Add(this.txtNomeRazaoSocial);
            this.tabDadosFornecedor.Controls.Add(this.lbNomeRazaoSocial);
            this.tabDadosFornecedor.Controls.Add(this.txtCpfCnpj);
            this.tabDadosFornecedor.Controls.Add(this.lbCpfCnpj);
            this.tabDadosFornecedor.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosFornecedor.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosFornecedor.Location = new System.Drawing.Point(4, 24);
            this.tabDadosFornecedor.Name = "tabDadosFornecedor";
            this.tabDadosFornecedor.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosFornecedor.Size = new System.Drawing.Size(1100, 194);
            this.tabDadosFornecedor.TabIndex = 0;
            this.tabDadosFornecedor.Text = "Dados do Fornecedor";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(608, 104);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 15);
            this.lblEmail.TabIndex = 118;
            this.lblEmail.Text = "E-Mail..:";
            // 
            // txtPesquisaListView
            // 
            this.txtPesquisaListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisaListView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaListView.Enabled = false;
            this.txtPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaListView.Location = new System.Drawing.Point(8, 166);
            this.txtPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPesquisaListView.Name = "txtPesquisaListView";
            this.txtPesquisaListView.Size = new System.Drawing.Size(328, 22);
            this.txtPesquisaListView.TabIndex = 119;
            this.txtPesquisaListView.TextChanged += new System.EventHandler(this.txtPesquisaListView_TextChanged);
            // 
            // lbContato
            // 
            this.lbContato.AutoSize = true;
            this.lbContato.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContato.Location = new System.Drawing.Point(8, 104);
            this.lbContato.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbContato.Name = "lbContato";
            this.lbContato.Size = new System.Drawing.Size(59, 15);
            this.lbContato.TabIndex = 117;
            this.lbContato.Text = "Contato..:";
            // 
            // txtUF
            // 
            this.txtUF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUF.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUF.Location = new System.Drawing.Point(1040, 72);
            this.txtUF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUF.MaxLength = 2;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(40, 22);
            this.txtUF.TabIndex = 102;
            // 
            // txtContato
            // 
            this.txtContato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContato.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContato.Location = new System.Drawing.Point(8, 120);
            this.txtContato.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(336, 22);
            this.txtContato.TabIndex = 104;
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.AutoSize = true;
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(8, 150);
            this.lblPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(124, 15);
            this.lblPesquisaListView.TabIndex = 120;
            this.lblPesquisaListView.Text = "Pesquisa Fornecedor..:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(608, 120);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(472, 22);
            this.txtEmail.TabIndex = 107;
            // 
            // lbUF
            // 
            this.lbUF.AutoSize = true;
            this.lbUF.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUF.Location = new System.Drawing.Point(1044, 56);
            this.lbUF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUF.Name = "lbUF";
            this.lbUF.Size = new System.Drawing.Size(31, 15);
            this.lbUF.TabIndex = 116;
            this.lbUF.Text = "UF..:";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMunicipio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMunicipio.Location = new System.Drawing.Point(696, 72);
            this.txtMunicipio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(320, 22);
            this.txtMunicipio.TabIndex = 101;
            // 
            // lbMunicipio
            // 
            this.lbMunicipio.AutoSize = true;
            this.lbMunicipio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMunicipio.Location = new System.Drawing.Point(697, 56);
            this.lbMunicipio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMunicipio.Name = "lbMunicipio";
            this.lbMunicipio.Size = new System.Drawing.Size(71, 15);
            this.lbMunicipio.TabIndex = 115;
            this.lbMunicipio.Text = "Municipio..:";
            // 
            // txtBairro
            // 
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(464, 72);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(208, 22);
            this.txtBairro.TabIndex = 99;
            // 
            // lbBairro
            // 
            this.lbBairro.AutoSize = true;
            this.lbBairro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBairro.Location = new System.Drawing.Point(464, 56);
            this.lbBairro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBairro.Name = "lbBairro";
            this.lbBairro.Size = new System.Drawing.Size(51, 15);
            this.lbBairro.TabIndex = 114;
            this.lbBairro.Text = "Bairro..:";
            // 
            // txtNumero
            // 
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(368, 72);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(72, 22);
            this.txtNumero.TabIndex = 97;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumero.Location = new System.Drawing.Point(368, 56);
            this.lbNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(60, 15);
            this.lbNumero.TabIndex = 113;
            this.lbNumero.Text = "Numero..:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndereco.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(8, 72);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(336, 22);
            this.txtEndereco.TabIndex = 96;
            // 
            // lbEndereco
            // 
            this.lbEndereco.AutoSize = true;
            this.lbEndereco.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndereco.Location = new System.Drawing.Point(8, 56);
            this.lbEndereco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEndereco.Name = "lbEndereco";
            this.lbEndereco.Size = new System.Drawing.Size(65, 15);
            this.lbEndereco.TabIndex = 112;
            this.lbEndereco.Text = "Endereço..:";
            // 
            // btnPesquisarCnpj
            // 
            this.btnPesquisarCnpj.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarCnpj.Image")));
            this.btnPesquisarCnpj.Location = new System.Drawing.Point(264, 23);
            this.btnPesquisarCnpj.Name = "btnPesquisarCnpj";
            this.btnPesquisarCnpj.Size = new System.Drawing.Size(37, 24);
            this.btnPesquisarCnpj.TabIndex = 111;
            this.btnPesquisarCnpj.UseVisualStyleBackColor = false;
            this.btnPesquisarCnpj.Click += new System.EventHandler(this.btnPesquisarCnpj_Click);
            // 
            // btnPesquisaCep
            // 
            this.btnPesquisaCep.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisaCep.Image")));
            this.btnPesquisaCep.Location = new System.Drawing.Point(1048, 23);
            this.btnPesquisaCep.Name = "btnPesquisaCep";
            this.btnPesquisaCep.Size = new System.Drawing.Size(37, 26);
            this.btnPesquisaCep.TabIndex = 110;
            this.btnPesquisaCep.UseVisualStyleBackColor = false;
            this.btnPesquisaCep.Click += new System.EventHandler(this.btnPesquisaCep_Click);
            // 
            // rdbCnpj
            // 
            this.rdbCnpj.AutoSize = true;
            this.rdbCnpj.Location = new System.Drawing.Point(8, 27);
            this.rdbCnpj.Name = "rdbCnpj";
            this.rdbCnpj.Size = new System.Drawing.Size(120, 21);
            this.rdbCnpj.TabIndex = 90;
            this.rdbCnpj.Text = "Pessoa Jurídica";
            this.rdbCnpj.UseVisualStyleBackColor = false;
            // 
            // rdbCpf
            // 
            this.rdbCpf.AutoSize = true;
            this.rdbCpf.Checked = true;
            this.rdbCpf.Location = new System.Drawing.Point(8, 8);
            this.rdbCpf.Name = "rdbCpf";
            this.rdbCpf.Size = new System.Drawing.Size(106, 21);
            this.rdbCpf.TabIndex = 89;
            this.rdbCpf.TabStop = true;
            this.rdbCpf.Text = "Pessoa Física";
            this.rdbCpf.UseVisualStyleBackColor = false;
            // 
            // txtFone_2
            // 
            this.txtFone_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFone_2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone_2.Location = new System.Drawing.Point(488, 120);
            this.txtFone_2.Mask = "(99) 9999-9999";
            this.txtFone_2.Name = "txtFone_2";
            this.txtFone_2.Size = new System.Drawing.Size(96, 22);
            this.txtFone_2.TabIndex = 106;
            this.txtFone_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFone_2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbFone_2
            // 
            this.lbFone_2.AutoSize = true;
            this.lbFone_2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFone_2.Location = new System.Drawing.Point(488, 104);
            this.lbFone_2.Name = "lbFone_2";
            this.lbFone_2.Size = new System.Drawing.Size(38, 15);
            this.lbFone_2.TabIndex = 109;
            this.lbFone_2.Text = "Fixo..:";
            // 
            // txtFone_1
            // 
            this.txtFone_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFone_1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone_1.Location = new System.Drawing.Point(368, 120);
            this.txtFone_1.Mask = "(99) 99999-9999";
            this.txtFone_1.Name = "txtFone_1";
            this.txtFone_1.Size = new System.Drawing.Size(96, 22);
            this.txtFone_1.TabIndex = 105;
            this.txtFone_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFone_1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbFone_1
            // 
            this.lbFone_1.AutoSize = true;
            this.lbFone_1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFone_1.Location = new System.Drawing.Point(368, 104);
            this.lbFone_1.Name = "lbFone_1";
            this.lbFone_1.Size = new System.Drawing.Size(52, 15);
            this.lbFone_1.TabIndex = 108;
            this.lbFone_1.Text = "Celular..:";
            // 
            // txtCep
            // 
            this.txtCep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCep.Culture = new System.Globalization.CultureInfo("");
            this.txtCep.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCep.Location = new System.Drawing.Point(968, 24);
            this.txtCep.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCep.Mask = "99999-999";
            this.txtCep.Name = "txtCep";
            this.txtCep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCep.Size = new System.Drawing.Size(73, 22);
            this.txtCep.TabIndex = 94;
            this.txtCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbCep
            // 
            this.lbCep.AutoSize = true;
            this.lbCep.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCep.Location = new System.Drawing.Point(968, 8);
            this.lbCep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCep.Name = "lbCep";
            this.lbCep.Size = new System.Drawing.Size(38, 15);
            this.lbCep.TabIndex = 103;
            this.lbCep.Text = "Cep..:";
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCadastro.Enabled = false;
            this.txtDataCadastro.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataCadastro.Location = new System.Drawing.Point(823, 24);
            this.txtDataCadastro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.Size = new System.Drawing.Size(120, 22);
            this.txtDataCadastro.TabIndex = 92;
            this.txtDataCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbDataCadastro
            // 
            this.lbDataCadastro.AutoSize = true;
            this.lbDataCadastro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataCadastro.Location = new System.Drawing.Point(824, 8);
            this.lbDataCadastro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDataCadastro.Name = "lbDataCadastro";
            this.lbDataCadastro.Size = new System.Drawing.Size(92, 15);
            this.lbDataCadastro.TabIndex = 100;
            this.lbDataCadastro.Text = "Data Cadastro..:";
            // 
            // txtNomeRazaoSocial
            // 
            this.txtNomeRazaoSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeRazaoSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeRazaoSocial.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeRazaoSocial.Location = new System.Drawing.Point(326, 24);
            this.txtNomeRazaoSocial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNomeRazaoSocial.Name = "txtNomeRazaoSocial";
            this.txtNomeRazaoSocial.Size = new System.Drawing.Size(472, 22);
            this.txtNomeRazaoSocial.TabIndex = 93;
            // 
            // lbNomeRazaoSocial
            // 
            this.lbNomeRazaoSocial.AutoSize = true;
            this.lbNomeRazaoSocial.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomeRazaoSocial.Location = new System.Drawing.Point(326, 8);
            this.lbNomeRazaoSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNomeRazaoSocial.Name = "lbNomeRazaoSocial";
            this.lbNomeRazaoSocial.Size = new System.Drawing.Size(119, 15);
            this.lbNomeRazaoSocial.TabIndex = 98;
            this.lbNomeRazaoSocial.Text = "Nome/Razão Social..:";
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCpfCnpj.Culture = new System.Globalization.CultureInfo("");
            this.txtCpfCnpj.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCpfCnpj.Location = new System.Drawing.Point(136, 24);
            this.txtCpfCnpj.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCpfCnpj.Name = "txtCpfCnpj";
            this.txtCpfCnpj.Size = new System.Drawing.Size(122, 22);
            this.txtCpfCnpj.TabIndex = 91;
            this.txtCpfCnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCpfCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbCpfCnpj
            // 
            this.lbCpfCnpj.AutoSize = true;
            this.lbCpfCnpj.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCpfCnpj.Location = new System.Drawing.Point(136, 8);
            this.lbCpfCnpj.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCpfCnpj.Name = "lbCpfCnpj";
            this.lbCpfCnpj.Size = new System.Drawing.Size(65, 15);
            this.lbCpfCnpj.TabIndex = 95;
            this.lbCpfCnpj.Text = "Cpf/Cnpj..:";
            // 
            // tabInformacoesAdicionais
            // 
            this.tabInformacoesAdicionais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabInformacoesAdicionais.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInformacoesAdicionais.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInformacoesAdicionais.Location = new System.Drawing.Point(4, 24);
            this.tabInformacoesAdicionais.Name = "tabInformacoesAdicionais";
            this.tabInformacoesAdicionais.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformacoesAdicionais.Size = new System.Drawing.Size(1100, 194);
            this.tabInformacoesAdicionais.TabIndex = 1;
            this.tabInformacoesAdicionais.Text = "  Informações Adicionais";
            // 
            // frmFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 505);
            this.Controls.Add(this.tabControlFornecedores);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.listViewFornecedores);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmFornecedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Fornecedores";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.tabControlFornecedores.ResumeLayout(false);
            this.tabDadosFornecedor.ResumeLayout(false);
            this.tabDadosFornecedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ListView listViewFornecedores;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.TextBox txtIDFornecedor;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Label lbTotalRegistros;
        private System.Windows.Forms.TabControl tabControlFornecedores;
        private System.Windows.Forms.TabPage tabDadosFornecedor;
        private System.Windows.Forms.TabPage tabInformacoesAdicionais;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lbContato;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lbUF;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label lbMunicipio;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label lbBairro;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lbEndereco;
        private System.Windows.Forms.Button btnPesquisarCnpj;
        private System.Windows.Forms.Button btnPesquisaCep;
        private System.Windows.Forms.RadioButton rdbCnpj;
        private System.Windows.Forms.RadioButton rdbCpf;
        private System.Windows.Forms.MaskedTextBox txtFone_2;
        private System.Windows.Forms.Label lbFone_2;
        private System.Windows.Forms.MaskedTextBox txtFone_1;
        private System.Windows.Forms.Label lbFone_1;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.Label lbCep;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.Label lbDataCadastro;
        private System.Windows.Forms.TextBox txtNomeRazaoSocial;
        private System.Windows.Forms.Label lbNomeRazaoSocial;
        private System.Windows.Forms.MaskedTextBox txtCpfCnpj;
        private System.Windows.Forms.Label lbCpfCnpj;
    }
}
namespace ProjetoTeste
{
    partial class frmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            this.txtIDUsuario = new System.Windows.Forms.TextBox();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.listViewUsuario = new System.Windows.Forms.ListView();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.tabControlUsuarios = new System.Windows.Forms.TabControl();
            this.tabDadosUsuario = new System.Windows.Forms.TabPage();
            this.btnExcluirImagem = new System.Windows.Forms.Button();
            this.btnInserirImagem = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtFone_2 = new System.Windows.Forms.MaskedTextBox();
            this.lbFone_2 = new System.Windows.Forms.Label();
            this.txtFone_1 = new System.Windows.Forms.MaskedTextBox();
            this.lbFone_1 = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.lbUF = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.lbMunicipio = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lbBairro = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lbNumero = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lbEndereco = new System.Windows.Forms.Label();
            this.btnPesquisaCep = new System.Windows.Forms.Button();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.lbCep = new System.Windows.Forms.Label();
            this.txtConfirmaSenha = new System.Windows.Forms.TextBox();
            this.lblConfirme = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.lbImagemUsuario = new System.Windows.Forms.Label();
            this.imgImagemUsuario = new System.Windows.Forms.PictureBox();
            this.tabInformacoesAdicionais = new System.Windows.Forms.TabPage();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.lbDataCadastro = new System.Windows.Forms.Label();
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.tabControlUsuarios.SuspendLayout();
            this.tabDadosUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagemUsuario)).BeginInit();
            this.tabInformacoesAdicionais.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIDUsuario
            // 
            this.txtIDUsuario.Location = new System.Drawing.Point(1068, 168);
            this.txtIDUsuario.Name = "txtIDUsuario";
            this.txtIDUsuario.Size = new System.Drawing.Size(20, 22);
            this.txtIDUsuario.TabIndex = 69;
            this.txtIDUsuario.Text = " ";
            this.txtIDUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIDUsuario.Visible = false;
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // lbTotalRegistros
            // 
            this.lbTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTotalRegistros.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erpProvider.SetIconAlignment(this.lbTotalRegistros, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.lbTotalRegistros.Location = new System.Drawing.Point(8, 6);
            this.lbTotalRegistros.Name = "lbTotalRegistros";
            this.lbTotalRegistros.Size = new System.Drawing.Size(312, 33);
            this.lbTotalRegistros.TabIndex = 58;
            this.lbTotalRegistros.Tag = "\"naoAplicar\"";
            this.lbTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewUsuario
            // 
            this.listViewUsuario.CausesValidation = false;
            this.listViewUsuario.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewUsuario.FullRowSelect = true;
            this.listViewUsuario.GridLines = true;
            this.listViewUsuario.HideSelection = false;
            this.listViewUsuario.Location = new System.Drawing.Point(14, 229);
            this.listViewUsuario.Name = "listViewUsuario";
            this.listViewUsuario.Size = new System.Drawing.Size(1108, 219);
            this.listViewUsuario.TabIndex = 75;
            this.listViewUsuario.UseCompatibleStateImageBehavior = false;
            this.listViewUsuario.View = System.Windows.Forms.View.Details;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotoes.Controls.Add(this.btnFechar);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Controls.Add(this.lbTotalRegistros);
            this.pnlBotoes.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBotoes.Location = new System.Drawing.Point(14, 452);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(1108, 49);
            this.pnlBotoes.TabIndex = 96;
            // 
            // btnFechar
            // 
            this.btnFechar.AutoSize = true;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(968, 2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(98, 40);
            this.btnFechar.TabIndex = 63;
            this.btnFechar.Text = "     Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(760, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(98, 40);
            this.btnSalvar.TabIndex = 61;
            this.btnSalvar.Text = "      Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(656, 2);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(98, 40);
            this.btnAlterar.TabIndex = 60;
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
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(864, 2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(98, 40);
            this.btnExcluir.TabIndex = 62;
            this.btnExcluir.Text = "     Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.AutoSize = true;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(552, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(98, 40);
            this.btnNovo.TabIndex = 59;
            this.btnNovo.Text = "     Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // tabControlUsuarios
            // 
            this.tabControlUsuarios.Controls.Add(this.tabDadosUsuario);
            this.tabControlUsuarios.Controls.Add(this.tabInformacoesAdicionais);
            this.tabControlUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlUsuarios.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlUsuarios.Location = new System.Drawing.Point(14, 3);
            this.tabControlUsuarios.Multiline = true;
            this.tabControlUsuarios.Name = "tabControlUsuarios";
            this.tabControlUsuarios.SelectedIndex = 0;
            this.tabControlUsuarios.Size = new System.Drawing.Size(1108, 222);
            this.tabControlUsuarios.TabIndex = 97;
            // 
            // tabDadosUsuario
            // 
            this.tabDadosUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosUsuario.Controls.Add(this.btnExcluirImagem);
            this.tabDadosUsuario.Controls.Add(this.btnInserirImagem);
            this.tabDadosUsuario.Controls.Add(this.txtEmail);
            this.tabDadosUsuario.Controls.Add(this.lblEmail);
            this.tabDadosUsuario.Controls.Add(this.txtFone_2);
            this.tabDadosUsuario.Controls.Add(this.lbFone_2);
            this.tabDadosUsuario.Controls.Add(this.txtFone_1);
            this.tabDadosUsuario.Controls.Add(this.lbFone_1);
            this.tabDadosUsuario.Controls.Add(this.txtIDUsuario);
            this.tabDadosUsuario.Controls.Add(this.txtUF);
            this.tabDadosUsuario.Controls.Add(this.lbUF);
            this.tabDadosUsuario.Controls.Add(this.txtMunicipio);
            this.tabDadosUsuario.Controls.Add(this.lbMunicipio);
            this.tabDadosUsuario.Controls.Add(this.txtBairro);
            this.tabDadosUsuario.Controls.Add(this.lbBairro);
            this.tabDadosUsuario.Controls.Add(this.txtNumero);
            this.tabDadosUsuario.Controls.Add(this.lbNumero);
            this.tabDadosUsuario.Controls.Add(this.txtEndereco);
            this.tabDadosUsuario.Controls.Add(this.lbEndereco);
            this.tabDadosUsuario.Controls.Add(this.btnPesquisaCep);
            this.tabDadosUsuario.Controls.Add(this.txtCep);
            this.tabDadosUsuario.Controls.Add(this.lbCep);
            this.tabDadosUsuario.Controls.Add(this.txtConfirmaSenha);
            this.tabDadosUsuario.Controls.Add(this.lblConfirme);
            this.tabDadosUsuario.Controls.Add(this.txtSenha);
            this.tabDadosUsuario.Controls.Add(this.lblSenha);
            this.tabDadosUsuario.Controls.Add(this.txtLogin);
            this.tabDadosUsuario.Controls.Add(this.lblLogin);
            this.tabDadosUsuario.Controls.Add(this.txtNome);
            this.tabDadosUsuario.Controls.Add(this.lbNome);
            this.tabDadosUsuario.Controls.Add(this.txtPesquisaListView);
            this.tabDadosUsuario.Controls.Add(this.lblPesquisaListView);
            this.tabDadosUsuario.Controls.Add(this.lbImagemUsuario);
            this.tabDadosUsuario.Controls.Add(this.imgImagemUsuario);
            this.tabDadosUsuario.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosUsuario.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosUsuario.Location = new System.Drawing.Point(4, 24);
            this.tabDadosUsuario.Name = "tabDadosUsuario";
            this.tabDadosUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosUsuario.Size = new System.Drawing.Size(1100, 194);
            this.tabDadosUsuario.TabIndex = 0;
            this.tabDadosUsuario.Text = "Dados do Usuário";
            // 
            // btnExcluirImagem
            // 
            this.btnExcluirImagem.AutoSize = true;
            this.btnExcluirImagem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluirImagem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirImagem.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirImagem.Image")));
            this.btnExcluirImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirImagem.Location = new System.Drawing.Point(976, 80);
            this.btnExcluirImagem.Name = "btnExcluirImagem";
            this.btnExcluirImagem.Size = new System.Drawing.Size(98, 40);
            this.btnExcluirImagem.TabIndex = 156;
            this.btnExcluirImagem.Text = "     Excluir";
            this.btnExcluirImagem.UseVisualStyleBackColor = false;
            this.btnExcluirImagem.Click += new System.EventHandler(this.btnExcluirImagem_Click);
            // 
            // btnInserirImagem
            // 
            this.btnInserirImagem.AutoSize = true;
            this.btnInserirImagem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInserirImagem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserirImagem.Image = ((System.Drawing.Image)(resources.GetObject("btnInserirImagem.Image")));
            this.btnInserirImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInserirImagem.Location = new System.Drawing.Point(976, 32);
            this.btnInserirImagem.Name = "btnInserirImagem";
            this.btnInserirImagem.Size = new System.Drawing.Size(98, 40);
            this.btnInserirImagem.TabIndex = 155;
            this.btnInserirImagem.Text = "     Inserir";
            this.btnInserirImagem.UseVisualStyleBackColor = false;
            this.btnInserirImagem.Click += new System.EventHandler(this.btnInserirImagem_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(536, 120);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(272, 22);
            this.txtEmail.TabIndex = 151;
            this.tlpDicas.SetToolTip(this.txtEmail, "Informe o E-Mail.");
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(536, 103);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 15);
            this.lblEmail.TabIndex = 154;
            this.lblEmail.Text = "E-Mail..:";
            // 
            // txtFone_2
            // 
            this.txtFone_2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone_2.Location = new System.Drawing.Point(419, 120);
            this.txtFone_2.Mask = "(99) 9999-9999";
            this.txtFone_2.Name = "txtFone_2";
            this.txtFone_2.Size = new System.Drawing.Size(93, 22);
            this.txtFone_2.TabIndex = 150;
            this.txtFone_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFone_2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tlpDicas.SetToolTip(this.txtFone_2, "Informe o Telefone Fixo.");
            // 
            // lbFone_2
            // 
            this.lbFone_2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFone_2.Location = new System.Drawing.Point(419, 103);
            this.lbFone_2.Name = "lbFone_2";
            this.lbFone_2.Size = new System.Drawing.Size(35, 15);
            this.lbFone_2.TabIndex = 153;
            this.lbFone_2.Text = "Fixo..:";
            // 
            // txtFone_1
            // 
            this.txtFone_1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone_1.Location = new System.Drawing.Point(304, 120);
            this.txtFone_1.Mask = "(99) 99999-9999";
            this.txtFone_1.Name = "txtFone_1";
            this.txtFone_1.Size = new System.Drawing.Size(93, 22);
            this.txtFone_1.TabIndex = 149;
            this.txtFone_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFone_1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tlpDicas.SetToolTip(this.txtFone_1, "Informe o Celular.");
            // 
            // lbFone_1
            // 
            this.lbFone_1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFone_1.Location = new System.Drawing.Point(304, 103);
            this.lbFone_1.Name = "lbFone_1";
            this.lbFone_1.Size = new System.Drawing.Size(49, 15);
            this.lbFone_1.TabIndex = 152;
            this.lbFone_1.Text = "Celular..:";
            // 
            // txtUF
            // 
            this.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUF.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUF.Location = new System.Drawing.Point(246, 120);
            this.txtUF.MaxLength = 2;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(36, 22);
            this.txtUF.TabIndex = 146;
            this.txtUF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tlpDicas.SetToolTip(this.txtUF, "Informe o Estado.");
            // 
            // lbUF
            // 
            this.lbUF.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUF.Location = new System.Drawing.Point(250, 103);
            this.lbUF.Name = "lbUF";
            this.lbUF.Size = new System.Drawing.Size(28, 15);
            this.lbUF.TabIndex = 148;
            this.lbUF.Text = "UF..:";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMunicipio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMunicipio.Location = new System.Drawing.Point(8, 120);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(216, 22);
            this.txtMunicipio.TabIndex = 145;
            this.tlpDicas.SetToolTip(this.txtMunicipio, "Informe o Municipio.");
            // 
            // lbMunicipio
            // 
            this.lbMunicipio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMunicipio.Location = new System.Drawing.Point(8, 103);
            this.lbMunicipio.Name = "lbMunicipio";
            this.lbMunicipio.Size = new System.Drawing.Size(68, 15);
            this.lbMunicipio.TabIndex = 147;
            this.lbMunicipio.Text = "Municipio..:";
            // 
            // txtBairro
            // 
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(575, 73);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(233, 22);
            this.txtBairro.TabIndex = 141;
            this.tlpDicas.SetToolTip(this.txtBairro, "Informe o Bairro.");
            // 
            // lbBairro
            // 
            this.lbBairro.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBairro.Location = new System.Drawing.Point(575, 56);
            this.lbBairro.Name = "lbBairro";
            this.lbBairro.Size = new System.Drawing.Size(48, 15);
            this.lbBairro.TabIndex = 144;
            this.lbBairro.Text = "Bairro..:";
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(485, 73);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(67, 22);
            this.txtNumero.TabIndex = 140;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpDicas.SetToolTip(this.txtNumero, "Informe o Numero.");
            // 
            // lbNumero
            // 
            this.lbNumero.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumero.Location = new System.Drawing.Point(485, 56);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(57, 15);
            this.lbNumero.TabIndex = 143;
            this.lbNumero.Text = "Numero..:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndereco.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(147, 72);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(315, 22);
            this.txtEndereco.TabIndex = 139;
            this.tlpDicas.SetToolTip(this.txtEndereco, "Informe o Endereço.");
            // 
            // lbEndereco
            // 
            this.lbEndereco.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndereco.Location = new System.Drawing.Point(147, 55);
            this.lbEndereco.Name = "lbEndereco";
            this.lbEndereco.Size = new System.Drawing.Size(62, 15);
            this.lbEndereco.TabIndex = 142;
            this.lbEndereco.Text = "Endereço..:";
            // 
            // btnPesquisaCep
            // 
            this.btnPesquisaCep.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisaCep.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisaCep.Image")));
            this.btnPesquisaCep.Location = new System.Drawing.Point(87, 70);
            this.btnPesquisaCep.Name = "btnPesquisaCep";
            this.btnPesquisaCep.Size = new System.Drawing.Size(37, 26);
            this.btnPesquisaCep.TabIndex = 138;
            this.tlpDicas.SetToolTip(this.btnPesquisaCep, "Botão para Pesquisar o Cep na Internet.");
            this.btnPesquisaCep.UseVisualStyleBackColor = false;
            this.btnPesquisaCep.Click += new System.EventHandler(this.btnPesquisaCep_Click);
            // 
            // txtCep
            // 
            this.txtCep.Culture = new System.Globalization.CultureInfo("");
            this.txtCep.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCep.Location = new System.Drawing.Point(8, 72);
            this.txtCep.Mask = "99999-999";
            this.txtCep.Name = "txtCep";
            this.txtCep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCep.Size = new System.Drawing.Size(73, 22);
            this.txtCep.TabIndex = 136;
            this.txtCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tlpDicas.SetToolTip(this.txtCep, "Informe o Cep.");
            // 
            // lbCep
            // 
            this.lbCep.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCep.Location = new System.Drawing.Point(8, 55);
            this.lbCep.Name = "lbCep";
            this.lbCep.Size = new System.Drawing.Size(35, 15);
            this.lbCep.TabIndex = 137;
            this.lbCep.Text = "Cep..:";
            // 
            // txtConfirmaSenha
            // 
            this.txtConfirmaSenha.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmaSenha.Location = new System.Drawing.Point(680, 24);
            this.txtConfirmaSenha.Name = "txtConfirmaSenha";
            this.txtConfirmaSenha.Size = new System.Drawing.Size(128, 22);
            this.txtConfirmaSenha.TabIndex = 134;
            this.tlpDicas.SetToolTip(this.txtConfirmaSenha, "Confirme a Senha.");
            this.txtConfirmaSenha.UseSystemPasswordChar = true;
            // 
            // lblConfirme
            // 
            this.lblConfirme.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirme.Location = new System.Drawing.Point(680, 7);
            this.lblConfirme.Name = "lblConfirme";
            this.lblConfirme.Size = new System.Drawing.Size(102, 15);
            this.lblConfirme.TabIndex = 135;
            this.lblConfirme.Text = "Confirme Senha..:";
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(538, 24);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(113, 22);
            this.txtSenha.TabIndex = 130;
            this.tlpDicas.SetToolTip(this.txtSenha, "Informe a Senha.");
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // lblSenha
            // 
            this.lblSenha.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(538, 7);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(48, 15);
            this.lblSenha.TabIndex = 133;
            this.lblSenha.Text = "Senha..:";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(336, 24);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(179, 22);
            this.txtLogin.TabIndex = 129;
            this.tlpDicas.SetToolTip(this.txtLogin, "Informe o Login.");
            // 
            // lblLogin
            // 
            this.lblLogin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(336, 7);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(44, 15);
            this.lblLogin.TabIndex = 132;
            this.lblLogin.Text = "Login..:";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(8, 24);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(296, 22);
            this.txtNome.TabIndex = 128;
            this.tlpDicas.SetToolTip(this.txtNome, "Informe o Nome Completo.");
            // 
            // lbNome
            // 
            this.lbNome.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNome.Location = new System.Drawing.Point(8, 7);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(99, 15);
            this.lbNome.TabIndex = 131;
            this.lbNome.Text = "Nome Completo..:";
            // 
            // txtPesquisaListView
            // 
            this.txtPesquisaListView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaListView.Enabled = false;
            this.txtPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaListView.Location = new System.Drawing.Point(8, 166);
            this.txtPesquisaListView.Name = "txtPesquisaListView";
            this.txtPesquisaListView.Size = new System.Drawing.Size(328, 22);
            this.txtPesquisaListView.TabIndex = 56;
            this.tlpDicas.SetToolTip(this.txtPesquisaListView, "Informe o Usuário a Pesquisar.");
            this.txtPesquisaListView.TextChanged += new System.EventHandler(this.txtPesquisaListView_TextChanged);
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(8, 150);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(104, 15);
            this.lblPesquisaListView.TabIndex = 57;
            this.lblPesquisaListView.Text = "Pesquisa Usuário..:";
            // 
            // lbImagemUsuario
            // 
            this.lbImagemUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbImagemUsuario.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImagemUsuario.Location = new System.Drawing.Point(850, 8);
            this.lbImagemUsuario.Name = "lbImagemUsuario";
            this.lbImagemUsuario.Size = new System.Drawing.Size(100, 13);
            this.lbImagemUsuario.TabIndex = 90;
            this.lbImagemUsuario.Text = "Imagem Usuário..:";
            this.lbImagemUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgImagemUsuario
            // 
            this.imgImagemUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgImagemUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgImagemUsuario.Location = new System.Drawing.Point(828, 24);
            this.imgImagemUsuario.Name = "imgImagemUsuario";
            this.imgImagemUsuario.Size = new System.Drawing.Size(136, 158);
            this.imgImagemUsuario.TabIndex = 89;
            this.imgImagemUsuario.TabStop = false;
            // 
            // tabInformacoesAdicionais
            // 
            this.tabInformacoesAdicionais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabInformacoesAdicionais.Controls.Add(this.txtDataCadastro);
            this.tabInformacoesAdicionais.Controls.Add(this.lbDataCadastro);
            this.tabInformacoesAdicionais.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInformacoesAdicionais.Location = new System.Drawing.Point(4, 24);
            this.tabInformacoesAdicionais.Name = "tabInformacoesAdicionais";
            this.tabInformacoesAdicionais.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformacoesAdicionais.Size = new System.Drawing.Size(1100, 194);
            this.tabInformacoesAdicionais.TabIndex = 1;
            this.tabInformacoesAdicionais.Text = "  Informações Adicionais";
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCadastro.Enabled = false;
            this.txtDataCadastro.Location = new System.Drawing.Point(8, 24);
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.Size = new System.Drawing.Size(117, 22);
            this.txtDataCadastro.TabIndex = 114;
            this.txtDataCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tlpDicas.SetToolTip(this.txtDataCadastro, "Informe a Data do Cadastro.");
            // 
            // lbDataCadastro
            // 
            this.lbDataCadastro.Location = new System.Drawing.Point(8, 7);
            this.lbDataCadastro.Name = "lbDataCadastro";
            this.lbDataCadastro.Size = new System.Drawing.Size(89, 15);
            this.lbDataCadastro.TabIndex = 115;
            this.lbDataCadastro.Text = "Data Cadastro..:";
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 505);
            this.Controls.Add(this.tabControlUsuarios);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.listViewUsuario);
            this.Name = "frmUsuarios";
            this.Text = "Cadastro de Usuários";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.tabControlUsuarios.ResumeLayout(false);
            this.tabDadosUsuario.ResumeLayout(false);
            this.tabDadosUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagemUsuario)).EndInit();
            this.tabInformacoesAdicionais.ResumeLayout(false);
            this.tabInformacoesAdicionais.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TextBox txtIDUsuario;
        private System.Windows.Forms.ListView listViewUsuario;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Label lbTotalRegistros;
        private System.Windows.Forms.TabControl tabControlUsuarios;
        private System.Windows.Forms.TabPage tabDadosUsuario;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.Label lbImagemUsuario;
        private System.Windows.Forms.PictureBox imgImagemUsuario;
        private System.Windows.Forms.TabPage tabInformacoesAdicionais;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox txtConfirmaSenha;
        private System.Windows.Forms.Label lblConfirme;
        private System.Windows.Forms.Button btnPesquisaCep;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.Label lbCep;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label lbBairro;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lbEndereco;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.Label lbUF;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label lbMunicipio;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.MaskedTextBox txtFone_2;
        private System.Windows.Forms.Label lbFone_2;
        private System.Windows.Forms.MaskedTextBox txtFone_1;
        private System.Windows.Forms.Label lbFone_1;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.Label lbDataCadastro;
        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnInserirImagem;
        private System.Windows.Forms.Button btnExcluirImagem;
    }
}
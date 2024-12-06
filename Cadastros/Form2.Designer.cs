namespace ProjetoTeste.Cadastros
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.imgLista = new System.Windows.Forms.ImageList(this.components);
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.lbContato = new System.Windows.Forms.Label();
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
            this.btnPesquisarCnpj = new System.Windows.Forms.Button();
            this.btnPesquisaCep = new System.Windows.Forms.Button();
            this.rdbCnpj = new System.Windows.Forms.RadioButton();
            this.rdbCpf = new System.Windows.Forms.RadioButton();
            this.txtCpfCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lbCpfCnpj = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.txtIDFornecedor = new System.Windows.Forms.TextBox();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.lbCep = new System.Windows.Forms.Label();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.lbDataCadastro = new System.Windows.Forms.Label();
            this.txtNomeRazaoSocial = new System.Windows.Forms.TextBox();
            this.lbNomeRazaoSocial = new System.Windows.Forms.Label();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtFone_2 = new System.Windows.Forms.MaskedTextBox();
            this.lbFone_2 = new System.Windows.Forms.Label();
            this.txtFone_1 = new System.Windows.Forms.MaskedTextBox();
            this.lbFone_1 = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.listViewFornecedores = new System.Windows.Forms.ListView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLista
            // 
            this.imgLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLista.ImageStream")));
            this.imgLista.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLista.Images.SetKeyName(0, "images (9).jpeg");
            this.imgLista.Images.SetKeyName(1, "images (10).jpeg");
            this.imgLista.Images.SetKeyName(2, "images (11).jpeg");
            this.imgLista.Images.SetKeyName(3, "user-login-icon-29.png");
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "images (9).jpeg");
            this.imageList1.Images.SetKeyName(1, "images (10).jpeg");
            this.imageList1.Images.SetKeyName(2, "images (11).jpeg");
            this.imageList1.Images.SetKeyName(3, "user-login-icon-29.png");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // lbTotalRegistros
            // 
            this.lbTotalRegistros.AutoSize = true;
            this.lbTotalRegistros.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRegistros.Location = new System.Drawing.Point(162, 468);
            this.lbTotalRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalRegistros.Name = "lbTotalRegistros";
            this.lbTotalRegistros.Size = new System.Drawing.Size(0, 19);
            this.lbTotalRegistros.TabIndex = 89;
            // 
            // txtPesquisaListView
            // 
            this.txtPesquisaListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisaListView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaListView.Enabled = false;
            this.txtPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaListView.Location = new System.Drawing.Point(156, 167);
            this.txtPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPesquisaListView.Name = "txtPesquisaListView";
            this.txtPesquisaListView.Size = new System.Drawing.Size(374, 22);
            this.txtPesquisaListView.TabIndex = 87;
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.AutoSize = true;
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(156, 151);
            this.lblPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(110, 15);
            this.lblPesquisaListView.TabIndex = 88;
            this.lblPesquisaListView.Text = "Pesquisa Cadastro..:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(874, 122);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(394, 22);
            this.txtEmail.TabIndex = 68;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(874, 106);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 15);
            this.lblEmail.TabIndex = 86;
            this.lblEmail.Text = "E-Mail..:";
            // 
            // txtContato
            // 
            this.txtContato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContato.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContato.Location = new System.Drawing.Point(156, 122);
            this.txtContato.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(374, 22);
            this.txtContato.TabIndex = 65;
            // 
            // lbContato
            // 
            this.lbContato.AutoSize = true;
            this.lbContato.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContato.Location = new System.Drawing.Point(156, 106);
            this.lbContato.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbContato.Name = "lbContato";
            this.lbContato.Size = new System.Drawing.Size(56, 15);
            this.lbContato.TabIndex = 85;
            this.lbContato.Text = "Contato..:";
            // 
            // txtUF
            // 
            this.txtUF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUF.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUF.Location = new System.Drawing.Point(1232, 79);
            this.txtUF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUF.MaxLength = 2;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(36, 22);
            this.txtUF.TabIndex = 63;
            // 
            // lbUF
            // 
            this.lbUF.AutoSize = true;
            this.lbUF.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUF.Location = new System.Drawing.Point(1232, 63);
            this.lbUF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUF.Name = "lbUF";
            this.lbUF.Size = new System.Drawing.Size(26, 15);
            this.lbUF.TabIndex = 84;
            this.lbUF.Text = "Uf..:";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMunicipio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMunicipio.Location = new System.Drawing.Point(873, 79);
            this.txtMunicipio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(322, 22);
            this.txtMunicipio.TabIndex = 62;
            // 
            // lbMunicipio
            // 
            this.lbMunicipio.AutoSize = true;
            this.lbMunicipio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMunicipio.Location = new System.Drawing.Point(873, 63);
            this.lbMunicipio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMunicipio.Name = "lbMunicipio";
            this.lbMunicipio.Size = new System.Drawing.Size(68, 15);
            this.lbMunicipio.TabIndex = 83;
            this.lbMunicipio.Text = "Municipio..:";
            // 
            // txtBairro
            // 
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(628, 79);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(198, 22);
            this.txtBairro.TabIndex = 60;
            // 
            // lbBairro
            // 
            this.lbBairro.AutoSize = true;
            this.lbBairro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBairro.Location = new System.Drawing.Point(628, 63);
            this.lbBairro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBairro.Name = "lbBairro";
            this.lbBairro.Size = new System.Drawing.Size(48, 15);
            this.lbBairro.TabIndex = 82;
            this.lbBairro.Text = "Bairro..:";
            // 
            // txtNumero
            // 
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(514, 79);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(67, 22);
            this.txtNumero.TabIndex = 59;
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumero.Location = new System.Drawing.Point(514, 63);
            this.lbNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(57, 15);
            this.lbNumero.TabIndex = 81;
            this.lbNumero.Text = "Numero..:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndereco.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(156, 79);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(315, 22);
            this.txtEndereco.TabIndex = 57;
            // 
            // lbEndereco
            // 
            this.lbEndereco.AutoSize = true;
            this.lbEndereco.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndereco.Location = new System.Drawing.Point(156, 63);
            this.lbEndereco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEndereco.Name = "lbEndereco";
            this.lbEndereco.Size = new System.Drawing.Size(62, 15);
            this.lbEndereco.TabIndex = 80;
            this.lbEndereco.Text = "Endereço..:";
            // 
            // btnPesquisarCnpj
            // 
            this.btnPesquisarCnpj.Location = new System.Drawing.Point(405, 32);
            this.btnPesquisarCnpj.Name = "btnPesquisarCnpj";
            this.btnPesquisarCnpj.Size = new System.Drawing.Size(37, 24);
            this.btnPesquisarCnpj.TabIndex = 79;
            this.btnPesquisarCnpj.UseVisualStyleBackColor = false;
            // 
            // btnPesquisaCep
            // 
            this.btnPesquisaCep.Location = new System.Drawing.Point(1231, 32);
            this.btnPesquisaCep.Name = "btnPesquisaCep";
            this.btnPesquisaCep.Size = new System.Drawing.Size(37, 24);
            this.btnPesquisaCep.TabIndex = 78;
            this.btnPesquisaCep.UseVisualStyleBackColor = false;
            // 
            // rdbCnpj
            // 
            this.rdbCnpj.AutoSize = true;
            this.rdbCnpj.Location = new System.Drawing.Point(156, 36);
            this.rdbCnpj.Name = "rdbCnpj";
            this.rdbCnpj.Size = new System.Drawing.Size(99, 17);
            this.rdbCnpj.TabIndex = 51;
            this.rdbCnpj.TabStop = true;
            this.rdbCnpj.Text = "Pessoa Juridica";
            this.rdbCnpj.UseVisualStyleBackColor = false;
            // 
            // rdbCpf
            // 
            this.rdbCpf.AutoSize = true;
            this.rdbCpf.Location = new System.Drawing.Point(156, 17);
            this.rdbCpf.Name = "rdbCpf";
            this.rdbCpf.Size = new System.Drawing.Size(92, 17);
            this.rdbCpf.TabIndex = 50;
            this.rdbCpf.TabStop = true;
            this.rdbCpf.Text = "Pessoa Física";
            this.rdbCpf.UseVisualStyleBackColor = false;
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCpfCnpj.Culture = new System.Globalization.CultureInfo("");
            this.txtCpfCnpj.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCpfCnpj.Location = new System.Drawing.Point(276, 33);
            this.txtCpfCnpj.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCpfCnpj.Name = "txtCpfCnpj";
            this.txtCpfCnpj.Size = new System.Drawing.Size(122, 22);
            this.txtCpfCnpj.TabIndex = 53;
            this.txtCpfCnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCpfCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbCpfCnpj
            // 
            this.lbCpfCnpj.AutoSize = true;
            this.lbCpfCnpj.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCpfCnpj.Location = new System.Drawing.Point(276, 17);
            this.lbCpfCnpj.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCpfCnpj.Name = "lbCpfCnpj";
            this.lbCpfCnpj.Size = new System.Drawing.Size(62, 15);
            this.lbCpfCnpj.TabIndex = 56;
            this.lbCpfCnpj.Text = "Cpf/Cnpj..:";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // txtIDFornecedor
            // 
            this.txtIDFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDFornecedor.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDFornecedor.Location = new System.Drawing.Point(871, 7);
            this.txtIDFornecedor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDFornecedor.Name = "txtIDFornecedor";
            this.txtIDFornecedor.Size = new System.Drawing.Size(23, 22);
            this.txtIDFornecedor.TabIndex = 69;
            this.txtIDFornecedor.Text = " ";
            this.txtIDFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIDFornecedor.Visible = false;
            // 
            // txtCep
            // 
            this.txtCep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCep.Culture = new System.Globalization.CultureInfo("");
            this.txtCep.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCep.Location = new System.Drawing.Point(1150, 33);
            this.txtCep.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCep.Mask = "99999-999";
            this.txtCep.Name = "txtCep";
            this.txtCep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCep.Size = new System.Drawing.Size(73, 22);
            this.txtCep.TabIndex = 55;
            this.txtCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbCep
            // 
            this.lbCep.AutoSize = true;
            this.lbCep.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCep.Location = new System.Drawing.Point(1147, 19);
            this.lbCep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCep.Name = "lbCep";
            this.lbCep.Size = new System.Drawing.Size(35, 15);
            this.lbCep.TabIndex = 64;
            this.lbCep.Text = "Cep..:";
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCadastro.Enabled = false;
            this.txtDataCadastro.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataCadastro.Location = new System.Drawing.Point(990, 35);
            this.txtDataCadastro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.Size = new System.Drawing.Size(117, 22);
            this.txtDataCadastro.TabIndex = 52;
            this.txtDataCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbDataCadastro
            // 
            this.lbDataCadastro.AutoSize = true;
            this.lbDataCadastro.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataCadastro.Location = new System.Drawing.Point(990, 19);
            this.lbDataCadastro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDataCadastro.Name = "lbDataCadastro";
            this.lbDataCadastro.Size = new System.Drawing.Size(89, 15);
            this.lbDataCadastro.TabIndex = 61;
            this.lbDataCadastro.Text = "Data Cadastro..:";
            // 
            // txtNomeRazaoSocial
            // 
            this.txtNomeRazaoSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeRazaoSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeRazaoSocial.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeRazaoSocial.Location = new System.Drawing.Point(482, 35);
            this.txtNomeRazaoSocial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNomeRazaoSocial.Name = "txtNomeRazaoSocial";
            this.txtNomeRazaoSocial.Size = new System.Drawing.Size(468, 22);
            this.txtNomeRazaoSocial.TabIndex = 54;
            // 
            // lbNomeRazaoSocial
            // 
            this.lbNomeRazaoSocial.AutoSize = true;
            this.lbNomeRazaoSocial.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomeRazaoSocial.Location = new System.Drawing.Point(482, 19);
            this.lbNomeRazaoSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNomeRazaoSocial.Name = "lbNomeRazaoSocial";
            this.lbNomeRazaoSocial.Size = new System.Drawing.Size(116, 15);
            this.lbNomeRazaoSocial.TabIndex = 58;
            this.lbNomeRazaoSocial.Text = "Nome/Razão Social..:";
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // txtFone_2
            // 
            this.txtFone_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFone_2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtFone_2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone_2.Location = new System.Drawing.Point(724, 124);
            this.txtFone_2.Mask = "(99) 9999-9999";
            this.txtFone_2.Name = "txtFone_2";
            this.txtFone_2.Size = new System.Drawing.Size(93, 22);
            this.txtFone_2.TabIndex = 67;
            this.txtFone_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFone_2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbFone_2
            // 
            this.lbFone_2.AutoSize = true;
            this.lbFone_2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFone_2.Location = new System.Drawing.Point(724, 106);
            this.lbFone_2.Name = "lbFone_2";
            this.lbFone_2.Size = new System.Drawing.Size(68, 15);
            this.lbFone_2.TabIndex = 77;
            this.lbFone_2.Text = "Telefone 2..:";
            // 
            // txtFone_1
            // 
            this.txtFone_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFone_1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone_1.Location = new System.Drawing.Point(581, 122);
            this.txtFone_1.Mask = "(99) 99999-9999";
            this.txtFone_1.Name = "txtFone_1";
            this.txtFone_1.Size = new System.Drawing.Size(93, 22);
            this.txtFone_1.TabIndex = 66;
            this.txtFone_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFone_1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbFone_1
            // 
            this.lbFone_1.AutoSize = true;
            this.lbFone_1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFone_1.Location = new System.Drawing.Point(581, 106);
            this.lbFone_1.Name = "lbFone_1";
            this.lbFone_1.Size = new System.Drawing.Size(68, 15);
            this.lbFone_1.TabIndex = 76;
            this.lbFone_1.Text = "Telefone 1..:";
            // 
            // btnNovo
            // 
            this.btnNovo.AutoSize = true;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(509, 460);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(98, 40);
            this.btnNovo.TabIndex = 70;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            // 
            // listViewFornecedores
            // 
            this.listViewFornecedores.CausesValidation = false;
            this.listViewFornecedores.FullRowSelect = true;
            this.listViewFornecedores.GridLines = true;
            this.listViewFornecedores.HideSelection = false;
            this.listViewFornecedores.Location = new System.Drawing.Point(156, 195);
            this.listViewFornecedores.Name = "listViewFornecedores";
            this.listViewFornecedores.Size = new System.Drawing.Size(1112, 257);
            this.listViewFornecedores.TabIndex = 75;
            this.listViewFornecedores.UseCompatibleStateImageBehavior = false;
            this.listViewFornecedores.View = System.Windows.Forms.View.Details;
            // 
            // btnFechar
            // 
            this.btnFechar.AutoSize = true;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(929, 460);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(98, 40);
            this.btnFechar.TabIndex = 74;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = true;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(823, 460);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(98, 40);
            this.btnExcluir.TabIndex = 73;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(613, 460);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(98, 40);
            this.btnAlterar.TabIndex = 71;
            this.btnAlterar.Tag = "";
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(719, 460);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(98, 40);
            this.btnSalvar.TabIndex = 72;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 500);
            this.Controls.Add(this.lbTotalRegistros);
            this.Controls.Add(this.txtPesquisaListView);
            this.Controls.Add(this.lblPesquisaListView);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtContato);
            this.Controls.Add(this.lbContato);
            this.Controls.Add(this.txtUF);
            this.Controls.Add(this.lbUF);
            this.Controls.Add(this.txtMunicipio);
            this.Controls.Add(this.lbMunicipio);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.lbBairro);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lbNumero);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.lbEndereco);
            this.Controls.Add(this.btnPesquisarCnpj);
            this.Controls.Add(this.btnPesquisaCep);
            this.Controls.Add(this.rdbCnpj);
            this.Controls.Add(this.rdbCpf);
            this.Controls.Add(this.txtCpfCnpj);
            this.Controls.Add(this.lbCpfCnpj);
            this.Controls.Add(this.txtIDFornecedor);
            this.Controls.Add(this.txtCep);
            this.Controls.Add(this.lbCep);
            this.Controls.Add(this.txtDataCadastro);
            this.Controls.Add(this.lbDataCadastro);
            this.Controls.Add(this.txtNomeRazaoSocial);
            this.Controls.Add(this.lbNomeRazaoSocial);
            this.Controls.Add(this.txtFone_2);
            this.Controls.Add(this.lbFone_2);
            this.Controls.Add(this.txtFone_1);
            this.Controls.Add(this.lbFone_1);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.listViewFornecedores);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnSalvar);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ImageList imgLista;
        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbTotalRegistros;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label lbContato;
        private System.Windows.Forms.TextBox txtUF;
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
        private System.Windows.Forms.MaskedTextBox txtCpfCnpj;
        private System.Windows.Forms.Label lbCpfCnpj;
        private System.Windows.Forms.TextBox txtIDFornecedor;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.Label lbCep;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.Label lbDataCadastro;
        private System.Windows.Forms.TextBox txtNomeRazaoSocial;
        private System.Windows.Forms.Label lbNomeRazaoSocial;
        private System.Windows.Forms.MaskedTextBox txtFone_2;
        private System.Windows.Forms.Label lbFone_2;
        private System.Windows.Forms.MaskedTextBox txtFone_1;
        private System.Windows.Forms.Label lbFone_1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ListView listViewFornecedores;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnSalvar;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}
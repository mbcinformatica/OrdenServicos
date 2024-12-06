namespace ProjetoTeste
{
    partial class frmLancamentoServicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLancamentoServicos));
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.imgImagemProduto = new System.Windows.Forms.PictureBox();
            this.tabDadosCliente = new System.Windows.Forms.TabPage();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.tabControlOrdenServico = new System.Windows.Forms.TabControl();
            this.tabDadosOrdenServico = new System.Windows.Forms.TabPage();
            this.lbValorTotalMaterial = new System.Windows.Forms.Label();
            this.txtValorTotalMaterial = new System.Windows.Forms.MaskedTextBox();
            this.lbValorServico = new System.Windows.Forms.Label();
            this.txtValorTotalServico = new System.Windows.Forms.MaskedTextBox();
            this.cmbProduto = new System.Windows.Forms.ComboBox();
            this.txtDescricaoDefeito = new System.Windows.Forms.TextBox();
            this.lbDescricaoDefeito = new System.Windows.Forms.Label();
            this.txtDataConclucao = new System.Windows.Forms.DateTimePicker();
            this.lbDataPrevistaConclucao = new System.Windows.Forms.Label();
            this.txtNumeroSerie = new System.Windows.Forms.TextBox();
            this.lbNumeroSerie = new System.Windows.Forms.Label();
            this.lbProduto = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lbMarcaProduto = new System.Windows.Forms.Label();
            this.txtDataEmissao = new System.Windows.Forms.DateTimePicker();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.lbImagemProduto = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lbCliente = new System.Windows.Forms.Label();
            this.ibDataEmissao = new System.Windows.Forms.Label();
            this.lbIDOrdenServico = new System.Windows.Forms.Label();
            this.txtIDOrdenServico = new System.Windows.Forms.TextBox();
            this.tabDadosMaterias = new System.Windows.Forms.TabPage();
            this.txtGarantiaMaterial = new System.Windows.Forms.TextBox();
            this.lbGarantiaMaterial = new System.Windows.Forms.Label();
            this.txtGarantiaServico = new System.Windows.Forms.TextBox();
            this.lbGarantiaServico = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.listViewLancamentoServicos = new System.Windows.Forms.ListView();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagemProduto)).BeginInit();
            this.tabControlOrdenServico.SuspendLayout();
            this.tabDadosOrdenServico.SuspendLayout();
            this.tabDadosMaterias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgImagemProduto
            // 
            this.imgImagemProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgImagemProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgImagemProduto.Location = new System.Drawing.Point(935, 24);
            this.imgImagemProduto.Name = "imgImagemProduto";
            this.imgImagemProduto.Size = new System.Drawing.Size(136, 160);
            this.imgImagemProduto.TabIndex = 89;
            this.imgImagemProduto.TabStop = false;
            this.tlpDicas.SetToolTip(this.imgImagemProduto, "Realiza Pesquisa desse Produto na Internet");
            // 
            // tabDadosCliente
            // 
            this.tabDadosCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDadosCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosCliente.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosCliente.Location = new System.Drawing.Point(4, 22);
            this.tabDadosCliente.Name = "tabDadosCliente";
            this.tabDadosCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosCliente.Size = new System.Drawing.Size(1100, 235);
            this.tabDadosCliente.TabIndex = 1;
            this.tabDadosCliente.Text = "   Dados do Cliente   ";
            // 
            // lbTotalRegistros
            // 
            this.lbTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTotalRegistros.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTotalRegistros.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erpProvider.SetIconAlignment(this.lbTotalRegistros, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.lbTotalRegistros.Location = new System.Drawing.Point(8, 6);
            this.lbTotalRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalRegistros.Name = "lbTotalRegistros";
            this.lbTotalRegistros.Size = new System.Drawing.Size(312, 33);
            this.lbTotalRegistros.TabIndex = 58;
            this.lbTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControlOrdenServico
            // 
            this.tabControlOrdenServico.Controls.Add(this.tabDadosOrdenServico);
            this.tabControlOrdenServico.Controls.Add(this.tabDadosCliente);
            this.tabControlOrdenServico.Controls.Add(this.tabDadosMaterias);
            this.tabControlOrdenServico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlOrdenServico.Location = new System.Drawing.Point(14, 3);
            this.tabControlOrdenServico.Multiline = true;
            this.tabControlOrdenServico.Name = "tabControlOrdenServico";
            this.tabControlOrdenServico.SelectedIndex = 0;
            this.tabControlOrdenServico.Size = new System.Drawing.Size(1108, 261);
            this.tabControlOrdenServico.TabIndex = 73;
            // 
            // tabDadosOrdenServico
            // 
            this.tabDadosOrdenServico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosOrdenServico.Controls.Add(this.lbValorTotalMaterial);
            this.tabDadosOrdenServico.Controls.Add(this.txtValorTotalMaterial);
            this.tabDadosOrdenServico.Controls.Add(this.lbValorServico);
            this.tabDadosOrdenServico.Controls.Add(this.txtValorTotalServico);
            this.tabDadosOrdenServico.Controls.Add(this.cmbProduto);
            this.tabDadosOrdenServico.Controls.Add(this.txtDescricaoDefeito);
            this.tabDadosOrdenServico.Controls.Add(this.lbDescricaoDefeito);
            this.tabDadosOrdenServico.Controls.Add(this.txtDataConclucao);
            this.tabDadosOrdenServico.Controls.Add(this.lbDataPrevistaConclucao);
            this.tabDadosOrdenServico.Controls.Add(this.txtNumeroSerie);
            this.tabDadosOrdenServico.Controls.Add(this.lbNumeroSerie);
            this.tabDadosOrdenServico.Controls.Add(this.lbProduto);
            this.tabDadosOrdenServico.Controls.Add(this.cmbMarca);
            this.tabDadosOrdenServico.Controls.Add(this.lbMarcaProduto);
            this.tabDadosOrdenServico.Controls.Add(this.txtDataEmissao);
            this.tabDadosOrdenServico.Controls.Add(this.txtPesquisaListView);
            this.tabDadosOrdenServico.Controls.Add(this.lblPesquisaListView);
            this.tabDadosOrdenServico.Controls.Add(this.lbImagemProduto);
            this.tabDadosOrdenServico.Controls.Add(this.imgImagemProduto);
            this.tabDadosOrdenServico.Controls.Add(this.cmbCliente);
            this.tabDadosOrdenServico.Controls.Add(this.lbCliente);
            this.tabDadosOrdenServico.Controls.Add(this.ibDataEmissao);
            this.tabDadosOrdenServico.Controls.Add(this.lbIDOrdenServico);
            this.tabDadosOrdenServico.Controls.Add(this.txtIDOrdenServico);
            this.tabDadosOrdenServico.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosOrdenServico.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosOrdenServico.Location = new System.Drawing.Point(4, 22);
            this.tabDadosOrdenServico.Name = "tabDadosOrdenServico";
            this.tabDadosOrdenServico.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosOrdenServico.Size = new System.Drawing.Size(1100, 235);
            this.tabDadosOrdenServico.TabIndex = 0;
            this.tabDadosOrdenServico.Text = "   Orden de Serviço   ";
            // 
            // lbValorTotalMaterial
            // 
            this.lbValorTotalMaterial.AutoSize = true;
            this.lbValorTotalMaterial.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorTotalMaterial.Location = new System.Drawing.Point(784, 128);
            this.lbValorTotalMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbValorTotalMaterial.Name = "lbValorTotalMaterial";
            this.lbValorTotalMaterial.Size = new System.Drawing.Size(124, 15);
            this.lbValorTotalMaterial.TabIndex = 183;
            this.lbValorTotalMaterial.Text = "Valor Total Material..:";
            // 
            // txtValorTotalMaterial
            // 
            this.txtValorTotalMaterial.Culture = new System.Globalization.CultureInfo("");
            this.txtValorTotalMaterial.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotalMaterial.Location = new System.Drawing.Point(784, 144);
            this.txtValorTotalMaterial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtValorTotalMaterial.Name = "txtValorTotalMaterial";
            this.txtValorTotalMaterial.Size = new System.Drawing.Size(128, 22);
            this.txtValorTotalMaterial.TabIndex = 182;
            this.txtValorTotalMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorTotalMaterial.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbValorServico
            // 
            this.lbValorServico.AutoSize = true;
            this.lbValorServico.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorServico.Location = new System.Drawing.Point(640, 128);
            this.lbValorServico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbValorServico.Name = "lbValorServico";
            this.lbValorServico.Size = new System.Drawing.Size(117, 15);
            this.lbValorServico.TabIndex = 181;
            this.lbValorServico.Text = "Valor Total Serviço..:";
            // 
            // txtValorTotalServico
            // 
            this.txtValorTotalServico.Culture = new System.Globalization.CultureInfo("");
            this.txtValorTotalServico.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotalServico.Location = new System.Drawing.Point(640, 144);
            this.txtValorTotalServico.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtValorTotalServico.Name = "txtValorTotalServico";
            this.txtValorTotalServico.Size = new System.Drawing.Size(128, 22);
            this.txtValorTotalServico.TabIndex = 180;
            this.txtValorTotalServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorTotalServico.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cmbProduto
            // 
            this.cmbProduto.BackColor = System.Drawing.Color.White;
            this.cmbProduto.FormattingEnabled = true;
            this.cmbProduto.Location = new System.Drawing.Point(224, 72);
            this.cmbProduto.Name = "cmbProduto";
            this.cmbProduto.Size = new System.Drawing.Size(480, 23);
            this.cmbProduto.TabIndex = 174;
            // 
            // txtDescricaoDefeito
            // 
            this.txtDescricaoDefeito.AccessibleDescription = "";
            this.txtDescricaoDefeito.AccessibleName = "";
            this.txtDescricaoDefeito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoDefeito.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoDefeito.Location = new System.Drawing.Point(16, 120);
            this.txtDescricaoDefeito.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescricaoDefeito.MaxLength = 1000;
            this.txtDescricaoDefeito.Multiline = true;
            this.txtDescricaoDefeito.Name = "txtDescricaoDefeito";
            this.txtDescricaoDefeito.Size = new System.Drawing.Size(600, 104);
            this.txtDescricaoDefeito.TabIndex = 173;
            // 
            // lbDescricaoDefeito
            // 
            this.lbDescricaoDefeito.AutoSize = true;
            this.lbDescricaoDefeito.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescricaoDefeito.Location = new System.Drawing.Point(16, 104);
            this.lbDescricaoDefeito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDescricaoDefeito.Name = "lbDescricaoDefeito";
            this.lbDescricaoDefeito.Size = new System.Drawing.Size(125, 15);
            this.lbDescricaoDefeito.TabIndex = 172;
            this.lbDescricaoDefeito.Text = "Descrição do Defeito..:";
            // 
            // txtDataConclucao
            // 
            this.txtDataConclucao.CustomFormat = "dd/MM/yyyy ";
            this.txtDataConclucao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.erpProvider.SetIconAlignment(this.txtDataConclucao, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtDataConclucao.Location = new System.Drawing.Point(288, 24);
            this.txtDataConclucao.Name = "txtDataConclucao";
            this.txtDataConclucao.Size = new System.Drawing.Size(152, 23);
            this.txtDataConclucao.TabIndex = 169;
            this.txtDataConclucao.Value = new System.DateTime(2024, 11, 26, 0, 0, 0, 0);
            // 
            // lbDataPrevistaConclucao
            // 
            this.lbDataPrevistaConclucao.AutoSize = true;
            this.lbDataPrevistaConclucao.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataPrevistaConclucao.Location = new System.Drawing.Point(288, 8);
            this.lbDataPrevistaConclucao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDataPrevistaConclucao.Name = "lbDataPrevistaConclucao";
            this.lbDataPrevistaConclucao.Size = new System.Drawing.Size(145, 15);
            this.lbDataPrevistaConclucao.TabIndex = 168;
            this.lbDataPrevistaConclucao.Text = "Data Prevista Conclução..:";
            // 
            // txtNumeroSerie
            // 
            this.txtNumeroSerie.AccessibleDescription = "";
            this.txtNumeroSerie.AccessibleName = "";
            this.txtNumeroSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroSerie.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroSerie.Location = new System.Drawing.Point(728, 72);
            this.txtNumeroSerie.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNumeroSerie.Name = "txtNumeroSerie";
            this.txtNumeroSerie.Size = new System.Drawing.Size(184, 22);
            this.txtNumeroSerie.TabIndex = 167;
            // 
            // lbNumeroSerie
            // 
            this.lbNumeroSerie.AutoSize = true;
            this.lbNumeroSerie.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumeroSerie.Location = new System.Drawing.Point(728, 56);
            this.lbNumeroSerie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNumeroSerie.Name = "lbNumeroSerie";
            this.lbNumeroSerie.Size = new System.Drawing.Size(107, 15);
            this.lbNumeroSerie.TabIndex = 166;
            this.lbNumeroSerie.Text = "Numero de Série..:";
            // 
            // lbProduto
            // 
            this.lbProduto.AutoSize = true;
            this.lbProduto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProduto.Location = new System.Drawing.Point(224, 56);
            this.lbProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProduto.Name = "lbProduto";
            this.lbProduto.Size = new System.Drawing.Size(127, 15);
            this.lbProduto.TabIndex = 164;
            this.lbProduto.Text = "Descrição do Produto..:";
            // 
            // cmbMarca
            // 
            this.cmbMarca.BackColor = System.Drawing.Color.White;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(16, 72);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(184, 23);
            this.cmbMarca.TabIndex = 162;
            // 
            // lbMarcaProduto
            // 
            this.lbMarcaProduto.AutoSize = true;
            this.lbMarcaProduto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMarcaProduto.Location = new System.Drawing.Point(16, 56);
            this.lbMarcaProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMarcaProduto.Name = "lbMarcaProduto";
            this.lbMarcaProduto.Size = new System.Drawing.Size(50, 15);
            this.lbMarcaProduto.TabIndex = 160;
            this.lbMarcaProduto.Text = "Marca..:";
            // 
            // txtDataEmissao
            // 
            this.txtDataEmissao.CustomFormat = "dd/MM/yyyy ";
            this.txtDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDataEmissao.Location = new System.Drawing.Point(112, 24);
            this.txtDataEmissao.Name = "txtDataEmissao";
            this.txtDataEmissao.Size = new System.Drawing.Size(152, 23);
            this.txtDataEmissao.TabIndex = 159;
            this.txtDataEmissao.Value = new System.DateTime(2024, 11, 26, 0, 0, 0, 0);
            // 
            // txtPesquisaListView
            // 
            this.txtPesquisaListView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaListView.Location = new System.Drawing.Point(640, 200);
            this.txtPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPesquisaListView.Name = "txtPesquisaListView";
            this.txtPesquisaListView.Size = new System.Drawing.Size(432, 22);
            this.txtPesquisaListView.TabIndex = 56;
            this.txtPesquisaListView.TextChanged += new System.EventHandler(this.txtPesquisaListView_TextChanged);
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.AutoSize = true;
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(640, 184);
            this.lblPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(105, 15);
            this.lblPesquisaListView.TabIndex = 57;
            this.lblPesquisaListView.Text = "Pesquisa Serviço..:";
            // 
            // lbImagemProduto
            // 
            this.lbImagemProduto.AutoSize = true;
            this.lbImagemProduto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImagemProduto.Location = new System.Drawing.Point(952, 8);
            this.lbImagemProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbImagemProduto.Name = "lbImagemProduto";
            this.lbImagemProduto.Size = new System.Drawing.Size(103, 15);
            this.lbImagemProduto.TabIndex = 90;
            this.lbImagemProduto.Text = "Imagem Produto..:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.BackColor = System.Drawing.Color.White;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(464, 24);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(448, 23);
            this.cmbCliente.TabIndex = 88;
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCliente.Location = new System.Drawing.Point(464, 8);
            this.lbCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(57, 15);
            this.lbCliente.TabIndex = 63;
            this.lbCliente.Text = "Cliente..:";
            // 
            // ibDataEmissao
            // 
            this.ibDataEmissao.AutoSize = true;
            this.ibDataEmissao.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibDataEmissao.Location = new System.Drawing.Point(112, 8);
            this.ibDataEmissao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ibDataEmissao.Name = "ibDataEmissao";
            this.ibDataEmissao.Size = new System.Drawing.Size(88, 15);
            this.ibDataEmissao.TabIndex = 66;
            this.ibDataEmissao.Text = "Data Emissão..:";
            // 
            // lbIDOrdenServico
            // 
            this.lbIDOrdenServico.AutoSize = true;
            this.lbIDOrdenServico.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIDOrdenServico.Location = new System.Drawing.Point(16, 8);
            this.lbIDOrdenServico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIDOrdenServico.Name = "lbIDOrdenServico";
            this.lbIDOrdenServico.Size = new System.Drawing.Size(54, 15);
            this.lbIDOrdenServico.TabIndex = 61;
            this.lbIDOrdenServico.Text = "ID O.S..:";
            // 
            // txtIDOrdenServico
            // 
            this.txtIDOrdenServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDOrdenServico.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDOrdenServico.Location = new System.Drawing.Point(16, 24);
            this.txtIDOrdenServico.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDOrdenServico.Name = "txtIDOrdenServico";
            this.txtIDOrdenServico.Size = new System.Drawing.Size(72, 22);
            this.txtIDOrdenServico.TabIndex = 64;
            this.txtIDOrdenServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabDadosMaterias
            // 
            this.tabDadosMaterias.Controls.Add(this.txtGarantiaMaterial);
            this.tabDadosMaterias.Controls.Add(this.lbGarantiaMaterial);
            this.tabDadosMaterias.Controls.Add(this.txtGarantiaServico);
            this.tabDadosMaterias.Controls.Add(this.lbGarantiaServico);
            this.tabDadosMaterias.Location = new System.Drawing.Point(4, 22);
            this.tabDadosMaterias.Name = "tabDadosMaterias";
            this.tabDadosMaterias.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosMaterias.Size = new System.Drawing.Size(1100, 235);
            this.tabDadosMaterias.TabIndex = 2;
            this.tabDadosMaterias.Text = "   Dados de Matériais   ";
            this.tabDadosMaterias.UseVisualStyleBackColor = true;
            // 
            // txtGarantiaMaterial
            // 
            this.txtGarantiaMaterial.AccessibleDescription = "";
            this.txtGarantiaMaterial.AccessibleName = "";
            this.txtGarantiaMaterial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGarantiaMaterial.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantiaMaterial.Location = new System.Drawing.Point(630, 114);
            this.txtGarantiaMaterial.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGarantiaMaterial.Name = "txtGarantiaMaterial";
            this.txtGarantiaMaterial.Size = new System.Drawing.Size(136, 22);
            this.txtGarantiaMaterial.TabIndex = 177;
            // 
            // lbGarantiaMaterial
            // 
            this.lbGarantiaMaterial.AutoSize = true;
            this.lbGarantiaMaterial.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGarantiaMaterial.Location = new System.Drawing.Point(627, 98);
            this.lbGarantiaMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGarantiaMaterial.Name = "lbGarantiaMaterial";
            this.lbGarantiaMaterial.Size = new System.Drawing.Size(138, 15);
            this.lbGarantiaMaterial.TabIndex = 176;
            this.lbGarantiaMaterial.Text = "Garantia dos Matériais..:";
            // 
            // txtGarantiaServico
            // 
            this.txtGarantiaServico.AccessibleDescription = "";
            this.txtGarantiaServico.AccessibleName = "";
            this.txtGarantiaServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGarantiaServico.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantiaServico.Location = new System.Drawing.Point(478, 114);
            this.txtGarantiaServico.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGarantiaServico.Name = "txtGarantiaServico";
            this.txtGarantiaServico.Size = new System.Drawing.Size(136, 22);
            this.txtGarantiaServico.TabIndex = 175;
            // 
            // lbGarantiaServico
            // 
            this.lbGarantiaServico.AutoSize = true;
            this.lbGarantiaServico.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGarantiaServico.Location = new System.Drawing.Point(475, 98);
            this.lbGarantiaServico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGarantiaServico.Name = "lbGarantiaServico";
            this.lbGarantiaServico.Size = new System.Drawing.Size(131, 15);
            this.lbGarantiaServico.TabIndex = 174;
            this.lbGarantiaServico.Text = "Garantia dos Serviços..:";
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(659, 2);
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
            this.btnExcluir.Location = new System.Drawing.Point(867, 2);
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
            this.btnNovo.Location = new System.Drawing.Point(555, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(98, 40);
            this.btnNovo.TabIndex = 59;
            this.btnNovo.Text = "     Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // listViewLancamentoServicos
            // 
            this.listViewLancamentoServicos.CausesValidation = false;
            this.listViewLancamentoServicos.FullRowSelect = true;
            this.listViewLancamentoServicos.GridLines = true;
            this.listViewLancamentoServicos.HideSelection = false;
            this.listViewLancamentoServicos.Location = new System.Drawing.Point(14, 264);
            this.listViewLancamentoServicos.Name = "listViewLancamentoServicos";
            this.listViewLancamentoServicos.Size = new System.Drawing.Size(1108, 184);
            this.listViewLancamentoServicos.TabIndex = 71;
            this.listViewLancamentoServicos.UseCompatibleStateImageBehavior = false;
            this.listViewLancamentoServicos.View = System.Windows.Forms.View.Details;
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(763, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(98, 40);
            this.btnSalvar.TabIndex = 61;
            this.btnSalvar.Text = "      Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AutoSize = true;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(971, 2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(98, 40);
            this.btnFechar.TabIndex = 63;
            this.btnFechar.Text = "     Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
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
            this.pnlBotoes.Location = new System.Drawing.Point(14, 452);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(1108, 49);
            this.pnlBotoes.TabIndex = 72;
            // 
            // frmLancamentoServicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 505);
            this.Controls.Add(this.tabControlOrdenServico);
            this.Controls.Add(this.listViewLancamentoServicos);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "frmLancamentoServicos";
            this.Text = "Lançamento Orden Serviço";
            ((System.ComponentModel.ISupportInitialize)(this.imgImagemProduto)).EndInit();
            this.tabControlOrdenServico.ResumeLayout(false);
            this.tabDadosOrdenServico.ResumeLayout(false);
            this.tabDadosOrdenServico.PerformLayout();
            this.tabDadosMaterias.ResumeLayout(false);
            this.tabDadosMaterias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.PictureBox imgImagemProduto;
        private System.Windows.Forms.TabPage tabDadosCliente;
        private System.Windows.Forms.Label lbTotalRegistros;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.TabControl tabControlOrdenServico;
        private System.Windows.Forms.TabPage tabDadosOrdenServico;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.Label lbImagemProduto;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.Label ibDataEmissao;
        private System.Windows.Forms.Label lbIDOrdenServico;
        private System.Windows.Forms.TextBox txtIDOrdenServico;
        private System.Windows.Forms.ListView listViewLancamentoServicos;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.TabPage tabDadosMaterias;
        private System.Windows.Forms.DateTimePicker txtDataEmissao;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label lbMarcaProduto;
        private System.Windows.Forms.Label lbProduto;
        private System.Windows.Forms.TextBox txtNumeroSerie;
        private System.Windows.Forms.Label lbNumeroSerie;
        private System.Windows.Forms.DateTimePicker txtDataConclucao;
        private System.Windows.Forms.Label lbDataPrevistaConclucao;
        private System.Windows.Forms.TextBox txtDescricaoDefeito;
        private System.Windows.Forms.Label lbDescricaoDefeito;
        private System.Windows.Forms.TextBox txtGarantiaMaterial;
        private System.Windows.Forms.Label lbGarantiaMaterial;
        private System.Windows.Forms.TextBox txtGarantiaServico;
        private System.Windows.Forms.Label lbGarantiaServico;
        private System.Windows.Forms.ComboBox cmbProduto;
        private System.Windows.Forms.Label lbValorTotalMaterial;
        private System.Windows.Forms.MaskedTextBox txtValorTotalMaterial;
        private System.Windows.Forms.Label lbValorServico;
        private System.Windows.Forms.MaskedTextBox txtValorTotalServico;
    }
}
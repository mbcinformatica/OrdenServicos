namespace ProjetoTeste.Cadastros
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.imgImagemProduto = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbNumeroSerie = new System.Windows.Forms.Label();
            this.txtDataUltimaCompra = new System.Windows.Forms.TextBox();
            this.tabInformacoesAdicionais = new System.Windows.Forms.TabPage();
            this.lbDataUltimaCompra = new System.Windows.Forms.Label();
            this.txtIDProduto = new System.Windows.Forms.TextBox();
            this.btnExcluirImagem = new System.Windows.Forms.Button();
            this.btnInserirImagem = new System.Windows.Forms.Button();
            this.txtGarantia = new System.Windows.Forms.TextBox();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.tabControlProdutos = new System.Windows.Forms.TabControl();
            this.tabDadosProduto = new System.Windows.Forms.TabPage();
            this.lbGarantia = new System.Windows.Forms.Label();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.lbImagemProduto = new System.Windows.Forms.Label();
            this.lbModeloProduto = new System.Windows.Forms.Label();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.cmbFornecedor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbtxtEstoqueAtual = new System.Windows.Forms.Label();
            this.txtEstoqueMinimo = new System.Windows.Forms.MaskedTextBox();
            this.txtEstoqueAtual = new System.Windows.Forms.MaskedTextBox();
            this.cmbUnidade = new System.Windows.Forms.ComboBox();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.lblValorVenda = new System.Windows.Forms.Label();
            this.lblValorCompra = new System.Windows.Forms.Label();
            this.txtPrecoVenda = new System.Windows.Forms.MaskedTextBox();
            this.txtPrecoCompra = new System.Windows.Forms.MaskedTextBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lbMarcaProduto = new System.Windows.Forms.Label();
            this.lbFornecedor = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtIDProdutoFabricante = new System.Windows.Forms.TextBox();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.lbCodigoFabricante = new System.Windows.Forms.Label();
            this.lbCodigoIntProduto = new System.Windows.Forms.Label();
            this.txtIDProdutoInterno = new System.Windows.Forms.TextBox();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.listViewProdutos = new System.Windows.Forms.ListView();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagemProduto)).BeginInit();
            this.tabInformacoesAdicionais.SuspendLayout();
            this.tabControlProdutos.SuspendLayout();
            this.tabDadosProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgImagemProduto
            // 
            this.imgImagemProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgImagemProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgImagemProduto.Location = new System.Drawing.Point(824, 24);
            this.imgImagemProduto.Name = "imgImagemProduto";
            this.imgImagemProduto.Size = new System.Drawing.Size(136, 160);
            this.imgImagemProduto.TabIndex = 89;
            this.imgImagemProduto.TabStop = false;
            this.tlpDicas.SetToolTip(this.imgImagemProduto, "Realiza Pesquisa desse Produto na Internet");
            // 
            // textBox1
            // 
            this.textBox1.AccessibleDescription = "";
            this.textBox1.AccessibleName = "";
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(8, 24);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 22);
            this.textBox1.TabIndex = 71;
            // 
            // lbNumeroSerie
            // 
            this.lbNumeroSerie.AutoSize = true;
            this.lbNumeroSerie.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumeroSerie.Location = new System.Drawing.Point(8, 8);
            this.lbNumeroSerie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNumeroSerie.Name = "lbNumeroSerie";
            this.lbNumeroSerie.Size = new System.Drawing.Size(107, 15);
            this.lbNumeroSerie.TabIndex = 70;
            this.lbNumeroSerie.Text = "Numero de Série..:";
            // 
            // txtDataUltimaCompra
            // 
            this.txtDataUltimaCompra.AccessibleDescription = "";
            this.txtDataUltimaCompra.AccessibleName = "";
            this.txtDataUltimaCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataUltimaCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataUltimaCompra.Enabled = false;
            this.txtDataUltimaCompra.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataUltimaCompra.Location = new System.Drawing.Point(936, 160);
            this.txtDataUltimaCompra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDataUltimaCompra.Name = "txtDataUltimaCompra";
            this.txtDataUltimaCompra.Size = new System.Drawing.Size(149, 22);
            this.txtDataUltimaCompra.TabIndex = 69;
            // 
            // tabInformacoesAdicionais
            // 
            this.tabInformacoesAdicionais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabInformacoesAdicionais.Controls.Add(this.textBox1);
            this.tabInformacoesAdicionais.Controls.Add(this.lbNumeroSerie);
            this.tabInformacoesAdicionais.Controls.Add(this.txtDataUltimaCompra);
            this.tabInformacoesAdicionais.Controls.Add(this.lbDataUltimaCompra);
            this.tabInformacoesAdicionais.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInformacoesAdicionais.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInformacoesAdicionais.Location = new System.Drawing.Point(4, 22);
            this.tabInformacoesAdicionais.Name = "tabInformacoesAdicionais";
            this.tabInformacoesAdicionais.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformacoesAdicionais.Size = new System.Drawing.Size(1100, 196);
            this.tabInformacoesAdicionais.TabIndex = 1;
            this.tabInformacoesAdicionais.Text = "  Informações Adicionais";
            // 
            // lbDataUltimaCompra
            // 
            this.lbDataUltimaCompra.AutoSize = true;
            this.lbDataUltimaCompra.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataUltimaCompra.Location = new System.Drawing.Point(936, 144);
            this.lbDataUltimaCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDataUltimaCompra.Name = "lbDataUltimaCompra";
            this.lbDataUltimaCompra.Size = new System.Drawing.Size(98, 15);
            this.lbDataUltimaCompra.TabIndex = 68;
            this.lbDataUltimaCompra.Text = "Ultima Compra..:";
            // 
            // txtIDProduto
            // 
            this.txtIDProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDProduto.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDProduto.Location = new System.Drawing.Point(1060, 164);
            this.txtIDProduto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDProduto.Name = "txtIDProduto";
            this.txtIDProduto.Size = new System.Drawing.Size(23, 22);
            this.txtIDProduto.TabIndex = 59;
            this.txtIDProduto.Text = " ";
            this.txtIDProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIDProduto.Visible = false;
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
            this.btnExcluirImagem.TabIndex = 158;
            this.btnExcluirImagem.Text = "     Excluir";
            this.btnExcluirImagem.UseVisualStyleBackColor = false;
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
            this.btnInserirImagem.TabIndex = 157;
            this.btnInserirImagem.Text = "     Inserir";
            this.btnInserirImagem.UseVisualStyleBackColor = false;
            // 
            // txtGarantia
            // 
            this.txtGarantia.AccessibleDescription = "";
            this.txtGarantia.AccessibleName = "";
            this.txtGarantia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGarantia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGarantia.Enabled = false;
            this.txtGarantia.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantia.Location = new System.Drawing.Point(664, 120);
            this.txtGarantia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGarantia.Name = "txtGarantia";
            this.txtGarantia.Size = new System.Drawing.Size(128, 22);
            this.txtGarantia.TabIndex = 94;
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
            // tabControlProdutos
            // 
            this.tabControlProdutos.Controls.Add(this.tabDadosProduto);
            this.tabControlProdutos.Controls.Add(this.tabInformacoesAdicionais);
            this.tabControlProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlProdutos.Location = new System.Drawing.Point(14, 3);
            this.tabControlProdutos.Multiline = true;
            this.tabControlProdutos.Name = "tabControlProdutos";
            this.tabControlProdutos.SelectedIndex = 0;
            this.tabControlProdutos.Size = new System.Drawing.Size(1108, 222);
            this.tabControlProdutos.TabIndex = 73;
            // 
            // tabDadosProduto
            // 
            this.tabDadosProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosProduto.Controls.Add(this.btnExcluirImagem);
            this.tabDadosProduto.Controls.Add(this.btnInserirImagem);
            this.tabDadosProduto.Controls.Add(this.txtIDProduto);
            this.tabDadosProduto.Controls.Add(this.txtGarantia);
            this.tabDadosProduto.Controls.Add(this.lbGarantia);
            this.tabDadosProduto.Controls.Add(this.txtPesquisaListView);
            this.tabDadosProduto.Controls.Add(this.lblPesquisaListView);
            this.tabDadosProduto.Controls.Add(this.lbImagemProduto);
            this.tabDadosProduto.Controls.Add(this.lbModeloProduto);
            this.tabDadosProduto.Controls.Add(this.cmbModelo);
            this.tabDadosProduto.Controls.Add(this.imgImagemProduto);
            this.tabDadosProduto.Controls.Add(this.cmbFornecedor);
            this.tabDadosProduto.Controls.Add(this.label1);
            this.tabDadosProduto.Controls.Add(this.lbtxtEstoqueAtual);
            this.tabDadosProduto.Controls.Add(this.txtEstoqueMinimo);
            this.tabDadosProduto.Controls.Add(this.txtEstoqueAtual);
            this.tabDadosProduto.Controls.Add(this.cmbUnidade);
            this.tabDadosProduto.Controls.Add(this.lbUnidade);
            this.tabDadosProduto.Controls.Add(this.lblValorVenda);
            this.tabDadosProduto.Controls.Add(this.lblValorCompra);
            this.tabDadosProduto.Controls.Add(this.txtPrecoVenda);
            this.tabDadosProduto.Controls.Add(this.txtPrecoCompra);
            this.tabDadosProduto.Controls.Add(this.cmbMarca);
            this.tabDadosProduto.Controls.Add(this.lbMarcaProduto);
            this.tabDadosProduto.Controls.Add(this.lbFornecedor);
            this.tabDadosProduto.Controls.Add(this.txtDescricao);
            this.tabDadosProduto.Controls.Add(this.txtIDProdutoFabricante);
            this.tabDadosProduto.Controls.Add(this.lbDescricao);
            this.tabDadosProduto.Controls.Add(this.lbCodigoFabricante);
            this.tabDadosProduto.Controls.Add(this.lbCodigoIntProduto);
            this.tabDadosProduto.Controls.Add(this.txtIDProdutoInterno);
            this.tabDadosProduto.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosProduto.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosProduto.Location = new System.Drawing.Point(4, 22);
            this.tabDadosProduto.Name = "tabDadosProduto";
            this.tabDadosProduto.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosProduto.Size = new System.Drawing.Size(1100, 196);
            this.tabDadosProduto.TabIndex = 0;
            this.tabDadosProduto.Text = "Dados do Produto";
            // 
            // lbGarantia
            // 
            this.lbGarantia.AutoSize = true;
            this.lbGarantia.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGarantia.Location = new System.Drawing.Point(661, 104);
            this.lbGarantia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGarantia.Name = "lbGarantia";
            this.lbGarantia.Size = new System.Drawing.Size(64, 15);
            this.lbGarantia.TabIndex = 93;
            this.lbGarantia.Text = "Garantia..:";
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
            this.txtPesquisaListView.TabIndex = 56;
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.AutoSize = true;
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(8, 150);
            this.lblPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(107, 15);
            this.lblPesquisaListView.TabIndex = 57;
            this.lblPesquisaListView.Text = "Pesquisa Produto..:";
            // 
            // lbImagemProduto
            // 
            this.lbImagemProduto.AutoSize = true;
            this.lbImagemProduto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImagemProduto.Location = new System.Drawing.Point(840, 8);
            this.lbImagemProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbImagemProduto.Name = "lbImagemProduto";
            this.lbImagemProduto.Size = new System.Drawing.Size(103, 15);
            this.lbImagemProduto.TabIndex = 90;
            this.lbImagemProduto.Text = "Imagem Produto..:";
            // 
            // lbModeloProduto
            // 
            this.lbModeloProduto.AutoSize = true;
            this.lbModeloProduto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModeloProduto.Location = new System.Drawing.Point(560, 56);
            this.lbModeloProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbModeloProduto.Name = "lbModeloProduto";
            this.lbModeloProduto.Size = new System.Drawing.Size(56, 15);
            this.lbModeloProduto.TabIndex = 74;
            this.lbModeloProduto.Text = "Modelo..:";
            // 
            // cmbModelo
            // 
            this.cmbModelo.BackColor = System.Drawing.Color.White;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(560, 72);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(232, 23);
            this.cmbModelo.TabIndex = 77;
            // 
            // cmbFornecedor
            // 
            this.cmbFornecedor.BackColor = System.Drawing.Color.White;
            this.cmbFornecedor.FormattingEnabled = true;
            this.cmbFornecedor.Location = new System.Drawing.Point(8, 72);
            this.cmbFornecedor.Name = "cmbFornecedor";
            this.cmbFornecedor.Size = new System.Drawing.Size(327, 23);
            this.cmbFornecedor.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(544, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "Estoque Minino..:";
            // 
            // lbtxtEstoqueAtual
            // 
            this.lbtxtEstoqueAtual.AutoSize = true;
            this.lbtxtEstoqueAtual.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtxtEstoqueAtual.Location = new System.Drawing.Point(424, 104);
            this.lbtxtEstoqueAtual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtxtEstoqueAtual.Name = "lbtxtEstoqueAtual";
            this.lbtxtEstoqueAtual.Size = new System.Drawing.Size(89, 15);
            this.lbtxtEstoqueAtual.TabIndex = 86;
            this.lbtxtEstoqueAtual.Text = "Estoque Atual..:";
            // 
            // txtEstoqueMinimo
            // 
            this.txtEstoqueMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstoqueMinimo.Culture = new System.Globalization.CultureInfo("");
            this.txtEstoqueMinimo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstoqueMinimo.Location = new System.Drawing.Point(544, 120);
            this.txtEstoqueMinimo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEstoqueMinimo.Name = "txtEstoqueMinimo";
            this.txtEstoqueMinimo.Size = new System.Drawing.Size(96, 22);
            this.txtEstoqueMinimo.TabIndex = 85;
            this.txtEstoqueMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEstoqueMinimo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtEstoqueAtual
            // 
            this.txtEstoqueAtual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstoqueAtual.Culture = new System.Globalization.CultureInfo("");
            this.txtEstoqueAtual.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstoqueAtual.Location = new System.Drawing.Point(424, 120);
            this.txtEstoqueAtual.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEstoqueAtual.Name = "txtEstoqueAtual";
            this.txtEstoqueAtual.Size = new System.Drawing.Size(96, 22);
            this.txtEstoqueAtual.TabIndex = 84;
            this.txtEstoqueAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEstoqueAtual.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.BackColor = System.Drawing.Color.White;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.Location = new System.Drawing.Point(8, 120);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.Size = new System.Drawing.Size(152, 23);
            this.cmbUnidade.TabIndex = 83;
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnidade.Location = new System.Drawing.Point(8, 104);
            this.lbUnidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(60, 15);
            this.lbUnidade.TabIndex = 82;
            this.lbUnidade.Text = "Unidade..:";
            // 
            // lblValorVenda
            // 
            this.lblValorVenda.AutoSize = true;
            this.lblValorVenda.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorVenda.Location = new System.Drawing.Point(304, 104);
            this.lblValorVenda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorVenda.Name = "lblValorVenda";
            this.lblValorVenda.Size = new System.Drawing.Size(80, 15);
            this.lblValorVenda.TabIndex = 81;
            this.lblValorVenda.Text = "Valor Venda..:";
            // 
            // lblValorCompra
            // 
            this.lblValorCompra.AutoSize = true;
            this.lblValorCompra.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorCompra.Location = new System.Drawing.Point(184, 104);
            this.lblValorCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorCompra.Name = "lblValorCompra";
            this.lblValorCompra.Size = new System.Drawing.Size(90, 15);
            this.lblValorCompra.TabIndex = 80;
            this.lblValorCompra.Text = "Valor Compra..:";
            // 
            // txtPrecoVenda
            // 
            this.txtPrecoVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecoVenda.Culture = new System.Globalization.CultureInfo("");
            this.txtPrecoVenda.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecoVenda.Location = new System.Drawing.Point(304, 120);
            this.txtPrecoVenda.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(96, 22);
            this.txtPrecoVenda.TabIndex = 79;
            this.txtPrecoVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecoVenda.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtPrecoCompra
            // 
            this.txtPrecoCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecoCompra.Culture = new System.Globalization.CultureInfo("");
            this.txtPrecoCompra.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecoCompra.Location = new System.Drawing.Point(184, 120);
            this.txtPrecoCompra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPrecoCompra.Name = "txtPrecoCompra";
            this.txtPrecoCompra.Size = new System.Drawing.Size(96, 22);
            this.txtPrecoCompra.TabIndex = 78;
            this.txtPrecoCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecoCompra.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cmbMarca
            // 
            this.cmbMarca.BackColor = System.Drawing.Color.White;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(360, 72);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(176, 23);
            this.cmbMarca.TabIndex = 76;
            // 
            // lbMarcaProduto
            // 
            this.lbMarcaProduto.AutoSize = true;
            this.lbMarcaProduto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMarcaProduto.Location = new System.Drawing.Point(360, 56);
            this.lbMarcaProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMarcaProduto.Name = "lbMarcaProduto";
            this.lbMarcaProduto.Size = new System.Drawing.Size(50, 15);
            this.lbMarcaProduto.TabIndex = 72;
            this.lbMarcaProduto.Text = "Marca..:";
            // 
            // lbFornecedor
            // 
            this.lbFornecedor.AutoSize = true;
            this.lbFornecedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFornecedor.Location = new System.Drawing.Point(8, 56);
            this.lbFornecedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFornecedor.Name = "lbFornecedor";
            this.lbFornecedor.Size = new System.Drawing.Size(75, 15);
            this.lbFornecedor.TabIndex = 69;
            this.lbFornecedor.Text = "Fornecedor..:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.AccessibleDescription = "";
            this.txtDescricao.AccessibleName = "";
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(360, 24);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(432, 22);
            this.txtDescricao.TabIndex = 65;
            // 
            // txtIDProdutoFabricante
            // 
            this.txtIDProdutoFabricante.AccessibleDescription = "";
            this.txtIDProdutoFabricante.AccessibleName = "";
            this.txtIDProdutoFabricante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDProdutoFabricante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDProdutoFabricante.Enabled = false;
            this.txtIDProdutoFabricante.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDProdutoFabricante.Location = new System.Drawing.Point(182, 24);
            this.txtIDProdutoFabricante.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDProdutoFabricante.Name = "txtIDProdutoFabricante";
            this.txtIDProdutoFabricante.Size = new System.Drawing.Size(150, 22);
            this.txtIDProdutoFabricante.TabIndex = 67;
            this.txtIDProdutoFabricante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescricao.Location = new System.Drawing.Point(360, 8);
            this.lbDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(68, 15);
            this.lbDescricao.TabIndex = 63;
            this.lbDescricao.Text = "Descrição..:";
            // 
            // lbCodigoFabricante
            // 
            this.lbCodigoFabricante.AutoSize = true;
            this.lbCodigoFabricante.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigoFabricante.Location = new System.Drawing.Point(182, 8);
            this.lbCodigoFabricante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCodigoFabricante.Name = "lbCodigoFabricante";
            this.lbCodigoFabricante.Size = new System.Drawing.Size(113, 15);
            this.lbCodigoFabricante.TabIndex = 66;
            this.lbCodigoFabricante.Text = "Código Fabricante..:";
            // 
            // lbCodigoIntProduto
            // 
            this.lbCodigoIntProduto.AutoSize = true;
            this.lbCodigoIntProduto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigoIntProduto.Location = new System.Drawing.Point(8, 8);
            this.lbCodigoIntProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCodigoIntProduto.Name = "lbCodigoIntProduto";
            this.lbCodigoIntProduto.Size = new System.Drawing.Size(96, 15);
            this.lbCodigoIntProduto.TabIndex = 61;
            this.lbCodigoIntProduto.Text = "Código Interno..:";
            // 
            // txtIDProdutoInterno
            // 
            this.txtIDProdutoInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDProdutoInterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDProdutoInterno.Enabled = false;
            this.txtIDProdutoInterno.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDProdutoInterno.Location = new System.Drawing.Point(8, 24);
            this.txtIDProdutoInterno.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDProdutoInterno.Name = "txtIDProdutoInterno";
            this.txtIDProdutoInterno.Size = new System.Drawing.Size(150, 22);
            this.txtIDProdutoInterno.TabIndex = 64;
            this.txtIDProdutoInterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // 
            // listViewProdutos
            // 
            this.listViewProdutos.CausesValidation = false;
            this.listViewProdutos.FullRowSelect = true;
            this.listViewProdutos.GridLines = true;
            this.listViewProdutos.HideSelection = false;
            this.listViewProdutos.Location = new System.Drawing.Point(14, 229);
            this.listViewProdutos.Name = "listViewProdutos";
            this.listViewProdutos.Size = new System.Drawing.Size(1108, 219);
            this.listViewProdutos.TabIndex = 71;
            this.listViewProdutos.UseCompatibleStateImageBehavior = false;
            this.listViewProdutos.View = System.Windows.Forms.View.Details;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 505);
            this.Controls.Add(this.tabControlProdutos);
            this.Controls.Add(this.listViewProdutos);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imgImagemProduto)).EndInit();
            this.tabInformacoesAdicionais.ResumeLayout(false);
            this.tabInformacoesAdicionais.PerformLayout();
            this.tabControlProdutos.ResumeLayout(false);
            this.tabDadosProduto.ResumeLayout(false);
            this.tabDadosProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.PictureBox imgImagemProduto;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbNumeroSerie;
        private System.Windows.Forms.TextBox txtDataUltimaCompra;
        private System.Windows.Forms.TabPage tabInformacoesAdicionais;
        private System.Windows.Forms.Label lbDataUltimaCompra;
        private System.Windows.Forms.TextBox txtIDProduto;
        private System.Windows.Forms.Button btnExcluirImagem;
        private System.Windows.Forms.Button btnInserirImagem;
        private System.Windows.Forms.TextBox txtGarantia;
        private System.Windows.Forms.Label lbTotalRegistros;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.TabControl tabControlProdutos;
        private System.Windows.Forms.TabPage tabDadosProduto;
        private System.Windows.Forms.Label lbGarantia;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.Label lbImagemProduto;
        private System.Windows.Forms.Label lbModeloProduto;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.ComboBox cmbFornecedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbtxtEstoqueAtual;
        private System.Windows.Forms.MaskedTextBox txtEstoqueMinimo;
        private System.Windows.Forms.MaskedTextBox txtEstoqueAtual;
        private System.Windows.Forms.ComboBox cmbUnidade;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.Label lblValorVenda;
        private System.Windows.Forms.Label lblValorCompra;
        private System.Windows.Forms.MaskedTextBox txtPrecoVenda;
        private System.Windows.Forms.MaskedTextBox txtPrecoCompra;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label lbMarcaProduto;
        private System.Windows.Forms.Label lbFornecedor;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtIDProdutoFabricante;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.Label lbCodigoFabricante;
        private System.Windows.Forms.Label lbCodigoIntProduto;
        private System.Windows.Forms.TextBox txtIDProdutoInterno;
        private System.Windows.Forms.ListView listViewProdutos;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
    }
}
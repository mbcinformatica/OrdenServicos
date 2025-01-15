namespace OrdenServicos
{
    partial class frmServicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicos));
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.tabInformacoesAdicionais = new System.Windows.Forms.TabPage();
            this.tabDadosServico = new System.Windows.Forms.TabPage();
            this.lblValorServico = new System.Windows.Forms.Label();
            this.txtValorServico = new System.Windows.Forms.MaskedTextBox();
            this.cmbCategoriaServico = new System.Windows.Forms.ComboBox();
            this.lbCategoriaServico = new System.Windows.Forms.Label();
            this.txtIDCodigoBase = new System.Windows.Forms.TextBox();
            this.ibCodigoBase = new System.Windows.Forms.Label();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.txtIDServico = new System.Windows.Forms.TextBox();
            this.tabControlServicos = new System.Windows.Forms.TabControl();
            this.listViewServicos = new System.Windows.Forms.ListView();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabDadosServico.SuspendLayout();
            this.tabControlServicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();

			this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
			this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
			this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
			this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

			// 
			// tabInformacoesAdicionais
			// 
			this.tabInformacoesAdicionais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabInformacoesAdicionais.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInformacoesAdicionais.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInformacoesAdicionais.Location = new System.Drawing.Point(4, 22);
            this.tabInformacoesAdicionais.Name = "tabInformacoesAdicionais";
            this.tabInformacoesAdicionais.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformacoesAdicionais.Size = new System.Drawing.Size(768, 110);
            this.tabInformacoesAdicionais.TabIndex = 1;
            this.tabInformacoesAdicionais.Text = "  Informações Adicionais";
            // 
            // tabDadosServico
            // 
            this.tabDadosServico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosServico.Controls.Add(this.lblValorServico);
            this.tabDadosServico.Controls.Add(this.txtValorServico);
            this.tabDadosServico.Controls.Add(this.cmbCategoriaServico);
            this.tabDadosServico.Controls.Add(this.lbCategoriaServico);
            this.tabDadosServico.Controls.Add(this.txtIDCodigoBase);
            this.tabDadosServico.Controls.Add(this.ibCodigoBase);
            this.tabDadosServico.Controls.Add(this.txtPesquisaListView);
            this.tabDadosServico.Controls.Add(this.lblPesquisaListView);
            this.tabDadosServico.Controls.Add(this.txtDescricao);
            this.tabDadosServico.Controls.Add(this.lbDescricao);
            this.tabDadosServico.Controls.Add(this.txtIDServico);
            this.tabDadosServico.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosServico.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosServico.Location = new System.Drawing.Point(4, 22);
            this.tabDadosServico.Name = "tabDadosServico";
            this.tabDadosServico.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosServico.Size = new System.Drawing.Size(768, 110);
            this.tabDadosServico.TabIndex = 0;
            this.tabDadosServico.Text = "Dados da Servico";
            // 
            // lblValorServico
            // 
            this.lblValorServico.AutoSize = true;
            this.lblValorServico.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorServico.Location = new System.Drawing.Point(16, 64);
            this.lblValorServico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorServico.Name = "lblValorServico";
            this.lblValorServico.Size = new System.Drawing.Size(102, 15);
            this.lblValorServico.TabIndex = 82;
            this.lblValorServico.Text = "Valor do Serviço..:";
            // 
            // txtValorServico
            // 
            this.txtValorServico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorServico.Culture = new System.Globalization.CultureInfo("");
            this.txtValorServico.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorServico.Location = new System.Drawing.Point(16, 80);
            this.txtValorServico.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtValorServico.Name = "txtValorServico";
            this.txtValorServico.Size = new System.Drawing.Size(128, 22);
            this.txtValorServico.TabIndex = 81;
            this.txtValorServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorServico.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cmbCategoriaServico
            // 
            this.cmbCategoriaServico.BackColor = System.Drawing.Color.White;
            this.cmbCategoriaServico.FormattingEnabled = true;
            this.cmbCategoriaServico.Location = new System.Drawing.Point(164, 24);
            this.cmbCategoriaServico.Name = "cmbCategoriaServico";
            this.cmbCategoriaServico.Size = new System.Drawing.Size(160, 23);
            this.cmbCategoriaServico.TabIndex = 80;
            // 
            // lbCategoriaServico
            // 
            this.lbCategoriaServico.AutoSize = true;
            this.lbCategoriaServico.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoriaServico.Location = new System.Drawing.Point(164, 8);
            this.lbCategoriaServico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCategoriaServico.Name = "lbCategoriaServico";
            this.lbCategoriaServico.Size = new System.Drawing.Size(126, 15);
            this.lbCategoriaServico.TabIndex = 79;
            this.lbCategoriaServico.Text = "Categoria do Serviço..:";
            // 
            // txtIDCodigoBase
            // 
            this.txtIDCodigoBase.AccessibleDescription = "";
            this.txtIDCodigoBase.AccessibleName = "";
            this.txtIDCodigoBase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDCodigoBase.Enabled = false;
            this.txtIDCodigoBase.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCodigoBase.Location = new System.Drawing.Point(16, 24);
            this.txtIDCodigoBase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDCodigoBase.Name = "txtIDCodigoBase";
            this.txtIDCodigoBase.Size = new System.Drawing.Size(128, 22);
            this.txtIDCodigoBase.TabIndex = 67;
            this.txtIDCodigoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ibCodigoBase
            // 
            this.ibCodigoBase.AutoSize = true;
            this.ibCodigoBase.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibCodigoBase.Location = new System.Drawing.Point(16, 8);
            this.ibCodigoBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ibCodigoBase.Name = "ibCodigoBase";
            this.ibCodigoBase.Size = new System.Drawing.Size(82, 15);
            this.ibCodigoBase.TabIndex = 66;
            this.ibCodigoBase.Text = "Código Base..:";
            // 
            // txtPesquisaListView
            // 
            this.txtPesquisaListView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaListView.Enabled = false;
            this.txtPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaListView.Location = new System.Drawing.Point(164, 80);
            this.txtPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPesquisaListView.Name = "txtPesquisaListView";
            this.txtPesquisaListView.Size = new System.Drawing.Size(332, 22);
            this.txtPesquisaListView.TabIndex = 56;
            this.txtPesquisaListView.TextChanged += new System.EventHandler(this.txtPesquisaListView_TextChanged);
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.AutoSize = true;
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(164, 64);
            this.lblPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(105, 15);
            this.lblPesquisaListView.TabIndex = 57;
            this.lblPesquisaListView.Text = "Pesquisa Serviço..:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.AccessibleDescription = "";
            this.txtDescricao.AccessibleName = "";
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(344, 24);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(408, 22);
            this.txtDescricao.TabIndex = 65;
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescricao.Location = new System.Drawing.Point(344, 8);
            this.lbDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(68, 15);
            this.lbDescricao.TabIndex = 63;
            this.lbDescricao.Text = "Descrição..:";
            // 
            // txtIDServico
            // 
            this.txtIDServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDServico.Enabled = false;
            this.txtIDServico.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDServico.Location = new System.Drawing.Point(728, 80);
            this.txtIDServico.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDServico.Name = "txtIDServico";
            this.txtIDServico.Size = new System.Drawing.Size(24, 22);
            this.txtIDServico.TabIndex = 64;
            this.txtIDServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIDServico.Visible = false;
            // 
            // tabControlServicos
            // 
            this.tabControlServicos.Controls.Add(this.tabDadosServico);
            this.tabControlServicos.Controls.Add(this.tabInformacoesAdicionais);
            this.tabControlServicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlServicos.Location = new System.Drawing.Point(14, 3);
            this.tabControlServicos.Multiline = true;
            this.tabControlServicos.Name = "tabControlServicos";
            this.tabControlServicos.SelectedIndex = 0;
            this.tabControlServicos.Size = new System.Drawing.Size(776, 136);
            this.tabControlServicos.TabIndex = 73;
            // 
            // listViewServicos
            // 
            this.listViewServicos.CausesValidation = false;
            this.listViewServicos.FullRowSelect = true;
            this.listViewServicos.GridLines = true;
            this.listViewServicos.HideSelection = false;
            this.listViewServicos.Location = new System.Drawing.Point(14, 144);
            this.listViewServicos.Name = "listViewServicos";
            this.listViewServicos.Size = new System.Drawing.Size(776, 176);
            this.listViewServicos.TabIndex = 71;
            this.listViewServicos.UseCompatibleStateImageBehavior = false;
            this.listViewServicos.View = System.Windows.Forms.View.Details;
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotoes.Controls.Add(this.btnFechar);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.lbTotalRegistros);
            this.pnlBotoes.Location = new System.Drawing.Point(14, 328);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(776, 49);
            this.pnlBotoes.TabIndex = 72;
            // 
            // lbTotalRegistros
            // 
            this.lbTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTotalRegistros.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTotalRegistros.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRegistros.Location = new System.Drawing.Point(4, 6);
            this.lbTotalRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalRegistros.Name = "lbTotalRegistros";
            this.lbTotalRegistros.Size = new System.Drawing.Size(220, 33);
            this.lbTotalRegistros.TabIndex = 66;
            this.lbTotalRegistros.Tag = "naoAplicarAutoSize";
            this.lbTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFechar
            // 
            this.btnFechar.AutoSize = true;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(658, 2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(98, 40);
            this.btnFechar.TabIndex = 71;
            this.btnFechar.Text = "     Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(450, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(98, 40);
            this.btnSalvar.TabIndex = 69;
            this.btnSalvar.Text = "      Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(346, 2);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(98, 40);
            this.btnAlterar.TabIndex = 68;
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
            this.btnExcluir.Location = new System.Drawing.Point(554, 2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(98, 40);
            this.btnExcluir.TabIndex = 70;
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
            this.btnNovo.Location = new System.Drawing.Point(242, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(98, 40);
            this.btnNovo.TabIndex = 67;
            this.btnNovo.Text = "     Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(658, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 40);
            this.btnCancelar.TabIndex = 72;
            this.btnCancelar.Text = "     Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // frmServicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 394);
            this.Controls.Add(this.tabControlServicos);
            this.Controls.Add(this.listViewServicos);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "frmServicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Serviços";
            this.tabDadosServico.ResumeLayout(false);
            this.tabDadosServico.PerformLayout();
            this.tabControlServicos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.TabPage tabInformacoesAdicionais;
        private System.Windows.Forms.TabPage tabDadosServico;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.TabControl tabControlServicos;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.ListView listViewServicos;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Label lbTotalRegistros;
        private System.Windows.Forms.TextBox txtIDCodigoBase;
        private System.Windows.Forms.Label ibCodigoBase;
        private System.Windows.Forms.TextBox txtIDServico;
        private System.Windows.Forms.ComboBox cmbCategoriaServico;
        private System.Windows.Forms.Label lbCategoriaServico;
        private System.Windows.Forms.Label lblValorServico;
        private System.Windows.Forms.MaskedTextBox txtValorServico;
		private System.Windows.Forms.Button btnFechar;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.Button btnAlterar;
		private System.Windows.Forms.Button btnExcluir;
		private System.Windows.Forms.Button btnNovo;
		private System.Windows.Forms.Button btnCancelar;
	}
}

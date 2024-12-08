namespace ProjetoTeste
{
    partial class frmUnidades
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
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.tabInformacoesAdicionais = new System.Windows.Forms.TabPage();
            this.lbDataUltimaCompra = new System.Windows.Forms.Label();
            this.tabDadosUnidade = new System.Windows.Forms.TabPage();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.lbIDUnidade = new System.Windows.Forms.Label();
            this.txtIDUnidade = new System.Windows.Forms.TextBox();
            this.tabControlUnidades = new System.Windows.Forms.TabControl();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.listViewUnidades = new System.Windows.Forms.ListView();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.tabDadosUnidade.SuspendLayout();
            this.tabControlUnidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
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
            // lbDataUltimaCompra
            // 
            this.lbDataUltimaCompra.Location = new System.Drawing.Point(0, 0);
            this.lbDataUltimaCompra.Name = "lbDataUltimaCompra";
            this.lbDataUltimaCompra.Size = new System.Drawing.Size(100, 23);
            this.lbDataUltimaCompra.TabIndex = 0;
            // 
            // tabDadosUnidade
            // 
            this.tabDadosUnidade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosUnidade.Controls.Add(this.txtPesquisaListView);
            this.tabDadosUnidade.Controls.Add(this.lblPesquisaListView);
            this.tabDadosUnidade.Controls.Add(this.txtDescricao);
            this.tabDadosUnidade.Controls.Add(this.lbDescricao);
            this.tabDadosUnidade.Controls.Add(this.lbIDUnidade);
            this.tabDadosUnidade.Controls.Add(this.txtIDUnidade);
            this.tabDadosUnidade.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosUnidade.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosUnidade.Location = new System.Drawing.Point(4, 22);
            this.tabDadosUnidade.Name = "tabDadosUnidade";
            this.tabDadosUnidade.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosUnidade.Size = new System.Drawing.Size(768, 110);
            this.tabDadosUnidade.TabIndex = 0;
            this.tabDadosUnidade.Text = "Dados da Unidade";
            // 
            // txtPesquisaListView
            // 
            this.txtPesquisaListView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaListView.Enabled = false;
            this.txtPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaListView.Location = new System.Drawing.Point(16, 80);
            this.txtPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPesquisaListView.Name = "txtPesquisaListView";
            this.txtPesquisaListView.Size = new System.Drawing.Size(328, 22);
            this.txtPesquisaListView.TabIndex = 56;
            this.txtPesquisaListView.TextChanged += new System.EventHandler(this.txtPesquisaListView_TextChanged);
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.AutoSize = true;
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(16, 64);
            this.lblPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(109, 15);
            this.lblPesquisaListView.TabIndex = 57;
            this.lblPesquisaListView.Text = "Pesquisa Unidade..:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.AccessibleDescription = "";
            this.txtDescricao.AccessibleName = "";
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(136, 24);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(432, 22);
            this.txtDescricao.TabIndex = 65;
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescricao.Location = new System.Drawing.Point(136, 8);
            this.lbDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(68, 15);
            this.lbDescricao.TabIndex = 63;
            this.lbDescricao.Text = "Descrição..:";
            // 
            // lbIDUnidade
            // 
            this.lbIDUnidade.AutoSize = true;
            this.lbIDUnidade.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIDUnidade.Location = new System.Drawing.Point(16, 8);
            this.lbIDUnidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIDUnidade.Name = "lbIDUnidade";
            this.lbIDUnidade.Size = new System.Drawing.Size(30, 15);
            this.lbIDUnidade.TabIndex = 61;
            this.lbIDUnidade.Text = "ID..:";
            // 
            // txtIDUnidade
            // 
            this.txtIDUnidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDUnidade.Enabled = false;
            this.txtIDUnidade.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDUnidade.Location = new System.Drawing.Point(16, 24);
            this.txtIDUnidade.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDUnidade.Name = "txtIDUnidade";
            this.txtIDUnidade.Size = new System.Drawing.Size(96, 22);
            this.txtIDUnidade.TabIndex = 64;
            this.txtIDUnidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabControlUnidades
            // 
            this.tabControlUnidades.Controls.Add(this.tabDadosUnidade);
            this.tabControlUnidades.Controls.Add(this.tabInformacoesAdicionais);
            this.tabControlUnidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlUnidades.Location = new System.Drawing.Point(14, 3);
            this.tabControlUnidades.Multiline = true;
            this.tabControlUnidades.Name = "tabControlUnidades";
            this.tabControlUnidades.SelectedIndex = 0;
            this.tabControlUnidades.Size = new System.Drawing.Size(776, 136);
            this.tabControlUnidades.TabIndex = 73;
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = global::ProjetoTeste.Properties.Resources.Editar24x24;
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(344, 2);
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
            this.btnExcluir.Image = global::ProjetoTeste.Properties.Resources.Excluir24x24;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(552, 2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(98, 40);
            this.btnExcluir.TabIndex = 62;
            this.btnExcluir.Text = "     Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // listViewUnidades
            // 
            this.listViewUnidades.CausesValidation = false;
            this.listViewUnidades.FullRowSelect = true;
            this.listViewUnidades.GridLines = true;
            this.listViewUnidades.HideSelection = false;
            this.listViewUnidades.Location = new System.Drawing.Point(14, 144);
            this.listViewUnidades.Name = "listViewUnidades";
            this.listViewUnidades.Size = new System.Drawing.Size(776, 176);
            this.listViewUnidades.TabIndex = 71;
            this.listViewUnidades.UseCompatibleStateImageBehavior = false;
            this.listViewUnidades.View = System.Windows.Forms.View.Details;
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
            this.btnSalvar.Image = global::ProjetoTeste.Properties.Resources.Salvar24x24;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(448, 2);
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
            this.btnFechar.Image = global::ProjetoTeste.Properties.Resources.Sair24x24;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(656, 2);
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
            this.pnlBotoes.Controls.Add(this.lbTotalRegistros);
            this.pnlBotoes.Controls.Add(this.btnFechar);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnNovo);
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
            // btnNovo
            // 
            this.btnNovo.AutoSize = true;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = global::ProjetoTeste.Properties.Resources.Novo24x24;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(240, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(98, 40);
            this.btnNovo.TabIndex = 59;
            this.btnNovo.Text = "     Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // frmUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 394);
            this.Controls.Add(this.tabControlUnidades);
            this.Controls.Add(this.listViewUnidades);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "frmUnidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Unidades";
            this.tabDadosUnidade.ResumeLayout(false);
            this.tabDadosUnidade.PerformLayout();
            this.tabControlUnidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.Label lbNumeroSerie;
        private System.Windows.Forms.TabPage tabInformacoesAdicionais;
        private System.Windows.Forms.Label lbDataUltimaCompra;
        private System.Windows.Forms.TabPage tabDadosUnidade;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.Label lbIDUnidade;
        private System.Windows.Forms.TextBox txtIDUnidade;
        private System.Windows.Forms.TabControl tabControlUnidades;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.ListView listViewUnidades;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lbTotalRegistros;
    }
}
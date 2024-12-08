namespace ProjetoTeste
{
    partial class frmModelos
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
            this.tabDadosModelo = new System.Windows.Forms.TabPage();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lbMarcaProduto = new System.Windows.Forms.Label();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.lbIDModelo = new System.Windows.Forms.Label();
            this.txtIDModelo = new System.Windows.Forms.TextBox();
            this.tabControlModelos = new System.Windows.Forms.TabControl();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.listViewModelos = new System.Windows.Forms.ListView();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.tabDadosModelo.SuspendLayout();
            this.tabControlModelos.SuspendLayout();
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
            // tabDadosModelo
            // 
            this.tabDadosModelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosModelo.Controls.Add(this.cmbMarca);
            this.tabDadosModelo.Controls.Add(this.lbMarcaProduto);
            this.tabDadosModelo.Controls.Add(this.txtPesquisaListView);
            this.tabDadosModelo.Controls.Add(this.lblPesquisaListView);
            this.tabDadosModelo.Controls.Add(this.txtDescricao);
            this.tabDadosModelo.Controls.Add(this.lbDescricao);
            this.tabDadosModelo.Controls.Add(this.lbIDModelo);
            this.tabDadosModelo.Controls.Add(this.txtIDModelo);
            this.tabDadosModelo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosModelo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosModelo.Location = new System.Drawing.Point(4, 22);
            this.tabDadosModelo.Name = "tabDadosModelo";
            this.tabDadosModelo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosModelo.Size = new System.Drawing.Size(768, 110);
            this.tabDadosModelo.TabIndex = 0;
            this.tabDadosModelo.Text = "Dados do Modelo";
            // 
            // cmbMarca
            // 
            this.cmbMarca.BackColor = System.Drawing.Color.White;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(112, 24);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(180, 23);
            this.cmbMarca.TabIndex = 78;
            // 
            // lbMarcaProduto
            // 
            this.lbMarcaProduto.AutoSize = true;
            this.lbMarcaProduto.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMarcaProduto.Location = new System.Drawing.Point(112, 8);
            this.lbMarcaProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMarcaProduto.Name = "lbMarcaProduto";
            this.lbMarcaProduto.Size = new System.Drawing.Size(50, 15);
            this.lbMarcaProduto.TabIndex = 77;
            this.lbMarcaProduto.Text = "Marca..:";
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
            this.lblPesquisaListView.Size = new System.Drawing.Size(105, 15);
            this.lblPesquisaListView.TabIndex = 57;
            this.lblPesquisaListView.Text = "Pesquisa Modelo..:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.AccessibleDescription = "";
            this.txtDescricao.AccessibleName = "";
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(320, 24);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(432, 22);
            this.txtDescricao.TabIndex = 65;
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescricao.Location = new System.Drawing.Point(320, 8);
            this.lbDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(68, 15);
            this.lbDescricao.TabIndex = 63;
            this.lbDescricao.Text = "Descrição..:";
            // 
            // lbIDModelo
            // 
            this.lbIDModelo.AutoSize = true;
            this.lbIDModelo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIDModelo.Location = new System.Drawing.Point(16, 8);
            this.lbIDModelo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIDModelo.Name = "lbIDModelo";
            this.lbIDModelo.Size = new System.Drawing.Size(30, 15);
            this.lbIDModelo.TabIndex = 61;
            this.lbIDModelo.Text = "ID..:";
            // 
            // txtIDModelo
            // 
            this.txtIDModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDModelo.Enabled = false;
            this.txtIDModelo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDModelo.Location = new System.Drawing.Point(16, 24);
            this.txtIDModelo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIDModelo.Name = "txtIDModelo";
            this.txtIDModelo.Size = new System.Drawing.Size(72, 22);
            this.txtIDModelo.TabIndex = 64;
            this.txtIDModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabControlModelos
            // 
            this.tabControlModelos.Controls.Add(this.tabDadosModelo);
            this.tabControlModelos.Controls.Add(this.tabInformacoesAdicionais);
            this.tabControlModelos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlModelos.Location = new System.Drawing.Point(14, 3);
            this.tabControlModelos.Multiline = true;
            this.tabControlModelos.Name = "tabControlModelos";
            this.tabControlModelos.SelectedIndex = 0;
            this.tabControlModelos.Size = new System.Drawing.Size(776, 136);
            this.tabControlModelos.TabIndex = 73;
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
            // listViewModelos
            // 
            this.listViewModelos.CausesValidation = false;
            this.listViewModelos.FullRowSelect = true;
            this.listViewModelos.GridLines = true;
            this.listViewModelos.HideSelection = false;
            this.listViewModelos.Location = new System.Drawing.Point(14, 144);
            this.listViewModelos.Name = "listViewModelos";
            this.listViewModelos.Size = new System.Drawing.Size(776, 176);
            this.listViewModelos.TabIndex = 71;
            this.listViewModelos.UseCompatibleStateImageBehavior = false;
            this.listViewModelos.View = System.Windows.Forms.View.Details;
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
            // frmModelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 394);
            this.Controls.Add(this.tabControlModelos);
            this.Controls.Add(this.listViewModelos);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "frmModelos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Modelos";
            this.tabDadosModelo.ResumeLayout(false);
            this.tabDadosModelo.PerformLayout();
            this.tabControlModelos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.TabPage tabInformacoesAdicionais;
        private System.Windows.Forms.TabPage tabDadosModelo;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.Label lbIDModelo;
        private System.Windows.Forms.TextBox txtIDModelo;
        private System.Windows.Forms.TabControl tabControlModelos;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.ListView listViewModelos;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lbTotalRegistros;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label lbMarcaProduto;
    }
}
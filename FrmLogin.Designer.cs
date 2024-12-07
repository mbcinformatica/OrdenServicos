namespace ProjetoTeste
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtSenhaHash = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.imgCadeadoAberto = new System.Windows.Forms.PictureBox();
            this.imgCadeadoFechado = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeadoAberto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeadoFechado)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(240, 88);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(232, 22);
            this.txtSenha.TabIndex = 1;
            this.tlpDicas.SetToolTip(this.txtSenha, "Informe a Senha");
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(240, 48);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(232, 22);
            this.txtLogin.TabIndex = 0;
            this.tlpDicas.SetToolTip(this.txtLogin, "Informe o Login");
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(360, 128);
            this.btnSair.Name = "btnSair";
            this.btnSair.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSair.Size = new System.Drawing.Size(112, 40);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "    Sair";
            this.tlpDicas.SetToolTip(this.btnSair, "Botão Sair do Sistema");
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtSenhaHash
            // 
            this.txtSenhaHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaHash.Location = new System.Drawing.Point(0, 192);
            this.txtSenhaHash.Name = "txtSenhaHash";
            this.txtSenhaHash.Size = new System.Drawing.Size(505, 20);
            this.txtSenhaHash.TabIndex = 10;
            this.tlpDicas.SetToolTip(this.txtSenhaHash, "Informe o Login");
            this.txtSenhaHash.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erpProvider.SetIconAlignment(this.btnLogin, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(240, 128);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogin.Size = new System.Drawing.Size(113, 40);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "       Login";
            this.tlpDicas.SetToolTip(this.btnLogin, "Botão para Entrar no Sistema");
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(180, 51);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(54, 16);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(180, 91);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(46, 16);
            this.lblSenha.TabIndex = 2;
            this.lblSenha.Tag = "\"naoAplicar\"";
            this.lblSenha.Text = "Senha";
            // 
            // imgCadeadoAberto
            // 
            this.imgCadeadoAberto.Enabled = false;
            this.imgCadeadoAberto.Image = ((System.Drawing.Image)(resources.GetObject("imgCadeadoAberto.Image")));
            this.imgCadeadoAberto.Location = new System.Drawing.Point(36, 48);
            this.imgCadeadoAberto.Name = "imgCadeadoAberto";
            this.imgCadeadoAberto.Size = new System.Drawing.Size(112, 120);
            this.imgCadeadoAberto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCadeadoAberto.TabIndex = 11;
            this.imgCadeadoAberto.TabStop = false;
            this.imgCadeadoAberto.Visible = false;
            // 
            // imgCadeadoFechado
            // 
            this.imgCadeadoFechado.Enabled = false;
            this.imgCadeadoFechado.Image = ((System.Drawing.Image)(resources.GetObject("imgCadeadoFechado.Image")));
            this.imgCadeadoFechado.Location = new System.Drawing.Point(36, 48);
            this.imgCadeadoFechado.Name = "imgCadeadoFechado";
            this.imgCadeadoFechado.Size = new System.Drawing.Size(112, 120);
            this.imgCadeadoFechado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCadeadoFechado.TabIndex = 9;
            this.imgCadeadoFechado.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSair;
            this.ClientSize = new System.Drawing.Size(505, 216);
            this.Controls.Add(this.imgCadeadoAberto);
            this.Controls.Add(this.txtSenhaHash);
            this.Controls.Add(this.imgCadeadoFechado);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "\"naoAplicar\"";
            this.Text = "    Login";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeadoAberto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeadoFechado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox imgCadeadoFechado;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtSenhaHash;
        private System.Windows.Forms.PictureBox imgCadeadoAberto;
    }
}


using OrdenServicos.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OrdenServicos
{
    public partial class frmConfigFormulario : BaseForm
    {
        private bool salvaConfigPadrao;
        public frmConfigFormulario()
        {
            InitializeComponent();
            LoadConfig();
            Paint += new PaintEventHandler(BaseForm_Paint);
            erpProvider = new ErrorProvider();
            CarregaControlesFormulario();
        }
        private void CarregaControlesFormulario()
        {
            // Exemplo de uso
            CentralizarControlesHorizontalmenteNoPanel(pnlExemplosAtual, btnExemploAtual, lblDescricaoAtual, txtExemploAtual);
            CentralizarControlesHorizontalmenteNoPanel(pnlExemplosAlterado, btnExemploAlterada, lblDescricaoAlterada, txtExemploAlterada);
            CentralizarControlesHorizontalmenteNoPanel(pnlExemplosConfiguracaoAtual, lbConfiguracaoAtual);
            CentralizarControlesHorizontalmenteNoPanel(pnlExemplosConfiguracaoAlterada, lbConfiguracaoAlterada);



            // Definindo o tamanho e a posição dos Panels
            Size panelSize = new Size(388, 192); // Exemplo de tamanho
            Point panelLocation = new Point(692, 16); // Exemplo de posição

            pnlOpcaoFormulario.Size = panelSize;
            pnlOpcaoFormulario.Location = panelLocation;
            pnlOpcaoFormulario.Visible = false;

            pnlOpcaoCampos.Size = panelSize;
            pnlOpcaoCampos.Location = panelLocation;
            pnlOpcaoCampos.Visible = false;

            pnlOpcaoBotoes.Size = panelSize;
            pnlOpcaoBotoes.Location = panelLocation;
            pnlOpcaoBotoes.Visible = false;

            pnlOpcaoDescricao.Size = panelSize;
            pnlOpcaoDescricao.Location = panelLocation;
            pnlOpcaoDescricao.Visible = false;

            btnExemploAlterada.Visible = false;
            lblDescricaoAlterada.Visible = false;
            txtExemploAlterada.Visible = false;
            mnsStripExemploAlterado.Visible = false;
        }
        private void lnkConfiguracaoCampos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlOpcaoFormulario.Visible = false;
            pnlOpcaoCampos.Visible = true;
            pnlOpcaoBotoes.Visible = false;
            pnlOpcaoDescricao.Visible = false;

        }
        private void lnkConfiguracaoFormulario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlOpcaoFormulario.Visible = true;
            pnlOpcaoCampos.Visible = false;
            pnlOpcaoBotoes.Visible = false;
            pnlOpcaoDescricao.Visible = false;
        }
        private void lnkConfiguracaoBotoes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlOpcaoFormulario.Visible = false;
            pnlOpcaoCampos.Visible = false;
            pnlOpcaoBotoes.Visible = true;
            pnlOpcaoDescricao.Visible = false;
        }
        private void lnkConfiguracaoRotuloCampos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlOpcaoFormulario.Visible = false;
            pnlOpcaoCampos.Visible = false;
            pnlOpcaoBotoes.Visible = false;
            pnlOpcaoDescricao.Visible = true;
        }
        private void lnkConfiguracaoPadrao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            salvaConfigPadrao = true;
            btnSalvarSair_Click(sender, e);
            salvaConfigPadrao = false;
        }
        private void lnkOpcaoCorFormulario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ;
            cldCores.Color = gradientStartColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                gradientStartColor = cldCores.Color;
                MessageBox.Show("Escolha a segunda cor para fazer um efeito gradiente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (cldCores.ShowDialog() == DialogResult.OK)
                {
                    gradientEndColor = cldCores.Color;
                    ApplyGradientColors();
                }
            }
        }
        private void lnkOpcaoCorFundoMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mnsStripExemploAlterado.Visible = false;

            cldCores.Color = menuStripBackgroundColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                menuStripBackgroundColor = cldCores.Color;
                MessageBox.Show("Escolha a segunda cor para fazer um efeito gradiente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (cldCores.ShowDialog() == DialogResult.OK)
                {
                    gradientMenuEndColor = cldCores.Color;
                }
                mnsStripExemploAlterado.Visible = true;
            }
        }
        private void lnkOpcaoCorFonteMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mnsStripExemploAlterado.Visible = false;
            cldCores.Color = menuStripFontColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                menuStripFontColor = cldCores.Color;
                mnsStripExemploAlterado.Visible = true;
            }
        }
        private void lnkOpcaoCorFundoDescricao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = labelBackgroundColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                labelBackgroundColor = cldCores.Color;
                lblDescricaoAlterada.Visible = true;
                lblDescricaoAlterada.BackColor = labelBackgroundColor;
            }
        }
        private void lnkOpcaoCorFundoDescricaoTransparente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            labelBackgroundColor = Color.FromArgb(0, 255, 255, 255);
            lblDescricaoAlterada.BackColor = labelBackgroundColor;
            lblDescricaoAlterada.ForeColor = labelFontColor;
            lblDescricaoAlterada.Visible = true;
        }
        private void lnkOpcaoCorFonteDescricao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = labelFontColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                labelFontColor = cldCores.Color;
                lblDescricaoAlterada.ForeColor = labelFontColor;
                lblDescricaoAlterada.Visible = true;
            }
        }
        private void lnkOpcaoFonteDescricao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ftdFontes.ShowDialog() == DialogResult.OK)
            {
                labelFontFamily = ftdFontes.Font.FontFamily.Name;
                lblDescricaoAlterada.Font = new Font(
                    ftdFontes.Font.FontFamily,
                    ftdFontes.Font.Size,
                    ftdFontes.Font.Style
                );
                lblDescricaoAlterada.Visible = true;
            }
        }
        private void lnkOpcaoCorFundoCampo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = textBoxBackgroundColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                textBoxBackgroundColor = cldCores.Color;
                txtExemploAlterada.BackColor = textBoxBackgroundColor;
                txtExemploAlterada.Visible = true;
            }
        }
        private void lnkOpcaoCorFonteCampo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = textBoxFontColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                textBoxFontColor = cldCores.Color;
                txtExemploAlterada.ForeColor = textBoxFontColor;
                txtExemploAlterada.Visible = true;
            }
        }
        private void lnkOpcaoFonteCampo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ftdFontes.ShowDialog() == DialogResult.OK)
            {
                textBoxFontFamily = ftdFontes.Font.FontFamily.Name;
                txtExemploAlterada.Font = new Font(
                    ftdFontes.Font.FontFamily,
                    ftdFontes.Font.Size,
                    ftdFontes.Font.Style
                );
                txtExemploAlterada.Visible = true;
            }
        }
        private void lnkOpcaoCorFundoBotao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = buttonBackgroundColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                buttonBackgroundColor = cldCores.Color;
                btnExemploAlterada.BackColor = buttonBackgroundColor;
                btnExemploAlterada.Visible = true;
            }
        }
        private void lnkOpcaoCorFonteBotao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = buttonFontColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                buttonFontColor = cldCores.Color;
                btnExemploAlterada.ForeColor = buttonFontColor;
                btnExemploAlterada.Visible = true;
            }
        }
        private void lnkOpcaoFonteBotao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ftdFontes.ShowDialog() == DialogResult.OK)
            {
                buttonFontFamily = ftdFontes.Font.FontFamily.Name;
                btnExemploAlterada.Font = new Font(
                    ftdFontes.Font.FontFamily,
                    ftdFontes.Font.Size,
                    ftdFontes.Font.Style
                );
                btnExemploAlterada.Visible = true;
            }
        }
        private void btnSalvarSair_Click(object sender, EventArgs e)
        {
            // Exibe uma mensagem de confirmação ao usuário
            DialogResult confirmResult = MessageBox.Show("Deseja realmente salvar as alterações?", "Confirmar Alterações", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (salvaConfigPadrao)
                    {
                        CarregaDadosControles("configpadrao.xml");
                    }
                    // Define o caminho do arquivo de configuração
                    string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XML", "config.xml");

                    // Carrega o documento XML de configuração
                    XDocument config;
                    using (var stream = File.OpenRead(configPath))
                    {
                        config = XDocument.Load(stream);
                    }

                    // Atualiza os valores no documento XML

                    config.Root.Element("MenuStripBackgroundColor").Value = menuStripBackgroundColor.ToArgb().ToString("X");
                    config.Root.Element("GradientMenuEndColor").Value = gradientMenuEndColor.ToArgb().ToString("X");
                    config.Root.Element("MenuStripFontColor").Value = menuStripFontColor.ToArgb().ToString("X");

                    config.Root.Element("TextBoxBackgroundColor").Value = textBoxBackgroundColor.ToArgb().ToString("X");
                    config.Root.Element("TextBoxFontColor").Value = textBoxFontColor.ToArgb().ToString("X");
                    config.Root.Element("TextBoxBorderStyle").Value = textBoxBorderStyle.ToString();
                    config.Root.Element("TextBoxFontFamily").Value = textBoxFontFamily;
                    config.Root.Element("TextBoxFontSize").Value = textBoxFontSize.ToString();
                    config.Root.Element("TextBoxFontStyle").Value = textBoxFontStyle.ToString();
                    config.Root.Element("TextBoxMarginLeft").Value = textBoxMarginLeft.ToString();
                    config.Root.Element("TextBoxMarginTop").Value = textBoxMarginTop.ToString();
                    config.Root.Element("TextBoxMarginRight").Value = textBoxMarginRight.ToString();
                    config.Root.Element("TextBoxMarginBottom").Value = textBoxMarginBottom.ToString();

                    config.Root.Element("ButtonBackgroundColor").Value = buttonBackgroundColor.ToArgb().ToString("X");
                    config.Root.Element("ButtonFontColor").Value = buttonFontColor.ToArgb().ToString("X");
                    config.Root.Element("ButtonAutoSize").Value = buttonAutoSize.ToString();
                    config.Root.Element("ButtonAppearance").Element("BorderColor").Value = buttonBorderColor.ToArgb().ToString("X");
                    config.Root.Element("ButtonAppearance").Element("MouseDownBackColor").Value = buttonMouseDownBackColor.ToArgb().ToString("X");
                    config.Root.Element("ButtonAppearance").Element("MouseOverBackColor").Value = buttonMouseOverBackColor.ToArgb().ToString("X");
                    config.Root.Element("ButtonFontFamily").Value = buttonFontFamily;
                    config.Root.Element("ButtonFontSize").Value = buttonFontSize.ToString();
                    config.Root.Element("ButtonFontStyle").Value = buttonFontStyle.ToString();

                    config.Root.Element("LabelBackgroundColor").Value = labelBackgroundColor.ToArgb().ToString("X");
                    config.Root.Element("LabelFontColor").Value = labelFontColor.ToArgb().ToString("X");
                    config.Root.Element("LabelAutoSize").Value = labelAutoSize.ToString();
                    config.Root.Element("LabelFontFamily").Value = labelFontFamily;
                    config.Root.Element("LabelFontSize").Value = labelFontSize.ToString();
                    config.Root.Element("LabelFontStyle").Value = labelFontStyle.ToString();
                    config.Root.Element("LabelMarginLeft").Value = labelMarginLeft.ToString();
                    config.Root.Element("LabelMarginTop").Value = labelMarginTop.ToString();
                    config.Root.Element("LabelMarginRight").Value = labelMarginRight.ToString();
                    config.Root.Element("LabelMarginBottom").Value = labelMarginBottom.ToString();

                    config.Root.Element("PanelBackgroundColor").Value = panelBackgroundColor.ToArgb().ToString("X");

                    config.Root.Element("GradientStartColor").Value = gradientStartColor.ToArgb().ToString("X");
                    config.Root.Element("GradientEndColor").Value = gradientEndColor.ToArgb().ToString("X");

                    // Salva o documento XML atualizado
                    using (var stream = File.OpenWrite(configPath))
                    {
                        config.Save(stream);
                    }

                    // Exibe uma mensagem de confirmação para reiniciar o sistema
                    DialogResult restartResult = MessageBox.Show("As configurações foram salvas. O sistema precisa ser reiniciado para aplicar as alterações. Deseja reiniciar agora?", "Reiniciar Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (restartResult == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show($"Erro ao salvar o arquivo de configuração: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Recarrega os controles do formulário
                CarregaControlesFormulario();
            }
        }
        private void btnCancelarSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ApplyGradientColors()
        {
            Invalidate(); // Isso força o formulário a repintar com as novas cores
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, gradientStartColor, gradientEndColor, 70F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        private void CentralizarControlesHorizontalmenteNoPanel(Panel panel, params Control[] controles)
        {
            foreach (Control controle in controles)
            {
                // Calcular a nova posição X do controle para centralizá-lo horizontalmente no painel
                int x = (panel.Width - controle.Width) / 2;

                // Manter a posição Y atual do controle
                int y = controle.Location.Y;

                // Definir a nova posição do controle
                controle.Location = new Point(x, y);
            }
        }
    }
}

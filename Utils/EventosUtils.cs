using ProjetoTeste.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoTeste.Utils
{
    public static class EventosUtils
    {
        public static void Evento_MouseDown(object sender, MouseEventArgs e, Control controleComparacao, Control controleAnterior)
        {
            if (sender is Control controleAtual && controleAtual == controleComparacao)
            {
                MessageBox.Show("Campo não é acessível.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FocusPreviousControl(controleAnterior);
            }
        }
        private static void FocusPreviousControl(Control controleAnterior)
        {
            if (controleAnterior is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Focus();
            }
            else if (controleAnterior is MaskedTextBox maskedTextBox && string.IsNullOrEmpty(maskedTextBox.Text))
            {
                maskedTextBox.Focus();
            }
            else if (controleAnterior is ComboBox comboBox && comboBox.SelectedIndex == -1)
            {
                comboBox.Focus();
            }
            else if (controleAnterior is DateTimePicker dateTimePicker && dateTimePicker.Value == DateTimePicker.MinimumDateTime)
            {
                dateTimePicker.Focus();
            }
        }
        public static void Button_MouseEnter(object sender, EventArgs e, BaseForm baseForm)
        {
            if (sender is Button button)
            {
                button.BackColor = baseForm.buttonFontColor; // Cor de fundo ao passar o mouse
                button.ForeColor = baseForm.buttonBackgroundColor; // Cor da fonte ao passar o mouse
            }
        }
        public static void Button_MouseLeave(object sender, EventArgs e, BaseForm baseForm)
        {
            if (sender is Button button)
            {
                button.BackColor = baseForm.buttonBackgroundColor; // Cor de fundo original
                button.ForeColor = baseForm.buttonFontColor; // Cor da fonte original
            }
        }
        public static void AcaoBotoes(String acaoBotao, Form form)
        {
            Button btnSalvar = null, btnAlterar = null, btnExcluir = null, btnFechar = null, btnNovo = null;

            foreach (Control control in form.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control panelControl in panel.Controls)
                    {
                        if (panelControl is Button button)
                        {
                            switch (button.Name)
                            {
                                case "btnSalvar":
                                    btnSalvar = button;
                                    break;
                                case "btnAlterar":
                                    btnAlterar = button;
                                    break;
                                case "btnExcluir":
                                    btnExcluir = button;
                                    break;
                                case "btnFechar":
                                    btnFechar = button;
                                    break;
                                case "btnNovo":
                                    btnNovo = button;
                                    break;
                            }
                        }
                    }
                }
            }
            if (acaoBotao == "DesabilitarBotoesAcoes")
            {
                if (btnSalvar != null) btnSalvar.Enabled = false;
                if (btnAlterar != null) btnAlterar.Enabled = false;
                if (btnExcluir != null) btnExcluir.Enabled = false;
                if (btnFechar != null) btnFechar.Enabled = true;
                if (btnNovo != null)
                {
                    btnNovo.Enabled = true;
                    btnNovo.Focus();
                }
            }
            else if (acaoBotao == "HabilitarBotaoSalvar")

            {
                if (btnSalvar != null) btnSalvar.Enabled = true;
                if (btnAlterar != null) btnAlterar.Enabled = false;
                if (btnExcluir != null) btnExcluir.Enabled = false;
                if (btnFechar != null) btnFechar.Enabled = false;
                if (btnNovo != null) btnNovo.Enabled = false;
            }
            else if (acaoBotao == "HabilitarBotoesAlterarExcluir")

            {
                if (btnSalvar != null) btnSalvar.Enabled = false;
                if (btnAlterar != null) btnAlterar.Enabled = true;
                if (btnExcluir != null) btnExcluir.Enabled = true;
                if (btnFechar != null) btnFechar.Enabled = true;
                if (btnNovo != null) btnNovo.Enabled = true;
            }
        }
    }
}
using ProjetoTeste.BLL;
using ProjetoTeste.Forms;
using ProjetoTeste.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoTeste.Utils
{
    public static class EventosUtils
    {
        public static void Evento_KeyDown(object sender, KeyEventArgs e, Control nomeControles, BaseForm form)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Impede o som de "beep"
                ((Form)form).SelectNextControl((Control)sender, true, true, true, true);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                form.escPressed = true;
                form.AutoValidate = AutoValidate.Disable;
                form.CarregarRegistros();
                form.LimparCampos();
                form.AutoValidate = AutoValidate.EnablePreventFocusChange;
            }
            else if (e.Shift && e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true; // Impede o som de "beep"
                ((Form)form).SelectNextControl((Control)sender, false, true, true, true);
            }
        }
        public static void Evento_Enter(object sender, EventArgs e, Control controleEspecifico, BaseFormFuncoes form)
        {
            if (sender is MaskedTextBox maskedTextBox)
            {
                form.ControleAnterior = maskedTextBox;
                maskedTextBox.SelectAll();
            }
            else if (sender is TextBox textBox)
            {
                if (controleEspecifico.Contains(textBox))
                {
                    form.ControleAnterior?.Focus();
                }
                else
                {
                    form.ControleAnterior = textBox;
                    textBox.SelectAll();
                }
            }
            else if (sender is ComboBox comboBox)
            {
                form.ControleAnterior = comboBox;
            }
            else if (sender is DateTimePicker dateTimePicker)
            {
                form.ControleAnterior = dateTimePicker;
            }
        }
        public static void Evento_KeyPress(object sender, KeyPressEventArgs e, Control controleEspecifico, BaseForm form)
        {
            if (sender is MaskedTextBox maskedTextBox)
            {
                // Permitir somente números, vírgula e controle (como backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
                // Permitir somente uma vírgula decimal
                if (e.KeyChar == ',' && maskedTextBox.Text.IndexOf(',') > -1)
                {
                    e.Handled = true;
                }
            }
            else if (sender is TextBox textBox)
            {
                if (controleEspecifico.Tag?.ToString() == "no-input")
                {
                    // Bloqueia qualquer entrada de caractere para o controle especificado
                    e.Handled = true;
                }
                else if (controleEspecifico.Tag?.ToString() == "numeric" && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // Permite somente números no TextBox específico
                    e.Handled = true;
                }
                else if (controleEspecifico.Tag?.ToString() == "letters" && !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                {
                    // Permite somente letras no TextBox específico
                    e.Handled = true;
                }
            }
        }
        public static void Evento_MouseDown(object sender, MouseEventArgs e, Control nomeControles, BaseForm form)
        {
            if (form.ControleAnterior != null && form.ControleAnterior.Enabled)
            {
                form.ControleAnterior.Focus();
            }
            else
            {
                Control btnNovo = form.Controls.Find("btnNovo", true).FirstOrDefault();
                if (btnNovo != null)
                {
                    btnNovo.Focus();
                }
            }
        }
        public static void Button_MouseEnter(object sender, EventArgs e, BaseForm form)
        {
            if (sender is Button button)
            {
                button.BackColor = form.buttonFontColor; // Cor de fundo ao passar o mouse
                button.ForeColor = form.buttonBackgroundColor; // Cor da fonte ao passar o mouse
            }
        }
        public static void Button_MouseLeave(object sender, EventArgs e, BaseForm form)
        {
            if (sender is Button button)
            {
                button.BackColor = form.buttonBackgroundColor; // Cor de fundo original
                button.ForeColor = form.buttonFontColor; // Cor da fonte original
            }
        }
        public static void AcaoBotoes(String acaoBotao, BaseForm form)
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
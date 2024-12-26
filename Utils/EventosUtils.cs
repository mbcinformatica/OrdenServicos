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

        public static void AdicionarToolTips(BaseForm form, List<ControlToolTipPair> controlToolTipPairs, ToolTip tlpDicas)
        {
            foreach (var pair in controlToolTipPairs)
            {
                AddToolTipRecursively(tlpDicas, form, pair.Control, pair.ToolTipText);
            }
        }
        private static void AddToolTipRecursively(ToolTip tlpDicas, Control parent, Control targetControl, string toolTipText)
        {
            foreach (Control control in parent.Controls)
            {
                if (control == targetControl)
                {
                    tlpDicas.SetToolTip(control, toolTipText);
                    return;
                }

                if (control.HasChildren)
                {
                    AddToolTipRecursively(tlpDicas, control, targetControl, toolTipText);
                }
            }
        }
        public static void InicializarEventos(Control.ControlCollection controles, List<Control> controlesKeyPress, List<Control> controlesLeave, List<Control> controlesEnter, List<Control> controlesMouseDown, List<Control> controlesKeyDown, List<Control> controlesBotoes, BaseForm form, TabControl tabControl, TabPage tabPage)

        {
            foreach (Control controle in controles)
            {
                if (controlesKeyPress.Contains(controle))
                {
                    controle.KeyPress += (sender, e) => Evento_KeyPress(sender, e, controle, form);
                }
                if (controlesLeave.Contains(controle))
                {
                    controle.Leave += (sender, e) => Evento_Leave(sender, e, controle, form, tabControl, tabPage);
                }
                if (controlesEnter.Contains(controle))
                {
                    controle.Enter += (sender, e) => Evento_Enter(sender, e, controle, form);
                }
                if (controlesMouseDown.Contains(controle))
                {
                    controle.MouseDown += (sender, e) => Evento_MouseDown(sender, e, controle, form);
                }
                if (controlesKeyDown.Contains(controle))
                {
                    controle.KeyDown += (sender, e) => Evento_KeyDown(sender, e, controle, form);
                }
                if (controle is Button && controlesBotoes.Contains(controle))
                {
                    controle.MouseEnter += (sender, e) => Button_MouseEnter(sender, e, form);
                    controle.MouseLeave += (sender, e) => Button_MouseLeave(sender, e, form);
                }
                if (controle is Panel || controle is TabControl || controle is TabPage)
                {
                    InicializarEventos(controle.Controls, controlesKeyPress,
                                       controlesLeave, controlesEnter, controlesMouseDown,
                                       controlesKeyDown, controlesBotoes, form, tabControl, tabPage);
                }
            }
        }
        public static DateTimePicker FindDateTimePickerByTag(Control.ControlCollection controls, string tag)
        {
            foreach (Control control in controls)
            {
                if (control is DateTimePicker dateTimePicker && dateTimePicker.Tag?.ToString() == tag)
                {
                    return dateTimePicker;
                }

                if (control.HasChildren)
                {
                    var foundControl = FindDateTimePickerByTag(control.Controls, tag);
                    if (foundControl != null)
                    {
                        return foundControl;
                    }
                }
            }

            return null;
        }
        public static void Evento_KeyDown(object sender, KeyEventArgs e, Control nomeControles, BaseForm form)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
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
                e.SuppressKeyPress = true;
                ((Form)form).SelectNextControl((Control)sender, false, true, true, true);
            }
        }
        public static void Evento_KeyPress(object sender, KeyPressEventArgs e, Control controleEspecifico, BaseForm form)
        {
            if (sender is MaskedTextBox maskedTextBox)
            {
                var customTag = controleEspecifico.Tag as BaseForm;
                if (customTag != null && maskedTextBox.Text.Length >= customTag.TagMaxDigito && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == ',' && maskedTextBox.Text.IndexOf(',') > -1)
                {
                    e.Handled = true;
                }
            }
            else if (sender is TextBox textBox)
            {
                var customTag = controleEspecifico.Tag as BaseForm;
                if (customTag != null && customTag.TagAction == "no-input")

                {
                    // Bloqueia qualquer entrada de caractere para o controle especificado
                    e.Handled = true;
                }
                else if (customTag != null && customTag.TagAction == "SomenteNumeros" && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // Permite somente números no TextBox específico
                    e.Handled = true;
                }
                else if (customTag != null && customTag.TagAction == "SomenteLetras" && !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                {
                    // Permite somente letras no TextBox específico
                    e.Handled = true;
                }
            }
        }
        public static void Evento_Enter(object sender, EventArgs e, Control controleEspecifico, BaseForm form)
        {
            if (sender is MaskedTextBox maskedTextBox)
            {
                form.ControleAnterior = maskedTextBox;
                maskedTextBox.SelectAll();
            }
            else if (sender is TextBox textBox)
            {
                var customTag = controleEspecifico.Tag as BaseForm;
                if (customTag != null && customTag.TagAction == "no-input")
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
                comboBox.SelectAll();
            }
            else if (sender is RadioButton radioButton)
            {
                var customTag = controleEspecifico.Tag as BaseForm;
                if (customTag != null && customTag.TagAction == "Checked")
                {
                    form.ControleAnterior = radioButton;
                }
            }
            else if (sender is DateTimePicker dateTimePicker)
            {
                form.ControleAnterior = dateTimePicker;
                var customTag = dateTimePicker.Tag as BaseForm;
                if (customTag != null && customTag.TagAction == "data-final")
                {

                    // Depuração para verificar se o controle foi encontrado
                    if (form.dataEmissaoControl == null && form.bNovo)
                    {
                        MessageBox.Show("Data de emissão não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (form.bNovo)
                    {
                        // Somar 15 dias à data de emissão
                        dateTimePicker.Value = form.dataEmissaoControl.AddDays(15);
                        dateTimePicker.CustomFormat = "dd/MM/yyyy";
                        dateTimePicker.Format = DateTimePickerFormat.Custom;
                    }
                }
            }
        }
        public static void Evento_Leave(object sender, EventArgs e, Control nomeControles, BaseForm form, TabControl tabControl, TabPage tabPage)
        {
            form.CampoObrigatorio = false;
            if (form.escPressed || (form.ActiveControl is Button button && button.Name == "btnSair") ||
               (form.ActiveControl is Button buttonCancel && buttonCancel.Name == "btnCancelar"))
            {
                if (form.Tag?.ToString() == "frmLogin")
                {
                    form.escPressed = true;
                    Application.Exit();
                }
                else if (form.ActiveControl is Button buttonCanc && buttonCanc.Name == "btnCancelar")
                {
                    form.escPressed = true;
                    form.CarregarRegistros();
                    form.LimparCampos();
                }
                return;
            }
            if (sender is MaskedTextBox maskedTextBox)
            {
                form.ControleAnterior = maskedTextBox;
                if (maskedTextBox == nomeControles)
                {
                    var customTag = maskedTextBox.Tag as BaseForm;
                    if (customTag != null)
                    {
                        if (customTag.TagFormato == "FormatoMoeda")
                        {
                            if (string.IsNullOrEmpty(maskedTextBox.Text))
                            {
                                maskedTextBox.Text = "0";
                            }
                            maskedTextBox.Text = StringUtils.FormatValorMoeda(maskedTextBox.Text);
                        }
                        else if (customTag.TagFormato == "FormatoUnidade")
                        {
                            if (string.IsNullOrEmpty(maskedTextBox.Text))
                            {
                                maskedTextBox.Text = "0";
                            }
                            maskedTextBox.Text = StringUtils.FormatValorUnidade(maskedTextBox.Text);
                        }
                        else if (customTag.TagFormato == "FormataCep")
                        {
                            form.ExecutaFuncaoEvento(maskedTextBox);
                        }
                        else if (customTag.TagFormato == "FormataFone")
                        {
                            maskedTextBox.Text = StringUtils.FormatPhoneNumber(maskedTextBox.Text);
                        }
                        else if (customTag.TagFormato == "FormataCpfCnpj")
                        {
                            form.ExecutaFuncaoEvento(maskedTextBox);
                        }
                        
                    }
                }
            }
            else if (sender is TextBox textBox)
            {
                form.ControleAnterior = textBox;
                if (textBox == nomeControles)
                {
                    var customTag = textBox.Tag as BaseForm;
                    if (customTag != null)
                    {
                        if (customTag.TagAction == "FocaBotaoSalvar")
                        {
                            Control btnSalvar = form.Controls.Find("btnSalvar", true).FirstOrDefault();
                            if (btnSalvar != null)
                            {
                                btnSalvar.Focus();
                            }
                        }
                    }
                    form.ExecutaFuncaoEvento(textBox);
                }
            }
            else if (sender is ComboBox comboBox)
            {
                form.ControleAnterior = comboBox;
                if (comboBox == nomeControles)
                {
                    form.ExecutaFuncaoEvento(comboBox);
                }
            }
            else if (sender is DateTimePicker dateTimePicker)
            {
                var customTag = dateTimePicker.Tag as BaseForm;
                if (customTag != null && customTag.TagAction == "data-inicial")
                {
                    form.ControleAnterior = dateTimePicker;
                    DateTime selectedDate = dateTimePicker.Value;
                    form.dataEmissaoControl = dateTimePicker.Value;
                    dateTimePicker.Value = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    dateTimePicker.CustomFormat = "dd/MM/yyyy";
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
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
            Button btnSalvar = null, btnAlterar = null,
                   btnExcluir = null, btnFechar = null, btnNovo = null, btnCancelar = null;

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
                                case "btnCancelar":
                                    btnCancelar = button;
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
                if (btnFechar != null) btnFechar.Visible = true;
                if (btnCancelar != null) btnCancelar.Visible = false;
                if (btnCancelar != null) btnCancelar.Enabled = false;
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
                if (btnFechar != null) btnFechar.Visible = false;
                if (btnNovo != null) btnNovo.Enabled = false;
                if (btnCancelar != null) btnCancelar.Visible = true;
                if (btnCancelar != null) btnCancelar.Enabled = true;
            }
            else if (acaoBotao == "HabilitarBotoesAlterarExcluir")

            {
                if (btnSalvar != null) btnSalvar.Enabled = false;
                if (btnAlterar != null) btnAlterar.Enabled = true;
                if (btnExcluir != null) btnExcluir.Enabled = true;
                if (btnFechar != null) btnFechar.Enabled = true;
                if (btnFechar != null) btnFechar.Visible = true;
                if (btnNovo != null) btnNovo.Enabled = true;
                if (btnCancelar != null) btnCancelar.Visible = false;
                if (btnCancelar != null) btnCancelar.Enabled = false;
            }
        }
        public static void DesabilitarControles(List<Control> controles, BaseForm form)
        {
            foreach (Control controle in form.Controls)
            {
                DesabilitarControleRecursivo(controle, controles);
            }
        }
        private static void DesabilitarControleRecursivo(Control controle, List<Control> controles)
        {
            if (controles.Contains(controle))
            {
                controle.Enabled = false;
            }

            foreach (Control childControl in controle.Controls)
            {
                DesabilitarControleRecursivo(childControl, controles);
            }
        }
        public static void HabilitarControles(List<Control> controles, BaseForm form)
        {
            // Habilitar controles fornecidos na lista
            foreach (Control control in controles)
            {
                HabilitarControleRecursivo(form, control);
            }
        }
        private static void HabilitarControleRecursivo(Control parent, Control controle)
        {
            foreach (Control childControl in parent.Controls)
            {
                if (childControl == controle)
                {
                    childControl.Enabled = true;
                    return;
                }

                if (childControl.HasChildren)
                {
                    HabilitarControleRecursivo(childControl, controle);
                }
            }
        }
    }
}
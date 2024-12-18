using System;
using System.Windows.Forms;

namespace ProjetoTeste.Forms
{
    public interface BaseFormFuncoes
    {
        bool escPressed { get; set; }
        bool bNovo { get; set; }
        string TagFormato { get; set; }
        string TagAction { get; set; }
        Control ControleAnterior { get; set; }
        void CarregarRegistros();
        void LimparCampos();
        void ExecutaFuncaoEventoLeaveComboBox(ComboBox comboBox);
        void ExecutaFuncaoEventoKeyDownTextBox(TextBox textBox);

    }
}

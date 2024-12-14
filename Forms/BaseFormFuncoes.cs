using System;
using System.Windows.Forms;

namespace ProjetoTeste.Forms
{
    public interface BaseFormFuncoes
    {
        void CarregarRegistros();
        void LimparCampos();
        void VerificaComboBox(ComboBox comboBox);
        bool escPressed { get; set; }
        bool bNovo { get; set; }
        Control ControleAnterior { get; set; }
        AutoValidate AutoValidate { get; set; }
    }
}

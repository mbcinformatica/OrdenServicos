using System;
using System.Windows.Forms;

namespace ProjetoTeste.Forms
{
    public interface BaseFormFuncoes
    {
        void CarregarRegistros();
        void LimparCampos();
        bool escPressed { get; set; }
        Control ControleAnterior { get; set; }
        AutoValidate AutoValidate { get; set; }
    }
}

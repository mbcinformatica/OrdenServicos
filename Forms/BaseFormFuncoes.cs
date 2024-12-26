using System;
using System.Windows.Forms;

namespace ProjetoTeste.Forms
{
    public interface BaseFormFuncoes
    {
        DateTime dataEmissaoControl { get; set; }
        bool escPressed { get; set; }
        bool CampoObrigatorio { get; set; }
        bool bNovo { get; set; }
        string TagFormato { get; set; }
        string TagAction { get; set; }
        int TagMaxDigito { get; set; }
        Control ControleAnterior { get; set; }
        void CarregarRegistros();
        void LimparCampos();
        void ExecutaFuncaoEvento(Control control);
    }
}

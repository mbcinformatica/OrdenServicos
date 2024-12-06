using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Componentes
{
    public class HoverButton : Button
    {
        // Propriedade pública para o BackColor padrão
        private Color _defaultBackColor;
        [Browsable(true)]  // Torna a propriedade visível no painel de propriedades
        [Category("Appearance")]  // Organiza a propriedade na categoria 'Appearance'
        [Description("Cor de fundo padrão do botão.")]
        public override Color BackColor
        {
            get
            {
                return _defaultBackColor;
            }
            set
            {
                _defaultBackColor = value;
                base.BackColor = value;
            }
        }

        // Propriedade pública para o ForeColor padrão
        private Color _defaultForeColor;
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Cor de texto padrão do botão.")]
        public override Color ForeColor
        {
            get
            {
                return _defaultForeColor;
            }
            set
            {
                _defaultForeColor = value;
                base.ForeColor = value;
            }
        }

        // Propriedade pública para a cor de fundo no hover
        private Color _hoverBackColor = Color.CornflowerBlue;
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Cor de fundo do botão quando o mouse passa sobre ele.")]
        public Color HoverBackColor
        {
            get { return _hoverBackColor; }
            set { _hoverBackColor = value; }
        }

        // Propriedade pública para a cor de texto no hover
        private Color _hoverForeColor = Color.White;
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Cor de texto do botão quando o mouse passa sobre ele.")]
        public Color HoverForeColor
        {
            get { return _hoverForeColor; }
            set { _hoverForeColor = value; }
        }

        // Construtor
        public HoverButton()
        {
            // Inicializa as cores padrão
            _defaultBackColor = this.BackColor;
            _defaultForeColor = this.ForeColor;

            // Habilitar o efeito de hover
            this.MouseEnter += HoverButton_MouseEnter;
            this.MouseLeave += HoverButton_MouseLeave;
        }

        // Evento quando o mouse entra sobre o botão
        private void HoverButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = _hoverBackColor;
            this.ForeColor = _hoverForeColor;
            this.Cursor = Cursors.Hand;  // Muda o cursor para a mãozinha
            this.Invalidate();
        }

        // Evento quando o mouse sai do botão
        private void HoverButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _defaultBackColor;  // Restaura a cor de fundo original
            this.ForeColor = _defaultForeColor;  // Restaura a cor do texto original
            this.Cursor = Cursors.Default;  // Restaura o cursor para o padrão
            this.Invalidate();
        }
    }

}
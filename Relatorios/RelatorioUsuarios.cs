using iTextSharp.text;
using iTextSharp.text.pdf;
using OrdenServicos.BLL;
using OrdenServicos.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OrdenServicos
{
    public class RelatorioUsuarios
    {
        public void GerarRelatorioUsuarios(string caminhoArquivo)
        {
            // Obter dados dos usuarios usando a camada BLL
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            List<UsuarioInfo> usuarios = usuarioBLL.Listar();

			// Verificar se a lista de usuarios está vazia
			if (usuarios.Count == 0)
			{
				MessageBox.Show("Nenhum dado de usuarios disponível para gerar o relatório.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			// Configurar documento para A4 paisagem com margens
			Document doc = new Document(PageSize.A4.Rotate());
            doc.SetMargins(20f, 20f, 80f, 40f);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

            // Adicionar evento de página personalizado com título
            HeaderFooter eventHandler = new HeaderFooter("Relatório de Usuários");
            writer.PageEvent = eventHandler;

            doc.Open();


            // Criar tabela
            PdfPTable tabela = new PdfPTable(10);
            tabela.WidthPercentage = 100;

            // Configurar larguras das colunas
            tabela.SetWidths(new float[] { 56f, 56f, 40f, 10f, 30f, 40f, 14f, 20f, 20f, 35f });

            // Adicionar cabeçalhos
            AdicionarCelulaCabecalho(tabela, "NOME");
            AdicionarCelulaCabecalho(tabela, "LOGIN");
            AdicionarCelulaCabecalho(tabela, "ENDEREÇO");
            AdicionarCelulaCabecalho(tabela, "NUMERO");
            AdicionarCelulaCabecalho(tabela, "BAIRRO");
            AdicionarCelulaCabecalho(tabela, "MUNICIPIO");
            AdicionarCelulaCabecalho(tabela, "CEP");
            AdicionarCelulaCabecalho(tabela, "CELULAR");
            AdicionarCelulaCabecalho(tabela, "FIXO");
            AdicionarCelulaCabecalho(tabela, "EMAIL");

            // Configurar a tabela para repetir os cabeçalhos em todas as páginas
            tabela.HeaderRows = 1;

            // Adicionar dados dos usuarios com cores alternadas
            bool linhaPar = false;
            foreach (var usuario in usuarios)
            {
                BaseColor corLinha = linhaPar ? BaseColor.LIGHT_GRAY : BaseColor.WHITE;
                AdicionarCelulaDado(tabela, usuario.Nome, 125f, Element.ALIGN_LEFT, corLinha);
                AdicionarCelulaDado(tabela, usuario.Login, 125f, Element.ALIGN_LEFT, corLinha);
                AdicionarCelulaDado(tabela, usuario.Endereco, 90f, Element.ALIGN_LEFT, corLinha);
                AdicionarCelulaDado(tabela, usuario.Numero, 10f, Element.ALIGN_RIGHT, corLinha);
                AdicionarCelulaDado(tabela, usuario.Bairro, 70f, Element.ALIGN_LEFT, corLinha);
                AdicionarCelulaDado(tabela, usuario.Municipio, 90f, Element.ALIGN_LEFT, corLinha);
                AdicionarCelulaDado(tabela, Utils.StringUtils.FormatCEP(usuario.Cep), 40f, Element.ALIGN_RIGHT, corLinha);
                AdicionarCelulaDado(tabela, Utils.StringUtils.FormatPhoneNumber(usuario.Fone_1), 47f, Element.ALIGN_RIGHT, corLinha);
                AdicionarCelulaDado(tabela, Utils.StringUtils.FormatPhoneNumber(usuario.Fone_2), 45f, Element.ALIGN_RIGHT, corLinha);
                AdicionarCelulaDado(tabela, usuario.Email, 80f, Element.ALIGN_LEFT, corLinha);
                linhaPar = !linhaPar;
            }

            // Adicionar tabela ao documento
            doc.Add(tabela);

            // Fechar documento
            doc.Close();
            Process.Start(new ProcessStartInfo(caminhoArquivo) { UseShellExecute = true });

			// Exiba uma mensagem de confirmação
			MessageBox.Show("Relatório gerado com sucesso em " + caminhoArquivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

		}

		private void AdicionarCelulaCabecalho(PdfPTable tabela, string texto)
        {
            PdfPCell celula = new PdfPCell(new Phrase(texto, new Font(Font.FontFamily.COURIER, 5, Font.BOLD)));
            celula.HorizontalAlignment = Element.ALIGN_CENTER;
            celula.VerticalAlignment = Element.ALIGN_MIDDLE;
            celula.BackgroundColor = BaseColor.LIGHT_GRAY;
            celula.NoWrap = true;
            tabela.AddCell(celula);
        }



        private void AdicionarCelulaDado(PdfPTable tabela, string texto, float larguraColuna, int alinhamento, BaseColor corFundo)
        {
            // Ajustar o tamanho da fonte
            Font fonte = new Font(Font.FontFamily.COURIER, 5, Font.NORMAL);
            BaseFont bf = fonte.GetCalculatedBaseFont(false);

            // Medir a largura do texto em pontos
            float larguraTexto = bf.GetWidthPoint(texto, fonte.Size);

            // Truncar o texto se necessário
            while (larguraTexto > larguraColuna)
            {
                texto = texto.Substring(0, texto.Length - 1);
                larguraTexto = bf.GetWidthPoint(texto, fonte.Size);
            }

            PdfPCell celula = new PdfPCell(new Phrase(texto, fonte));
            celula.HorizontalAlignment = alinhamento;
            celula.VerticalAlignment = Element.ALIGN_MIDDLE;
            celula.BackgroundColor = corFundo;
            celula.NoWrap = true; // Evita quebra de linha
            tabela.AddCell(celula);
        }


    }
}

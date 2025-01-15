using iTextSharp.text;
using iTextSharp.text.pdf;
using MySqlX.XDevAPI;
using OrdenServicos.BLL;
using OrdenServicos.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OrdenServicos
{
    public class RelatorioFornecedores
    {
        public void GerarRelatorioFornecedores(string caminhoArquivo)
        {
            // Obter dados dos fornecedors usando a camada BLL
            FornecedorBLL fornecedorBLL = new FornecedorBLL();
            List<FornecedorInfo> fornecedores = fornecedorBLL.Listar();

			// Verificar se a lista de fornecedores está vazia
			if (fornecedores.Count == 0)
			{
				MessageBox.Show("Nenhum dado de fornecedores disponível para gerar o relatório.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			// Configurar documento para A4 paisagem com margens
			Document doc = new Document(PageSize.A4.Rotate());
            doc.SetMargins(20f, 20f, 80f, 40f);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

            // Adicionar evento de página personalizado com título
            HeaderFooter eventHandler = new HeaderFooter("Relatório de Fornecedores");
            writer.PageEvent = eventHandler;

            doc.Open();


            // Criar tabela
            PdfPTable tabela = new PdfPTable(11);
            tabela.WidthPercentage = 100;

            // Configurar larguras das colunas
            tabela.SetWidths(new float[] { 24f, 56f, 40f, 10f, 30f, 40f, 14f, 40f, 20f, 20f, 35f });

            // Adicionar cabeçalhos
            AdicionarCelulaCabecalho(tabela, "CPF/CNPJ");
            AdicionarCelulaCabecalho(tabela, "NOME/RAZÃO SOCIAL");
            AdicionarCelulaCabecalho(tabela, "ENDEREÇO");
            AdicionarCelulaCabecalho(tabela, "NUMERO");
            AdicionarCelulaCabecalho(tabela, "BAIRRO");
            AdicionarCelulaCabecalho(tabela, "MUNICIPIO");
            AdicionarCelulaCabecalho(tabela, "CEP");
            AdicionarCelulaCabecalho(tabela, "CONTATO");
            AdicionarCelulaCabecalho(tabela, "CELULAR");
            AdicionarCelulaCabecalho(tabela, "FIXO");
            AdicionarCelulaCabecalho(tabela, "EMAIL");

            // Configurar a tabela para repetir os cabeçalhos em todas as páginas
            tabela.HeaderRows = 1;

            // Adicionar dados dos fornecedors com cores alternadas
            bool linhaPar = false;
            foreach (var fornecedor in fornecedores)
            {
                BaseColor corLinha = linhaPar ? BaseColor.LIGHT_GRAY : BaseColor.WHITE;
                AdicionarCelulaDado(tabela, fornecedor.TipoPessoa == "FÍSICA" ? Utils.StringUtils.FormatCPF(fornecedor.Cpf_Cnpj) : Utils.StringUtils.FormatCNPJ(fornecedor.Cpf_Cnpj), 54f, Element.ALIGN_RIGHT, corLinha);
                AdicionarCelulaDado(tabela, fornecedor.Nome_RazaoSocial, 125f, Element.ALIGN_LEFT, corLinha);
                AdicionarCelulaDado(tabela, fornecedor.Endereco, 90f, Element.ALIGN_LEFT, corLinha);
                AdicionarCelulaDado(tabela, fornecedor.Numero, 10f, Element.ALIGN_RIGHT, corLinha);
                AdicionarCelulaDado(tabela, fornecedor.Bairro, 70f, Element.ALIGN_LEFT, corLinha);
                AdicionarCelulaDado(tabela, fornecedor.Municipio, 90f, Element.ALIGN_LEFT, corLinha);
                AdicionarCelulaDado(tabela, Utils.StringUtils.FormatCEP(fornecedor.Cep), 40f, Element.ALIGN_RIGHT, corLinha);
                AdicionarCelulaDado(tabela, fornecedor.Contato, 90f, Element.ALIGN_LEFT, corLinha);
                AdicionarCelulaDado(tabela, Utils.StringUtils.FormatPhoneNumber(fornecedor.Fone_1), 47f, Element.ALIGN_RIGHT, corLinha);
                AdicionarCelulaDado(tabela, Utils.StringUtils.FormatPhoneNumber(fornecedor.Fone_2), 45f, Element.ALIGN_RIGHT, corLinha);
                AdicionarCelulaDado(tabela, fornecedor.Email, 80f, Element.ALIGN_LEFT, corLinha);
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

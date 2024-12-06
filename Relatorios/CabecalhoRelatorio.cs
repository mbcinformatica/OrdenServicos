using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

public class HeaderFooter : PdfPageEventHelper
{
    private Image logo;
    private string titulo;

    public HeaderFooter(string titulo)
    {
        this.titulo = titulo;
        // Carregar a imagem do logo
        string caminhoLogo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources", "LogoRelatorio.png");
        if (File.Exists(caminhoLogo))
        {
            logo = Image.GetInstance(caminhoLogo);
            logo.ScaleToFit(300f, 300f);
            logo.Alignment = Element.ALIGN_LEFT;
        }
    }

    public override void OnEndPage(PdfWriter writer, Document document)
    {

        // Adicionar Cabeçalho

        PdfPTable header = new PdfPTable(2);
        header.TotalWidth = document.PageSize.Width - (document.LeftMargin + document.RightMargin);
        header.DefaultCell.Border = Rectangle.NO_BORDER;

        if (logo != null)
        {
            PdfPCell logoCell = new PdfPCell(logo);
            logoCell.Border = Rectangle.NO_BORDER;
            logoCell.HorizontalAlignment = Element.ALIGN_LEFT;
            header.AddCell(logoCell);
        }
        else
        {
            PdfPCell emptyCell = new PdfPCell();
            emptyCell.Border = Rectangle.NO_BORDER;
            header.AddCell(emptyCell);
        }

        // Adicionar informações de contato
        PdfPCell infoCell = new PdfPCell();
        infoCell.Border = Rectangle.NO_BORDER;
        infoCell.HorizontalAlignment = Element.ALIGN_CENTER;
        infoCell.AddElement(new Paragraph(titulo, new Font(Font.FontFamily.COURIER, 16, Font.BOLD)));
        header.AddCell(infoCell);

        header.WriteSelectedRows(0, -1, document.LeftMargin, (document.PageSize.Height - 20), writer.DirectContent);

        // Adicionar rodapé

        PdfPTable footer = new PdfPTable(1);
        footer.TotalWidth = document.PageSize.Width - (document.LeftMargin - document.RightMargin);
        footer.DefaultCell.Border = Rectangle.NO_BORDER;

        PdfPCell footerCell = new PdfPCell(new Phrase($"Página {writer.PageNumber}", new Font(Font.FontFamily.COURIER, 10, Font.NORMAL)));
        footerCell.HorizontalAlignment = Element.ALIGN_CENTER;
        footerCell.Border = Rectangle.NO_BORDER;
        footer.AddCell(footerCell);

        footer.WriteSelectedRows(0, -1, document.LeftMargin, 40, writer.DirectContent);


    }
}

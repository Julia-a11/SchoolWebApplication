using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using SchoolBusinessLogic.HelperModel;


namespace SchoolBusinessLogic.BusinessLogic
{
    public class SaveToPdfLogic
    {
        public static void CreateDoc(PdfInfo info)
        {
            PdfWriter writer = new PdfWriter(info.FileName);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont font = PdfFontFactory.CreateFont(@"C:\Windows\Fonts\Arial.ttf", "Identity-H", true);

            Paragraph header = new Paragraph(info.Title)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20)
               .SetFont(font);

            Paragraph dates = new Paragraph($"с {info.DateFrom.ToShortDateString()} по { info.DateTo.ToShortDateString()}")
                .SetFontSize(18)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFont(font);

            document.Add(header);
            document.Add(dates);

            foreach (var society in info.Societies)
            {
                Paragraph societyName = new Paragraph(society.SocietyName)
                .SetFontSize(18)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBold()
                .SetFont(font);

                document.Add(societyName);

                Paragraph dateCreate = new Paragraph(society.DateCreate.ToShortDateString())
                .SetFontSize(16)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFont(font);

                document.Add(dateCreate);

                Paragraph costHeader = new Paragraph("Затраты")
                    .SetFontSize(16)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFont(font);

                document.Add(costHeader);

                Table tableCosts = new Table(2, false);

                Cell numberCell = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph("Номер затраты"))
                        .SetFont(font);

                Cell sumCell = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Сумма"))
                    .SetFont(font);

                tableCosts.AddCell(numberCell);
                tableCosts.AddCell(sumCell);

                foreach (var cost in society.Costs)
                {
                    numberCell = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(cost.Id.ToString())
                        .SetFont(font));

                    sumCell = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(cost.Sum.ToString()))
                        .SetFont(font);

                    tableCosts.AddCell(numberCell);
                    tableCosts.AddCell(sumCell);
                }

                document.Add(tableCosts);
            }

            document.Close();
        }
    }
}

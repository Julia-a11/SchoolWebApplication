﻿//using DocumentFormat.OpenXml.Spreadsheet;
//using DocumentFormat.OpenXml.Wordprocessing;
//using MigraDoc.DocumentObjectModel;
//using MigraDoc.Rendering;
//using SchoolBusinessLogic.HelperModel;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using static System.Collections.Specialized.BitVector32;

//namespace SchoolBusinessLogic.BusinessLogic
//{
//    public class SaveToPdfLogic
//    {
//        [Obsolete]
//        public static void CreateDoc(PdfInfo info)
//        {
//            Document document = new Document();
//            DefineStyles(document);

//            Section section = document.AddSection();
//            Paragraph paragraph = section.AddParagraph(info.Title);
//            paragraph.Format.SpaceAfter = "1cm";
//            paragraph.Format.Alignment = ParagraphAlignment.Center;
//            paragraph.Style = "NormalTitle";

//            paragraph = section.AddParagraph($"c {info.DateFrom.ToShortDateString()} по {info.DateTo.ToShortDateString()}");
//            paragraph.Format.SpaceAfter = "1cm";
//            paragraph.Format.Alignment = ParagraphAlignment.Center;
//            paragraph.Style = "Normal";

//            var table = document.LastSection.AddTable();

//            List<string> columns = new List<string> { "3cm", "6cm", "3cm", "2cm", "3cm" };
//            foreach (var elem in columns)
//            {
//                table.AddColumn(elem);
//            }

//            CreateRow(new PdfRowParameters
//            {
//                Table = table,
//                Texts = new List<string> { "Дата заказа", "Изделие", "Количество", "Сумма", "Статус" },
//                Style = "NormalTitle",
//                ParagraphAlignment = ParagraphAlignment.Center
//            });

//            foreach (var order in info.Orders)
//            {
//                CreateRow(new PdfRowParameters
//                {
//                    Table = table,
//                    Texts = new List<string> { order.DateCreate.ToShortDateString(),
//                    order.SecureName, order.Count.ToString(), order.Sum.ToString(), order.Status.ToString()},
//                    Style = "Normal",
//                    ParagraphAlignment = ParagraphAlignment.Left
//                });
//            }

//            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
//            {
//                Document = document
//            };
//            renderer.RenderDocument();
//            renderer.PdfDocument.Save(info.FileName);
//        }

//        // Создание стилей для документа
//        private static void DefineStyles(Document document)
//        {
//            Style style = document.Styles["Normal"];
//            style.Font.Name = "Times New Roman";
//            style.Font.Size = 14;

//            style = document.Styles.AddStyle("NormalTitle", "Normal");
//            style.Font.Bold = true;
//        }

//        // Создание и заполнение строки
//        private static void CreateRow(PdfRowParameters rowParameters)
//        {
//            Row row = rowParameters.Table.AddRow();
//            for (int i = 0; i < rowParameters.Texts.Count; ++i)
//            {
//                FillCell(new PdfCellParameters
//                {
//                    Cell = row.Cells[i],
//                    Text = rowParameters.Texts[i],
//                    Style = rowParameters.Style,
//                    BorderWidth = 0.5,
//                    ParagraphAlignment = rowParameters.ParagraphAligment
//                });
//            }
//        }

//        // Заполнение ячейки
//        private static void FillCell(PdfCellParameters cellParameters)
//        {
//            cellParameters.Cell.AddParagraph(cellParameters.Text);

//            if (!string.IsNullOrEmpty(cellParameters.Style))
//            {
//                cellParameters.Cell.Style = cellParameters.Style;
//            }

//            cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
//            cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
//            cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
//            cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;

//            cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
//            cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
//        }
//    }
//}
using DocumentFormat.OpenXml.Spreadsheet;
using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.HelperModel
{
    public class PdfCellParameters
    {
        public Cell Cell { get; set; }

        public string Text { get; set; }

        public string Style { get; set; }

        public ParagraphAlignment ParagraphAlignment { get; set; }

        public Unit BorderWidth { get; set; }
    }
}

using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using MigraDoc.DocumentObjectModel.Tables;
namespace SchoolBusinessLogic.HelperModel
{
    public class PdfRowParameters
    {
        public Table Table { get; set; }

        public List<string> Texts { get; set; }

        public string Style { get; set; }

        public ParagraphAlignment ParagraphAligment { get; set; }
       
        public ParagraphAlignment ParagraphAlignment { get; internal set; }
    }
}

using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.HelperModel
{
    public class PdfInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public List<SocietyViewModel> Societies { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BindingModel
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public List<int> SelectedSocieties { get; set; }

        public int ClientId { get; set; }
    }
}

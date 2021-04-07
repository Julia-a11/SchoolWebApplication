using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.HelperModel
{
    public class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<SocietyViewModel> Societies { get; set; }
    }
}

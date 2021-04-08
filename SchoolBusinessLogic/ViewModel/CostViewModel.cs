using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolBusinessLogic.ViewModel
{
    public class CostViewModel
    {
        [DisplayName("Номер затраты")]
        public int Id { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
    }
}

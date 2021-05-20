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

        [DisplayName("Дата выставления затрат")]
        public DateTime CostDate { get; set; }

        public int EmployeeId { get; set; }

        [DisplayName("Имя работника")]
        public string EmployeeName { get; set; }

        public string Description { get; set; }

        public decimal AdditionalCost { get; set; }
    }
}

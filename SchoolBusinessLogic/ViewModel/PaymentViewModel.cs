using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolBusinessLogic.ViewModel
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        [DisplayName("Занятие")]
        public string LessonName { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
    }
}

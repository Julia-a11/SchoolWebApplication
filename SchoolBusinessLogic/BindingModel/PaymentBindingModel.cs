using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolBusinessLogic.BindingModel
{
    public class PaymentBindingModel
    {
        public int? Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public int LessonId { get; set; }

        public int ClientId { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
    }
}

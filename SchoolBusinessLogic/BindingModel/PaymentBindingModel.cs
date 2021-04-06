using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolBusinessLogic.BindingModel
{
    public class PaymentBindingModel
    {
        public int? Id { get; set; }

        public int LessonId { get; set; }

        [DisplayName("Сумма")]
        public double Sum { get; set; }
    }
}

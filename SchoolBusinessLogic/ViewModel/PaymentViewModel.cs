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

        [DisplayName("Всего к оплате")]
        public decimal FullSum { get; set; }

        [DisplayName("Дата оплаты")]
        public DateTime PaymentDate { get; set; }

        public int ClientId { get; set; }

        [DisplayName("Имя клиента")]
        public string ClientName { get; set; }
    }
}

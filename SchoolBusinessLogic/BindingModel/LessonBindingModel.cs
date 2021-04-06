using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolBusinessLogic.BindingModel
{
    public class LessonBindingModel
    {
        public int? Id { get; set; }

        [DisplayName("Название")]
        public string LessonName { get; set; }

        [DisplayName("Количество занятий")]
        public int LessonCount { get; set; }

        [DisplayName("Стоимость")]
        public decimal Price { get; set; }

        public int EmployeeId { get; set; }
    }
}

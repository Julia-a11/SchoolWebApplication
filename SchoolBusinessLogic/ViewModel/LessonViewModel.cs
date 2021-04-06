﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolBusinessLogic.ViewModel
{
    public class LessonViewModel
    {
        public int Id { get; set; }

        [DisplayName("Занятие")]
        public string LessonName { get; set; }

        [DisplayName("Количество занятий")]
        public int LessonCount { get; set; }

        [DisplayName("Стоимость")]
        public decimal Price { get; set; }

        public int EmployeeId { get; set; }

        [DisplayName("ФИО работника")]
        public string EmployeeName { get; set; }
    }
}

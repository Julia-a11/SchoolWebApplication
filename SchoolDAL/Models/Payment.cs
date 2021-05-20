﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDAL.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public int LessonId { get; set; }

        public virtual Lesson Lesson { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}

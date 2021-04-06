﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDAL.Models
{
    public class SocietyCost
    {
        public int Id { get; set; }

        public int SocietyId { get; set; }

        public int CostId { get; set; }

        public virtual Society Society { get; set; }

        public virtual Cost Cost { get; set; }
    }
}

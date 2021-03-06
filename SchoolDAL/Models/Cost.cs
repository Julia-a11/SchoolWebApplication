using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDAL.Models
{
    public class Cost
    {
        public int Id { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CostDate { get; set; }

        [ForeignKey("CostId")]
        public virtual List<SocietyCost> SocietyCosts { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

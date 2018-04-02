using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDH7A1.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public int Students { get; set; }

        [Required]
        public bool ComputerRoom { get; set; }

        [Required]
        public bool SurveillantNeeded { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int EuropeanCredits { get; set; }

        [Required]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Moment> Moments { get; set; }

        public Exam()
        {
            Moments = new HashSet<Moment>();
        }
    }
}
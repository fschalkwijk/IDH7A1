using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDH7A1.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public int Students { get; set; }

        public bool ComputerRoom { get; set; }

        public bool SurveillantNeeded { get; set; }

        public string Code { get; set; }

        public int EuropeanCredits { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Moment> Moments { get; set; }

        public Exam()
        {
            Moments = new HashSet<Moment>();
        }
    }
}
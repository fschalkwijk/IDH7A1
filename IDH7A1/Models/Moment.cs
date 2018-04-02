using IDH7A1.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDH7A1.Models
{
    public class Moment
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
        
        public string Name { get { return String.Format("{0} {1}", Exam.Name, StartTime); } }

        [Required]
        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }
        
        public virtual ICollection<MomentRoom> MomentRooms { get; set; }

        public Moment()
        {
            MomentRooms = new HashSet<MomentRoom>();
        }
    }
}
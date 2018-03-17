using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDH7A1.Models
{
    public class Room
    {
        [Key]
        [StringLength(10)]
        public string Key { get; set; }

        public int Computers { get; set; }

        public int MaxStudents { get; set; }

        public virtual ICollection<MomentRoom> MomentRooms { get; set; }

        public Room()
        {
            MomentRooms = new HashSet<MomentRoom>();
        }
    }
}
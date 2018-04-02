using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDH7A1.Models
{
    public class Surveillant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<MomentRoom> MomentRooms { get; set; }

        public Surveillant()
        {
            MomentRooms = new HashSet<MomentRoom>();
        }
    }
}
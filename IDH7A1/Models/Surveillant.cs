using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDH7A1.Models
{
    public class Surveillant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MomentRoom> MomentRooms { get; set; }

        public Surveillant()
        {
            MomentRooms = new HashSet<MomentRoom>();
        }
    }
}
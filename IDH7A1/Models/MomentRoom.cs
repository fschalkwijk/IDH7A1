using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IDH7A1.Models
{
    public class MomentRoom
    {
        [Key, Column(Order = 0)]
        public int MomentId { get; set; }

        [Key, Column(Order = 1)]
        public string RoomKey { get; set; }

        public virtual Moment Moment { get; set; }

        public virtual Room Room { get; set; }

        public virtual Surveillant Surveillant { get; set; }
    }
}
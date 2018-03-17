using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDH7A1.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }

        public User()
        {
            Exams = new HashSet<Exam>();
        }
    }
}
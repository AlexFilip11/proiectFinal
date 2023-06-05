using proiectFinal.Database_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectFinal.Models
{
    public class Teacher
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public Address? Address { get; set; }
        public Rank Rank { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}

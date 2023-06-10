using proiectFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectFinal.Database_Classes
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Address? Address { get; set; }
        public List<Mark>? Marks { get; set; } = new List<Mark>();
        public List<Subject>? Subjects { get; set; } 
    }
}

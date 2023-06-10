using proiectFinal.Database_Classes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectFinal.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime DataAndTime { get; set; }
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set;}
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set;}
    }
}

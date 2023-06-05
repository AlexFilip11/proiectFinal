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
        public int? SubjectID { get; set; }
        public Subject Subjects { get; set; }
        public List<Student> Students { get; set;} = new List<Student>();
    }
}

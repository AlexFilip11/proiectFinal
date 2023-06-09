using proiectFinal.Database_Classes;
using proiectFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectFinal.DAL
{
    internal class DataAccessLayerSubjects
    {
        private readonly StudentsDbContext ctx;
        public DataAccessLayerSubjects(StudentsDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void AddSubject(Subject newSubject)
        {
            var subject = new Subject { Name = newSubject.Name };
            ctx.Subjects.Add(subject);
            ctx.SaveChanges();
        }
        public List<Subject> GetAllSubjects() => ctx.Subjects.ToList();
        public List<Subject> GetAllSubjectsOfASpecificStudent(int studentId)
        {
            return ctx.Marks.Where(s=> s.StudentId == studentId).Select(m => m.Subject).Distinct().ToList();
        }
        public void DeleteSubject(int subjectId)
        {
            var subject = ctx.Subjects.Single(s => s.Id == subjectId);
            if (subject.Marks != null)
            {
                ctx.Marks.RemoveRange(subject.Marks);
            }
            ctx.Subjects.Remove(subject);
            ctx.SaveChanges();
        }
    }
}

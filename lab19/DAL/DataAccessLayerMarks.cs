using Microsoft.EntityFrameworkCore;
using proiectFinal.Database_Classes;
using proiectFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectFinal.DAL
{
    internal class DataAccessLayerMarks
    {
        private readonly StudentsDbContext ctx;
        public DataAccessLayerMarks(StudentsDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void GradeStudent(int studentId, int gradeValue, int subjectId)
        {
            if(ctx.Students.Any(s=> s.Id != studentId))
            {
                //throw exepction no student with id
            }
            if(ctx.Subjects.Any(s=> s.Id != subjectId))
            {
                //throw exeption no such subject for this student
            }
            ctx.Marks.Add(new Mark { Value = gradeValue, SubjectId = subjectId, StudentId = studentId, DataAndTime = DateTime.Now });
            ctx.SaveChanges();
        }
        public List<bool> GetAllMarksForAStudent(int studentId)
        {
            if(ctx.Students.Any(s=>s.Id != studentId)) 
            {
                //throw exep invalid student
            }
            if(!ctx.Marks.Any(m=> m.StudentId == studentId))
            {
                //throw exep no marks
            }
            return ctx.Marks.Select(m => m.StudentId == studentId).ToList();
            
            
        }
        public List<bool> GetAllMarksForASubject(int studentId, int subjectId) 
        {
            if (ctx.Students.Any(s => s.Id != studentId))
            {
                //throw exep invalid student
            }
            if(ctx.Subjects.Any(s=> s.Id != subjectId))
            {
                //throw ex no subject
            }
            if (!ctx.Marks.Any(m => m.StudentId == studentId))
            {
                //throw exep no marks
            }
            return ctx.Marks.Where(s=> s.SubjectId == subjectId).Select(m => m.StudentId == studentId).ToList();
        }
    }
}

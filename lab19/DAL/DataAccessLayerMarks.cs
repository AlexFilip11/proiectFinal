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
                throw new InvalidIdException($"invalid student id {studentId}");
            }
            if(ctx.Subjects.Any(s=> s.Id != subjectId))
            {
                throw new InvalidIdException($"invalid subject id {subjectId}");
            }
            ctx.Marks.Add(new Mark { Value = gradeValue, SubjectId = subjectId, StudentId = studentId, DataAndTime = DateTime.Now });
            ctx.SaveChanges();
        }
        public List<bool> GetAllMarksForAStudent(int studentId)
        {
            if(ctx.Students.Any(s=>s.Id != studentId)) 
            {
                throw new InvalidIdException($"invalid student id {studentId}");
            }
            if(!ctx.Marks.Any(m=> m.StudentId == studentId))
            {
                throw new InvalidIdException($"invalid no marks for student id {studentId}");
            }
            return ctx.Marks.Select(m => m.StudentId == studentId).ToList();
            
            
        }
        public List<bool> GetAllMarksForASubject(int studentId, int subjectId) 
        {
            if (ctx.Students.Any(s => s.Id != studentId))
            {
                throw new InvalidIdException($"invalid student id {studentId}");
            }
            if(ctx.Subjects.Any(s=> s.Id != subjectId))
            {
                throw new InvalidIdException($"invalid subject id {subjectId}");
            }
            if (!ctx.Marks.Any(m => m.StudentId == studentId))
            {
                throw new InvalidIdException($"invalid no marks for student id {studentId}");
            }
            return ctx.Marks.Where(s=> s.SubjectId == subjectId).Select(m => m.StudentId == studentId).ToList();
        }
        public List<string> GetAverageGradeForAStudent(int studentId)
        {
            List<string> averages = new List<string>();
            if (!ctx.Students.Any(s => s.Id == studentId))
            {
                throw new InvalidIdException($"invalid student id {studentId}");
            }
            if(!ctx.Subjects.Any(s=> s.StudentId == studentId))
            {
                throw new InvalidIdException($"invalid no subject for student id {studentId}");
            }
            if (!ctx.Marks.Where(s => s.StudentId == studentId).Any())
            {
                throw new InvalidIdException($"invalid no marks for student id {studentId}");
            }
            foreach (var subject in ctx.Subjects.Where(s=> s.StudentId == studentId).Distinct())
            {
                var average = 0;
                var count = 0;
                foreach (var mark in ctx.Marks.Where(s => s.SubjectId == subject.Id))
                {
                    average += mark.Value;
                    count++;
                }
                averages.Add( $"{ctx.Students.Where(s=> s.Id == studentId).Single()} +{subject.Name.Single()} +{average / count} /n");
            }
            return averages;
        }
       /* public List<string> GetAllStudentsOrderedByGrades()
        {
            List<string> averages = new List<string>();
            foreach(var student in ctx.Students.Average(s=> s.Marks.AddRange())
            {
                student.Marks.Average(m => m.StudentId);
            }
        }*/

    }
}

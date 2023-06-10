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
    internal class DataAccessLayerStudents : IDataAccessLayerService
    {
        private readonly StudentsDbContext ctx;
        public DataAccessLayerStudents(StudentsDbContext ctx) 
        {
            this.ctx = ctx;
        }

        public IEnumerable<Student> GetAllStudents() => ctx.Students.ToList();
       
        public Student GetStudentByStudentId(int studentId)
        {
            try
            {
                var student = ctx.Students.Single(s => s.Id == studentId);
                return student;
            }
            catch (Exception ex)
            {
                throw new InvalidIdException($"invalid no student id {studentId}");
            }
        }
        public void CreateStudent(Student newStudent)
        {
            var student = new Student{Name = newStudent.Name, Surname = newStudent.Surname, Age=newStudent.Age};
            ctx.Students.Add(student);
            ctx.SaveChanges();
        }

        public void DeleteStudent(int studentId) 
        { 
            var student = ctx.Students.Single(s => s.Id == studentId);
            if(student.Address!= null) 
            {
                ctx.Addresses.Remove(student.Address);
            }
            if(student.Marks!= null) 
            {
                ctx.Marks.RemoveRange(student.Marks);
            }
            ctx.Students.Remove(student);
            ctx.SaveChanges();
        }
        public void UpdateStudent(Student studentToUpdate)
        {
            var student = ctx.Students.Single(s => s.Id == studentToUpdate.Id);
            student.Name = studentToUpdate.Name;
            student.Surname = studentToUpdate.Surname;
            student.Age = studentToUpdate.Age;
            ctx.SaveChanges();

        }
        public void UpdateOrCreateStudentAddress(int studentId, Address newAddress)
        {
            var student = ctx.Students.Include(s=> s.Address).Single(s => s.Id == studentId);
            if(student.Address==null)
            {
                student.Address = new Address();
            }
            student.Address.City= newAddress.City;
            student.Address.Street = newAddress.Street;
            student.Address.Number = newAddress.Number;
            ctx.SaveChanges();
        }
        
    }
}

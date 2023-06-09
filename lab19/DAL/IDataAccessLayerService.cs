using proiectFinal.Database_Classes;
using proiectFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectFinal.DAL
{
    public interface IDataAccessLayerService
    {
        void CreateStudent(Student student);
        void DeleteStudent(int studentId);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentByStudentId(int studentId);
        void UpdateOrCreateStudentAddress (int studentId, Address newAddress);
        void UpdateStudent(Student studentToUpdate);
        
    }
}

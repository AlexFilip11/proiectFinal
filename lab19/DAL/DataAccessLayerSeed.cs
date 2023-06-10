using proiectFinal.Database_Classes;
using proiectFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectFinal.DAL
{
    internal class DataAccessLayerSeed
    {
        public void Seed()
        {
            using var ctx = new StudentsDbContext();
            var MsPop = new Teacher { Name = "Ms. Pop", Rank = Rank.Assistant, Address = new Address {City = "Oradea", Street="Iuliu Maniu", Number = 3 } };
            ctx.Add(MsPop);
            var MrVoicu = new Teacher { Name = "Mr. Voicu", Rank = Rank.Professor, Address = new Address { City = "Oradea", Street = "Pascal", Number = 30 } };
            ctx.Add(MrVoicu);
            var maths = new Subject { Name = "Maths", Teacher = new List<Teacher>() { MsPop, MrVoicu } };
            ctx.Add(maths);
            var MsVlaicu = new Teacher { Name = "Ms. Vlaicu", Rank = Rank.Associate, Address = new Address { City = "Marghita", Street = "1 Decembrie", Number = 17 } };
            ctx.Add(MsVlaicu);
            var English = new Subject { Name = "English", Teacher = new List<Teacher>() { MsVlaicu, MsPop } };
            ctx.Add(English);
            var MrCiupe = new Teacher { Name = "Mr. Ciupe", Rank = Rank.Instructor, Address = new Address { City = "Alesd", Street = "Republicii", Number = 81 } };
            ctx.Add(MrCiupe);
            var PE = new Subject { Name = "Physical Education", Teacher = new List<Teacher>() { MrCiupe} };
            ctx.Add(PE);
            var Literature = new Subject { Name = "Literature", Teacher = new List<Teacher>() { MsVlaicu } };
            ctx.Add(Literature);
            ctx.Add(new Student
            {
                Name = "Alex",
                Surname = "Filip",
                Age = 23,
                Address = new Address { City = "Marghita", Street = "Ierului", Number = 8 },
                Marks = new List<Mark>()
                { new Mark { Value = 10, DataAndTime = DateTime.Now, Subject = maths, Teacher=MsPop }, new Mark{Value = 9, DataAndTime= DateTime.Today, Subject = English, Teacher=MsVlaicu} }
            });
            ctx.Add(new Student
            {
                Name = "Alexandra",
                Surname = "Pop",
                Age = 20,
                Address = new Address { City = "Cluj", Street = "Republicii", Number = 13 },
                Marks = new List<Mark>()
                { new Mark { Value = 10, DataAndTime = DateTime.Now, Subject = PE, Teacher=MrCiupe }, new Mark{Value = 8, DataAndTime= DateTime.Today, Subject = Literature, Teacher=MsVlaicu} }
            });
            ctx.Add(new Student
            {
                Name = "Denis",
                Surname = "Farcas",
                Age = 21,
                Address = new Address { City = "Oradea", Street = "Cantemir", Number = 32 },
                Marks = new List<Mark>()
                { new Mark { Value = 6, DataAndTime = DateTime.Now, Subject = maths, Teacher=MsPop }, new Mark{Value = 9, DataAndTime= DateTime.Today, Subject = PE, Teacher=MrCiupe} }
            });
            ctx.Add(new Student
            {
                Name = "Dorel",
                Surname = "Manciu",
                Age = 24,
                Address = new Address { City = "Alesd", Street = "Principala", Number = 2 },
                Marks = new List<Mark>()
                { new Mark { Value = 10, DataAndTime = DateTime.Now, Subject = Literature, Teacher=MsVlaicu }, new Mark{Value = 4, DataAndTime= DateTime.Today, Subject = maths, Teacher=MrVoicu} }
            });
            ctx.Add(new Student
            {
                Name = "Diana",
                Surname = "Alb",
                Age = 22,
                Address = new Address { City = "Oradea", Street = "Mihai Eminescu", Number = 14 },
                Marks = new List<Mark>()
                { new Mark { Value = 10, DataAndTime = DateTime.Now, Subject = maths, Teacher=MrVoicu }, new Mark{Value = 10, DataAndTime= DateTime.Today, Subject = PE, Teacher=MrCiupe} }
            });
            ctx.SaveChanges();
        }
    }
}

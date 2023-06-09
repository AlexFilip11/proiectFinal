// See https://aka.ms/new-console-template for more information
using proiectFinal.Database_Classes;
using proiectFinal.Models;
using proiectFinal.DAL;

Seed();
Student x = null;
DataAccessLayerStudents dal = new DataAccessLayerStudents(new StudentsDbContext());
dal.CreateStudent(x);

void Seed()
{
    using var ctx = new StudentsDbContext();

    var address1 = new Address
    {
        City = "Oradea",
        Street = "Pascal",
        Number = 20
    };
    ctx.Add(address1);
    var student1 = new Student
    {
        Name = "Alex",
        Surname = "Filip",
        Age = 23,
        Address = address1,
    };
    ctx.Add(student1);

    ctx.Add(new Student
    {
        Name = "X",
        Surname = "Y",
        Age = 20,
        Address = new Address { City = "cluj", Street = "z", Number = 15 },
    });

    ctx.SaveChanges();
}
        


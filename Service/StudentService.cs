using Lesson_10___Homework.Database;
using Lesson_10___Homework.Models;
using Lesson_10___Homework.Service.Interface;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Lesson_10___Homework.Service;

internal class StudentService : IStudentService
{
    private readonly DB _db;
    public StudentService()
    {
        _db = new DB();
    }

    public void Add(Student student)
    {
        _db.Students.Add(student);
    }

    public void AddAll(params Student[] students)
    {
        foreach (var item in students)
            Add(item);
    }

    public void PrintAllFullnames()
    {
        Func<Student, string> tempFunc = GetFullname;
        _db.Students.Select(tempFunc).ToList().ForEach(x => Console.WriteLine(x));
        //_db.Students.Select(GetFullname).ToList().ForEach(x => Console.WriteLine(x));
    }

    public List<Student> GetStudentsOlderThan18()
    {
        Predicate<int> olderThan18 = isOlderThan18;
        return _db.Students.Where(s => olderThan18(s.Age)).ToList();
    }

    public void PrintAllStudents()
    {
        Action<Student> myAct = Print;
        _db.Students.ForEach(myAct);
        _db.Students.ForEach(Print);
    }

    public List<Student> SortByAge()
    {
        return _db.Students.OrderBy(s => s.Age).ToList();
    }

    /////////////////////////////////////////////////////////////////////

    private string GetFullname(Student std)
    {
        return std.Fullname();
    }

    private bool isOlderThan18(int age)
    {
        return age > 18;
    }

    private void Print(Student s)
    {
        //Bu sekilde bir metodu normalda Student class-nin icinde yaziram
        //Lakin Action istifade etmek ucun burada yazdim
        Console.WriteLine(
            $"{s.ID} / " +
            $"{s.Name} / " +
            $"{s.Surname} / " +
            $"{s.Age}"
            );
    }

}

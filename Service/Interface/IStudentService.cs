using Lesson_10___Homework.Models;

namespace Lesson_10___Homework.Service.Interface;

internal interface IStudentService
{
    void Add(Student student);
    void AddAll(params Student[] students);
    void PrintAllFullnames();
    List<Student> GetStudentsOlderThan18();
    void PrintAllStudents();
    List<Student> SortByAge();
}

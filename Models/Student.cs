namespace Lesson_10___Homework.Models;

internal class Student
{
    public int ID { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; } = 0;

    public string Fullname() => $"{Name} {Surname}";

    
}

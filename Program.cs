using Lesson_10___Homework.Models;
using Lesson_10___Homework.Service;

StudentService studentService = new();

Student std3 = new() { ID = 3, Name = "Sanan 3", Surname = "Gambarov 3", Age = 20 };
Student std1 = new() { ID = 1, Name = "Sanan 1", Surname = "Gambarov 1", Age = 10 };
Student std2 = new() { ID = 2, Name = "Sanan 2", Surname = "Gambarov 2", Age = 15 };
Student std6 = new() { ID = 3, Name = "Sanan 6", Surname = "Gambarov 6", Age = 35 };
Student std4 = new() { ID = 3, Name = "Sanan 4", Surname = "Gambarov 4", Age = 25 };
Student std5 = new() { ID = 3, Name = "Sanan 5", Surname = "Gambarov 5", Age = 30 };

//Teleberlin database-e elave olunmasi
studentService.AddAll(std3, std1, std2, std6, std4, std5);
Console.WriteLine("Students created and added");
Thread.Sleep(500);

//Print All
Console.WriteLine("\nAll Students (Fullnames)");
studentService.PrintAllFullnames();
Thread.Sleep(500);

//18 den yuxari olanlari cixardir
Console.WriteLine("\nStudents age older than 18");
studentService.GetStudentsOlderThan18().ForEach(x => Console.WriteLine(x.Fullname()));
Thread.Sleep(500);

//Butun telebeler
Console.WriteLine("\nAll Students Infos");
studentService.PrintAllStudents();
Thread.Sleep(500);

//Yasa gore siralama
Console.WriteLine("\nSort by Age");
studentService.SortByAge().ForEach(x => Console.WriteLine(x.Fullname()));
Thread.Sleep(500);
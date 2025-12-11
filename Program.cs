class Program
{
    static void Main(string[] args)
    {
        try
        {
            PersonService personService = new PersonService();
            personService.Add(new Person()
            {
                ID = 1,
                Fullname = "Sanan Gambarov",
                Age = 18
            });
            Console.WriteLine("Complete");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

class PersonDB
{
    public List<Person> Persons = new List<Person>();
}

class Person
{
    public int ID { get; set; }
    public string Fullname { get; set; }
    public int Age { get; set; }
}

class PersonService
{
    private readonly PersonDB? personDb = null;
    private delegate bool PersonChecker(Person p);
    private PersonChecker? personChecker = null;

    public PersonService()
    {
        personDb = new PersonDB();

        personChecker = isAgeAcceptable;
        personChecker += isFullnameLengthAcceptable;
        personChecker += isIDAcceptable;
    }

    public void Add(Person person)
    {
        bool result;
        foreach (PersonChecker func in personChecker.GetInvocationList())
        {
            result = func.Invoke(person);
            if (result) throw new Exception("Wrong");
        }

        personDb.Persons.Add(person);
    }

    private bool isIDAcceptable(Person p) => p.ID <= 0;
    private bool isAgeAcceptable(Person p) => p.Age < 18;
    private bool isFullnameLengthAcceptable(Person p) => p.Fullname.Length > 20;
}



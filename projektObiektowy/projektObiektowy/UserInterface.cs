namespace projektObiektowy;

public class UserInterface
{
    public string Id { get; protected set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public UserInterface(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
}

public class Student : UserInterface, IBorrower
{
    private static int _idCounter;
    public string Major { get; set; }
    public string Degree { get; set; }
    public int RentalLimit => 2;

    public Student(string name, string surname, string major, string degree)
        : base(name, surname)
    {
        _idCounter++;
        Id = "s" + _idCounter;
        Major = major;
        Degree = degree;
    }
}

public class Employee : UserInterface, IBorrower
{
    private static int _idCounter;
    public string Degree { get; set; }
    public string Chair { get; set; }
    public int RentalLimit => 5;

    public Employee(string name, string surname, string degree, string chair)
        : base(name, surname)
    {
        _idCounter++;
        Id = "e" + _idCounter;
        Degree = degree;
        Chair = chair;
    }
}
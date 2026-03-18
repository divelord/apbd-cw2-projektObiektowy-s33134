namespace projektObiektowy;

public class UserInterface
{
    private static int _idCounter;

    public int Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserType { get; set; }
    
    public UserInterface(string name, string surname, string userType)
    {
        _idCounter++;
        Id = _idCounter;
        Name = name;
        Surname = surname;
        UserType = userType;
    }
}
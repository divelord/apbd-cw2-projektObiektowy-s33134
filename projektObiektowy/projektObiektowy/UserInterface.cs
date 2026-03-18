namespace projektObiektowy;

public class UserInterface
{
    private int id;
    private String name;
    private String surname;
    private String userType;

    public UserInterface(String name, String surname, String userType)
    {
        this.name = name;
        this.surname = surname;
        this.userType = userType;
    }
    
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Surname
    {
        get => surname;
        set => surname = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string UserType
    {
        get => userType;
        set => userType = value ?? throw new ArgumentNullException(nameof(value));
    }
}
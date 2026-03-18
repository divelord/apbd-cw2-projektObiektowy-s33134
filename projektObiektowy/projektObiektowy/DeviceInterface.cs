namespace projektObiektowy;

public class DeviceInterface
{
    private int id;
    private String name;
    private Availability availability;
    
    public DeviceInterface(String name, Availability availability)
    {
        this.name = name;
        this.availability = availability;
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Availability Availability
    {
        get => availability;
        set => availability = value;
    }
}
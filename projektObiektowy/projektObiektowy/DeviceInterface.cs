namespace projektObiektowy;

public class DeviceInterface
{
    private static int _idCounter;
    
    public int Id { get; private set; }
    public string Name { get; set; }

    public Availability Availability { get; set; }
    
    public DeviceInterface(string name, Availability availability)
    {
        _idCounter++;
        Id = _idCounter;
        Name = name;
        Availability = availability;
    }
}
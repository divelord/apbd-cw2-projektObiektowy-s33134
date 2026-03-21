namespace projektObiektowy;

public class DeviceInterface
{
    private static int _idCounter;
    public string Id { get; private set; }
    public string Name { get; set; }
    public Availability Availability { get; set; }

    public DeviceInterface(string name, Availability availability)
    {
        _idCounter++;
        Id = "d" + _idCounter;
        Name = name;
        Availability = availability;
    }
}

public class Laptop : DeviceInterface
{
    public string OperatingSystem { get; set; }
    public string Processor { get; set; }

    public Laptop(string name, Availability availability, string operatingSystem, string processor)
        : base(name, availability)
    {
        OperatingSystem = operatingSystem;
        Processor = processor;
    }
}

public class Projector : DeviceInterface
{
    public int Brightness { get; set; }
    public string Resolution { get; set; }

    public Projector(string name, Availability availability, int brightness, string resolution)
        : base(name, availability)
    {
        Brightness = brightness;
        Resolution = resolution;
    }
}

public class Camera : DeviceInterface
{
    public string Sensor { get; set; }
    public string Lens { get; set; }

    public Camera(string name, Availability availability, string sensor, string lens)
        : base(name, availability)
    {
        Sensor = sensor;
        Lens = lens;
    }
}
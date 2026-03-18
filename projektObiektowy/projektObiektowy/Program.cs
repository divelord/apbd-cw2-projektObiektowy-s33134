using projektObiektowy;

namespace MyNamespace;

class Program
{
    static void Main(string[] args)
    {
        UserInterface student = new UserInterface("Jan", "Kowalski", "student");
        UserInterface employee = new UserInterface("Maciek", "Nowak", "employee");
        
        DeviceInterface laptop = new DeviceInterface("Laptop", Availability.Available);
        DeviceInterface projector = new DeviceInterface("Projector", Availability.Available);
        DeviceInterface camera = new DeviceInterface("Camera", Availability.Available);
        
        Console.WriteLine(student.Name + " " + student.Surname + ", user type: " + student.UserType);
        Console.WriteLine(employee.Name + " " + employee.Surname + ", user type: " + employee.UserType);
        Console.WriteLine("Device " + laptop.Name + " is " + laptop.Availability);
        Console.WriteLine("Device " + projector.Name + " is " + projector.Availability);
        Console.WriteLine("Device " + camera.Name + " is " + camera.Availability);
    }
}

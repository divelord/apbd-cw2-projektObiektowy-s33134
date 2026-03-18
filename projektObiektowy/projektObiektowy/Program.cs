namespace projektObiektowy;

class Program
{
    static void Main(string[] args)
    {
        UserInterface student = new UserInterface("Jan", "Kowalski", "student");
        UserInterface employee = new UserInterface("Maciek", "Nowak", "employee");
        
        DeviceInterface laptop = new DeviceInterface("Laptop", Availability.Available);
        DeviceInterface projector = new DeviceInterface("Projector", Availability.Available);
        DeviceInterface camera = new DeviceInterface("Camera", Availability.Available);
        
        Console.WriteLine($"{student.Name} {student.Surname}, user type: {student.UserType} with id: {student.Id}");
        Console.WriteLine($"{employee.Name} {employee.Surname}, user type: {employee.UserType} with id: {employee.Id}");
        Console.WriteLine($"Device {laptop.Name} is {laptop.Availability} with id: {laptop.Id}");
        Console.WriteLine($"Device {projector.Name} is  {projector.Availability} with id: {projector.Id}");
        Console.WriteLine($"Device {camera.Name} is {camera.Availability} with id: {camera.Id}");
    }
}

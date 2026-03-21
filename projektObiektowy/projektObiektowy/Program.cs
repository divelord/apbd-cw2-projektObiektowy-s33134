namespace projektObiektowy;

class Program
{
    static void Main(string[] args)
    {
        Student student01 = new Student("Grzegorz", "Abacki", "IT", "magisterka");
        Student student02 = new Student("Marcin", "Babacki", "SNM", "inżynierka");
        Employee employee01 = new Employee("Tomasz", "Cabacki", "dr inż.", "Bazy danych");
        Employee employee02 = new Employee("Adam", "Dabacki", "prof. dr hab.", "Sieci komputerowe");
        Employee employee03 = new Employee("Krzysztof", "Ebacki", "dr hab.", "Inżynieria oprogramowania");
        Console.WriteLine($"Student o ID: {student01.Id} {student01.Name} {student01.Surname} studiuje {student01.Major} na {student01.Degree}");
        Console.WriteLine($"Student o ID: {student02.Id} {student02.Name} {student02.Surname} studiuje {student02.Major} na {student02.Degree}");
        Console.WriteLine($"Pracownik o ID: {employee01.Id} {employee01.Name} {employee01.Surname} ma tytuł {employee01.Degree} i jest związany z katedrą {employee01.Chair}");
        Console.WriteLine($"Pracownik o ID: {employee02.Id} {employee02.Name} {employee02.Surname} ma tytuł {employee02.Degree} i jest związany z katedrą {employee02.Chair}");
        Console.WriteLine($"Pracownik o ID: {employee03.Id} {employee03.Name} {employee03.Surname} ma tytuł {employee03.Degree} i jest związany z katedrą {employee03.Chair}");
        
        Laptop laptop01 = new Laptop("Laptop", Availability.Available, "Windows 11", "Intel i7");
        Projector projector01 = new Projector("Projector", Availability.Available, 3000, "1920x1080");
        Camera camera01 = new Camera("Camera", Availability.Available, "APS-C", "Zoom lenses");

        Console.WriteLine($"Urządzenie o ID: {laptop01.Id} {laptop01.Name} z parametrami: {laptop01.OperatingSystem}, {laptop01.Processor} jest {laptop01.Availability}");
        Console.WriteLine($"Urządzenie o ID: {projector01.Id} {projector01.Name} z parametrami: {projector01.Brightness}, {projector01.Resolution} jest {projector01.Availability}");
        Console.WriteLine($"Urządzenie o ID: {camera01.Id} {camera01.Name} z parametrami: {camera01.Sensor}, {camera01.Lens} jest {camera01.Availability}");
        
        Rental rental01 = new Rental(student01, laptop01, 14);
        Console.WriteLine($"Urządzenie o ID: {laptop01.Id} {laptop01.Name} z parametrami: {laptop01.OperatingSystem}, {laptop01.Processor} jest {laptop01.Availability}");
        Console.WriteLine($"Urządzenie {rental01.LendedDevice.Name} wypożyczono {rental01.Borrower.Name} {rental01.Borrower.Surname} w dniu {rental01.RentalDate.ToShortDateString()} do dnia {rental01.DueDate.ToShortDateString()}");
        
        Console.WriteLine($"Czy urządzenie oddano: {rental01.IsReturned} {rental01.ReturnDate?.ToShortDateString()}");
        rental01.ReturnDate = DateTime.Now;
        rental01.LendedDevice.Availability = Availability.Available;
        Console.WriteLine($"Czy urządzenie oddano: {rental01.IsReturned} {rental01.ReturnDate?.ToShortDateString()}");
    }
}

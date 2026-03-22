namespace projektObiektowy;

class Program
{
    static void Main(string[] args)
    {
        RentalService rentalService = new RentalService();
        List<DeviceInterface> allDevices = new List<DeviceInterface>();
        
        // dodanie użytkowników do systemu
        
        Student student01 = new Student("Grzegorz", "Abacki", "IT", "magisterka");
        Student student02 = new Student("Marcin", "Babacki", "SNM", "inżynierka");
        Employee employee01 = new Employee("Tomasz", "Cabacki", "dr inż.", "Bazy danych");
        Employee employee02 = new Employee("Adam", "Dabacki", "prof. dr hab.", "Sieci komputerowe");
        Employee employee03 = new Employee("Krzysztof", "Ebacki", "dr hab.", "Inżynieria oprogramowania");

        // dodanie sprzętu do systemu
        
        for (int i = 1; i <= 10; i++)
        {
            allDevices.Add(new Laptop($"laptop{i}", Availability.Available, "Windows 11", $"Intel i{i}"));
            allDevices.Add(new Projector($"Projector{i}", Availability.Available, 2000 + 100 * i, "1920x1080"));
            allDevices.Add(new Camera($"Camera{i}", Availability.Available, "APS-C", $"{10 * i}mm lenses"));
        }
        
        // wyświetlenie listy całego sprzętu z aktualnym statusem
        rentalService.ShowAllDevices(allDevices);
        
        // wyświetlenie listy sprzętu dostępnego do wypożyczenia
        rentalService.ShowAvailableDevices(allDevices);
        
        // wypożyczanie sprzętu użytkownikowi
        
        rentalService.RentDevice(student01, allDevices[0], 7);
        rentalService.RentDevice(student02, allDevices[1], 14);
        rentalService.RentDevice(employee01, allDevices[0], 2);
        
        // oznaczenie sprzętu jako niedostępnego
        
        rentalService.MarkasUnderMaintenance(allDevices[10], "Usterka");
        
        rentalService.ShowAllDevices(allDevices);
        
        // lista aktywnych wypożyczeń użytkownika
        
        rentalService.ShowActiveDevices(student01);
        
        // lista przeterminowanych wypożyczeń
        
        rentalService.ShowOverdueDevices();
        
        // oddanie sprzętu

        var addDays = rentalService.Rentals.FirstOrDefault(r => r.LendedDevice == allDevices[0]);
        addDays?.DueDate = DateTime.Now.AddDays(-3);
        rentalService.ReturnDevice(allDevices[0]);
        rentalService.ReturnDevice(allDevices[1]);
        
        // wygenerowanie krótkiego raportu
        
        rentalService.ShowRentalReport(allDevices);
    }
}

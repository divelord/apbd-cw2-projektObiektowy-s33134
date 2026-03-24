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
            allDevices.Add(new Laptop($"Laptop{i}", Availability.Available, "Windows 11", $"Intel i{i}"));
            allDevices.Add(new Projector($"Projector{i}", Availability.Available, 2000 + 100 * i, "1920x1080"));
            allDevices.Add(new Camera($"Camera{i}", Availability.Available, "APS-C", $"{10 * i}mm lenses"));
        }
        
        // wyświetlenie listy całego sprzętu z aktualnym statusem
        
        rentalService.ShowAllDevices(allDevices);
        Console.WriteLine();
        
        // wyświetlenie listy sprzętu dostępnego do wypożyczenia
        
        rentalService.ShowAvailableDevices(allDevices);
        Console.WriteLine();
        
        // wypożyczanie sprzętu użytkownikowi

        // do limitu studentów
        rentalService.RentDevice(student01, allDevices[0], 7);
        rentalService.RentDevice(student01, allDevices[1], 14);
        rentalService.RentDevice(student01, allDevices[2], 14); // nie powiedzie się
        Console.WriteLine();

        // do limitu pracowników
        rentalService.RentDevice(employee01, allDevices[3], 1);
        rentalService.RentDevice(employee01, allDevices[4], 3);
        rentalService.RentDevice(employee01, allDevices[5], 4);
        rentalService.RentDevice(employee01, allDevices[6], 3);
        rentalService.RentDevice(employee01, allDevices[7], 5);
        rentalService.RentDevice(employee01, allDevices[8], 7); // nie powiedzie się
        Console.WriteLine();

        // oznaczenie sprzętu jako niedostępnego
        
        rentalService.MarkAsUnderMaintenance(allDevices[10], "Wypalona lampa");
        rentalService.MarkAsUnderMaintenance(allDevices[15], "Uszkodzona matryca");
        rentalService.MarkAsUnderMaintenance(allDevices[20], "Uszkodzone gniazdo karty SD");
        Console.WriteLine();
        
        // ukończenie serwisu
        
        rentalService.FinishMaintenance(allDevices[20]);
        Console.WriteLine();
        
        rentalService.FinishMaintenance(allDevices[25]);
        Console.WriteLine();
        
        // pokazanie dostępności urządzeń po zmianach
        
        rentalService.ShowAllDevices(allDevices);
        Console.WriteLine();
        
        // wypożyczanie sprzętu niedostępnego
        
        rentalService.RentDevice(student02, allDevices[0], 1); // wypożyczone
        rentalService.RentDevice(employee02, allDevices[3], 3); // wypożyczone
        rentalService.RentDevice(employee03, allDevices[10], 3); // w trakcie serwisu
        Console.WriteLine();
        
        // oddanie kilku sprzętów
        
        // zwrot na czas
        rentalService.ReturnDevice(allDevices[0]);
        rentalService.ReturnDevice(allDevices[3]);
        Console.WriteLine();
        
        // zwrot po terminie
        var addDays = rentalService.Rentals.FirstOrDefault(r => r.LendedDevice == allDevices[1]);
        addDays?.DueDate = DateTime.Now.AddDays(-3);
        rentalService.ReturnDevice(allDevices[1]);
        Console.WriteLine();
        
        // niewypożyczonego sprzętu
        rentalService.ReturnDevice(allDevices[21]);
        Console.WriteLine();
        
        // lista aktywnych wypożyczeń użytkownika
        
        rentalService.ShowActiveDevices(student01);
        Console.WriteLine();

        rentalService.ShowActiveDevices(employee01);
        Console.WriteLine();
        
        // lista przeterminowanych wypożyczeń

        addDays = rentalService.Rentals.FirstOrDefault(r => r.LendedDevice == allDevices[7]);
        addDays?.DueDate = DateTime.Now.AddDays(-5);

        rentalService.ShowOverdueDevices();
        Console.WriteLine();

        // wygenerowanie krótkiego raportu

        rentalService.ShowRentalReport(allDevices);
        Console.WriteLine();
    }
}

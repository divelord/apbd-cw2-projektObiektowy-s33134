namespace projektObiektowy;

public class RentalService
{
    private double _totalPenalty = 0.0;
    private const int StudentLimit = 2;
    private const int EmployeeLimit = 5;
    private const double DailyPenalty = 5.0;
    private List<Rental> _rentals = new List<Rental>();
    public List<Rental> Rentals => _rentals;

    public void RentDevice(UserInterface user, DeviceInterface device, int days)
    {
        if (device.Availability == Availability.NotAvailable)
        {
            Console.WriteLine($"Urządzenie {device.Name} jest niedostępne");
            return;
        }

        if (device.Availability == Availability.UnderMaintenance)
        {
            Console.WriteLine($"Urządzenie {device.Name} jest w trakcie serwisu");
            return;
        }
        
        int countDevices = _rentals.Count(r => r.Borrower == user  && !r.IsReturned);
        int userLimit = (user is Student) ?  StudentLimit : EmployeeLimit;

        if (countDevices >= userLimit)
        {
            Console.WriteLine($"Użytkownik {user.Name} {user.Surname} przekroczył limit aktywnych wypożyczeń");
            return;
        }

        device.Availability = Availability.NotAvailable;
        Rental rental = new Rental(user, device, days);
        _rentals.Add(rental);

        Console.WriteLine($"Wypożyczono urządzenie: {device.Name} użytkownikowi {user.Name} {user.Surname} na {days} dni");
    }

    public void ReturnDevice(DeviceInterface device)
    {
        var rental = _rentals.FirstOrDefault(r => r.LendedDevice == device && !r.IsReturned);

        if (rental != null)
        {
            rental.ReturnDate = DateTime.Now;
            device.Availability = Availability.Available;

            double penalty = 0.0;

            if (!rental.ReturnedOnTime)
            {
                int daysDelayed = (rental.ReturnDate.Value - rental.DueDate).Days;

                penalty = daysDelayed * DailyPenalty;
                _totalPenalty += penalty;
            }
            
            string isOnTime = rental.ReturnedOnTime ? "w terminie" : "po terminie";
            string penaltyMsg = penalty > 0 ? $"naliczona kara {penalty}zł" : "";

            Console.WriteLine($"Urządzenie {device.Name} oddano {isOnTime} {penaltyMsg}");
        }
        else
        {
            Console.WriteLine("Nie znaleziono urządzenia do oddania");
        }
    }

    public void MarkAsUnderMaintenance(DeviceInterface device, string reason)
    {
        device.Availability = Availability.UnderMaintenance;
        Console.WriteLine($"Urządzenie [{device.Id}]{device.Name} jest w trakcie serwisu. Powód: {reason}");
    }

    public void FinishMaintenance(DeviceInterface device)
    {
        if (device.Availability == Availability.UnderMaintenance)
        {
            device.Availability = Availability.Available;
            Console.WriteLine($"Ukończono serwis urządzenia [{device.Id}]{device.Name}");
        }
        else
        {
            Console.WriteLine($"Urządzenie {device.Name} nie jest w trakcie serwisu");
        }
    }

    public void ShowAllDevices(List<DeviceInterface> devices)
    {
        Console.WriteLine("Wszystkie urządzenia:");
        foreach (var device in devices)
        {
            Console.WriteLine($" - [{device.Id}]{device.Name}, Dostępność: {device.Availability}");
        }
    }

    public void ShowAvailableDevices(List<DeviceInterface> devices)
    {
        Console.WriteLine("Urządzenia dostępne do wypożyczenia:");
        var availableDevices = devices.Where(d => d.Availability == Availability.Available).ToList();
        foreach (var device in availableDevices)
        {
            Console.WriteLine($" - [{device.Id}]{device.Name}");
        }
    }

    public void ShowActiveDevices(UserInterface user)
    {
        Console.WriteLine($"Wypożyczone urządzenia użytkownika {user.Name} {user.Surname}");
        
        var activeDevices = _rentals.Where(r => r.Borrower == user && !r.IsReturned).ToList();

        if (!activeDevices.Any())
        {
            Console.WriteLine("Brak wypożyczonych urządzeń");
        }
        else
        {
            foreach (var device in activeDevices)
            {
                Console.WriteLine($" - {device.LendedDevice.Name} Termin oddania: {device.DueDate.ToShortDateString()}");
            }
        }
    }

    public void ShowOverdueDevices()
    {
        Console.WriteLine("Lista przeterminowanych wypożyczeń");
        
        var devices = _rentals.Where(r => !r.ReturnedOnTime).ToList();

        if (!devices.Any())
        {
            Console.WriteLine("Brak przeterminowanych wypożyczeń");
        }
        else
        {
            foreach (var device in devices)
            {
                string status = device.IsReturned ? "oddał po terminie" : "nie oddał";
                
                Console.WriteLine($" - Użytkownik {device.Borrower.Name} {device.Borrower.Surname} {status} urządzenia {device.LendedDevice.Name}");
            }
        }
    }
    
    public void ShowRentalReport(List<DeviceInterface> devices)
    {
        Console.WriteLine("Raport dotyczący stanu wypożyczalni");
        
        int allRentals =  _rentals.Count;
        int returnedOnTime = _rentals.Count(r => r.ReturnedOnTime && r.IsReturned);
        int returnedNotOnTime = _rentals.Count(r => !r.ReturnedOnTime && r.IsReturned);
        
        var availableDevices = devices.Where(d => d.Availability == Availability.Available).ToList();
        int availableCount = availableDevices.Count;
        int notAvailableCount = devices.Count(d => d.Availability == Availability.NotAvailable);

        Console.WriteLine($"Liczba dostępnych urządzeń: {availableCount}");
        if (availableCount > 0)
        {
            foreach (var device in availableDevices)
            {
                Console.WriteLine($" - [{device.Id}]{device.Name}");
            }
        }
        Console.WriteLine($"Liczba niedostępnych urządzeń: {notAvailableCount}");
        Console.WriteLine($"Liczba wszyskich wypożyczeń: {allRentals}");
        Console.WriteLine($"Liczba urządzeń zwróconych na czas: {returnedOnTime}");
        Console.WriteLine($"Liczba urządzeń zwróconych po terminie: {returnedNotOnTime}");
        Console.WriteLine($"Suma wszystkich naliczonych kar: {_totalPenalty}zł");
    }
}
namespace projektObiektowy;

public class RentalService
{
    private List<Rental> _rentals = new List<Rental>();
    
    public List<Rental> Rentals => _rentals;

    public void RentDevice(UserInterface user, DeviceInterface device, int days)
    {
        if (device.Availability == Availability.NotAvailable)
        {
            Console.WriteLine($"Urządzenie {device.Name} jest niedostępne");
            return;
        }

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

                penalty = daysDelayed * 5;
            }
            
            string isOnTime = rental.ReturnedOnTime ? "w terminie" : "po terminie";
            string penaltyMsg = penalty > 0 ? $"naliczona kara {penalty}zł" : "";

            Console.WriteLine($"Urządzenie {device.Name} oddano {isOnTime} {penaltyMsg}");
        }
        else
        {
            Console.WriteLine($"Nie znaleziono urządzenia do oddania");
        }
    }

    public void MarkasUnderMaintenance(DeviceInterface device, string reason)
    {
        device.Availability = Availability.UnderMaintenance;
        Console.WriteLine($"Urządzenie [{device.Id}]{device.Name} jest w trakcie serwisu. Powód: {reason}");
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
        Console.WriteLine($"Liczba urządzeń zwróconych na czas: {returnedOnTime}");
        Console.WriteLine($"Liczba urządzeń zwróconych po terminie: {returnedNotOnTime}");
        Console.WriteLine($"Liczba wszyskich wypożyczeń: {allRentals}");
    }
}
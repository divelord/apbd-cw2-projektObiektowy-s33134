namespace projektObiektowy;

public class Rental
{
    public UserInterface Borrower { get; set; }
    public DeviceInterface LendedDevice { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public Rental(UserInterface borrower, DeviceInterface lendedDevice, int days)
    {
        Borrower = borrower;
        LendedDevice = lendedDevice;
        RentalDate = DateTime.Now;
        DueDate = DateTime.Now.AddDays(days);

        LendedDevice.Availability = Availability.NotAvailable;
    }

    public bool IsReturned => ReturnDate.HasValue;
}
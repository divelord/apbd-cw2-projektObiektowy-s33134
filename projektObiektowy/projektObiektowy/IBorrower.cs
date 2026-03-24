namespace projektObiektowy;

public interface IBorrower
{
    string Name { get; }
    string Surname { get; }
    int RentalLimit { get; }
}
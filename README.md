# apbd-cw2-projektObiektowy-s33134

## Drugie zadanie wykonane na ćwiczeniach z APBD

### Opis projektu

Prosta aplikacja konsolowa w C# symulująca wypożyczanie sprzętu.

### Decyzje projektowe

* Enum Availability: przechowywanie stanu dostępności urządzeń  
* IBorrower: interfejsc pomogający wprowadzenie limitu wypożyczeń
* DeviceInterface i UserInterface: klasy bazowe, od których dziedziczą klasy podrzędne
* Rental: klasa przechowująca dane wypożyczeń
* RentalService: klasa obsługująca logikę wypożyczeń

### Dlaczego taki podział:

Każda klasa odpowiada za osobną część aplikacji, co poprawia czytelność kodu oraz umożliwia i umożliwia łatwiejszą (potencjalną) rozbudowę aplikacji.

_Kohezja:_ Klasy dziedziczące (np. Laptop, Student)

_Coupling:_ IBorrower

_Solid:_ RentalService

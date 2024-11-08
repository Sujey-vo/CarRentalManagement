using System;

public class RentalViewModel
{
    public int RentalId { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
}

public class RentalController
{
    private readonly RentalService _rentalService;

    public RentalController()
    {
        _rentalService = new RentalService(new CarRentalRepository());
    }

    public void ShowAllRentals()
    {
        var rentals = _rentalService.GetAllRentals();

        Console.WriteLine("Historial de Alquileres:");
        foreach (var rental in rentals)
        {
            var rentalViewModel = new RentalViewModel
            {
                RentalId = rental.Id,
                Type = rental.Type.ToString(),
                Price = _rentalService.CalculateRentalPrice(rental)
            };

            Console.WriteLine("ID de Alquiler: {0}, Tipo de Auto: {1}, Precio Total: {2}", 
                              rentalViewModel.RentalId, rentalViewModel.Type, rentalViewModel.Price);
        }
    }

    public void ShowSampleRental()
    {
        var rental = new Rental
        {
            Id = 1,
            Type = CarType.SUV,
            StartDate = DateTime.Today,
            EndDate = DateTime.Today.AddDays(10),
            DailyRate = 100
        };

        var rentalViewModel = new RentalViewModel
        {
            RentalId = rental.Id,
            Type = rental.Type.ToString(),
            Price = _rentalService.CalculateRentalPrice(rental)
        };

        Console.WriteLine("\nEjemplo de Reserva:");
        Console.WriteLine("ID de Alquiler: {0}", rentalViewModel.RentalId);
        Console.WriteLine("Tipo de Auto: {0}", rentalViewModel.Type);
        Console.WriteLine("Precio Total: {0}", rentalViewModel.Price);
    }
}

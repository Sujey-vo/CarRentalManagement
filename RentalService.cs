public class RentalService
{
    private readonly ICarRentalRepository _repository;

    public RentalService(ICarRentalRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Rental> GetAllRentals()
    {
        return _repository.GetAllRentals();
    }

    public decimal CalculateRentalPrice(Rental rental)
    {
        decimal basePrice = rental.DailyRate * rental.Days;
        decimal discount = ApplyDiscount(rental);
        return basePrice - discount;
    }

    private decimal ApplyDiscount(Rental rental)
    {
        return rental.Days > 7 ? 0.1m * rental.DailyRate * rental.Days : 0;
    }
}


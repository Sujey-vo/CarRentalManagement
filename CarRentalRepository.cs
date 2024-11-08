public interface ICarRentalRepository
{
    IEnumerable<Rental> GetAllRentals();
    Rental GetRentalById(int id);
    void SaveRental(Rental rental);
}

public class CarRentalRepository : ICarRentalRepository
{
    private readonly List<Rental> _rentals = new List<Rental>();

    public IEnumerable<Rental> GetAllRentals()
    {
        return _rentals;
    }

    public Rental GetRentalById(int id)
    {
        return _rentals.FirstOrDefault(r => r.Id == id);
    }

    public void SaveRental(Rental rental)
    {
        _rentals.Add(rental);
    }
}

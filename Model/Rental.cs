using System;
using System.Collections.Generic;
using System.Linq;

public enum CarType
{
    Sedan,
    SUV,
    Hatchback
}

public class Rental
{
    public int Id { get; set; }
    public CarType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DailyRate { get; set; }
    public int Days
    {
        get { return (EndDate - StartDate).Days; }
    }
}

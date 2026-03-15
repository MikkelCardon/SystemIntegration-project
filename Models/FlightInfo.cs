using System.ComponentModel.DataAnnotations;

namespace Models;

// Vi gør enumen public, så den kan bruges direkte som type i vores property.
// Det gør koden simplere, og EF Core/JSON kan sagtens håndtere det.
public enum FlightStatus
{
    OnTime,
    Delayed,
    Boarding,
    Departed,
    Cancelled
}

public class FlightInfo
{
    [Key]
    public string FlightNumber { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public string Gate { get; set; }

    // Ved at bruge enumen direkte, slipper vi for manuel validering i en setter.
    public FlightStatus Status { get; set; }

    public FlightInfo()
    {
    }

    public FlightInfo(string flightNumber, string destination, DateTime departureTime, string gate, FlightStatus status)
    {
        FlightNumber = flightNumber;
        Destination = destination;
        DepartureTime = departureTime;
        Gate = gate;
        Status = status;
    }
}
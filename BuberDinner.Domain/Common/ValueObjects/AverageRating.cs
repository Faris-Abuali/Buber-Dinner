using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public class AverageRating : ValueObject
{
    private AverageRating(float value, int numberOfRatings)
    {
        Value = value;
        NumberOfRatings = numberOfRatings;
    }

    public float Value { get; private set; }
    public int NumberOfRatings { get; private set; }
    
    public static AverageRating CreateNew(float rating = 0, int numberOfRatings = 0)
    {
        return new AverageRating(rating, numberOfRatings);
    }
    
    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumberOfRatings) + rating.Value) / ++NumberOfRatings;
    }
    
    internal void RemoveRating(Rating rating)
    {
        Value = ((Value * NumberOfRatings) - rating.Value) / --NumberOfRatings;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
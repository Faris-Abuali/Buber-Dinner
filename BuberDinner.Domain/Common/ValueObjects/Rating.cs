using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public class Rating : ValueObject
{
    private Rating(float value)
    {
        Value = value;
    }
    
    public float Value { get; private set; }
    
    
    public static Rating CreateNew(float rating = 0)
    {
        return new(rating);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
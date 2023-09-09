using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject
{
    public Guid Value { get; }
    
    private MenuReviewId(Guid id)
    {
        Value = id;
    }
    
    public static MenuReviewId CreateUnique()
    {
        return new (Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    #pragma warning disable CS8618
    private MenuReviewId()
    {
        // For EF Core
    }
    #pragma warning restore CS8618
}
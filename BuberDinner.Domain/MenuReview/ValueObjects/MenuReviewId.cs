using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject
{
    public Guid Id { get; }
    
    private MenuReviewId(Guid id)
    {
        Id = id;
    }
    
    public static MenuReviewId CreateUnique()
    {
        return new (Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
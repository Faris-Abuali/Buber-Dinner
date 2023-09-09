namespace BuberDinner.Domain.Common.Models;

// Two entities are equal when their IDs are equal
public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        Id = id;
    }
    
    // This implements Equatable interface
    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other); // simply call the below Equals() method
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> other && Id.Equals(other.Id);
        
        // `obj is Entity<TId> other`: This line checks if the `obj` parameter can be cast to an instance of the `Entity<TId>` class. If the cast is successful, it assigns the result to the `other` variable, which is of type `Entity<TId>`. This is essentially a type check and cast in one step.
    }
    
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }
    
    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }
    
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    
    #pragma warning disable CS8618
    protected Entity() { } // Required for EF Core
    #pragma warning restore CS8618
}
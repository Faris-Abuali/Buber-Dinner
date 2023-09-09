using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public class Dinner : AggregateRoot<DinnerId>
{
    protected Dinner(DinnerId id) : base(id)
    {
    }

    #pragma warning disable CS8618
        private Dinner() { } // Required for EF Core
    #pragma warning restore CS8618
}
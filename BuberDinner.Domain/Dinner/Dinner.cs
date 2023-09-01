using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public class Dinner : AggregateRoot<DinnerId>
{
    protected Dinner(DinnerId id) : base(id)
    {
    }
}
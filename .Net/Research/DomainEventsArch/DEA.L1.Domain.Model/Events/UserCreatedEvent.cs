using DEA.L1.Domain.Model.Entities;

namespace DEA.L1.Domain.Model.Events;

public class UserCreatedEvent : Event
{
    public UserCreatedEvent(User user)
    {
        User = user;
    }

    public User User { get; }
}

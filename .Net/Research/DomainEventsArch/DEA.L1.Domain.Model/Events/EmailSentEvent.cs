using DEA.L1.Domain.Model.Entities;

namespace DEA.L1.Domain.Model.Events;

public class EmailSentEvent : Event
{
    public EmailSentEvent(Email email, User user)
    {
        Email = email;
        User = user;
    }

    public Email Email { get; set; }
    public User User { get; }
}

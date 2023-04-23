using DEA.L1.Domain.Model.Events;
using MediatR;

namespace DEA.L2.ApplicationServices.EmailManager;

public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
{
    private readonly IEmailService _emailService;

    public UserCreatedEventHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public Task Handle(UserCreatedEvent e, CancellationToken cancellationToken)
    {
        _emailService.SendInvitation(e.User);

        return Task.CompletedTask;
    }
}

using DEA.L1.Domain.Model.Entities;
using DEA.L1.Domain.Model.Providers;
using MediatR;

namespace DEA.L3.Infrastructure.EmailProvider;

internal class EmailProvider : IEmailProvider
{
    private readonly IMediator _mediator;

    public EmailProvider(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Send(Email email)
    {
        foreach (var e in email.ReadEvents())
        {
            _mediator.Publish(e);
        }

        // external.Sent(email);
    }
}

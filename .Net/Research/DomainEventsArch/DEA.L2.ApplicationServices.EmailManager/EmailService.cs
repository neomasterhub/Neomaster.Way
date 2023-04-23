using DEA.L1.Domain.Model.Entities;
using DEA.L1.Domain.Model.Events;
using DEA.L1.Domain.Model.Providers;

namespace DEA.L2.ApplicationServices.EmailManager;

internal class EmailService : IEmailService
{
    private readonly IEmailProvider _emailProvider;

    public EmailService(IEmailProvider emailProvider)
    {
        _emailProvider = emailProvider;
    }

    public static Email CreateEmail(User user) => new()
    {
        To = user.Email,
        Subjct = "Invitation",
        Body = "Welcome!",
        From = "my@company.com",
    };

    public void SendInvitation(User user)
    {
        var email = CreateEmail(user);

        email.AddEvent(new EmailSentEvent(email, user));

        _emailProvider.Send(email);
    }
}

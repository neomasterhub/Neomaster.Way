using DEA.L1.Domain.Model.Entities;

namespace DEA.L2.ApplicationServices.EmailManager;

public interface IEmailService
{
    void SendInvitation(User user);
}

using DEA.L1.Domain.Model.Entities;

namespace DEA.L1.Domain.Model.Providers;

public interface IEmailProvider
{
    void Send(Email email);
}

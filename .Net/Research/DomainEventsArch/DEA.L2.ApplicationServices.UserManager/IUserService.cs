using DEA.L1.Domain.Model.Entities;

namespace DEA.L2.ApplicationServices.UserManager;

public interface IUserService
{
    void Save(User user);
}

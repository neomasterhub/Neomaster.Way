using DEA.L1.Domain.Model.Entities;
using DEA.L1.Domain.Model.Events;
using DEA.L1.Domain.Model.Repositories;

namespace DEA.L2.ApplicationServices.UserManager;

internal class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public void Save(User user)
    {
        user.AddEvent(new UserCreatedEvent(user));

        _userRepository.Save(user);
    }
}

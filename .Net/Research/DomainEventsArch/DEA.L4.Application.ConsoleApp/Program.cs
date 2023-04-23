using DEA.L1.Domain.Model.Entities;
using DEA.L2.ApplicationServices.Audit;
using DEA.L2.ApplicationServices.UserManager;
using DEA.L3.Infrastructure.DAL;
using DEA.L3.Infrastructure.EmailProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDAL();
        services.AddUserManager();
        services.AddAudit();
        services.AddEmailProvider();
    })
    .Build();

var userService = host.Services.GetRequiredService<IUserService>();

var user = new User { Email = "ivan@mail.ru" };

userService.Save(user);

/*
[ Entity save event ]
"User": {
  "Email": "ivan@mail.ru"
}

[ Audit event ]
"UserCreatedEvent": {
  "User": {
    "Email": "ivan@mail.ru"
  }
}

[ Audit event ]
"EmailSentEvent": {
  "Email": {
    "To": "ivan@mail.ru",
    "From": "my@company.com",
    "Subjct": "Invitation",
    "Body": "Welcome!"
  },
  "User": {
    "Email": "ivan@mail.ru"
  }
}
*/

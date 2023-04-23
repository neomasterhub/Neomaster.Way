using DEA.L0.PlatformExtension;
using DEA.L1.Domain.Model.Events;
using MediatR;

namespace DEA.L2.ApplicationServices.Audit;

public class AnyEventHandler<T> : INotificationHandler<T>
    where T : Event
{
    public Task Handle(T e, CancellationToken cancellationToken)
    {
        Logger.WriteLineObjectDescription("Audit event:", e);

        return Task.CompletedTask;
    }
}

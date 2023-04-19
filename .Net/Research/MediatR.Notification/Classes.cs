namespace MediatR.Notification;

public class Ping : INotification
{
}

public class Pong1 : INotificationHandler<Ping>
{
    public Task Handle(Ping notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Pong 1");

        return Task.CompletedTask;
    }
}

public class Pong2 : INotificationHandler<Ping>
{
    public Task Handle(Ping notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Pong 2");

        return Task.CompletedTask;
    }
}

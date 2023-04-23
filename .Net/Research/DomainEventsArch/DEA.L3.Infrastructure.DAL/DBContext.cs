using DEA.L0.PlatformExtension;
using DEA.L1.Domain.Model.Entities;
using MediatR;

namespace DEA.L3.Infrastructure.DAL;

internal class DBContext
{
    private readonly IMediator _mediator;

    public DBContext(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void SaveChanges(Observable entity)
    {
        Logger.WriteLineObjectDescription("Entity save event", entity);

        foreach (var e in entity.ReadEvents())
        {
            _mediator.Publish(e);
        }

        // base.SaveChanges();
    }
}

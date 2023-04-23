using DEA.L1.Domain.Model.Events;

namespace DEA.L1.Domain.Model.Entities;

public abstract class Observable
{
    private readonly Queue<Event> _events = new();

    public void AddEvent(Event e) => _events.Enqueue(e);

    public IEnumerable<Event> ReadEvents()
    {
        while (_events.Count > 0)
        {
            yield return _events.Dequeue();
        }
    }
}

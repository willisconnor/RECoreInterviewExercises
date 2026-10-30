namespace InterviewExercises.InMemoryEventBus;

public sealed class EventBus
{
    //making shared storage
    //Key: The event type (e.g typeOf(OrderPlace))
    //value: every handler subscribed to that type, in subscription order.
    //The value is Delegate, not Action<TEvent>, so one dictionary can hold
    //handlers for many different event types.
    private readonly Dictionary<Type, List<Delegate>> _handlers = new();
    //This registers a handler, and only stores it. Nothing runs until publish
    public void Subscribe<TEvent>(Action<TEvent> handler)
    {
        //look for an existing handler for this event type
        //if found, 'list' points to the list stored in the dictionary
        if(!_handlers.TryGetValue(typeof(TEvent), out var list))
        {
            //First subscriber for this type: create an empty list
            //and store it in the dictionary
            list = new List<Delegate>();
            _handlers[typeof(TEvent)] = list;
        }
        //'list' is the same object stored in the dictionary, so adding here updates
        //the storage directly. List keeps insertion order, e.g. subscription order
        list.Add(handler);
    }

    //Calls every hanbdler subscribed to this event's type, passing it the event
    public void Publish<TEvent>(TEvent @event)
    {
        //Nobody subscribed to this type, do nothing
        //Only this types list is looked up, so handlers for other types never receive
        if(!_handlers.TryGetValue(typeof(TEvent), out var list))
        {
            return;
        }

        //Run handlers from front to back, in subscription order
        foreach(var handler in list)
        {
            //Stored as Delegate, so cast back to specific type before calling it.
            var typed = (Action<TEvent>)handler;
            typed(@event);
        }
    }
}

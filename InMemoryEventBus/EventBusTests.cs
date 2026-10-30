namespace InterviewExercises.InMemoryEventBus;

public class EventBusTests
{
    [Fact]
    public void Publish_InvokesTheHandlerRegisteredForTheEventType()
    {
        var eventBus = new EventBus();
        var receivedEvents = new List<OrderPlaced>();

        eventBus.Subscribe<OrderPlaced>(receivedEvents.Add);

        var orderPlaced = new OrderPlaced(42);
        eventBus.Publish(orderPlaced);

        var received = Assert.Single(receivedEvents);
        Assert.Same(orderPlaced, received);
    }

    [Fact]
    // Publishing twice delivers both events; nothing is used up after the first publish.
    public void Publish_CalledTwice_InvokesHandlerForEachEvent()
    {
        var eventBus = new EventBus();
        var receivedEvents = new List<OrderPlaced>();

        eventBus.Subscribe<OrderPlaced>(receivedEvents.Add);

        // Different IDs so a missing, duplicated or reordered event fails the assert.
        var orderPlaced1 = new OrderPlaced(42);
        eventBus.Publish(orderPlaced1);

        var orderPlaced2 = new OrderPlaced(43);
        eventBus.Publish(orderPlaced2);

        //Compares item by item, in order. Records compare by value
        Assert.Equal(new[] { orderPlaced1, orderPlaced2 }, receivedEvents);
    }

    //A handler receives only events of the type it subscribed to.
    [Fact]
    public void Publish_OnlyInvokesHandlersForThatEventType()
    {
        var eventBus = new EventBus();
        var calls = new List<string>();

        //Subscribe to two types so an empty result can't pass by accident
        eventBus.Subscribe<OrderPlaced>(e => calls.Add("order"));
        eventBus.Subscribe<UserCreated>(e => calls.Add("user"));

        eventBus.Publish(new OrderPlaced(42));
        
        //Only the OrderPlaced handler should run
        Assert.Equal(new[] { "order" }, calls);
    }

    [Fact]
    //an event type can have several handlers, and every one runs
    public void Publish_InvokesEveryHandlerForTheEventType()
    {
        var eventBus = new EventBus();
        var calls = new List<string>();

        eventBus.Subscribe<OrderPlaced>(e => calls.Add("first"));
        eventBus.Subscribe<OrderPlaced>(e => calls.Add("second"));
        eventBus.Subscribe<OrderPlaced>(e => calls.Add("third"));

        eventBus.Publish(new OrderPlaced(42));

        //count catches a handler running twice; Contains checks each one ran (in any order)
        Assert.Equal(3, calls.Count);
        Assert.Contains("first", calls);
        Assert.Contains("second", calls);
        Assert.Contains("third", calls);
    }

    [Fact]
    //Handlers run in the order they were subscribed
    public void Publish_InvokesHandlersInSubscriptionOrder()
    {
        var eventBus = new EventBus();
        var calls = new List<string>();

        eventBus.Subscribe<OrderPlaced>(e => calls.Add("first"));
        eventBus.Subscribe<OrderPlaced>(e => calls.Add("second"));
        eventBus.Subscribe<OrderPlaced>(e => calls.Add("third"));

        eventBus.Publish(new OrderPlaced(42));

        //Sequence Equal compares position by position, so order matters here
        Assert.Equal(new[] { "first", "second", "third" }, calls);
    }

    [Fact]
    //Publishing with no subscribers does nothing and doesn't throw.
    public void Publish_WithNoSubscribers_DoesNotThrow()
    {
        var eventBus = new EventBus();

        //Record. Exception runs the lambda and returns what it threw, ir null if nothing
        var exception = Record.Exception(() => eventBus.Publish(new OrderPlaced(42)));
        
        Assert.Null(exception);
    }
    //Test only event types. Records give value equality for free.
    private sealed record OrderPlaced(int OrderId);
    private sealed record UserCreated(string Name);
}

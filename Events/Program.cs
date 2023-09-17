EventEmitter emitter = new EventEmitter();
EventPlayground eventPlayground = new EventPlayground(5, emitter);
eventPlayground.RunEvent(false);
Console.WriteLine("Let's do it again!");
eventPlayground.RunEvent(false);
Console.WriteLine("Let's do it again, this time we will unsubscribe.");
eventPlayground.RunEvent(true);
Console.WriteLine("Test after unsubscribe.");
eventPlayground.RunEvent(true);
Console.WriteLine("Done.");



/// <summary>
/// Class that will emit a simple event.
/// </summary>
public class EventEmitter{

    public event Action<EventEmitter, bool>? SomethingHappened;
    
    public EventEmitter(){}

    /// <summary>
    /// Fires an event.
    /// </summary>
    public void MakeEventHappen(bool unsubscribe){
        SomethingHappened?.Invoke(this, unsubscribe);
    }

}

/// <summary>
/// Listens to the simple event. 
/// </summary>
public class EventListener{
    private string Name { get; init; }
    public EventListener(string name, EventEmitter emitter){
        Name = name;
        emitter.SomethingHappened += OnSomethingHappened;
    }

    /// <summary>
    /// When event fires, write ackowledgement to console. Possibility of unsubscribing after.
    /// </summary>
    /// <param name="emitter">object that emitter the event</param>
    /// <param name="unsubscribe">whether to unsubscribe after</param>
    public void OnSomethingHappened(EventEmitter emitter, bool unsubscribe=true){
        Console.WriteLine($"Handler {Name} handling the event.");
        if (unsubscribe){
            emitter.SomethingHappened -= OnSomethingHappened;
            Console.WriteLine($"Handler {Name} unsubscribed from the event.");
        }
        
    }
}

/// <summary>
/// Event playground for experimentation with events.
/// </summary>
public class EventPlayground{
    private List<EventListener> Listeners { get; init; }
    private EventEmitter Emitter{ get; init; }

    /// <summary>
    /// Construct playground with specific amount of listeres.
    /// </summary>
    /// <param name="listenersAmount">How many listeners to create</param>
    /// <param name="emitter">Emitter that it'll be listening for</param>
    public EventPlayground(int listenersAmount, EventEmitter emitter){
        Listeners = new List<EventListener>();
        Emitter = emitter;

        CreateListeners(listenersAmount);
        
    }

    /// <summary>
    /// Creactes listeners.
    /// </summary>
    /// <param name="amount">How many listeners to create.</param>
    private void CreateListeners(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Listeners.Add(new EventListener($"Listener {i}", Emitter));
        }
    }

    /// <summary>
    /// Runs emitter event.
    /// </summary>
    /// <param name="unsubscribe">Whether to unsubscribe in the event.</param>
    public void RunEvent(bool unsubscribe){
        Emitter.MakeEventHappen(unsubscribe);
    }
}









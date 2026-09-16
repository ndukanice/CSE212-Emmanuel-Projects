/// <summary>
/// A basic implementation of a Queue (FIFO)
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the back of the queue
    /// </summary>
    public void Enqueue(Person person)
    {
        _queue.Add(person); // add at the end
    }

    /// <summary>
    /// Remove a person from the front of the queue
    /// </summary>
    public Person Dequeue()
    {
        var person = _queue[0]; // take from the front
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

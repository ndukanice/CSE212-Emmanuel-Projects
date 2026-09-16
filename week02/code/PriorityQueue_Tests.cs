using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities.
    // Expected Result: Items should be dequeued in order of highest priority first.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue()); // highest priority
        Assert.AreEqual("C", pq.Dequeue()); // next highest
        Assert.AreEqual("A", pq.Dequeue()); // lowest
    }

    [TestMethod]
    // Scenario: Enqueue items with equal priority.
    // Expected Result: Items with the same priority should be dequeued in the order they were added (FIFO for ties).
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 5);
        pq.Enqueue("Y", 5);
        pq.Enqueue("Z", 1);

        Assert.AreEqual("X", pq.Dequeue()); // X first
        Assert.AreEqual("Y", pq.Dequeue()); // Y next
        Assert.AreEqual("Z", pq.Dequeue()); // lowest
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue()); // empty queue should throw
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{

    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items are dequeued in order of descending priority
    // Defect(s) Found: Original Dequeue logic did not remove the item or handled priority incorrectly
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }


    [TestMethod]
    // Scenario: Enqueue items with same highest priority
    // Expected Result: The first inserted item among the highest priority is removed first (FIFO)
    // Defect(s) Found: Original Dequeue chose last item with highest priority
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 4);
        pq.Enqueue("Y", 4);
        pq.Enqueue("Z", 3);

        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("Z", pq.Dequeue());
    }
    
    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Original Dequeue did not throw correct exception
    public void TestPriorityQueue_3()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}
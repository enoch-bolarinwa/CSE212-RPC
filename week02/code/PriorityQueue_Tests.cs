using Microsoft.VisualStudio.TestTools.UnitTesting;
// TODO Problem 2 - Write and run test cases and fix the code to match requirements.
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A(pri 1), B(pri 3), C(pri 3), D(pri 2), in that order. Two items (B and C)
    // tie for the highest priority. Dequeue repeatedly until the queue is empty.
    // Expected Result: B, C, D, A -- highest priority first, and on the B/C tie the one enqueued
    // first (B) comes out first (FIFO tie-break).
    // Defect(s) Found: The original Dequeue loop used "index < _queue.Count - 1", so the last
    // item in the list was never examined and could never be selected as the highest priority.
    // It also used ">=" instead of ">" when comparing priorities, so on a tie it kept overwriting
    // highPriorityIndex with the later item, returning C before B instead of respecting FIFO order.
    // Finally, Dequeue never removed the selected item from the list (no RemoveAt call), so the
    // queue never actually shrank and the same item could be returned repeatedly.
    // Fixed by looping over the full list, using strict ">" for the priority comparison, and
    // calling _queue.RemoveAt(highPriorityIndex) before returning the value.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue on a brand-new, empty PriorityQueue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: None. The empty check at the top of Dequeue already throws the correct
    // exception type and message. Test passes.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue X(pri 5), Y(pri 5), Z(pri 5) -- three items that all tie on priority --
    // then dequeue all three.
    // Expected Result: X, Y, Z, in that exact insertion order, confirming FIFO tie-breaking holds
    // even with more than two tied items and across multiple calls (not just the first dequeue).
    // Defect(s) Found: Same as TestPriorityQueue_1 -- the ">=" comparison caused later
    // equal-priority items to overwrite earlier ones, so the original code would have returned
    // Z, Y, X instead of X, Y, Z. Fixed by the same change (strict ">" comparison).
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 5);
        priorityQueue.Enqueue("Y", 5);
        priorityQueue.Enqueue("Z", 5);

        Assert.AreEqual("X", priorityQueue.Dequeue());
        Assert.AreEqual("Y", priorityQueue.Dequeue());
        Assert.AreEqual("Z", priorityQueue.Dequeue());
    }
    // Add more test cases as needed below.
}

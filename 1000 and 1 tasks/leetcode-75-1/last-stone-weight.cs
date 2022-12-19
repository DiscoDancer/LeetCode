public class Solution
{
    public static int LastStoneWeight(int[] stones) {
        var queue = new PriorityQueue<int, int>();
        foreach (var s in stones) {
            queue.Enqueue(s,- s);
        }

        while (queue.Count > 1) {
            var a = queue.Dequeue();
            var b = queue.Dequeue();
            var diff = a-b;

            if (diff > 0) {
                queue.Enqueue(diff, - diff);
            }
        }

        return queue.Count == 1 ? queue.Dequeue() : 0;
    }


    public static void Main()
    {
        Console.WriteLine(LastStoneWeight(new []{2,7,4,1,8,1}));
    }
}
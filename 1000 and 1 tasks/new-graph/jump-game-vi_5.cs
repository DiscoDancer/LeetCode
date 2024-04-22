
// протухающая очередь
public class Solution {
    public int MaxResult(int[] nums, int k) {
        var table = new int[nums.Length];
        table[nums.Length-1] = nums[nums.Length-1];

        var heap = new PriorityQueue<int, int>();
        heap.Enqueue(nums.Length-1, -table[nums.Length-1]);

        for (int index = nums.Length-2; index >= 0; index--) {
            
            // clean queue
            while (heap.Count > 0 && Math.Abs(index - heap.Peek()) > k)
            {
                heap.Dequeue();
            }

            var max = table[heap.Peek()];

            table[index] = nums[index] + max;
            
            heap.Enqueue(index, -table[index]);
        }

        return (int)table[0];
    }
}
public class Solution {
    public int Jump(int[] nums) {
        var queue = new Queue<(int i, int jumpCount)>();
        var visited = new bool[nums.Length];

        visited[0] = true;
        queue.Enqueue((0, 0));

        while (queue.Any()) {
            var (node, jumpCount) = queue.Dequeue();

            if (node == nums.Length - 1) {
                return jumpCount;
            }
            
            for (int i = 1; i <= nums[node] && i + node < nums.Length; i++) {
                if (!visited[i + node]) {
                    queue.Enqueue((i + node, jumpCount + 1));
                    visited[i + node] = true;
                }
            }
        }

        return -1;
    }
}
public class Solution {
    // Time limit
    public int IntegerBreak(int n) {
        var queue = new Queue<(int product, int sum)>();

        for (int i = 1; i < n; i++) {
            queue.Enqueue((i,i));
        }

        var max = 0;

        while (queue.Any()) {
            var (curProduct, curSum) = queue.Dequeue();
            if (curSum == n) {
                max = Math.Max(max, curProduct);
            }

            for (int i = 1; i <= n; i++) {
                if (curSum + i <= n) {
                    queue.Enqueue((curProduct*i,curSum + i));
                }
            }
        }

        return max;
    }
}
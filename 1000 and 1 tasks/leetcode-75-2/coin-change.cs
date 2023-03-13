public class Solution {
    // BFS out of memory
    public int CoinChange(int[] coins, int amount) {
        if (amount == 0) {
            return 0;
        }
        
        var queue = new Queue<(int cur, int generation)>();

        foreach (var coin in coins) {
            if (amount - coin >= 0) {
                queue.Enqueue((amount - coin, 1));
            }
        }

        while (queue.Any()) {
            var (cur, generation) = queue.Dequeue();
            if (cur == 0) {
                return generation;
            }
            
            foreach (var coin in coins) {
                if (cur - coin >= 0) {
                    queue.Enqueue((cur - coin, generation + 1));
                }
            }
        }

        return -1;
    }
}
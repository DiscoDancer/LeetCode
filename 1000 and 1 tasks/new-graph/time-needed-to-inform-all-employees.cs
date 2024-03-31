public class Solution {
    // все ок, это просто идет паралелльно
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        // можно словарь
        var iAmManagerOf = new List<int>[n];
        for (int i = 0; i < n; i++) {
            iAmManagerOf[i] = new ();
        }
        // можно за 1
        for (int i = 0; i < n; i++) {
            if (manager[i] != -1) {
                iAmManagerOf[manager[i]].Add(i);
            }
        }

        var max = 0;

        var queue = new Queue<(int v, int sum)>();
        queue.Enqueue((headID, informTime[headID]));

        while (queue.Any()) {
            var (x, sum) = queue.Dequeue();
            max = Math.Max(sum, max);
            foreach (var y in iAmManagerOf[x]) {
                queue.Enqueue((y, sum + informTime[y]));
            }
        }

        return max;
    }
}
public class Solution {
    public bool CanReach(int[] arr, int start) {
        var N = arr.Length;
        var visited = new bool[N];
        visited[start] = true;

        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Any()) {
            var cur = queue.Dequeue();
            var a = cur - arr[cur];
            var b = cur + arr[cur];

            if (a >= 0 && !visited[a]) {
                visited[a] = true;
                queue.Enqueue(a);
            }
            if (b < N && !visited[b]) {
                visited[b] = true;
                queue.Enqueue(b);
            }
        }

        for (int i = 0; i < N; i++) {
            if (arr[i] == 0 && visited[i]) {
                return true;
            }
        }

        return false;
    }
}
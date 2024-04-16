public class Solution {
    public bool CanReach(int[] arr, int start) {
        var visited = new bool[arr.Length];
        visited[start] = true;

        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Any()) {
            var cur = queue.Dequeue();
            if (arr[cur] == 0) {
                return true;
            }

            if (cur + arr[cur] < arr.Length && !visited[cur + arr[cur]]) {
                visited[cur + arr[cur]] = true;
                queue.Enqueue(cur + arr[cur]);
            }
            if (cur - arr[cur] >= 0 && !visited[cur - arr[cur]]) {
                visited[cur - arr[cur]] = true;
                queue.Enqueue(cur - arr[cur]);
            }
        }

        return false;
    }
}
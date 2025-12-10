import java.util.*;


class Solution {

    public boolean canReach(int[] arr, int start) {
        if (arr[start] == 0) {
            return true;
        }

        var visited = new boolean[arr.length];
        Queue<Integer> queue = new ArrayDeque<>();
        queue.add(start);

        while (!queue.isEmpty()) {
            var cur = queue.poll();
            if (visited[cur]) {
                continue;
            }
            visited[cur] = true;

            if (arr[cur] == 0) {
                return true;
            }
            if (cur - arr[cur] >= 0 && !visited[cur - arr[cur]]) {
                queue.add(cur - arr[cur]);
            }
            if (cur + arr[cur] < arr.length && !visited[cur + arr[cur]]) {
                queue.add(cur + arr[cur]);
            }
        }

        return false;
    }
}
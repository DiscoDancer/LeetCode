import java.util.*;

class Solution {
    public int[] findOrder(int numCourses, int[][] prerequisites) {
        var forXRequireYs = new int[numCourses];
        List<Integer>[] xIsRequiredByYs = new ArrayList[numCourses];

        var result = new int[numCourses];
        var resultIndex = 0;

        for (int i = 0; i < numCourses; i++) {
            xIsRequiredByYs[i] = new ArrayList<>();
            forXRequireYs[i] = 0;
        }

        for (var prerequisite : prerequisites) {
            // to take course 0 you have to first take course 1
            var x = prerequisite[0];
            var y = prerequisite[1];

            forXRequireYs[x]++;
            xIsRequiredByYs[y].add(x);
        }

        Queue<Integer> queue = new LinkedList<>();
        for (int i = 0; i < numCourses; i++) {
            if (forXRequireYs[i] == 0) {
                queue.add(i);
            }
        }

        while (!queue.isEmpty()) {
            var x = queue.poll();
            result[resultIndex++] = x;
            for (var y : xIsRequiredByYs[x]) {
                forXRequireYs[y]--;
                if (forXRequireYs[y] == 0) {
                    queue.add(y);
                }
            }
        }

        return resultIndex == numCourses ? result : new int[0];
    }
}
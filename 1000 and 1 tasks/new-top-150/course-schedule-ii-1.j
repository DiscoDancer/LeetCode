import java.util.*;

class Solution {
    public int[] findOrder(int numCourses, int[][] prerequisites) {
        var forXRequireYs = new int[numCourses];
        var xIsRequiredByYs = new HashMap<Integer, List<Integer>>();

        var result = new int[numCourses];
        var resultIndex = 0;

        for (int i = 0; i < numCourses; i++) {
            xIsRequiredByYs.put(i, new ArrayList<>());
            forXRequireYs[i] = 0;
        }

        for (var prerequisite : prerequisites) {
            // to take course 0 you have to first take course 1
            var x = prerequisite[0];
            var y = prerequisite[1];

            forXRequireYs[x]++;
            xIsRequiredByYs.get(y).add(x);
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
            for (var y : xIsRequiredByYs.get(x)) {
                forXRequireYs[y]--;
                if (forXRequireYs[y] == 0) {
                    queue.add(y);
                }
            }
        }

        return resultIndex == numCourses ? result : new int[0];
    }
}
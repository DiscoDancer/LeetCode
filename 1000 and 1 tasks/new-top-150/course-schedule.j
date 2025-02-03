import java.util.*;

class Solution {
    public boolean canFinish(int numCourses, int[][] prerequisites) {
        var forXRequireYs = new HashMap<Integer, Integer>();
        var xIsRequiredByYs = new HashMap<Integer, List<Integer>>();

        for (int i = 0; i < numCourses; i++) {
            xIsRequiredByYs.put(i, new ArrayList<>());
            forXRequireYs.computeIfAbsent(i, k -> 0);
        }

        for (var prerequisite : prerequisites) {
            // to take course 0 you have to first take course 1
            var x = prerequisite[0];
            var y = prerequisite[1];

            forXRequireYs.put(x, forXRequireYs.get(x) + 1);
            xIsRequiredByYs.get(y).add(x);
        }

        Queue<Integer> queue = new LinkedList<>();
        for (var k: forXRequireYs.keySet()) {
            if (forXRequireYs.get(k) == 0) {
                queue.add(k);
            }
        }

        var coursesTaken = 0;
        while (!queue.isEmpty()) {
            var x = queue.poll();
            coursesTaken++;
            for (var y : xIsRequiredByYs.get(x)) {
                forXRequireYs.put(y, forXRequireYs.get(y) - 1);
                if (forXRequireYs.get(y) == 0) {
                    queue.add(y);
                }
            }
        }
        
        return coursesTaken == numCourses;
    }
}
public class Solution {
    // see course-schedule-i for more solutions
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var dependsOnMe = new Dictionary<int, List<int>>();
        var iDependOn = new int[numCourses];

        foreach (var prerequisite in prerequisites) {
            var a = prerequisite[0];
            var b = prerequisite[1];
            // a depends on b
            iDependOn[a]++;
            if (!dependsOnMe.ContainsKey(b)) {
                dependsOnMe[b] = new ();
            }
            dependsOnMe[b].Add(a);
        }

        var queue = new Queue<int>();

        for (int i = 0 ; i < numCourses; i++) {
            if (iDependOn[i] == 0) {
                queue.Enqueue(i);
            }
        }

        var result = new List<int>();
        while (queue.Any()) {
            var cur = queue.Dequeue();
            result.Add(cur);

            if (!dependsOnMe.ContainsKey(cur)) {
                continue;
            }

            foreach (var dep in dependsOnMe[cur]) {
                iDependOn[dep]--;
                if (iDependOn[dep] == 0) {
                    queue.Enqueue(dep);
                }
            }
        }

        if (result.Count() != numCourses) {
            return new int[] {};
        }
        return result.ToArray();
    }
}
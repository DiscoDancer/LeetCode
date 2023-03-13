public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var dependsOnMe = new List<int>[numCourses];
        var iDependOn = new List<int>[numCourses];

        for (int i = 0; i < numCourses; i++) {
            dependsOnMe[i] = new ();
            iDependOn[i] = new ();
        }

        foreach (var prerequisite in prerequisites) {
            var a = prerequisite[0];
            var b = prerequisite[1];
            // a depends on b
            iDependOn[a].Add(b);
            dependsOnMe[b].Add(a);
        }

        var queue = new Queue<int>();

        for (int i = 0 ; i < numCourses; i++) {
            if (!iDependOn[i].Any()) {
                queue.Enqueue(i);
            }
        }

        while (queue.Any()) {
            var cur = queue.Dequeue();
            iDependOn[cur] = null;

            foreach (var dep in dependsOnMe[cur]) {
                // visited
                if (iDependOn[dep] == null) {
                    continue;
                }
                iDependOn[dep].Remove(cur);
                if (!iDependOn[dep].Any()) {
                    queue.Enqueue(dep);
                }
            }
        }

        return iDependOn.All(x => x == null);
    }
}
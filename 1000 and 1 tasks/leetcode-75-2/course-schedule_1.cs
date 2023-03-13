public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var dependsOnMe = new List<int>[numCourses];
        var iDependOn = new int[numCourses];

        for (int i = 0; i < numCourses; i++) {
            dependsOnMe[i] = new ();
        }

        foreach (var prerequisite in prerequisites) {
            var a = prerequisite[0];
            var b = prerequisite[1];
            // a depends on b
            iDependOn[a]++;
            dependsOnMe[b].Add(a);
        }

        var queue = new Queue<int>();

        for (int i = 0 ; i < numCourses; i++) {
            if (iDependOn[i] == 0) {
                queue.Enqueue(i);
            }
        }

        while (queue.Any()) {
            var cur = queue.Dequeue();

            foreach (var dep in dependsOnMe[cur]) {
                iDependOn[dep]--;
                if (iDependOn[dep] == 0) {
                    queue.Enqueue(dep);
                }
            }
        }

        return iDependOn.All(x => x == 0);
    }
}
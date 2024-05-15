public class Solution {
    // topological sort
    // propogate updates
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var coursesVisitedCount = 0;

        var toEnrollMeRequiredCount = new int[numCourses];
        var iAmRequiredToEnrolTo = new List<int>[numCourses];
        // could be optimized
        for (int i = 0; i < numCourses; i++) {
            iAmRequiredToEnrolTo[i] = new ();
        }

        foreach (var ab in prerequisites) {
            // for course a, b is required
            var a = ab[0];
            var b = ab[1];

            toEnrollMeRequiredCount[a]++;
            iAmRequiredToEnrolTo[b].Add(a);
        }

        var queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (toEnrollMeRequiredCount[i] == 0) {
                queue.Enqueue(i);
                coursesVisitedCount++;
            }
        }

        while (queue.Any()) {
            var cur = queue.Dequeue();
            foreach (var other in iAmRequiredToEnrolTo[cur]) {
                toEnrollMeRequiredCount[other]--;
                if (toEnrollMeRequiredCount[other] == 0) {
                    queue.Enqueue(other);
                    coursesVisitedCount++;
                }
            }
        }

        return coursesVisitedCount == numCourses;
    }
}
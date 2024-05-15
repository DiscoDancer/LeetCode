public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var result = new List<int>();

        var toEnrollMeRequiredCount = new int[numCourses];
        var iAmRequiredToEnrolTo = new List<int>[numCourses];

        foreach (var ab in prerequisites) {
            // for course a, b is required
            var a = ab[0];
            var b = ab[1];

            toEnrollMeRequiredCount[a]++;
            if (iAmRequiredToEnrolTo[b] == null) {
                iAmRequiredToEnrolTo[b] = [a];
            }
            else {
                iAmRequiredToEnrolTo[b].Add(a);
            }
        }

        var queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (toEnrollMeRequiredCount[i] == 0) {
                queue.Enqueue(i);
            }
        }

        while (queue.Any()) {
            var cur = queue.Dequeue();
            result.Add(cur);
            if (iAmRequiredToEnrolTo[cur] == null) continue;
            foreach (var other in iAmRequiredToEnrolTo[cur]) {
                toEnrollMeRequiredCount[other]--;
                if (toEnrollMeRequiredCount[other] == 0) {
                    queue.Enqueue(other);
                }
            }
        }

        if (result.Count() != numCourses) {
            return [];
        }

        // can be optimized with global index
        return result.ToArray();
    }
}
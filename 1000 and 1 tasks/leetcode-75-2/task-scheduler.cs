public class Solution {
    public class TaskNode {
        public int Count { get; set; }
        public int LockedUntil {get; set;}
    }

    public int LeastInterval(char[] tasks, int n) {
        var table = new int[26];
        foreach (var t in tasks) {
            table[t - 'A']++;
        }

        var list = new List<TaskNode>();

        for (int i = 0; i < 26; i++) {
            if (table[i] > 0) {
                var node = new TaskNode {
                    Count = table[i],
                    LockedUntil = 0
                };
                list.Add(node);
            }
        }

        var taskRemaining = tasks.Length;
        var time = 0;

        while (taskRemaining > 0) {
            var max = -1;
            TaskNode best = null;
            foreach (var node in list) {
                if (node.LockedUntil <= time) {
                    if (node.Count > max) {
                        max = node.Count;
                        best = node;
                    }
                }
            }

            if (best == null) {
                time++;
                continue;
            }

            best.Count--;
            if (best.Count == 0) {
                list.Remove(best);
            }
            else {
                best.LockedUntil = time + n + 1;
            }
            taskRemaining--;

            time++;
        }

        return time;
    }
}
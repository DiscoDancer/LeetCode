public class Solution {
    // n people 1..n
    // split into 2 groups
    // Each person may dislike some other people, and they should not go into the same group.

    // неверно
    public bool PossibleBipartition(int n, int[][] dislikes) {
        // who dislikes x
        var dislikeTable = new Dictionary<int, HashSet<int>>();
        foreach (var d in dislikes) {
            if (!dislikeTable.ContainsKey(d[0])) {
                dislikeTable[d[0]] = new HashSet<int>();
            }
            if (!dislikeTable.ContainsKey(d[1])) {
                dislikeTable[d[1]] = new HashSet<int>();
            }

            dislikeTable[d[0]].Add(d[1]);
            dislikeTable[d[1]].Add(d[0]);
        }

        var group1 = new List<int>();
        var group2 = new List<int>();

        for (int i = 1; i <= n; i++) {
            if (!dislikeTable.ContainsKey(i)) {
                continue;
            }

            var isPossibleToAddInto1 = true;
            foreach (var g1 in group1) {
                if (dislikeTable[i].Contains(g1)) {
                    isPossibleToAddInto1 = false;
                    break;
                }
            }
            if (isPossibleToAddInto1) {
                 group1.Add(i);
                 continue;
            }

            var isPossibleToAddInto2 = true;
            foreach (var g2 in group2) {
                if (dislikeTable[i].Contains(g2)) {
                    isPossibleToAddInto2 = false;
                    break;
                }
            }
            if (isPossibleToAddInto2) {
                 group2.Add(i);
                 continue;
            }

            return false;

            // if possible to add into group 1 -> add
            // else if possible to add into group 2 -> add
            // else return false
        }

        return true;
    }
}
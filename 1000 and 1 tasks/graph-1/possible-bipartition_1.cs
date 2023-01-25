public class Solution {
    // https://leetcode.com/problems/possible-bipartition/solutions/2834180/possible-bipartition/?envType=study-plan&id=graph-i&orderBy=most_votes

    public bool IsPossibleColorize(int i) {
        var queue = new Queue<int>();
        queue.Enqueue(i);
        _colors[i] = RED;

        while (queue.Any()) {
            var cur = queue.Dequeue();

            if (!_dislikeTable.ContainsKey(cur)) {
                continue;
            }

            foreach (var hater in _dislikeTable[cur]) {
                if (_colors[hater] == _colors[cur]) {
                    return false;
                }

                if (_colors[hater] == 0) {
                    _colors[hater] = _colors[cur] == RED ? BLUE : RED;
                    queue.Enqueue(hater);
                }
            }
        }

        return true;
    }

    private const int RED = 5;
    private const int BLUE = 6;

    private int[] _colors;
    private Dictionary<int, HashSet<int>> _dislikeTable;

    public bool PossibleBipartition(int n, int[][] dislikes) {
        // who dislikes x
        _dislikeTable = new Dictionary<int, HashSet<int>>();
        foreach (var d in dislikes) {
            if (!_dislikeTable.ContainsKey(d[0])) {
                _dislikeTable[d[0]] = new HashSet<int>();
            }
            if (!_dislikeTable.ContainsKey(d[1])) {
                _dislikeTable[d[1]] = new HashSet<int>();
            }

            _dislikeTable[d[0]].Add(d[1]);
            _dislikeTable[d[1]].Add(d[0]);
        }

        _colors = new int[n+1];

        for (int i = 1; i <= n; i++) {
            if (_colors[i] == 0) {
                if (!IsPossibleColorize(i)) {
                    return false;
                }
            }
        }

        return true;
    }
}
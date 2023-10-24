public class Solution {
    // пускаем круги от 0ля
    // premature optimization = NO
    public int MinReorder(int n, int[][] connections) {
        var fromTable = new List<int>[n];
        var toTable = new List<int>[n];

        for (int i = 0; i < connections.Length; i++) {
            var from = connections[i][0];
            var to = connections[i][1];

            if (fromTable[from] == null) {
                fromTable[from] = new ();
            }
            fromTable[from].Add(to);

            if (toTable[to] == null) {
                toTable[to] = new ();
            }
            toTable[to].Add(from);
        }

        var connected = new bool[n];
        connected[0] = true;
        var result = 0;
        var queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Any()) {
            var cur = queue.Dequeue();
            if (toTable[cur] != null) {
                foreach (var city in toTable[cur]) {
                    if (!connected[city]) {
                        connected[city] = true;
                        queue.Enqueue(city);
                    }
                }
            }
            if (fromTable[cur] != null) {
                foreach (var city in fromTable[cur]) {
                    if (!connected[city]) {
                        connected[city] = true;
                        queue.Enqueue(city);
                        result++;
                    }
                }
            }
        }

        return result;
    }
}
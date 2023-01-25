public class Solution {
    // n cities: 0..n-1
    // undirected roads[from,to]
    public int MaximalNetworkRank(int n, int[][] roads) {
        var count = new int[n];
        var connectedWith = new Dictionary<int, List<int>>();

        foreach (var r in roads) {
            count[r[0]]++;
            count[r[1]]++;

            if (!connectedWith.ContainsKey(r[0])) {
                connectedWith[r[0]] = new List<int>();
            }
            if (!connectedWith.ContainsKey(r[1])) {
                connectedWith[r[1]] = new List<int>();
            }
            connectedWith[r[0]].Add(r[1]);
            connectedWith[r[1]].Add(r[0]);
        }

        var max = 0;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (i != j) {
                    if (connectedWith.ContainsKey(i)) {
                        var minus = connectedWith[i].Contains(j) ? 1 : 0;
                        max = Math.Max(max, count[i] + count[j] - minus);
                    }
                }
            }
        }

        return max;

        // посчитать количество дорог для города
        // найти соединенных
        // profit
    }
}
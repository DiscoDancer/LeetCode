public class Solution {
    // n cities 0..n-1
    // src -> target
    // most k stops
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var resultTable = new int[n+1][];
        for (int i = 0; i < n+1; i++) {
            resultTable[i] = new int[n];
            Array.Fill(resultTable[i], int.MaxValue);
        }

        resultTable[0][src] = 0;

        var adjacencyTable = new Dictionary<int, List<(int y, int cost)>>();
        foreach (var flight in flights) {
            if (!adjacencyTable.ContainsKey(flight[0])) {
                adjacencyTable[flight[0]] = new ();
            }
            adjacencyTable[flight[0]].Add((flight[1], flight[2]));
        }

        for (int row = 1; row <= k+1; row++) { // count of edges
            for (var node = 0; node < n; node++) {
                if (resultTable[row-1][node] != int.MaxValue && adjacencyTable.ContainsKey(node)) {
                    foreach (var (neighbour, cost) in adjacencyTable[node]) {
                        resultTable[row][neighbour] = Math.Min(
                            resultTable[row][neighbour],
                            resultTable[row-1][node] + cost
                        );
                    }
                }

                resultTable[row][node] = Math.Min(resultTable[row][node], resultTable[row-1][node]);
            }
        }

        return resultTable[k+1][dst] == int.MaxValue ? -1 : resultTable[k+1][dst];
    }
}
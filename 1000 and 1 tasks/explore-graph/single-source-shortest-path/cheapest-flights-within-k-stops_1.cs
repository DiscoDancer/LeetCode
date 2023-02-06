public class Solution {
    // n cities 0..n-1
    // src -> target
    // most k stops
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var adjacencyTable = new Dictionary<int, List<(int y, int cost)>>();
        foreach (var flight in flights) {
            if (!adjacencyTable.ContainsKey(flight[0])) {
                adjacencyTable[flight[0]] = new ();
            }
            adjacencyTable[flight[0]].Add((flight[1], flight[2]));
        }

        var prevLine = new int[n];
        Array.Fill(prevLine, int.MaxValue);
        prevLine[src] = 0;
        int[] curLine = prevLine;

        for (int row = 0; row < k+1; row++) { // count of edges
            curLine = prevLine.ToArray();
            for (var node = 0; node < n; node++) {
                if (prevLine[node] != int.MaxValue && adjacencyTable.ContainsKey(node)) {
                    foreach (var (neighbour, cost) in adjacencyTable[node]) {
                        curLine[neighbour] = Math.Min(
                            curLine[neighbour],
                            prevLine[node] + cost
                        );
                    }
                }
            }
            prevLine = curLine;
        }

        return curLine[dst] == int.MaxValue ? -1 : curLine[dst];
    }
}
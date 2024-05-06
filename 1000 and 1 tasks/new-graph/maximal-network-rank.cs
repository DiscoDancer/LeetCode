public class Solution {
    // square solution
    public int MaximalNetworkRank(int n, int[][] roads) {
        var iConnectedWith = new List<int>[n];
        for (int i = 0; i < n; i++) {
            iConnectedWith[i] = new ();
        }

        foreach (var road in roads) {
            // a <-> b
            var a = road.First();
            var b = road.Last();

            iConnectedWith[b].Add(a);
            iConnectedWith[a].Add(b);
        }

        var max = 0;
        
        // мб второй и первый максимум взять
        // матрица квадрат connected bool[,]
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                var cur = iConnectedWith[i].Count() + iConnectedWith[j].Count();
                if (iConnectedWith[i].Contains(j)) {
                    cur--;
                }

                max = Math.Max(max, cur);
            }
        }

        return max;
    }
}
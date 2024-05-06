public class Solution {
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        var iConnectedWithCount = new int[n];
        var connectedTable = new bool[n, n];

        foreach (var road in roads)
        {
            // a <-> b
            var a = road.First();
            var b = road.Last();

            connectedTable[b, a] = true;
            connectedTable[a, b] = true;
            iConnectedWithCount[a]++;
            iConnectedWithCount[b]++;
        }

        var max = 0;

        // мб второй и первый максимум взять
        // скорее pq
        // но это все не то
        // матрица квадрат connected bool[,]
        // нарисовать все случаи
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var cur = iConnectedWithCount[i] + iConnectedWithCount[j];
                if (connectedTable[i, j])
                {
                    cur--;
                }

                max = Math.Max(max, cur);
            }
        }

        return max;
    }
}
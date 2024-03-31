// // https://leetcode.com/problems/shortest-path-with-alternating-colors/?envType=study-plan-v2&envId=graph-theory
public class Solution {

    public const int NEUTRAL = 1;
    public const int RED = 2;
    public const int BLUE = 3;

    // дейкстра или просто propogate updates
    // нужно табличка, откуда куда есть пусть
    // visited
    // BFS будет сразу давать результат оптимальный, поэтому visited сработает
    // weight нету, поэтому propogate updates не нужен
    // но зато visited для разных цветов походу нужен
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges) {
        var result = new int[n];
        Array.Fill(result, int.MaxValue);
        result[0] = 0;

        var listRed = new List<int>[n];
        var listBlue = new List<int>[n];

        for (int i = 0; i < n; i++) {
            listRed[i] = new ();
            listBlue[i] = new ();
        }


        var visitedRed = new bool[n];
        var visitedBlue = new bool[n];

        visitedRed[0] = true;
        visitedBlue[0] = true;

        var queue = new Queue<(int v, int sum, int color)>();
        foreach (var red in redEdges) {
            var x = red[0];
            var y = red[1];
            if (x != y && x == 0) {
                queue.Enqueue((y, 1, RED));
                result[y] = 1;
                visitedRed[y] = true;
            }
            listRed[x].Add(y);
        }
        foreach (var blue in blueEdges) {
            var x = blue[0];
            var y = blue[1];
            if (x != y && x == 0) {
                queue.Enqueue((y, 1, BLUE));
                result[y] = 1;
                visitedBlue[y] = true;
            }
            listBlue[x].Add(y);
        }

        while (queue.Any()) {
            var (x, sum, color) = queue.Dequeue();
            result[x] = Math.Min(result[x], sum);
            // x -> y

            if (color == RED) {
                foreach (var y in listBlue[x]) {
                    if (!visitedBlue[y]) {
                        visitedBlue[y] = true;
                        queue.Enqueue((y, sum + 1, BLUE));
                    }
                }
            }
            if (color == BLUE) {
                foreach (var y in listRed[x]) {
                    if (!visitedRed[y]) {
                        visitedRed[y]  = true;
                        queue.Enqueue((y, sum + 1, RED));
                    }
                }
            }
        }

        for (int i = 1; i < n; i++) {
            if (result[i] == int.MaxValue) {
                result[i] = -1;
            }
        }

        return result;
    }
}
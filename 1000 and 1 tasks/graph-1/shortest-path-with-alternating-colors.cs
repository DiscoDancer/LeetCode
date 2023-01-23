public class Solution {
    // nodes 0..n-1
    // edges: parallel, self edge
    // redEdges[i] = [from, to]
    // answer[i] min length of alternating path 0..i or -1

    /*
        Идеи:
        - 4 таблицы out + in x red + blue
        - идем от 0, кладем в очередь (vertex:0, color: red, length:0) + (vertex:0, color: blue, length:0)
        - отмечать visited red и visited blue (и второй раз в них не ходить)
        - заполнить distances max и обновлять как min
        - int.maxvalue в конце превратить в -1
        - как перебирать дальше?
    */
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges) {
        var redTable = new Dictionary<int, List<int>>();
        var blueTable = new Dictionary<int, List<int>>();

        const int RED = 1;
        const int BLUE = 2;

        foreach (var edge in redEdges) {
            var from = edge[0];
            var to = edge[1];

            if (!redTable.ContainsKey(from)) {
                redTable[from] = new List<int>();
            }
            redTable[from].Add(to);
        }

        foreach (var edge in blueEdges) {
            var from = edge[0];
            var to = edge[1];

            if (!blueTable.ContainsKey(from)) {
                blueTable[from] = new List<int>();
            }
            blueTable[from].Add(to);
        }

        var distances = new int[n];
        var visitedBlue = new bool[n];
        var visitedRed = new bool[n];
        Array.Fill(distances, int.MaxValue);


        var queue = new Queue<(int vertex, int color, int length)>();
        queue.Enqueue((0, RED, 0));
        queue.Enqueue((0, BLUE, 0));
        visitedBlue[0] = true;
        visitedRed[0] = true;

        // process
        while (queue.Any()) {
            var ( vertex,  color,  length) = queue.Dequeue();
            distances[vertex] = Math.Min(length, distances[vertex]);

            if (color == RED) {
                if (!blueTable.ContainsKey(vertex)) {
                    continue;
                }

                foreach (var v in blueTable[vertex]) {
                    if (!visitedBlue[v]) {
                        queue.Enqueue((v, BLUE, length + 1));
                        visitedBlue[v] = true;
                    }
                }
            }
            else {
                if (!redTable.ContainsKey(vertex)) {
                    continue;
                }

                foreach (var v in redTable[vertex]) {
                    if (!visitedRed[v]) {
                        queue.Enqueue((v, RED, length + 1));
                        visitedRed[v] = true;
                    }
                }
            }
        }

        return distances.Select(x => x == int.MaxValue ? -1 : x).ToArray();
    }
}
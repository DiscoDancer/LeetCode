public class Solution
{
    //https://leetcode.com/problems/shortest-path-visiting-all-nodes/description/
    public int ShortestPathLength(int[][] graph)
    {
        if (graph.Length == 1)
        {
            return 0;
        }

        int n = graph.Length;
        int endingMask = (1 << n) - 1;
        
        var seen = new bool[n][];
        for (int i = 0; i < n; i++)
        {
            seen[i] = new bool[endingMask];
        }

        var queue = new Queue<(int node, int mask)>();
        for (int i = 0; i < n; i++)
        {
            queue.Enqueue((i, 1 << i));
            seen[i][1 << i] = true;
        }

        int steps = 0;
        while (queue.Any())
        {
            var nextQueue = new Queue<(int node, int mask)>();

            while (queue.Any())
            {
                var (node, mask) = queue.Dequeue();
                foreach (var neighbor in graph[node])
                {
                    int nextMask = mask | (1 << neighbor);
                    if (nextMask == endingMask)
                    {
                        return 1 + steps;
                    }

                    if (!seen[neighbor][nextMask])
                    {
                        seen[neighbor][nextMask] = true;
                        nextQueue.Enqueue((neighbor, nextMask));
                    }
                }
            }

            steps++;
            queue = nextQueue;
        }

        return -1;
    }
}
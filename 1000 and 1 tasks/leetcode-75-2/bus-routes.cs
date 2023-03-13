public class Solution {
    // bfs дает сразу минимум
    // таблица: stop => Buses(Routes)
    public int NumBusesToDestination(int[][] routes, int source, int target) {
        if (source == target) {
            return 0;
        }

        var table = new Dictionary<int, List<int[]>>();

        foreach (var route in routes) {
            foreach (var stop in route) {
                if (!table.ContainsKey(stop)) {
                    table[stop] = new ();
                }
                table[stop].Add(route);
            }
        }

        // идем по автобусам(маршрутам)
        var visitedRoutes = new HashSet<int[]>();
        var queue = new Queue<(int[] route, int generation)>();

        foreach (var route in table[source]) {
            queue.Enqueue((route, 1));
            visitedRoutes.Add(route);
        }

        while (queue.Any()) {
            var (curRoute, generation) = queue.Dequeue();
            foreach (var stop in curRoute) {
                if (stop == target) {
                    return generation;
                }
                foreach (var differentRoute in table[stop]) {
                    if (visitedRoutes.Add(differentRoute)) {
                        queue.Enqueue((differentRoute, generation + 1));
                    }
                }
            }
        }

        return -1;
    }
}
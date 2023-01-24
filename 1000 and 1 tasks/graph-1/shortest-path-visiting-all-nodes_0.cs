public class Solution {
    // nodes 0..n-1
    // graph[i] is a list of all the nodes connected with node i by an edge.
    // все соединены

    // пусть начинаем 0, какое было бы решение?
    // соседей считать не надо, все уже оптимально
    // мб считать высоту или количество детей?

    private int[][] _graph;

    public int f(int node, List<int> rest) {
        var notVisitedChildren = _graph[node]
            .Where(x => rest.Contains(x))
            .ToArray();

        if (notVisitedChildren.Length == 0) {
            return 0;
        }
        else if (notVisitedChildren.Length == 1) {
            var copy = rest.ToList();
            copy.Remove(notVisitedChildren[0]);
            return 1 + f(notVisitedChildren[0], copy);
        }
        else {
            var min = int.MaxValue;
            foreach (var child in notVisitedChildren) {
                var sum = 0;
                var restrest = notVisitedChildren.Except(new int[] {child}).ToArray();
                sum += 1 + f(child, restrest.ToList());

                foreach (var r in restrest) {
                    var copy = notVisitedChildren.ToList();
                    copy.Remove(r);
                    sum += 2 + 2*f(r, copy);
                }

                min = Math.Min(min, sum);
            }

            return min;
        }
    }

    // неверно, но иногда работает и не циклится
    public int ShortestPathLength(int[][] graph) {
        var N = graph.Length;
        _graph = graph;

        var min = int.MaxValue;

        for (int i = 0; i < N; i++) {
            var head = i;

            var rest = new List<int>();
            for (int j = 0; j < N; j++) {
                if (j != head) {
                    rest.Add(j);
                }    
            }

            min = Math.Min(min, f(head, rest));
        }

        return min;
    }
}
public class Solution {
    // n cities: 0..n-1
    // n-1 roads (minimum possible amount = tree)
    // want to make them 1 directional
    // connections[i] = [from, to]
    // root = 0

    /*
        Идеи: 
        - таблички out и in
        - обхожу дерево жопой вперед и делаю ++ исправленных стрелочек
    */

    public class Node {
        public Node(int val) {
            Val = val;
        }

        public int Val {get; set;} = 0;
        public List<Node> Children {get; set;} = new List<Node>();
    }

    public int MinReorder(int n, int[][] connections) {
        var tableFromTo = new Dictionary<int, List<int>>();
        var tableToFrom = new Dictionary<int, List<int>>();

        foreach (var connection in connections) {
            var from = connection[0];
            var to = connection[1];

            if (!tableFromTo.ContainsKey(from)) {
                tableFromTo[from] = new List<int>();
            }
            tableFromTo[from].Add(to);

            
            if (!tableToFrom.ContainsKey(to)) {
                tableToFrom[to] = new List<int>();
            }
            tableToFrom[to].Add(from);
        }

        var root = new Node(0);

        var visited = new bool[n];
        var queue = new Queue<(int val, Node parent)>();
        queue.Enqueue((0, root));
        visited[0] = true;

        // строим n-рное дерево

        while (queue.Any()) {
            var (vertex, node) = queue.Dequeue();

            var children = new List<int>();
            if (tableFromTo.ContainsKey(vertex)) {
                children.AddRange(tableFromTo[vertex]);
            }
            if (tableToFrom.ContainsKey(vertex)) {
                children.AddRange(tableToFrom[vertex]);
            }
            
            foreach (var child in children) {
                if (visited[child])
                {
                    continue;
                }
                var childNode = new Node(child);
                node.Children.Add(childNode);
                queue.Enqueue((child, childNode));
                visited[child] = true;
            }
        }

        var countWrong = 0;
        var queue2 = new Queue<Node>();
        queue2.Enqueue(root);

        while (queue2.Any()) {
            var cur = queue2.Dequeue();

            foreach (var child in cur.Children) {
                // if direction is wrong -> countWrong++;
                if (tableFromTo.ContainsKey(cur.Val)) {
                    if (tableFromTo[cur.Val].Contains(child.Val)) {
                        countWrong++;
                    }
                }
                queue2.Enqueue(child);
            }
        }

        return countWrong;
    }
}
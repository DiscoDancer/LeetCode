public class Codec {
    // Encodes an n-ary tree to a binary tree.
    public string serialize(Node root)
    {
        if (root == null)
        {
            return null;
        }
        
        var sbValues = new StringBuilder();
        var sbRelationships = new StringBuilder();
        
        var queue = new Queue<Node>();
        queue.Enqueue(root);

        var table = new Dictionary<Node, int>();
        var nodeCount = 0;

        table[root] = nodeCount++;
        sbValues.Append($"{table[root]},{root.val};");
        
        while (queue.Any()) {
            var size = queue.Count();
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                var childIds = new List<int>();
                foreach (var child in cur.children) {
                    table[child] = nodeCount++;
                    sbValues.Append($"{table[child]},{child.val};");
                    childIds.Add(table[child]);
                    queue.Enqueue(child);
                }
                
                sbRelationships.Append($"{table[cur]}:");
                for (int j = 0; j < childIds.Count(); j++)
                {
                    sbRelationships.Append($"{childIds[j]}");
                    if (j != childIds.Count() - 1)
                    {
                        sbRelationships.Append(',');
                    }
                }

                sbRelationships.Append(';');
            }

        }
        
        return $"{sbValues.ToString()}%{sbRelationships.ToString()}";
    }
    
    // Decodes your binary tree to an n-ary tree.
    public Node deserialize(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return null;
        }
        
        var split = data.Split('%');
        
        var sbValues = split[0];
        var sbRelationships = split[1];
        
        var table = new Dictionary<int, Node>();

        split = sbValues.Split(';');
        foreach (var s in split)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                continue;
            }

            var subsplit = s.Split(',');
            var node = new Node(int.Parse(subsplit[1]), new List<Node>() {});
            table[int.Parse(subsplit[0])] = node;
        }

        split = sbRelationships.Split(';');
        foreach (var s in split)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                continue;
            }

            var subsplit = s.Split(':');
            var node = table[int.Parse(subsplit[0])];

            if (!string.IsNullOrWhiteSpace(subsplit[1]))
            {
                var subsubsplit = subsplit[1].Split(',');
                foreach (var ss in subsubsplit)
                {
                    if (string.IsNullOrWhiteSpace(ss))
                    {
                        continue;
                    }

                    var child = table[int.Parse(ss)];
                    node.children.Add(child);
                }
            }
        }

        if (table.Count == 0)
        {
            return null;
        }

        return table[0];
    }
}
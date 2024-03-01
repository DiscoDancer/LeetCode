public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(Node root)
    {
        if (root == null)
        {
            return "";
        }

        var nodeToIndexTable = new Dictionary<Node, int>();
        var nodeToParentTable = new Dictionary<Node, Node>();

        var queue = new Queue<(Node node, Node parent)>();
        if (root != null)
        {
            queue.Enqueue((root, null));
        }

        var processedCount = 0;
        while (queue.Any())
        {
            var childrenCount = queue.Count;
            for (int i = 0; i < childrenCount; i++)
            {
                var (node, parent) = queue.Dequeue();
                nodeToParentTable[node] = parent;
                nodeToIndexTable[node] = processedCount++;

                if (node.children != null)
                {
                    foreach (var child in node.children)
                    {
                        queue.Enqueue((child, node));
                    }
                }
            }
        }

        var sb = new StringBuilder();

        sb.Append(processedCount);
        sb.Append(':');

        foreach (var (node, index) in nodeToIndexTable)
        {
            sb.Append($"{node.val};{index}");
            sb.Append('?');
        }
        sb.Remove(sb.Length - 1, 1);
        
        sb.Append(':');
        
        foreach (var (node, parent) in nodeToParentTable)
        {
            sb.Append($"{nodeToIndexTable[node]};{(parent == null ? -1 : nodeToIndexTable[parent])}");
            sb.Append('?');
        }
        sb.Remove(sb.Length - 1, 1);

        return sb.ToString();
    }
	
    // Decodes your encoded data to tree.
    public Node deserialize(string data) {
        if (string.IsNullOrWhiteSpace(data))
        {
            return null;
        }

        var valuesParents = data.Split(':');
        var nodeCount = int.Parse(valuesParents[0]);
        var values = valuesParents[1];
        var parents = valuesParents[2];

        var indexToNode = new Node[nodeCount];
        foreach (var valIndex in values.Split('?'))
        {
            var split = valIndex.Split(';');
            var val = int.Parse(split[0]);
            var index = int.Parse(split[1]);
            indexToNode[index] = new Node(val, new List<Node>());
        }

        Node root = null;
        foreach (var nodeParent in parents.Split('?'))
        {
            var split = nodeParent.Split(';');
            var nodeIndex = int.Parse(split[0]);
            var parentIndex = int.Parse(split[1]);

            var node = indexToNode[nodeIndex];
            if (parentIndex == -1)
            {
                root = node;
            }
            else
            {
                var parent = indexToNode[parentIndex];
                parent.children.Add(node);
            }
        }

        return root;
    }
}
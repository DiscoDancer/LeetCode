public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(Node root)
    {
        if (root == null)
        {
            return "";
        }
        
        var values = new List<int>();
        var nodeIndexToParentIndexTable = new Dictionary<int, int>();

        var queue = new Queue<(Node node, int parentIndex)>();
        if (root != null)
        {
            queue.Enqueue((root, -1));
        }

        var processedCount = 0;
        while (queue.Any())
        {
            var childrenCount = queue.Count;
            for (int i = 0; i < childrenCount; i++)
            {
                var (node, parentIndex) = queue.Dequeue();
                var nodeIndex = processedCount++;
                // nodeToIndexTable[node] = nodeIndex;
                values.Add(node.val);
                nodeIndexToParentIndexTable[nodeIndex] = parentIndex;


                foreach (var child in node.children)
                {
                    queue.Enqueue((child, nodeIndex));
                }
            }
        }

        var sb = new StringBuilder();

        sb.Append(processedCount);
        sb.Append(':');

        for (int i = 0; i < values.Count; i++)
        {
            sb.Append($"{values[i]};{i}");
            sb.Append('?');
        }
        sb.Remove(sb.Length - 1, 1);
        
        sb.Append(':');
        
        foreach (var (nodeIndex, parentIndex) in nodeIndexToParentIndexTable)
        {
            sb.Append($"{nodeIndex};{parentIndex}");
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
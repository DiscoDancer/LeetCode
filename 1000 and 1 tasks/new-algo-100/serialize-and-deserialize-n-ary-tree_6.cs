// это работает потому при построении я гарантирую, что потомок всегда будет после предка!

public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(Node root)
    {
        if (root == null)
        {
            return "";
        }
        
        var nodeList = new List<(int value, int id, int parentId)>();

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
                
                nodeList.Add((node.val, nodeIndex, parentIndex));
                
                foreach (var child in node.children)
                {
                    queue.Enqueue((child, nodeIndex));
                }
            }
        }

        var sb = new StringBuilder();

        sb.Append(processedCount);
        sb.Append('?');

        foreach (var (value, id, parentId) in nodeList)
        {
            sb.Append($"{value};{id};{parentId}:");
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

        var split1 = data.Split('?');
        var count = int.Parse(split1[0]);
        
        var tree = new Node[count];
        foreach (var str in split1[1].Split(':'))
        {
            var split = str.Split(';');
            var val = int.Parse(split[0]);
            var index = int.Parse(split[1]);
            var parentIndex = int.Parse(split[2]);

            tree[index] = new Node(val, new List<Node>());
            
            if (parentIndex != -1)
            {
                var parent = tree[parentIndex];
                parent.children.Add(tree[index]);
            }
        }
        
        return tree[0];
    }
}
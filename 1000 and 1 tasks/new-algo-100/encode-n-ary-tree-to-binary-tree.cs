/*

fake root

left line = list of nodes

- their right is their index

right line = list of nodes

[index, parent index]

inspired by https://leetcode.com/problems/serialize-and-deserialize-n-ary-tree/description/?envType=study-plan-v2&envId=premium-algo-100

*/


public class Codec
{
    // Encodes an n-ary tree to a binary tree.
    public TreeNode encode(Node root)
    {
        
        var queue = new Queue<(Node node, int parentIndex)>();
        if (root != null)
        {
            queue.Enqueue((root, -1));
        }

        var fakeRoot = new TreeNode(-1);
        var leftMost = fakeRoot;
        var rightMost = fakeRoot;
        
        var processedCount = 0;
        while (queue.Any())
        {
            var childrenCount = queue.Count;
            for (var i = 0; i < childrenCount; i++)
            {
                var (node, parentIndex) = queue.Dequeue();
                var nodeIndex = processedCount++;

                var encodedLeft = new TreeNode(node.val)
                {
                    right = new TreeNode(nodeIndex),
                };

                leftMost.left = encodedLeft;
                leftMost = leftMost.left;

                var encodedRight = new TreeNode(nodeIndex)
                {
                    left = new TreeNode(parentIndex),
                };
                rightMost.right = encodedRight;
                rightMost = rightMost.right;
                
                foreach (var child in node.children ?? new List<Node>())
                {
                    queue.Enqueue((child, nodeIndex));
                }
            }
        }

        fakeRoot.val = processedCount;

        return fakeRoot;
    }

    // Decodes your binary tree to an n-ary tree.
    public Node decode(TreeNode fakeRoot)
    {
        var processedCount = fakeRoot.val;
        var nodes = new Node[processedCount];

        var leftPointer = fakeRoot.left;
        while (leftPointer != null)
        {
            var index = leftPointer.right.val;
            var value = leftPointer.val;

            nodes[index] = new Node(value, new List<Node>());
            
            leftPointer = leftPointer.left;
        }

        var rightPointer = fakeRoot.right;
        while (rightPointer != null)
        {
            var nodeIndex = rightPointer.val;
            var parentIndex = rightPointer.left.val;

            if (parentIndex >= 0)
            {
                nodes[parentIndex].children.Add(nodes[nodeIndex]);
            }

            rightPointer = rightPointer.right;
        }


        return processedCount == 0 ? null : nodes[0];
    }
}
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

        // номер -> значение; 
        // номер -> left; right

        // private Dictionary<TreeNode, int> _nodeToIndex = new ();
        private int _nodesCount = 0;

        private void DFS(TreeNode root, Dictionary<TreeNode, int> nodeToIndex) {
            if (root == null) {
                return;
            }

            nodeToIndex[root] = _nodesCount++;

            if (root.left != null) {
                DFS(root.left, nodeToIndex);
            }
            if (root.right != null) {
                DFS(root.right, nodeToIndex);
            }
        }

        private string GetNodesToValue(Dictionary<TreeNode, int> _nodeToIndex) {
            var sb = new StringBuilder();
            foreach (var k in _nodeToIndex.Keys) {
                sb.Append($"{_nodeToIndex[k]}={k.val};");
            }
            return sb.ToString();
        }

        private string GetNodesToChildren(Dictionary<TreeNode, int> _nodeToIndex) {
            var sb = new StringBuilder();
            foreach (var k in _nodeToIndex.Keys) {
                var left = k.left == null ? - 1 : _nodeToIndex[k.left];
                var right = k.right == null ? - 1 : _nodeToIndex[k.right];
                sb.Append($"N:{_nodeToIndex[k]},L:{left},R:{right};");
            }
            return sb.ToString();
        }

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            var nodeToIndex = new Dictionary<TreeNode, int>();
            DFS(root, nodeToIndex);
            return GetNodesToValue(nodeToIndex) + "?" + GetNodesToChildren(nodeToIndex) + "?" + (root == null ? "" : nodeToIndex[root]);
        }

        private Dictionary<int, TreeNode> BuildDic(string nodesToValue) {
            var dic = new Dictionary<int, TreeNode>();
            var split = nodesToValue.Split(';');
            foreach (var s in split) {
                if (s.Length == 0) {
                    continue;
                }
                var split2 = s.Split('=');
                var index = int.Parse(split2[0]);
                var value = int.Parse(split2[1]);
                dic[index] = new TreeNode(value);
            }

            return dic;
        }

        private void Relate(Dictionary<int, TreeNode> dic, string nodesToChildren)
        {
            var split = nodesToChildren.Split(';');
            foreach (var s in split)
            {
                if (s.Length == 0) {
                    continue;
                }

                var NLR = s.Split(',');

                var nodeIndex = int.Parse(NLR[0].Split(':')[1]);
                var leftIndex = int.Parse(NLR[1].Split(':')[1]);
                var rightIndex = int.Parse(NLR[2].Split(':')[1]);

                if (leftIndex != -1)
                {
                    dic[nodeIndex].left = dic[leftIndex];
                }
                if (rightIndex != -1)
                {
                    dic[nodeIndex].right = dic[rightIndex];
                }
            }
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data) {
            var split = data.Split('?');
            var nodesToValue = split[0];
            var nodesToChildren = split[1];
            var root = split[2];

            if (root.Length == 0)
            {
                return null;
            }
            
            var dic = BuildDic(nodesToValue);
            Relate(dic, nodesToChildren);

            return dic[int.Parse(root)];
        }
    }

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
import java.util.*;

// no deep copy

class Solution {

    private TreeNode deepCopy(TreeNode root) {
        if (root == null) {
            return null;
        }

        var table = new HashMap<TreeNode, TreeNode>();
        var queue = new LinkedList<TreeNode>();
        queue.add(root);

        while (!queue.isEmpty()) {
            var current = queue.poll();
            var mapped = table.get(current);
            if (mapped == null) {
                mapped = new TreeNode(current.val);
                table.put(current, mapped);
            }

            var left = current.left;
            if (left != null) {
                var mappedLeft = table.get(left);
                if (mappedLeft == null) {
                    mappedLeft = new TreeNode(left.val);
                    table.put(left, mappedLeft);
                }
                mapped.left = mappedLeft;
                queue.add(left);
            }
            var right = current.right;
            if (right != null) {
                var mappedRight = table.get(right);
                if (mappedRight == null) {
                    mappedRight = new TreeNode(right.val);
                    table.put(right, mappedRight);
                }
                mapped.right = mappedRight;
                queue.add(right);
            }
        }

        return table.get(root);
    }

    // 1 2 3
    private List<TreeNode> generateBaseCase(List<Integer> list) {
        var n = list.size();
        if (n == 0) {
            List<TreeNode> res = new ArrayList<>();
            res.add(null);
            return res;
        }
        if (n == 1) {
            return List.of(new TreeNode(list.get(0)));
        }
        if (n == 2) {
            var n1_1 = new TreeNode(list.get(0));

            n1_1.right = new TreeNode(list.get(1));

            var n2_2 = new TreeNode(list.get(1));

            n2_2.left = new TreeNode(list.get(0));

            return List.of(n1_1, n2_2);
        }
        if (n == 3) {
            // case 1
            var n1_1 = new TreeNode(list.get(0));
            var n2_1 = new TreeNode(list.get(1));
            var n3_1 = new TreeNode(list.get(2));

            n1_1.right = n3_1;
            n3_1.left = n2_1;

            // case 2
            var n1_2 = new TreeNode(list.get(0));
            var n2_2 = new TreeNode(list.get(1));
            var n3_2 = new TreeNode(list.get(2));

            n1_2.right = n2_2;
            n2_2.right = n3_2;

            // case 3
            var n1_3 = new TreeNode(list.get(0));
            var n2_3 = new TreeNode(list.get(1));
            var n3_3 = new TreeNode(list.get(2));

            n2_3.left = n1_3;
            n2_3.right = n3_3;

            // case 4
            var n1_4 = new TreeNode(list.get(0));
            var n2_4 = new TreeNode(list.get(1));
            var n3_4 = new TreeNode(list.get(2));

            n3_4.left = n2_4;
            n2_4.left = n1_4;

            // case 5
            var n1_5 = new TreeNode(list.get(0));
            var n2_5 = new TreeNode(list.get(1));
            var n3_5 = new TreeNode(list.get(2));

            n3_5.left = n1_5;
            n1_5.right = n2_5;


            return List.of(n1_1, n1_2, n2_3, n3_4, n3_5);
        }

        // n >= 4
        List<TreeNode> result = new ArrayList<>();

        var lessThan = new ArrayList<Integer>();
        var greaterThan = new ArrayList<Integer>();

        for (var i = 1; i < list.size(); i++) {
            greaterThan.add(list.get(i));
        }

        for (var rootValue: list) {
            var lefts = generateBaseCase(lessThan);
            var rights = generateBaseCase(greaterThan);

            for (var left : lefts) {
                for (var right : rights) {
                    var root = new TreeNode(rootValue);
                    root.left = left;
                    root.right = right;
                    result.add(root);
                }
            }

            lessThan.add(rootValue);
            if (greaterThan.size() > 0) {
                greaterThan.removeFirst();
            }
        }

        return result;
    }

    public List<TreeNode> generateTrees(int n) {
        List<Integer> list = new ArrayList<>();
        for (var i = 1; i <= n; i++) {
            list.add(i);
        }

        return generateBaseCase(list);
    }
}
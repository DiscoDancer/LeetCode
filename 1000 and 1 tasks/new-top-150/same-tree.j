import java.util.*;

class Solution {
    public boolean isSameTree(TreeNode p, TreeNode q) {
        Queue<TreeNode> queueP = new LinkedList<>();
        Queue<TreeNode> queueQ = new LinkedList<>();

        if (p == null && q != null || p != null && q == null) {
            return false;
        }

        // either both are null or both are not null
        if (p != null) {
            queueP.add(p);
            queueQ.add(q);
        }

        while (!queueP.isEmpty() && !queueQ.isEmpty()) {
            var nodeP = queueP.poll();
            var nodeQ = queueQ.poll();

            if (nodeP.val != nodeQ.val) {
                return false;
            }

            if (nodeP.left == null && nodeQ.left != null) {
                return false;
            }
            if (nodeP.right == null && nodeQ.right != null) {
                return false;
            }

            if (nodeP.left != null && nodeQ.left == null) {
                return false;
            }
            if (nodeP.right != null && nodeQ.right == null) {
                return false;
            }

            // either both are null or both are not null
            if (nodeP.left != null) {
                queueP.add(nodeP.left);
                queueQ.add(nodeQ.left);
            }
            // either both are null or both are not null
            if (nodeP.right != null) {
                queueP.add(nodeP.right);
                queueQ.add(nodeQ.right);
            }
        }


        return true;
    }
}
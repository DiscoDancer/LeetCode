import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

class Solution {



    public List<Integer> inorderTraversal(TreeNode root) {
        var result = new ArrayList<Integer>();

        // надо не зациклиться
        // нужен current
        Stack<TreeNode> stack = new Stack<>();
        TreeNode current = root;
        while (current != null || !stack.isEmpty()) {
            if (current != null) {
                while (current.left != null) {
                    stack.push(current);
                    current = current.left;
                }
            }
            else {
                current = stack.pop();
            }
            result.add(current.val);
            current = current.right;
        }

        return result;
    }

    public void flatten(TreeNode root) {
        return;
    }
}
import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

class Solution {



    public List<Integer> preorderTraversal(TreeNode root) {
        var result = new ArrayList<Integer>();

        Stack<TreeNode> stack = new Stack<>();
        TreeNode current = root;
        while (current != null || !stack.isEmpty()) {
            if (current != null) {
                while (current != null) {
                    result.add(current.val);
                    if (current.right != null) {
                        stack.push(current.right);
                    }
                    current = current.left;
                }
            }
            else {
                current = stack.pop();
            }
        }

        return result;
    }

    public void flatten(TreeNode root) {
        return;
    }
}
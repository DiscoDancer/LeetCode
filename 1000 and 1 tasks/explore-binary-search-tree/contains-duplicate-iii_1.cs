public class Solution {
    // по индексам - это окружность
    // если знать min/max на range - можно за O(n) сделать по if(ам)
    // sliding window
    
    // BST + sliding windows (все операции logn inset, search, delete)
    // sliding window гарантирует, что все элементы в дереве попадают по индексу
    // нужно только быстро проверить, если ли там достаточно близкие
    // O(n) не то, но Olog пойдет. Но как его получить?
    // а если считать при построении дерева min diff c родителем. Мб надо еще с братом? (на вид нет)
    
    // вроде может получиться
    
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }

        var p = root;

        while (true)
        {
            if (Math.Abs(p.val - val) <= _valueDiff)
            {
                _hasValue = true;
            }
            
            if (val > p.val)
            {
                if (p.right == null)
                {
                    p.right = new TreeNode(val);
                    return root;
                }
                else
                {
                    p = p.right;
                }
            }
            else if (val < p.val)
            {
                if (p.left == null)
                {
                    p.left = new TreeNode(val);
                    return root;
                }
                else
                {
                    p = p.left;
                }
            }
            else
            {
                _hasValue = true;
                return root;
            }
        }

        return root;
    }
    
    private TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        var leftMost = root;
        var stack = new Stack<TreeNode>();

        TreeNode? prev = null;

        while (leftMost != null || stack.Any())
        {
            while (leftMost != null)
            {
                stack.Push(leftMost);
                leftMost = leftMost.left;
            }

            var cur = stack.Pop();
            if (p == prev)
            {
                return cur;
            }
            prev = cur;

            leftMost = cur.right;
        }

        return null;
    }
    
    
    public enum ParentState
    {
        Root,
        Left,
        Right
    }
    
     public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null) return null;

        var parentState = ParentState.Root;
        TreeNode parent = null;
        var p = root;

        while (p != null)
            if (p.val == key)
            {
                if (p.left == null && p.right == null)
                {
                    if (parentState == ParentState.Root) return null;

                    if (parentState == ParentState.Left)
                        parent.left = null;
                    else if (parentState == ParentState.Right) parent.right = null;
                    return root;
                }
                else if (p.left == null && p.right != null)
                {
                    if (parentState == ParentState.Root)
                        return p.right;
                    if (parentState == ParentState.Left)
                        parent.left = p.right;
                    else if (parentState == ParentState.Right) parent.right = p.right;
                    return root;
                }
                else if (p.left != null && p.right == null)
                {
                    if (parentState == ParentState.Root)
                        return p.left;
                    if (parentState == ParentState.Left)
                        parent.left = p.left;
                    else if (parentState == ParentState.Right) parent.right = p.left;
                    return root;
                }
                else if (p.left != null && p.right != null)
                {
                    var inorderSuccessor = InorderSuccessor(root, p);
                    p.val = inorderSuccessor.val;
                    key = inorderSuccessor.val;
                    parent = p;
                    parentState = ParentState.Right;
                    p = p.right;
                }
            }
            else if (key < p.val)
            {
                parent = p;
                parentState = ParentState.Left;
                p = p.left;
            }
            else if (key > p.val)
            {
                parent = p;
                parentState = ParentState.Right;
                p = p.right;
            }

        return root;
    }

    private int _valueDiff;
    private bool _hasValue = false;
    
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
    {
        _valueDiff = valueDiff;

        indexDiff = Math.Min(indexDiff, nums.Length - 1);
        
        
        var l = 0;
        var r = indexDiff;

        
        // initial build
        TreeNode root = null;
        for (int i = 0; i <= indexDiff; i++)
        {
            root = InsertIntoBST(root, nums[i]);
        }
        if (_hasValue)
        {
            return true;
        }
        
        while (r < nums.Length - 1)
        {
            // rebuild

            _hasValue = false;
            root = DeleteNode(root, nums[l]);
            root = InsertIntoBST(root, nums[r + 1]);
            if (_hasValue)
            {
                return true;
            }
            
            l++;
            r++;
        }

        return false;
    }
}
public class Solution {
    // editorial
    public bool VerifyPreorder(int[] preorder) {
        var minLimit = int.MinValue;
        var stack = new Stack<int>();
        
        foreach (var num in preorder) {
            while (stack.Any() && stack.Peek() < num) {
                minLimit = stack.Pop();
            }
            
            if (num <= minLimit) {
                return false;
            }
            
            stack.Push(num);
        }
        
        return true;
    }
}
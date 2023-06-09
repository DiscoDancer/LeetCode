public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();

        foreach (var c in s) {
            if (c == '(' || c == '{' || c == '[') {
                stack.Push(c);
            }
            else if (!stack.Any()) {
                return false;
            }
            else if (c == ')' && stack.Peek() != '(') {
                return false;
            }
            else if (c == '}' && stack.Peek() != '{') {
                return false;
            }
            else if (c == ']' && stack.Peek() != '[') {
                return false;
            }
            else {
                stack.Pop();
            }
        }

        return !stack.Any();
    }
}
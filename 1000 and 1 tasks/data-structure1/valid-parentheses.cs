public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();

        foreach (var c in s) {
            if (c == '(' || c == '{' || c == '[') {
                stack.Push(c);
                continue;
            }

            if (c == ')' || c == '}' || c == ']') {
                if (!stack.Any()) {
                    return false;
                }

                var pop = stack.Pop();
                if (c == ')' && pop != '(' ) {
                    return false;
                }
                if (c == ']' && pop != '[' ) {
                    return false;
                }
                if (c == '}' && pop != '{' ) {
                    return false;
                }
            }
        }

        return !stack.Any();
    }
}
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.Stack;

class Solution {

    public boolean isValid(String s) {
        var stack = new Stack<Character>();
        for (var c : s.toCharArray()) {
            if (c == '(' || c == '[' || c == '{') {
                stack.push(c);
            } else {
                if (stack.isEmpty()) {
                    return false;
                }
                var top = stack.pop();
                if (c == ')' && top != '(') {
                    return false;
                }
                if (c == ']' && top != '[') {
                    return false;
                }
                if (c == '}' && top != '{') {
                    return false;
                }
            }
        }
        
        return stack.isEmpty();
    }
}
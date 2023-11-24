public class Solution {
    public bool ConfusingNumber(int n) {
        var digits = (n + "").ToCharArray();
        var stack = new Stack<char>();
        foreach (var d in digits) {
            if (d == '2' || d == '3' || d == '4' || d == '5' || d == '7') {
                return false;
            }
            if (!stack.Any() && d == '0') {
                // ignore leading zeroes
            }
            else {
                if (d == '6') {
                    stack.Push('9');
                }
                else if (d == '9') {
                    stack.Push('6');
                }
                else {
                    stack.Push(d);
                }
            }
        }

        var i = 0;
        while (stack.Any()) {
            var c = stack.Pop();
            if (digits[i++] != c) {
                return true;
            }
        }

        // i == 0 // либо n == 0, либо были только нули
        return i == digits.Length || i == 0 ? false : true;
    }
}
public class Solution {
    public string DecodeString(string s) {
        var stack = new Stack<string>();

        foreach (var c in s) {
            if (c != ']') {
                stack.Push(c.ToString());
                continue;
            }

            var sb = new StringBuilder();
            while (stack.Peek() != "[") {
                sb.Insert(0, stack.Pop());
            }
            var chars = sb.ToString();
            stack.Pop(); // [

            sb = new StringBuilder();
            while (stack.Any() && stack.Peek()[0] >= '0' && stack.Peek()[0] <= '9') {
                sb.Insert(0, stack.Pop());
            }
            var digits = sb.ToString();

            sb = new StringBuilder();
            for (int i = 0; i < int.Parse(digits); i++) {
                sb.Append(chars);
            }

            stack.Push(sb.ToString());

            // foreach (var cc in sb.ToString()) {
            //     stack.Push(cc.ToString());
            // }
        }

        var resultSb = new StringBuilder();
        while (stack.Any()) {
            resultSb.Insert(0, stack.Pop());
        }

        return resultSb.ToString();
    }
}
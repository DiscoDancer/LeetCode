public class Solution {
    public string DecodeString(string s) {
        var stack = new Stack<string>();
        for (int i = 0; i < s.Length; i++) {
            var c = s[i];
            if (c != ']') {
                stack.Push(c + "");
            } else {
                var sb = new StringBuilder();
                while (stack.Peek() != "[") {
                    sb.Insert(0, stack.Pop());
                }

                stack.Pop(); // remove [

                var str = sb.ToString();

                sb = new StringBuilder();
                while (stack.Any() && char.IsDigit(stack.Peek()[0])) {
                    sb.Insert(0, stack.Pop());
                }

                var num = int.Parse(sb.ToString());

                var res = "";
                for (int j = 0; j < num; j++) {
                    res += str;
                }

                stack.Push(res);
            }
        }


        // чистим в конце
        var result = new StringBuilder();
        while (stack.Any()) {
            result.Insert(0, stack.Pop());
        }

        return result.ToString();
    }
}
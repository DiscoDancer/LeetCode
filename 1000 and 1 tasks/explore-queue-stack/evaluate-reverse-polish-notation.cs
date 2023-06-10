public class Solution {
    private (int? num, char? op) Parse(string token) {
        if (token == "+" || token == "-" || token == "*" || token == "/") {
            return (null, token[0]);
        }

        return (int.Parse(token), null);
    }

    private int Calc(int a, int b, char op) {
        if (op == '+') {
            return a + b;
        }
        if (op == '-') {
            return a - b;
        }
        if (op == '*') {
            return a * b;
        }
        if (op == '/') {
            return a / b;
        }

        throw new ArgumentException(nameof(op));
    }

    public int EvalRPN(string[] tokens) {
        var stack = new Stack<(int? num, char? op)>();

        foreach(var token in tokens) {
            stack.Push(Parse(token));

            while (stack.Peek().op != null) {
                char op = stack.Pop().op.Value;
                int b = stack.Pop().num.Value;
                int a = stack.Pop().num.Value;
                var result = Calc(a,b,op);
                stack.Push((result, null));
            }
        }

        return stack.Pop().num.Value;
    }
}
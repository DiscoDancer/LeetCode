public class Solution
{
    private string Calc(int a, int b, string t)
    {
        switch (t)
        {
            case "+":
                return a + b + "";
            case "-":
                return a - b + "";
            case "*":
                return a * b + "";
            case "/":
                return a / b + "";
            default:
                throw new ArgumentException(nameof(t));
        }
        throw new ArgumentException(nameof(t));
    }

    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<string>();
        var ops = new string[] { "+", "-", "*", "/" };
        foreach (var t in tokens)
        {
            if (!ops.Contains(t))
            {
                stack.Push(t);
            }
            else
            {
                var b = int.Parse(stack.Pop());
                var a = int.Parse(stack.Pop());

                stack.Push(Calc(a, b, t));
            }
        }

        return int.Parse(stack.Pop());

    }
}
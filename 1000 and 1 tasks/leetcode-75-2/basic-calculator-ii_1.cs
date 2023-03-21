public class Solution {
    // https://leetcode.com/problems/basic-calculator-ii/editorial/
    public int Calculate(string s) {
        if (string.IsNullOrWhiteSpace(s))
        {
            return 0;
        }

        var stack = new Stack<int>();
        var currentNumber = 0;
        var operation = '+';

        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (char.IsDigit(c))
            {
                currentNumber = (currentNumber * 10) + (c - '0');
            }

            if (!char.IsDigit(c) && c != ' ' || i == s.Length - 1)
            {
                if (operation == '-')
                {
                    stack.Push(-currentNumber);
                }
                else if (operation == '+')
                {
                    stack.Push(currentNumber);
                }
                else if (operation == '*')
                {
                    stack.Push(stack.Pop() * currentNumber);
                }
                else if (operation == '/')
                {
                    stack.Push(stack.Pop() / currentNumber);
                }

                operation = c;
                currentNumber = 0;
            }
        }

        var result = 0;
        while (stack.Any())
        {
            result += stack.Pop();
        }
        return result;
    }
}
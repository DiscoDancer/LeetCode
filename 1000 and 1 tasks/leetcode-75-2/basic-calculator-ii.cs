public class Solution {
    private int EvalEasy(List<char> list)
    {
        var calcQueue = new Queue<(int? num, char? op)>();
        var bufferSB = new StringBuilder();

        for (int i = 0; i < list.Count; i++)
        {
            var c = list[i];
            if (char.IsDigit(c))
            {
                bufferSB.Append(c);
            }
            else
            {
                if (bufferSB.Length > 0)
                {
                    calcQueue.Enqueue((int.Parse(bufferSB.ToString()), null));
                    bufferSB = new StringBuilder();
                }
                calcQueue.Enqueue((null, c));
            }

            if (i == list.Count - 1 && bufferSB.Length > 0)
            {
                calcQueue.Enqueue((int.Parse(bufferSB.ToString()), null));
            }
        }

        var result = calcQueue.Dequeue().num;

        while (calcQueue.Count > 1)
        {
            var op = calcQueue.Dequeue().op;
            var b = calcQueue.Dequeue().num;
            if (op == '*')
            {
                result *= b;
            }
            else
            {
                result /= b;
            }
        }


        return result.Value;
    }

    // плюсы и минусы = островки
    public int Calculate(string s) {
        var list = new List<char>();
        var sign = '+';
        var sum = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];

            if (c == '+' || c == '-')
            {
                sum += EvalEasy(list) * (sign == '+' ? 1 : -1);
                list = new List<char>();
                sign = c;
            }
            else if (c != ' ')
            {
                list.Add(c);
            }

            if (i == s.Length - 1)
            {
                sum += EvalEasy(list) * (sign == '+' ? 1 : -1);
            }
        }

        return sum;
    }
}
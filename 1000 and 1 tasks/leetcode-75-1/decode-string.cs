public class Solution {

    // string builder can help
    // stack мб все только портит
    public string DecodeString(string s) {
        var stack = new Stack<string>();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] != ']') {
                stack.Push(s[i].ToString());
            }
            else {
                var buffer = new List<string>();
                while (stack.Peek() != "[") {
                    buffer.Add(stack.Pop());
                }
                stack.Pop(); // выкинули '['
                buffer.Reverse();
                var str = buffer.Aggregate((x,y) => x + y); // срока внутри []

                var numbers = new List<string>();
                while (stack.Any() && char.IsDigit(stack.Peek()[0])) {
                    numbers.Add(stack.Pop());
                }
                numbers.Reverse();
                var numStr = numbers.Aggregate((x,y) => x + y);
                var num = int.Parse(numStr);
                
                var newS = "";
                for (int j = 0; j < num; j++) {
                    newS += str;
                }

                stack.Push(newS);
            }
        }

        var res = new List<string>();

        while (stack.Any())
        {
            res.Add(stack.Pop());
        }

        res.Reverse();

        return res.Aggregate((x, y) => x + y);
    }
}
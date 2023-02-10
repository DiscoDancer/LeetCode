public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var N = temperatures.Length;
        var result = new int[N];
        var stack = new Stack<int>();

        for (int i = 0; i < N; i++) {
            while (stack.Any() && temperatures[stack.Peek()] < temperatures[i]) {
                var j = stack.Pop();
                result[j] = i-j;
            }
            stack.Push(i);
        }

        return result;
    }
}
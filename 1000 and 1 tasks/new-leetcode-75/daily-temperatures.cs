public class Solution {
    // квадрат легко
    // гистограмма o(n)k

    // мб в стек класть индексы (только индексы)
    public int[] DailyTemperatures(int[] temperatures) {
        var result = new int[temperatures.Length];
        var stack = new Stack<int>();
        stack.Push(0);

        for (int i = 1; i < temperatures.Length; i++) {
            var current = temperatures[i];
            if (current > temperatures[stack.Peek()]) {
                while (stack.Any() && current > temperatures[stack.Peek()]) {
                    var j = stack.Pop();
                    result[j] = i-j;
                }
                stack.Push(i);
            }
            else {
                stack.Push(i);
            }
        }

        while (stack.Any()) {
            var j = stack.Pop();
            result[j] = 0;
        }

        return result;

    }
}
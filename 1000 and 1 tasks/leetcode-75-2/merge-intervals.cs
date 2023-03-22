public class Solution {

    // более простой вариант в сравнении с insert interval
    public int[][] Merge(int[][] intervals) {
        var sorted = intervals.OrderBy(x => x[0]).ToArray();

        var stack = new Stack<int[]>();
        for (int i = sorted.Length - 1; i >= 0; i--) {
            stack.Push(sorted[i]);
        }

        var result = new List<int[]>();
        while (stack.Count() > 1) {
            var cur = stack.Pop();
            var next = stack.Pop();

            if (cur[1] >= next[0])
            {
                var a = Math.Min(cur[0], next[0]);
                var b = Math.Max(cur[1], next[1]);
                stack.Push(new[] {a, b});
            }
            else
            {
                stack.Push(next);
                result.Add(cur);
            }
        }

        while (stack.Any()) {
            result.Add(stack.Pop());
        }

        return result.ToArray();
    }
}
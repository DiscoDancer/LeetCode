public class Solution {
    // добавить в нужное место
    // bs
    // merge (prev и next?) - вообще в цикле

    private int BS(int[][] intervals, int[] newInterval) {
        var l = 0;
        var r = intervals.Length - 1;

        while (l <= r) {
            var m = l + (r-l)/2;
            if (intervals[m][0] <= newInterval[0]) {
                l = m + 1;
            }
            else {
                r = m - 1;
            }
        }

        return r + 1; // индекс куда вставить (алгоритм first bad version мой github )
    }

    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var list = intervals.ToList();
        var foundIndex = BS(intervals, newInterval);

        if (foundIndex <= intervals.Length - 1)
        {
            list.Insert(foundIndex, newInterval);
        }
        else
        {
            list.Add(newInterval);
        }

        var result = new List<int[]>();

        var curIndex = Math.Max(0, foundIndex - 1);

        for (int i = 0; i < curIndex; i++)
        {
            result.Add(list[i]);
        }

        var stack = new Stack<int[]>();
        for (var i = list.Count - 1; i >= curIndex; i--)
        {
            stack.Push(list[i]);
        }

        var breakCount = 0; // 2 потому что с конфликты могут быть со следующий и с предыдущим

        while (stack.Count > 1)
        {
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
                breakCount++;
                stack.Push(next);
                result.Add(cur);
                if (breakCount == 2)
                {
                    break;
                }
            }
        }

        while (stack.Any())
        {
            result.Add(stack.Pop());
        }

        return result.ToArray();
    }
}
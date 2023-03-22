public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        var stack = new Stack<int>();
        foreach (var asteroid in asteroids)
        {
            stack.Push(asteroid);
            while (stack.Count > 1)
            {
                var cur = stack.Pop();
                var next = stack.Pop();

                // пример -2, -1, 1, 2 не должен проходить => cur > 0 && next < 0
                if (cur < 0 && next < 0 || cur > 0 && next > 0 || cur > 0 && next < 0)
                {
                    stack.Push(next);
                    stack.Push(cur);
                    break;
                }
                else if (cur + next == 0)
                {
                    continue;
                }
                else
                {
                    if (Math.Abs(cur) > Math.Abs(next))
                    {
                        stack.Push(cur);
                    }
                    else
                    {
                        stack.Push(next);
                    }
                }
            }
        }

        var result = new int[stack.Count()];
        var i = result.Length - 1;
        while (stack.Any())
        {
            result[i--] = stack.Pop();
        }

        return result;
    }
}
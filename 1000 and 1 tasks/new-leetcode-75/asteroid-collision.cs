public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        var stack = new Stack<int>();

        foreach (var a in asteroids) {
            var isStackEmpty = !stack.Any();
            var isSameSign = stack.Any() && (stack.Peek() > 0 && a > 0 || a < 0 && stack.Peek() < 0);
            var isLR = stack.Any() && stack.Peek() < 0 && a > 0;
            if (isStackEmpty || isSameSign || isLR) {
                stack.Push(a);
                continue;
            }


            var aDestroyed = false;

            // а летит и ломает
            while (!aDestroyed && stack.Any() && stack.Peek() > 0 && a < 0 && Math.Abs(a) >= Math.Abs(stack.Peek()))  {
                if (Math.Abs(a) == Math.Abs(stack.Peek())) {
                    stack.Pop();
                    aDestroyed = true;
                }
                else {
                    stack.Pop();
                }
            }

            aDestroyed |= stack.Any() && stack.Peek() > 0 && a < 0 && Math.Abs(a) < Math.Abs(stack.Peek());

            // если все сломал - остался
            if (!aDestroyed) {
                stack.Push(a);
            }
        }

        var result = new int[stack.Count()];
        var i = stack.Count() - 1;
        while (stack.Any()) {
            result[i--] = stack.Pop();
        }

        return result;
    }
}
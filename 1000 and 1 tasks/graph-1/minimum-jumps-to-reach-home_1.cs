public class Solution {
    // 0 --> x 
    // a right, b left
    // нельзя назад 2 раза подряд
    // нельзя прыгать в forbidden
    // можно прыгать за x

    // visited объединить с forbidden

    // https://leetcode.com/problems/minimum-jumps-to-reach-home/solutions/978357/c-bidirectional-bfs-solution-with-proof-for-search-upper-bound/
    public int MinimumJumps(int[] forbidden, int a, int b, int x) {
        if (x == 0) {
            return 0;
        }

        var furtherest = a + b + x + forbidden.Max();

        var visited = new HashSet<int>();
        foreach (var f in forbidden) {
            visited.Add(f);
        }
        visited.Add(0);

        const int START = 0;
        const int FORWARD = 1;
        const int BACKWARD = 2;

        var queue = new Queue<(int index, int direction, int steps)>();
        queue.Enqueue((0, START, 0));

        var min = int.MaxValue;

        while (queue.Any()) {
            var (index, direction, steps) = queue.Dequeue();

            if (index == x) {
                min = Math.Min(min, steps);
                continue;
            }

            var back = index - b;
            var front = index + a;

            // can go back ?
            if (back >= 0 && direction != BACKWARD && !visited.Contains(back)) {
                visited.Add(back);
                queue.Enqueue((back, BACKWARD, steps + 1));
            }

            // can go further ?
            // тут вся сложность, до какого момент имеет смысл прыгать вперед ?
            if (front <= furtherest && !visited.Contains(front)) {
                visited.Add(front);
                queue.Enqueue((front, FORWARD, steps + 1));
            }
        }

        return min == int.MaxValue ? -1 : min;
    }
}
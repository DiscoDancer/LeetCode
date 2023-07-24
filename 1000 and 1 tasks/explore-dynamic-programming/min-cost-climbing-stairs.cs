public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        // точно верно
        if (cost.Length == 2) {
            return Math.Min(cost[0], cost[1]);
        }

        // типа изначально a и b взять бесплатно
        var a = 0;
        var b = 0;

        // нам надо попасть не в полследнюю точку, а в ту, которая за ней, поэтому + 1
        for (int i = 2; i < cost.Length + 1; i++) {
            // а потом, если мы их берем, то уже начинаем платить
            var c = Math.Min(a + cost[i-2], b + cost[i-1]);
            a = b;
            b = c;
        }

        return b;
    }
}
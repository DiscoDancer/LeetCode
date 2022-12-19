public class Solution {
    public int LastStoneWeight(int[] stones) {
        var max = stones.Max();
        var count = stones.Length;
        var table = new int[max + 1];

        foreach (var s in stones) table[s]++;

        var curWeight = max;
        while (count > 1)
        {
            while (table[curWeight] == 0) curWeight--;
            if (table[curWeight] > 1) {
                count -= table[curWeight] - table[curWeight] % 2;
                table[curWeight] = table[curWeight] % 2;
                continue;
            }

            var first = curWeight;
            table[curWeight]--;
            count--;

            while (table[curWeight] == 0) curWeight--;
            var second = curWeight;
            table[curWeight]--;
            count--;

            if (first != second)
            {
                table[first - second]++;
                curWeight = Math.Max(curWeight, first - second);
                count++;
            }
        }

        if (count == 0) return 0;

        while (table[curWeight] == 0) curWeight--;

        return curWeight;
    }
}
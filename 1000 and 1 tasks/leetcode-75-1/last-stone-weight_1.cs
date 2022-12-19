public class Solution {
    public int LastStoneWeight(int[] stones) {
        if (stones.Length == 1)
        {
            return stones.First();
        }
        
        var max = stones.Max();
        var count = stones.Length;
        var table = new int[max + 1];

        foreach (var s in stones) table[s]++;

        var curWeight = max;
        while (count > 1)
        {
            while (table[curWeight] == 0) curWeight--;
            var first = curWeight;
            table[curWeight]--;

            while (table[curWeight] == 0) curWeight--;
            var second = curWeight;
            table[curWeight]--;

            if (first == second)
            {
                count -= 2;
            }
            else
            {
                
                table[first - second]++;
                curWeight = Math.Max(curWeight, first - second);
                count -= 1;
            }
        }

        if (count == 0)
        {
            return 0;
        }

        while (table[curWeight] == 0)
        {
            curWeight--;
        }

        return curWeight;
    }
}
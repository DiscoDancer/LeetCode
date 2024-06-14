public class Solution {
    // Each child must have at least one candy.
    // Children with a higher rating get more candies than their neighbors.

    // топологическая сортировка
    // строим от меньшего
    public int Candy(int[] ratings) {
        var n = ratings.Length;

        var iLessThan = new List<int>[n];
        var iBiggerThan = new List<int>[n];

        for (int i = 0; i < n; i++) {
            iLessThan[i] = [];
            iBiggerThan[i] = [];
        }

        for (int i = 1; i < n; i++) {
            if (ratings[i-1] < ratings[i]) {
                iLessThan[i-1].Add(i);
                iBiggerThan[i].Add(i-1);
            }
            else if (ratings[i-1] > ratings[i]) {
                iLessThan[i].Add(i-1);
                iBiggerThan[i-1].Add(i);
            }
        }

        var queue = new Queue<(int i, int c)>();
        for (int i = 0; i < n; i++)
        {
            if (iBiggerThan[i].Count == 0)
            {
                queue.Enqueue((i, 1));
            }
        }

        var sum = 0;
        while (queue.Any())
        {
            var (i, c) = queue.Dequeue();
            sum += c;
            foreach (var j in iLessThan[i])
            {
                iBiggerThan[j].Remove(i);
                if (iBiggerThan[j].Count == 0)
                {
                    queue.Enqueue((j,c+1));
                }
            }
        }

        return sum;
    }
}
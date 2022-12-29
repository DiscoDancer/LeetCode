public class Solution {
    public int[] SortByBits(int[] arr) {
        const int TableSize = 32;
        var table = new List<int>[TableSize];

        foreach (var n in arr) {
            var k = n;
            var ones = 0;
            while (k > 0) {
                if (k % 2 == 1) {
                    ones++;
                }
                k = k >> 1;
            }
            if (table[ones] == null) {
                table[ones] = new List<int>();
            }
            table[ones].Add(n);
        }

        var list = new List<int>();
        for (int i = 0; i < TableSize; i++) {
            if (table[i] != null && table[i].Any()) {
                list.AddRange(table[i].OrderBy(x => x));
            }
        }

        return list.ToArray();
    }
}
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var tableNegative = new int[10001];
        var tablePositive = new int[10001];

        foreach (var n in nums) {
            if (n < 0) {
                tableNegative[-n]++;
            }
            else {
                tablePositive[n]++;
            }
        }

        var countTable = new List<int>[100001];

        for (int i = 0; i < 10001; i++) {
            if (tableNegative[i] > 0) {
                if (countTable[tableNegative[i]] == null) {
                    countTable[tableNegative[i]] = new();
                }
                countTable[tableNegative[i]].Add(-i);
            }
            if (tablePositive[i] > 0) {
                if (countTable[tablePositive[i]] == null) {
                    countTable[tablePositive[i]] = new();
                }
                countTable[tablePositive[i]].Add(i);
            }
        }

        var result = new List<int>();

        for (int i = 100000; i > 0; i--) {
            if (countTable[i] != null) {
                foreach (var n in countTable[i]) {
                    result.Add(n);
                    if (result.Count() == k) {
                        return result.ToArray();
                    }
                }
            }
        }

        return result.ToArray();
    }
}
public class Solution {
    public int ArrayPairSum(int[] nums) {
        // 0 пишем в позитивные
        var posivite = new int[10001];
        var negative = new int[10001];

        foreach (var n in nums) {
            if (n >= 0) {
                posivite[n]++;
            }
            else {
                negative[n*(-1)]++;
            }
        }

        var sum = 0;
        var index = 10000;
        int? remainder = null;
        while (index >= 0) {
            if (posivite[index] == 0) {
                index--;
                continue;
            }

            if (remainder != null) {
                sum += index;
                posivite[index]--;
                remainder = null;
            }
            while (posivite[index] >= 2) {
                sum += index;
                posivite[index] -= 2;
            }
            if (posivite[index] > 0) {
                remainder = index;
            }

            index--;
        }

        index = 0;
        while (index < 10001) {
            if (negative[index] == 0) {
                index++;
                continue;
            }

            if (remainder != null) {
                sum -= index;
                negative[index]--;
                remainder = null;
            }
            while (negative[index] >= 2) {
                sum -= index;
                negative[index] -= 2;
            }
            if (negative[index] > 0) {
                remainder = index;
            }

            index++;
        }

        return sum;
    }
}
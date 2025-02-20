import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedList;

class Solution {
    public int maxSubArray(int[] nums) {

        var max = Integer.MIN_VALUE;

        var lastPositiveSum = 0;
        var curPositiveSum = 0;
        var curNegativeSum = 0;

        final int PLUS = 1;
        final int MINUS = 2;

        var prevSign = PLUS;

        for (int num : nums) {
            max = Math.max(max, num);

            var sign = num >= 0 ? PLUS : MINUS;
            // в целом алгоритм очень простой, мы просто копим суммы положительных и отрицательных
            // обращаем внимание только на смену знака
            // положительное число - повод проверить текущую сумму
            if (sign != prevSign) {
                if (sign == PLUS) {
                    // пытаемся подцепить предыдущий остров, если имеет смысл
                    curPositiveSum += Math.max(0, curNegativeSum + lastPositiveSum);
                    curNegativeSum = 0;
                } else {
                    lastPositiveSum = curPositiveSum;
                    curPositiveSum = 0;
                }
            }
            if (sign == PLUS) {
                curPositiveSum += num;
                max = Math.max(max, curPositiveSum);

            } else {
                curNegativeSum += num;
            }
            prevSign = sign;
        }

        return max;
    }
}
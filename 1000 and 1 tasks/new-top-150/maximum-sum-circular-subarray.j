import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedList;

class Solution {

    // суть в том, что если будет поворот, то мы возьмем и слева и справа
    // значит в середине должен остаться минимум. И мы его как раз может найти через обычный Карган только наоборот.
    // тогда слева и српава будет просто остаток.
    // но отдельный случай, если все числа отрицательные, тогда мы просто берем максимальное число. Потому что иначе появится 0.

    public int maxSubarraySumCircular(int[] nums) {
        var normal = maxSubArray(nums);

        long sum = 0;
        var max = Integer.MIN_VALUE;
        for (int num : nums) {
            sum += num;
            max = Math.max(max, num);
        }

        if (max < 0) {
            return max;
        }

        return Math.max(normal, (int)(sum - minSubArray(nums)));
    }

    public int minSubArray(int[] nums) {
        var min = Integer.MAX_VALUE;

        var curPositiveSum = 0;
        var curNegativeSum = 0;
        var lastNegativeSum = 0;

        final int PLUS = 1;
        final int MINUS = 2;

        var prevSign = PLUS;

        for (int num : nums) {
            min = Math.min(min, num);

            var sign = num >= 0 ? PLUS : MINUS;
            // в целом алгоритм очень простой, мы просто копим суммы положительных и отрицательных
            // обращаем внимание только на смену знака
            // положительное число - повод проверить текущую сумму
            if (sign != prevSign) {
                if (sign == PLUS) {

                    lastNegativeSum = curNegativeSum;
                    curNegativeSum = 0;
                } else {
                    // пытаемся подцепить предыдущий остров, если имеет смысл
                    curNegativeSum += Math.min(0, curPositiveSum + lastNegativeSum);
                    curPositiveSum = 0;
                }
            }
            if (sign == PLUS) {
                curPositiveSum += num;
            } else {
                curNegativeSum += num;
                min = Math.min(min, curNegativeSum);
            }
            prevSign = sign;
        }

        return min;
    }

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
import java.util.Arrays;
import java.util.LinkedList;

class Solution {
    public int maxSubArray(int[] nums) {

        var max = Integer.MIN_VALUE;

        // max can be any element
        for (int i = 0; i < nums.length; i++) {
            max = Math.max(max, nums[i]);
        }

        // суммируем последовательности, создаем острова
        var list = new LinkedList<Integer>();
        for (int i = 0; i < nums.length; i++) {
            var sum = nums[i];
            if (nums[i] >= 0) {
                while (i + 1 < nums.length && nums[i + 1] >= 0) {
                    sum += nums[i + 1];
                    i++;
                }
            } else {
                while (i + 1 < nums.length && nums[i + 1] < 0) {
                    sum += nums[i + 1];
                    i++;
                }
            }
            list.add(sum);
            max = Math.max(max, sum);
        }

        // должно быть еще 2 элемента минимум
        for (int i = 0; i < list.size() - 2; i++) {
            if (list.get(i) < 0) {
                continue;
            }

            // a >= 0 b < 0 c >= 0
            // по построению
            // если есть d, то он будет отрицательным
            var a = list.get(i);
            var b = list.get(i + 1);
            var c = list.get(i + 2);

            // какой смысл объединять положительные числа?
            if (a + b +c > a || a + b +c  > c) {
                max = Math.max(max, a + b + c);
                // это элегатное решение позволяем "рекурсивно" объединять острова дальше
                list.set(i + 2, Math.max(a + b + c, c));
            }
            // go to c
            i++;
        }


        return max;
    }
}
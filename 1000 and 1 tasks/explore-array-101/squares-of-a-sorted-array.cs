public class Solution {
    // нужно найти первый положительный и дальше 2мя указателями отсорировать

    public int FirstBadVersion(int[] nums) {
        var a = 0;
        var b = nums.Length - 1;

        while (a <= b)
        {
            var m = a + (b - a) / 2;
            if (nums[m] < 0)
            {
                a = m + 1;

            }
            else
            {
                b = m - 1;
            }
        }

        return b + 1;
    }


    public int[] SortedSquares(int[] nums) {
        var firstPositiveIndex = FirstBadVersion(nums);
        var lastPositiveIndex = nums.Last() >= 0 ? nums.Length - 1 : -1;

        var firstNegativeIndex = nums.First() < 0 ? 0 : -1;
        var lastNegativeIndex = firstPositiveIndex - 1;
        var globalIndex = 0;

        var result = new int[nums.Length];

        while (firstPositiveIndex <= lastPositiveIndex && firstPositiveIndex != -1 && lastNegativeIndex >= firstNegativeIndex && firstNegativeIndex != -1) {
            if (Math.Abs(nums[firstPositiveIndex]) <  Math.Abs(nums[lastNegativeIndex])) {
                result[globalIndex++] = nums[firstPositiveIndex] * nums[firstPositiveIndex];
                firstPositiveIndex++;
            }
            else {
                result[globalIndex++] = nums[lastNegativeIndex] * nums[lastNegativeIndex];
                lastNegativeIndex--;
            }
        }

        while (firstPositiveIndex <= lastPositiveIndex && firstPositiveIndex != -1) {
            result[globalIndex++] = nums[firstPositiveIndex] * nums[firstPositiveIndex];
            firstPositiveIndex++;
        }

        while (lastNegativeIndex >= firstNegativeIndex && firstNegativeIndex != -1) {
            result[globalIndex++] = nums[lastNegativeIndex] * nums[lastNegativeIndex];
            lastNegativeIndex--;
        }
        
        return result;
    }
}
public class Solution {
    public int[] SortedSquares(int[] nums) {
        var lastNegative = 0;
        while (lastNegative < nums.Length && nums[lastNegative] < 0) {
            lastNegative++;
        }
        lastNegative--;

        if (lastNegative < 0) {
            return nums.Select(x => x*x).ToArray();
        }

        var firstPositive = lastNegative + 1;
        if (firstPositive > nums.Length - 1) {
            // no positive, return reverse squares
            return nums.Select(x => x*x).Reverse().ToArray();
        }

        var newArray = new int[nums.Length];
        var k = 0;

        while (firstPositive <= nums.Length - 1 && lastNegative >= 0) {
            if (nums[firstPositive] < nums[lastNegative] * (-1)) {
                newArray[k++] = nums[firstPositive++];
            }
            else {
                newArray[k++] = nums[lastNegative--];
            }
        }

        while (firstPositive <= nums.Length - 1) {
            newArray[k++] = nums[firstPositive++];
        }

        while (lastNegative >= 0) {
            newArray[k++] = nums[lastNegative--];
        }

        for (int i = 0; i < newArray.Length; i++) {
            newArray[i] = newArray[i] * newArray[i];
        }

        return newArray;
    }
}
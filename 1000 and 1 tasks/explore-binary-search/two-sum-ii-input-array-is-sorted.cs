public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var l = 0;
        var r = numbers.Length - 1;

        while (l < r) {
            var sum = numbers[l] + numbers[r];
            if (sum == target) {
                return new int[] {l + 1, r + 1};
            }
            if (sum < target) {
                l++;
            }
            else {
                r--;
            }
        }

        return null;
    }
}
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var l = 0;
        var r = numbers.Length - 1;

        while (l < r) {
            if (numbers[l] + numbers[r] == target) {
                return new int [] {l + 1 ,r + 1};
            }
            else if (numbers[l] + numbers[r] < target) {
                l++;
            }
            else {
                r--;
            }
        }

        return null;
    }
}
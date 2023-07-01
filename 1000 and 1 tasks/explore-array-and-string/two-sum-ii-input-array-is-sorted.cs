public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var L = 0;
        var R = numbers.Length - 1;

        while (L < R) {
            var sum = numbers[L] + numbers[R];
            if (sum == target) {
                return new int[] {L+1,R+1};
            }
            else if (sum < target) {
                L++;
            }
            else {
                R--;
            }
        }

        return null;
    }
}
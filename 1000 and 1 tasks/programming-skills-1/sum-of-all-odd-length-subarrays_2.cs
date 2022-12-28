public class Solution {
    // https://leetcode.com/problems/sum-of-all-odd-length-subarrays/solutions/2773805/sum-of-all-odd-length-subarrays/?orderBy=most_votes
    public int SumOddLengthSubarrays(int[] arr) {
        var total = 0;

        for (int i = 0; i < arr.Length; i++) {
            var left = i + 1;
            var left_odd = left / 2;
            var left_even = left - left_odd;

            var right = arr.Length - i;
            var right_odd = right / 2;
            var right_even = right - right_odd;

            total += arr[i]*left_odd*right_odd;
            total += arr[i]*left_even*right_even;
        }

        return total;
    }
}

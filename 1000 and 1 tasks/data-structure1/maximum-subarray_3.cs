public class Solution {
    private int[] _numsArray;

    public int MaxSubArray(int[] nums) {
        _numsArray = nums;

        return FindBestSubarray(0, _numsArray.Length - 1);
    }

    private int FindBestSubarray(int left, int right) {
        if (left > right) {
            return int.MinValue;
        }

        var mid = (left + right) / 2;
        var curr = 0;
        var bestLeftSum = 0;
        var bestRightSum = 0;

        // Iterate from the middle to the beginning.
        for (var i = mid - 1; i >= left; i--) {
            curr += _numsArray[i];
            bestLeftSum = Math.Max(bestLeftSum, curr);
        }

        // Reset curr and iterate from the middle to the end.
        curr = 0;
        for (var i = mid + 1; i <= right; i++) {
            curr += _numsArray[i];
            bestRightSum = Math.Max(bestRightSum, curr);
        }

        // The bestCombinedSum uses the middle element and the best
        // possible sum from each half.
        var bestCombinedSum = _numsArray[mid] + bestLeftSum + bestRightSum;

        // Find the best subarray possible from both halves.
        var leftHalf = FindBestSubarray(left, mid - 1);
        var rightHalf = FindBestSubarray(mid + 1, right);

        // The largest of the 3 is the answer for any given input array.
        return Math.Max(bestCombinedSum, Math.Max(leftHalf, rightHalf));
    }
}
public class Solution {
    // based on heap sort
    public int FindKthLargest(int[] nums, int k) {
        for (int i = nums.Length / 2 - 1; i >= 0; i-- ) {
            MaxHeapify(nums, nums.Length, i);
        }

        var size = nums.Length - 1;
        var kk = 0;

        for (int i = nums.Length - 1; i > 0; i--) {
            var result = nums[0];
            nums[0] = nums[i];
            MaxHeapify(nums, size, 0);
            size--;
            kk++;
            if (kk == k) {
                return result;
            }
        }

        return nums[0];
    }

    private void MaxHeapify(int[] nums, int size, int index) {
        var leftIndex = index * 2 + 1;
        var rightIndex = index * 2 + 2;

        var largestIndex = index;
        if (leftIndex < size && nums[leftIndex] > nums[largestIndex]) {
            largestIndex = leftIndex;
        }
        if (rightIndex < size && nums[rightIndex] > nums[largestIndex]) {
            largestIndex = rightIndex;
        }

        if (index != largestIndex) {
            var tmp = nums[index];
            nums[index] = nums[largestIndex];
            nums[largestIndex] = tmp;

            MaxHeapify(nums, size, largestIndex);
        }
    }
}
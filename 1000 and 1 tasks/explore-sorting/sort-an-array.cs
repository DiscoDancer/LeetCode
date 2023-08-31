public class Solution {
    public int[] SortArray(int[] nums) {
        for (int i = nums.Length / 2 - 1; i >= 0; i--) {
            MaxHeapify(nums, nums.Length, i);
        }

        for (int i = nums.Length - 1; i > 0; i--) {
            var tmp = nums[i];
            nums[i] = nums[0];
            nums[0] = tmp;
            MaxHeapify(nums, i, 0);
        }

        return nums;
    }

    private void MaxHeapify(int[] arr, int size, int index) {
        var leftIndex = index * 2 + 1;
        var rightIndex = index * 2 + 2;

        var largest = index;
        if (leftIndex < size && arr[leftIndex] > arr[largest]) {
            largest = leftIndex;
        }
        if (rightIndex < size && arr[rightIndex] > arr[largest]) {
            largest = rightIndex;
        }

        if (index != largest) {
            var tmp = arr[index];
            arr[index] = arr[largest];
            arr[largest] = tmp;
            MaxHeapify(arr, size, largest);
        }
    }
}
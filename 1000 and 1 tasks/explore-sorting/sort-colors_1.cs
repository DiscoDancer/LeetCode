public class Solution {
    // editorial
    private void Swap(int[] nums, int i, int j) {
        var tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }

    public void SortColors(int[] nums) {
        // for all idx < p0 : nums[idx < p0] = 0
        // curr is an index of element under consideration
        int p0 = 0, curr = 0;
        // for all idx > p2 : nums[idx > p2] = 2
        int p2 = nums.Length - 1;

        while (curr <= p2) {
            if (nums[curr] == 0) {
                Swap(nums, curr, p0);
                curr++;
                p0++;
            }
            else if (nums[curr] == 2) {
                Swap(nums, curr, p2);
                p2--;
            }
            else curr++;
        }
    }
}
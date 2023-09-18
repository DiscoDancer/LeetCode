public class Solution {
    // out of memore
    public int SmallestDistancePair(int[] nums, int k) {
        var list = new List<int>();

        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                list.Add(Math.Abs(nums[i] - nums[j]));
            }
        }

        list.Sort();

        return list[k-1];
    }
}
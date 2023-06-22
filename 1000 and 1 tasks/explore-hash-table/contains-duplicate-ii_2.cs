public class Solution {
    // editorial
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        var hs = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++) {
            var n = nums[i];
            if (hs.Contains(n)) {
                return true;
            }
            hs.Add(n);
            if (hs.Count > k) {
                hs.Remove(nums[i- k]);
            }
        }

        return false;
    }
}
public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        var dictionary = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++) {
            var n = nums[i];
            if (dictionary.ContainsKey(n)) {
                foreach (var j in dictionary[n]) {
                    if (Math.Abs(i-j) <= k) {
                        return true;
                    }
                }
                dictionary[n].Add(i);
            }
            else {
                dictionary[n] = new List<int>() {i};
            }
        }

        return false;
    }
}
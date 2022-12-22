public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var hs = new HashSet<int>();
        foreach (var n in nums) {
            hs.Add(n);
        }

        return hs.Count != nums.Length;
    }
}
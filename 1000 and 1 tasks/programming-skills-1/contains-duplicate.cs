public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var hs = new HashSet<int>();
        foreach (var n in nums) {
            if (hs.Contains(n)) {
                return true;
            }
            hs.Add(n);
        }

        return false;
    }
}
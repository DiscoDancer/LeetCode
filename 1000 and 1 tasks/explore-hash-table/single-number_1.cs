public class Solution {
    public int SingleNumber(int[] nums) {
        var hs = new HashSet<int>();
        foreach (var n in nums) {
            if (hs.Contains(n)) {
                hs.Remove(n);
            }
            else {
                hs.Add(n);
            }
        }

        foreach (var x in hs) {
            return x;
        }

        return -1;
    }
}
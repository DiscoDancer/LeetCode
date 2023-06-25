public class Solution {
    // editorial
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
        var result = 0;
        var ht = new Dictionary<int, int>();

        foreach (var a in nums1) {
            foreach (var b in nums2) {
                if (!ht.ContainsKey(a+b)) {
                    ht[a+b] = 0;
                }
                ht[a+b]++;
            }
        }

        foreach (var c in nums3) {
            foreach (var d in nums4) {
                if (ht.ContainsKey(-(c+d))) {
                    result += ht[-(c+d)];
                }
            }
        }

        return result;
    }
}
public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        var vals = new int[1001];
        
        for (int i = 0; i < nums1.Length; i++) {
            vals[nums1[i]]++;
        }
        
        var res = new List<int>();
        
        for (int i = 0; i < nums2.Length; i++) {
            if (vals[nums2[i]] > 0) {
                res.Add(nums2[i]);
                vals[nums2[i]]--;
            }
        }
        
        return res.ToArray();
    }
}
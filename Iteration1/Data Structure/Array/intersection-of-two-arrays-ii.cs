public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        // hast table: N + M time N space
        // 1st sort then bin search N^2 + M*logN O(1) space
        
        // var sorted = nums1.OrderBy().ToArray();
        
        var table = new int[1001];
        
        var res = new List<int>();
        
        for (int i = 0; i < nums1.Length; i++) {
            table[nums1[i]]++;
        }
        
        for (int i = 0; i < nums2.Length; i++) {
            if (table[nums2[i]] > 0) {
                res.Add(nums2[i]);
            }
            table[nums2[i]]--;
        }
        
        return res.ToArray();
    }
}
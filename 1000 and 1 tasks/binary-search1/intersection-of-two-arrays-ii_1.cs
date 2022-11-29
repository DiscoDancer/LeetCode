public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        var dic = new Dictionary<int,int>();
        
        foreach (var n in nums1) {
            if (dic.ContainsKey(n)) {
                dic[n]++;
            } else {
                dic[n] = 1;
            }
        }
        
        var res = new List<int>();
        
        foreach (var n in nums2) {
            if (dic.ContainsKey(n)) {
                if (dic[n] >0 ) {
                    res.Add(n);
                    
                }
                dic[n]--;
            }
        }
        
        return res.ToArray();
    }
}
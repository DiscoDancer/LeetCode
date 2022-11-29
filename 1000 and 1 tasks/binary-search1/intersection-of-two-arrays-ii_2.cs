public class Solution {
    // оптимизация по длине
    public int[] Intersect(int[] nums1, int[] nums2) {
        var a11 = nums1.ToList();
        var a22 = nums2.ToList();
        
        a11.Sort();
        a22.Sort();
        
        var a1 = a11.ToArray();
        var a2 = a22.ToArray();
        
        var p1 = 0;
        var p2 = 0;
        
        var res = new List<int>();
        while (p1 < a1.Length && p2 < a2.Length) {
            if (a1[p1] == a2[p2]) {
                res.Add(a1[p1]);
                p1++;
                p2++;
            }
            else if (a1[p1] < a2[p2]) {
                p1++;
                
            }
            else if (a1[p1] > a2[p2]) {
                p2++;
            }
        }
        
        return res.ToArray();
    }
}
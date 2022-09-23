public class Solution {
    // в лоб
    // оптимизация hash table
    // динамич программирование, сколько больше, чем N
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var res = new int[nums1.Length];
        
        var table = new Dictionary<int, int>();
        for (int i = 0; i < nums2.Length; i++) {
            table[nums2[i]] = i;
        }
        
        
        for (int i = 0; i < nums1.Length; i++) {
            var curRes = -1;
            for (int j = table[nums1[i]] + 1; j < nums2.Length && curRes < 0; j++) {
                if (nums2[j] > nums1[i]) {
                    curRes = nums2[j];
                }
            }
            res[i] = curRes;
        }
        
        return res;
    }
}
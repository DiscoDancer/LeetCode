public class Solution {
    
    public int[] Intersect(int[] nums1, int[] nums2) {
        nums1 = nums1.OrderBy(x => x).ToArray();
        nums2 = nums2.OrderBy(x => x).ToArray();
        
        int i = 0;
        int j = 0;
        int k = 0;
        
        while (i < nums1.Length && j < nums2.Length) {
            if (nums1[i] < nums2[j]) {
                i++;
            } else if (nums1[i] > nums2[j]) {
                j++;
            }
            else {
                nums1[k] = nums2[j];
                i++;
                k++;
                j++;
            }
        }
        
        return nums1.Take(k).ToArray();
    }
}
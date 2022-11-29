public class Solution {
    /*
        Roadmap:
            + n*n
            + optimized n*n
            + n*long (binary search + optimized)
            - 2 pointers
    */
    
    // квадрат слишком долго
    // массивы сортированы, можно ускориться бинарным поиском
    // ну 2 points навеное тоже ок
    public int MaxDistance(int[] nums1, int[] nums2) {
        var p1 = 0;
        var p2 = 0;
        
        var max = 0;
        
        while (p1 < nums1.Length && p2 < nums2.Length) {
            if (nums1[p1] > nums2[p2]) {
                p1++;
            }
            else {
                max = Math.Max(max, p2 - p1);
                p2++;
            }
        }
        
        return max;
    }
}
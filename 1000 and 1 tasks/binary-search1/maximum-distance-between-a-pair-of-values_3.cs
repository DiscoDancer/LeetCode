public class Solution {
    /*
        Roadmap:
            + n*n
            + optimized n*n
            + n*long (binary search + optimized)
    */
    
    // квадрат слишком долго
    // массивы сортированы, можно ускориться бинарным поиском
    // ну 2 points навеное тоже ок
    public int MaxDistance(int[] nums1, int[] nums2) {
        var max = 0;
        
        for (int i = 0; i < nums1.Length; i++) {            
            var a = i + 1 + max;
            var b = nums2.Length - 1;
            while (a <= b) {
                var m = a + (b-a)/2;
                if (nums1[i] <= nums2[m]) {
                    max = Math.Max(max, m - i);
                    a = m + 1;
                } 
                else if (nums1[i] > nums2[m]) {
                    b = m - 1;
                }
                
            }
        }
        
        return max;
    }
}
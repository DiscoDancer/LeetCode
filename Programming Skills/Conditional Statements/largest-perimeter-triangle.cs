public class Solution {
    public int LargestPerimeter(int[] nums) {
        var arr = nums.OrderByDescending(x => x).ToArray();
        
        for (int i = 2; i < arr.Length; i++) {
            var a = arr[i - 2];
            var b = arr[i - 1];
            var c = arr[i];
            
            if (a < b + c) {
                return a + b + c;
            }
        }
        
        return 0;
    }
}
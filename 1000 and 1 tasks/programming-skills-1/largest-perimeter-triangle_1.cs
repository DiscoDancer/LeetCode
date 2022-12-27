public class Solution {
    public int LargestPerimeter(int[] nums) {
        var arr = nums.OrderBy(x => -x).ToArray();

        for (var i = 2; i < arr.Length; i++) {
            if (arr[i-2] < arr[i] + arr[i-1]) {
                return arr[i-2] + arr[i] + arr[i-1];
            }
        }

        return 0;
    }
}
public class Solution {
    // editorial
    public bool IncreasingTriplet(int[] nums) {
        int first_num = int.MaxValue;
        int second_num = int.MaxValue;
        foreach (var n in nums) {
            if (n <= first_num) {
                first_num = n;
            } else if (n <= second_num) {
                second_num = n;
            } else {
                return true;
            }
        }
        return false;
    }
}
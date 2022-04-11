public class Solution {
    public bool CanMakeArithmeticProgression(int[] arr) {
        
        arr = arr.OrderBy(x => x).ToArray();
        
        var diff = arr[1] - arr[0];
        
        for (int i = 2; i < arr.Length; i++) {
            if (arr[i] - arr[i - 1] != diff) {
                return false;
            }
        }
        
        return true;
    }
}
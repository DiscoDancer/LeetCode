public class Solution {
    public bool CanMakeArithmeticProgression(int[] arr) {
        arr = arr.OrderBy(x => x).ToArray();

        var diff = arr[1] - arr[0];
        var prev = arr[1];

        for (int i = 2; i < arr.Length; i++) {
            if (arr[i] - prev != diff) {
                return false;
            }
            prev = arr[i];
        }

        return true;
    }
}
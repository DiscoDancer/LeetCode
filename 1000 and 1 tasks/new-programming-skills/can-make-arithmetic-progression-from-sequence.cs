public class Solution {
    public bool CanMakeArithmeticProgression(int[] arr) {
        var sorted = arr.OrderBy(x => x).ToArray();

        var diff = sorted[1]-sorted[0];

        for (int i = 2; i < sorted.Length; i++) {
            if (diff != sorted[i] - sorted[i-1]) {
                return false;
            }
        } 

        return true;
    }
}
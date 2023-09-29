public class Solution {
    // 4 cases
    public int CountOdds(int low, int high) {
        if (low % 2 == 0 && high % 2 == 0) {
            return (high - low) / 2;
        }
        if (low % 2 == 0 && high % 2 == 1) {
            return 1 + CountOdds(low, high - 1);
        }
        if (low % 2 == 1 && high % 2 == 0) {
            return 1 + CountOdds(low + 1, high);
        }
        if (low % 2 == 1 && high % 2 == 1) {
            return 2 + CountOdds(low+1, high-1);
        }

        throw new Exception();
    }
}
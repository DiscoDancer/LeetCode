public class Solution {
    public int CountOdds(int low, int high) {
        var diff2 = (high - low) / 2;
        
        if (low % 2 == 0 && high % 2 == 0) {
            return diff2;
        }
        
        return diff2 + 1;
    }
}
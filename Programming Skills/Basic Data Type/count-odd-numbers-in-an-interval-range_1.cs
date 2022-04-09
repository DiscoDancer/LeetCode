public class Solution {
    public int CountOdds(int low, int high) {
        var diff2 = (high - low) >> 1;
        
        if ( ( (low & 1) == 0) && ( (high & 1) == 0) ) {
            return diff2;
        }
        
        return diff2 + 1;
    }
}
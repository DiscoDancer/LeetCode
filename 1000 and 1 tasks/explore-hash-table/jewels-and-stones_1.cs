public class Solution {
    // bytes instead of bools
    public int NumJewelsInStones(string jewels, string stones) {
        var lowerJewels = 0;
        var upperJewels = 0;

        foreach (var j in jewels) {
            if (char.IsUpper(j)) {
                var two = 1 << j-'A';
                upperJewels = upperJewels | two;
            }
            else {
                var two = 1 << j-'a';
                lowerJewels = lowerJewels | two;
            }
        }

        var count = 0;
        foreach (var s in stones) {
            if (char.IsUpper(s)) {
                var two = 1 << s-'A';
                if ((upperJewels & two) > 0) {
                    count++;
                }       
            }
            else {
                var two = 1 << s-'a';
                if ( (lowerJewels & two) > 0) {
                    count++;
                } 
            }
        }

        return count;
    }
}
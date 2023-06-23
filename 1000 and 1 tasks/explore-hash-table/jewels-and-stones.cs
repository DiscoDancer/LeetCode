public class Solution {
    // bytes instead of bools
    public int NumJewelsInStones(string jewels, string stones) {
        var lowerJewels = new bool[26];
        var upperJewels = new bool[26];

        foreach (var j in jewels) {
            if (char.IsUpper(j)) {
                upperJewels[j-'A'] = true;
            }
            else {
                lowerJewels[j-'a'] = true;
            }
        }

        var count = 0;
        foreach (var s in stones) {
            if (char.IsUpper(s) && upperJewels[s-'A']) {
                count++;
            }
            else if (!char.IsUpper(s) && lowerJewels[s-'a'] ) {
                count++;
            }
        }

        return count;
    }
}
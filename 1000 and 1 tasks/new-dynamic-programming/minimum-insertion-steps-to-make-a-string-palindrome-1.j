import java.util.*;

class Solution {
    public int minInsertions(String s) {
        var table = new int[s.length() + 1][s.length() + 1];
        for (var l = s.length() - 1; l >= 0; l--) {
            for (var r = 0; r < s.length(); r++) {
                if (l >= r) {
                    table[l][r] = 0;
                }
                else if (s.charAt(l) == s.charAt(r)) {
                    table[l][r] = table[l+1][r-1];
                }
                else {
                    var insertRight = 1 + table[l+1][r];
                    var insertLeft = 1 + table[l][r-1];
                    table[l][r] = Math.min(insertRight, insertLeft);
                }
            }
        }

        return table[0][s.length() - 1];
    }
}
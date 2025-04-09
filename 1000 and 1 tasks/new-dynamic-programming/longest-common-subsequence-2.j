import java.util.*;


class Solution {
    public int longestCommonSubsequence(String text1, String text2) {

        var table = new int[text1.length() + 1][text2.length() + 1];
        for (var i  = text1.length(); i >= 0; i--) {
            for (var j = text2.length(); j >= 0; j--) {
                if (i == text1.length() || j == text2.length()) {
                    table[i][j] = 0;
                }
                else {
                    var take = 0;
                    if (text1.charAt(i) == text2.charAt(j)) {
                        take = 1 + table[i + 1][j + 1];
                    }
                    var skip1 = table[i + 1][j];
                    var skip2 = table[i][j + 1];

                    table[i][j] = Math.max(take, Math.max(skip1, skip2));
                }
            }
        }

        return table[0][0];
    }
}
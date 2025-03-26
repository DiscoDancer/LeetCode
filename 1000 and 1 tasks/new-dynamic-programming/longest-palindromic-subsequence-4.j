import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

// TL

class Solution {

    // char -> indexes
    private int[][] indexTable;
    private String s;

    private int getNextIndex(int l, int r) {
        var c = s.charAt(l);
        var indexes = indexTable[c - 'a'];

        var result = new ArrayList<Integer>();
        for (var i = 0; i < indexes.length; i++) {
            if (indexes[i] > l && indexes[i] <= r) {
                result.add(indexes[i]);
            }
        }

        if (result.size() > 0) {
            return result.get(result.size() - 1);
        }

        return -1;
    }

    private void fillIndexTable() {
        var countTable = new int[26];
        for (var i = 0; i < s.length(); i++) {
            countTable[s.charAt(i) - 'a']++;
        }

        var nextIndexes = new int[26];

        // index table
        indexTable = new int[26][];
        for (var i = 0; i < 26; i++) {
            indexTable[i] = new int[countTable[i]];
        }
        for (var i = 0; i < s.length(); i++) {
            var c = s.charAt(i) - 'a';
            indexTable[c][nextIndexes[c]] = i;
            nextIndexes[c]++;
        }
    }

    public int longestPalindromeSubseq(String s) {
        this.s = s;
        fillIndexTable();

        var table = new int[s.length() + 1][s.length() + 1];
        for (var l = s.length() - 1; l >= 0; l--) {
            for (var r = l; r <= s.length() - 1; r++) {
                if (l == r) {
                    table[l][r] = 1;
                    continue;
                }

                var rx = getNextIndex(l, r);
                if (rx != -1) {
                    table[l][r] = table[l+1][rx-1] + 2;
                }

                // и еще их можно просто пропустить левый
                table[l][r] = Math.max(table[l][r], table[l + 1][r]);
            }
        }

        return table[0][s.length() - 1];
    }
}

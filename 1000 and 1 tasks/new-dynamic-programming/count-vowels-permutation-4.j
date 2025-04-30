import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {

    // see https://leetcode.com/problems/paint-house/description/?envType=study-plan-v2&envId=dynamic-programming
    // and II

    public int countVowelPermutation(int n) {
        var table = new int[n+1][5+1];

        for (var i = n; i >= 0; i--) {
            for (var prevC = 5; prevC >= 0; prevC--) {
                if (i == n) {
                    table[i][prevC] = 1;
                    continue;
                }
                if (i != 0 && prevC == 0) {
                    continue;
                }
                if (prevC == 0) {
                    table[i][prevC] += table[i+1][1];
                    table[i][prevC] %= 1000000007;
                    table[i][prevC] += table[i+1][2];
                    table[i][prevC] %= 1000000007;
                    table[i][prevC] += table[i+1][3];
                    table[i][prevC] %= 1000000007;
                    table[i][prevC] += table[i+1][4];
                    table[i][prevC] %= 1000000007;
                    table[i][prevC] += table[i+1][5];
                    table[i][prevC] %= 1000000007;
                }
                else {
                    if (prevC == 2) {
                        table[i][prevC] += (table[i + 1][1]);
                        table[i][prevC] %= 1000000007;
                    }
                    if (prevC == 1 || prevC == 3) {
                        table[i][prevC] += (table[i + 1][2]);
                        table[i][prevC] %= 1000000007;
                    }
                    if (prevC != 3) {
                        table[i][prevC] += (table[i + 1][3]);
                        table[i][prevC] %= 1000000007;
                    }
                    if (prevC == 3 || prevC == 5) {
                        table[i][prevC] += (table[i + 1][4]);
                        table[i][prevC] %= 1000000007;
                    }
                    if (prevC == 1) {
                        table[i][prevC] += (table[i + 1][5]);
                        table[i][prevC] %= 1000000007;
                    }
                }

            }
        }

        return table[0][0];
    }
}

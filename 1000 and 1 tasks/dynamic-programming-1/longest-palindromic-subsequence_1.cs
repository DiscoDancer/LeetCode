public class Solution {

    // https://leetcode.com/problems/longest-palindromic-subsequence/solutions/99111/evolve-from-brute-force-to-dp/
    private int?[][] Table {get; set;}

    public int LongestPalindromeSubseqInner(string s, int l, int r) {
        if (l == r) {
            return 1;
        }
        if (l > r) {
            return 0;
        }
        if (Table[l][r] != null) {
            return Table[l][r].Value;
        }
        if (s[l] == s[r]) {
            var res11 = 2 + LongestPalindromeSubseqInner(s, l+1, r-1);
            Table[l][r] = res11;
            return res11;
        }

        var res1 = LongestPalindromeSubseqInner(s, l +1, r);
        var res2 = LongestPalindromeSubseqInner(s, l, r-1);
        var res = Math.Max(res1, res2);
        Table[l][r] = res;

        return res;
    }

    public int LongestPalindromeSubseq(string s) {
        if (s.Length == 1) {
            return 1;
        }

        Table = new int?[s.Length][];

        for (int i = 0; i < s.Length; i++) {
            Table[i] = new int?[s.Length];
        }

        LongestPalindromeSubseqInner(s, 0, s.Length - 1);

        return Table[0][s.Length-1].Value;
    }
}
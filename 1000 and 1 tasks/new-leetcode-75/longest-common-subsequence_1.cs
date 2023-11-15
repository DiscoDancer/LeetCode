public class Solution {
    /*
        Decision making options:
        - start over
        - skip cur char
        - take cur char (if possible)
    */

    private string _text1;
    private string _text2;

    // i in text1, j in text2
    private int F(int i, int j) {
        if (i == _text1.Length || j == _text2.Length) {
            return 0;
        }

        var A = 0;
        var B = 0;
        var C = 0;

        if (_text1[i] == _text2[j]) {
            A = F(i+1, j + 1) + 1;
        }

        B = F(i, j + 1);
        C = F(i + 1, j);

        return Math.Max(A, Math.Max(B,C));
    }

    public int LongestCommonSubsequence(string text1, string text2) {
        _text1 = text1;
        _text2 = text2;

        return F(0, 0);
    }
}
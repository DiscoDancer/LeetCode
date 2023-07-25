public class Solution {
    private string _text1;
    private string _text2;

    private int F(int i, int j) {
        if (i == _text1.Length || j == _text2.Length) {
            return 0;
        }

        if (_text1[i] == _text2[j]) {
            return 1 + F(i+1,j+1);
        }
        else {
            return Math.Max(F(i+1, j), F(i, j+1));
        }
    }

    // STILL TL
    public int LongestCommonSubsequence(string text1, string text2) {
        _text1 = text1;
        _text2 = text2;

        return F(0,0);
    }
}
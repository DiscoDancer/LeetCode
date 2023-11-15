public class Solution {
    /*
        Decision making options:
        - start over
        - skip cur char
        - take cur char (if possible)
    */

    private int _bestScore = 0;
    private string _text1;
    private string _text2;

    // i in text1, j in text2
    private void F(int i, int j, int score) {
        _bestScore = Math.Max(_bestScore, score);
        if (i == _text1.Length || j == _text2.Length) {
            return;
        }

        if (_text1[i] == _text2[j]) {
            F(i+1, j + 1, score + 1);
        }

        F(i, j + 1, score);
        F(i + 1, j, score);
    }

    // TL
    public int LongestCommonSubsequence(string text1, string text2) {
        _text1 = text1;
        _text2 = text2;

        F(0, 0, 0);


        return _bestScore;
    }
}
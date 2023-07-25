public class Solution {
    private string _text1;
    private string _text2;

    private int _max = 0;


    private void F(int i, int j, int res) {
        if (i == _text1.Length || j == _text2.Length) {
            _max = Math.Max(_max, res);
            return;
        }

        if (_text1[i] == _text2[j]) {
            F(i+1,j+1, res + 1);
        }
        else {
            F(i+1, j, res);
            F(i, j+1, res);
        }
    }

    // TL
    public int LongestCommonSubsequence(string text1, string text2) {
        _text1 = text1;
        _text2 = text2;

        F(0,0,0);

        return _max;
    }
}
public class Solution {
    private string _text1;
    private string _text2;
    private int?[,] _mem;

    private int? F(int i, int j) {
        if (i == _text1.Length || j == _text2.Length) {
            return 0;
        }

        if (_mem[i,j] != null) {
            return _mem[i,j];
        }

        if (_text1[i] == _text2[j]) {
            _mem[i,j] = 1 + F(i+1,j+1);
        }
        else {
            _mem[i,j] = Math.Max(F(i+1, j).Value, F(i, j+1).Value);
        }

        return _mem[i,j];
    }

    public int LongestCommonSubsequence(string text1, string text2) {
        _text1 = text1;
        _text2 = text2;

        _mem = new int? [text1.Length, text2.Length];
        F(0,0);

        return _mem[0,0].Value;
    }
}
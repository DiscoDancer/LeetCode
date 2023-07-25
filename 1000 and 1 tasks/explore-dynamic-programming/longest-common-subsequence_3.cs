public class Solution {

    // сам переписал
    public int LongestCommonSubsequence(string text1, string text2) {
        var _mem = new int [text1.Length + 1, text2.Length + 1];
        _mem[text1.Length, text2.Length] = 0;
        _mem[text1.Length - 1, text2.Length] = 0;
        _mem[text1.Length, text2.Length - 1] = 0;

        for (int i = text1.Length - 1; i >= 0; i--) {
            for (int j = text2.Length - 1; j >= 0; j--) {
                if (text1[i] == text2[j]) {
                    _mem[i,j] = _mem[i+1,j+1] + 1;
                }
                else {
                    _mem[i,j] = Math.Max(_mem[i+1,j], _mem[i,j+1]);
                }
            }
        }

        return _mem[0,0];
    }
}
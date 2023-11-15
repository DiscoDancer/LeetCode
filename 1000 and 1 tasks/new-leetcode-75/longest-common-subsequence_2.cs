public class Solution {
    /*
        Decision making options:
        - start over
        - skip cur char
        - take cur char (if possible)
    */

    public int LongestCommonSubsequence(string text1, string text2) {
        var table = new int[text1.Length + 1, text2.Length + 1];
        // explicit
        table[text1.Length, text2.Length] = 0;

        for (int i = text1.Length - 1; i >= 0; i--) {
            for (int j = text2.Length - 1; j >= 0; j--) {
                var A = 0;
                var B = 0;
                var C = 0;

                if (text1[i] == text2[j]) {
                    A = table[i+1, j + 1] + 1;
                }

                B = table[i, j + 1];
                C = table[i + 1, j];

                table[i,j] = Math.Max(A, Math.Max(B,C));
            }
        }

        return table[0, 0];
    }
}
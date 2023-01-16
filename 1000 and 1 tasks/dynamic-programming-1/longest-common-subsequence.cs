public class Solution {

    private string Text1;
    private string Text2;

    private int FindInText2(char target, int start) {
        for (int i = start; i < Text2.Length; i++) {
            if (Text2[i] == target) {
                return i;
            }
        }

        return -1;
    }

    // TL

    public int LongestCommonSubsequenceInner(int p1, int p2, int acc) {
        // смотрим на первую букву text1, можем ее взять?
        if (p1 >= Text1.Length || p2 >= Text2.Length) {
            return acc;
        }

        var curLetterIn1 = Text1[p1];
        var indexInText2 = FindInText2(curLetterIn1, p2);
        var canIncludeCurLetterIn1 = indexInText2 >= 0;

        int include = 0;
        int exclude = 0;

        if (canIncludeCurLetterIn1) {
            include = LongestCommonSubsequenceInner(p1 + 1, indexInText2 + 1, acc + 1);
        } else {
            include = LongestCommonSubsequenceInner(p1 + 1, p2, acc);
        }

        exclude = LongestCommonSubsequenceInner(p1 + 1, p2, acc);

        return Math.Max(include, exclude);
    }

    public int LongestCommonSubsequence(string text1, string text2) {
        Text1 = text1;
        Text2 = text2;
        return LongestCommonSubsequenceInner(0,0,0);
    }
}
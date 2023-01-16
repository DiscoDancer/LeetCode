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

    private Dictionary<(int, int), int> Mem = new ();
    
    public int LongestCommonSubsequenceInner(int p1, int p2) {
        // смотрим на первую букву text1, можем ее взять?
        if (p1 >= Text1.Length || p2 >= Text2.Length) {
            return 0;
        }
        if (Mem.ContainsKey((p1,p2))) {
            return Mem[(p1,p2)];
        }

        var curLetterIn1 = Text1[p1];
        var indexInText2 = FindInText2(curLetterIn1, p2);
        var canIncludeCurLetterIn1 = indexInText2 >= 0;

        var include = canIncludeCurLetterIn1 ? LongestCommonSubsequenceInner(p1 + 1, indexInText2 + 1) + 1 : 0;
        var exclude = LongestCommonSubsequenceInner(p1 + 1, p2);
        var result = Math.Max(include, exclude);
        Mem[(p1,p2)] = result;
        return result;
    }

    public int LongestCommonSubsequence(string text1, string text2) {
        Text1 = text1;
        Text2 = text2;
        return LongestCommonSubsequenceInner(0,0);
    }
}
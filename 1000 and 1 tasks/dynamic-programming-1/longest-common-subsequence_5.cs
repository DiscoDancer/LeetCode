public class Solution {

    private string Text1;
    private string Text2;

    private Dictionary<(int, int), int> Mem = new ();
    
    public int LongestCommonSubsequenceInner(int p1, int p2) {
        // смотрим на первую букву text1, можем ее взять?
        if (p1 >= Text1.Length || p2 >= Text2.Length) {
            return 0;
        }
        if (Mem.ContainsKey((p1,p2))) {
            return Mem[(p1,p2)];
        }

        int result;

        if (Text1[p1] == Text2[p2]) {
            Mem[(p1,p2)] = 1 + LongestCommonSubsequenceInner(p1 + 1, p2 + 1);
        }
        else {
            Mem[(p1,p2)] = Math.Max(LongestCommonSubsequenceInner(p1 + 1, p2), LongestCommonSubsequenceInner(p1, p2 + 1));
        }

        return Mem[(p1,p2)];
    }

    public int LongestCommonSubsequence(string text1, string text2) {
        Text1 = text1;
        Text2 = text2;
        return LongestCommonSubsequenceInner(0,0);
    }
}
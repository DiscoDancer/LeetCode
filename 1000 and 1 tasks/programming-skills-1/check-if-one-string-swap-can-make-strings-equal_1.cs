public class Solution {
    public bool AreAlmostEqual(string s1, string s2) {
        var countSame = 0;
        var badIndexes = new List<int>();

        for (int i = 0; i < s1.Length; i++) {
            if (s1[i] == s2[i]) {
                countSame++;
            } else {
                badIndexes.Add(i);
            }
        }

        if (countSame == s1.Length) {
            return true;
        }

        if (countSame != s1.Length -2) {
            return false;
        }

        // имеем 2 индекса, в которых не совпадает
        return s1[badIndexes.First()] == s2[badIndexes.Last()] &&
        s1[badIndexes.Last()] == s2[badIndexes.First()];
    }
}
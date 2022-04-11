public class Solution {
    public bool AreAlmostEqual(string s1, string s2) {
        int k = 0;
        var firstIndex = -1;
        var secondIndex = -1;
        
        for (int i = 0; i < s1.Length; i++) {
            if (s1[i] != s2[i]) {
                k++;
                if (firstIndex < 0) {
                    firstIndex = i;
                } else if (secondIndex < 0) {
                    secondIndex = i;
                }
                if (k > 2) {
                    return false;
                }
            }
        }
        
        if (k == 2) {
            return s1[firstIndex] == s2[secondIndex] && s1[secondIndex] == s2[firstIndex];
        }
        
        return k == 2 || k == 0;
    }
}
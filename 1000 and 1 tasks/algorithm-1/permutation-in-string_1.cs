public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) {
            return false;
        }

        var table = new int[26];
        foreach (var c in s1) {
            table[c-'a']++;
        }

        for (int i = 0; i <= s2.Length - s1.Length; i++) {
            if (i == 0) {
                for (int j = 0; j < s1.Length; j++) {
                    table[s2[j]-'a']--;
                }
            } else {
                table[s2[i-1]-'a']++;
                table[s2[i + s1.Length - 1]-'a']--;
            }
            
            if (table.All(x => x == 0)) {
                return true;
            }
        }

        return false;
    }
}
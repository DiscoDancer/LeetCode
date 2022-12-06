public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        const int AlphabetSize = 128;
        const int currNumberInitialValue = 200; // 200 > 128

        var currNumber = currNumberInitialValue;
        var dictionary = new int[AlphabetSize];

        for (int i = 0; i < s.Length; i++) {
            if (dictionary[s[i]] == 0) {
                dictionary[s[i]] = currNumber++;
            }
        }

        var dictionary2 = new int[AlphabetSize];
        currNumber = currNumberInitialValue;
        for (int i = 0; i < t.Length; i++) {
            if (dictionary2[t[i]] == 0) {
                dictionary2[t[i]] = currNumber++;
            }
            if (dictionary2[t[i]] != dictionary[s[i]]) {
                return false;
            }
        }

        return true;
    }
}
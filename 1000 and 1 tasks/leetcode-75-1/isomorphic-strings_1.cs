public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        const int AlphabetSize = 128;

        var arr = new int[s.Length];
        var currNumber = 200;
        var dictionary = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++) {
            if (!dictionary.ContainsKey(s[i])) {
                dictionary[s[i]] = currNumber++;
            }
            arr[i] = dictionary[s[i]];
        }

        var dictionary2 = new Dictionary<char, int>();
        var currNumber2 = 200;
        for (int i = 0; i < t.Length; i++) {
            if (!dictionary2.ContainsKey(t[i])) {
                dictionary2[t[i]] = currNumber2++;
            }
            if (dictionary2[t[i]] != arr[i]) {
                return false;
            }
        }

        return true;
    }
}
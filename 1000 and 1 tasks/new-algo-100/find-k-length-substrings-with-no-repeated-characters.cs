public class Solution {
    // словарь и лист
    // словарь заменить на таблицу, лист заменить на индексы

    public int NumKLenSubstrNoRepeats(string s, int k) {
        if (s.Length < k) {
            return 0;
        }

        var list = new List<char>();
        var table = new int[26];
        var hs = new HashSet<char>();
        var result = 0;

        var i = 0;
        while (i < k) {
            list.Add(s[i]);
            table[s[i]-'a']++;
            hs.Add(s[i]);
            i++;
        }

        if (hs.Count() == list.Count()) {
            result++;
        }

        for (int right = i; right < s.Length; right++) {
            // remove first
            var first = list[0];

            list.RemoveAt(0);
            list.Add(s[right]);

            table[first-'a']--;
            if (table[first-'a'] == 0) {
                hs.Remove(first);
            }

            table[s[right]-'a']++;
            hs.Add(s[right]);

            if (hs.Count() == list.Count()) {
                result++;
            }
        }

        return result;
    }
}
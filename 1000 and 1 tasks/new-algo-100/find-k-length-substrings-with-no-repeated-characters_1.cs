public class Solution {
    // словарь и лист
    // словарь заменить на таблицу, лист заменить на индексы


    // можно убрать hs

    public int NumKLenSubstrNoRepeats(string s, int k) {
        if (s.Length < k) {
            return 0;
        }

        var list = new List<char>();
        var table = new int[26];
        var result = 0;
        var uniqueCount = 0;

        var i = 0;
        while (i < k) {
            list.Add(s[i]);
            if (table[s[i]-'a'] == 0) {
                uniqueCount++;
            }
            table[s[i]-'a']++;
            i++;
        }

        if (uniqueCount == list.Count()) {
            result++;
        }

        for (int right = i; right < s.Length; right++) {
            var first = list[0];

            list.RemoveAt(0);
            list.Add(s[right]);

            table[first-'a']--;
            if (table[first-'a'] == 0) {
                uniqueCount--;
            }

            table[s[right]-'a']++;
            if (table[s[right]-'a'] == 1) {
                uniqueCount++;
            }

            if (uniqueCount == list.Count()) {
                result++;
            }
        }

        return result;
    }
}
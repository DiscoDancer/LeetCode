public class Solution {
    // словарь и лист
    // словарь заменить на таблицу, лист заменить на индексы


    // можно убрать hs

    public int NumKLenSubstrNoRepeats(string s, int k) {
        if (s.Length < k) {
            return 0;
        }
        
        var table = new int[26];
        var result = 0;
        var uniqueCount = 0;
        var headIndex = 0;

        var i = 0;
        while (i < k) {
            if (table[s[i]-'a'] == 0) {
                uniqueCount++;
            }
            table[s[i]-'a']++;
            i++;
        }

        if (uniqueCount == k) {
            result++;
        }

        for (int right = i; right < s.Length; right++) {
            var first = s[headIndex];
            table[first-'a']--;
            if (table[first-'a'] == 0) {
                uniqueCount--;
            }

            table[s[right]-'a']++;
            if (table[s[right]-'a'] == 1) {
                uniqueCount++;
            }

            if (uniqueCount == k) {
                result++;
            }

            headIndex++;
        }

        return result;
    }
}
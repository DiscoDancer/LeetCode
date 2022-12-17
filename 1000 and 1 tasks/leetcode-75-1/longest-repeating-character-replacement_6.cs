public class Solution {
    public int CharacterReplacement(string s, int k) {
        var start = 0;
        var table = new int[26];
        var maxOccurance = 0;
        

        for (int end = 0; end < s.Length; end++) { 
            table[s[end]-'A']++;
            if (table[s[end]-'A'] > maxOccurance) {
                maxOccurance = table[s[end]-'A'];
            }

            var isValid = end + 1 - start - maxOccurance <= k;
            if (isValid) {
                // если валидная ничего не делаем, идем дальше
            }
            else {
                // если не валидная свдигаем start
                // обновить maxOccurance не обязательно (не оч понятно почему)
                table[s[start]-'A']--;
                start++;
            }
        }

        return s.Length - start;
    }
}
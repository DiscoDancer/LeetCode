public class Solution {
    public int FirstUniqChar(string s) {
        var table = new int?[26];

        for (var i = 0; i < s.Length; i++) {
            var charToInt = s[i]-'a';
            if (table[charToInt] == null) {
                table[charToInt] = i;
            }
            else {
                table[charToInt] = -1;
            }
        }

        var res = table.Where(x => x != null && x != -1).ToArray();
        if (!res.Any()) {
            return -1;
        }

        return res.Min().Value;
    }
    
}

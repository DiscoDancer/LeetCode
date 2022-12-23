public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var table = new int[26];

        foreach(var c in magazine) {
            table[c - 'a']++;
        }

        foreach(var c in ransomNote) {
            var charToInt = c - 'a';
            table[charToInt]--;
            if (table[charToInt] < 0) {
                return false;
            }
        }

        return true;
    }
}
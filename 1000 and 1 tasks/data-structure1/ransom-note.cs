public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var table = new int[26];

        foreach(var c in ransomNote) {
            table[c - 'a']--;
        }
        foreach(var c in magazine) {
            table[c - 'a']++;
        }

        return table.All(x => x >= 0);
    }
}
import java.util.*;


class Solution {
    public boolean canConstruct(String ransomNote, String magazine) {

        var table = new short[26];

        for (char c : magazine.toCharArray()) {
            table[c - 'a']++;
        }
        for (char c : ransomNote.toCharArray()) {
            table[c - 'a']--;
            if (table[c - 'a'] < 0)
                return false;
        }

        return true;
    }
}
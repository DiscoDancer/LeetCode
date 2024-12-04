import java.util.Arrays;

public class Solution {
    public boolean canConstruct(String ransomNote, String magazine) {
        var table = new int[26];
        for (var ch : magazine.toCharArray()) {
            table[ch - 'a']++;
        }
        for (var ch : ransomNote.toCharArray()) {
            table[ch - 'a']--;
        }

        return Arrays.stream(table).allMatch(count -> count >= 0);
    }
}
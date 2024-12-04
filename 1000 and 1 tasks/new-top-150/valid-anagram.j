class Solution {
    public boolean isAnagram(String s, String t) {
        var table = new int[26];
        for (var ch : s.toCharArray()) {
            table[ch - 'a']++;
        }
        for (var ch : t.toCharArray()) {
            table[ch - 'a']--;
        }

        return Arrays.stream(table).allMatch(count -> count == 0);
    }
}
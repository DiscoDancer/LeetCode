public class Solution {
    public bool BuddyStrings(string s, string goal) {
        if (s.Length != goal.Length) {
            return false;
        }

        if (s == goal) {
            var table = new char[26];
            foreach (var c in s) {
                table[c-'a']++;
            }

            return table.Any(x => x > 0 && x != 1);
        }

        var differences = new List<int>();

        var count = 0;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] != goal[i]) {
                differences.Add(i);
            }
            if (differences.Count() > 2) {
                return false;
            }
        }

        if (differences.Count() != 2) {
            return false;
        }

        return s[differences[0]] == goal[differences[1]] && s[differences[1]] == goal[differences[0]];
    }
}
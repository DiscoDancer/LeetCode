public class Solution {
    // Пример, когда для самого популярного будет неверно проверять
    // CCACCFGUUFGUUFGUU и k = 1

    private List<string> GenerateSubstrings(string s) {
        var list = new List<string>();

        for (int length = 1; length <= s.Length; length++) {
            for (int position = 0; position < s.Length && position + length <= s.Length; position++) {
                list.Add(s.Substring(position, length));
            }
        }

        return list;
    }

    public int CharacterReplacement(string s, int k) {
        var max = 0;

        for (char currentChar = 'A'; currentChar <= 'Z'; currentChar++) {
            if (!s.Contains(currentChar)) {
                continue;
            }

            var subs = GenerateSubstrings(s);

            foreach (var sub in subs) {
                var countNotCurrentChar = sub.Count(x => x != currentChar);
                if (countNotCurrentChar <= k) {
                    max = Math.Max(max, sub.Length);
                }
            }
        }

        return max;
    }
}
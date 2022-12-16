public class Solution {
    // Пример, когда для самого популярного будет неверно проверять
    // CCACCFGUUFGUUFGUU и k = 1
    // буквы все не оч перебирать

    private List<string> GenerateSubstrings(string s) {
        var list = new List<string>();

        const int substringMinLength = 1;

        for (int length = substringMinLength; length <= s.Length; length++) {
            for (int position = 0; position < s.Length && position + length <= s.Length; position++) {
                list.Add(s.Substring(position, length));
            }
        }

        return list;
    }

    private int GetMostPopularCount (string s) {
        var table = new char[26];

        var max = 0;

        foreach(var c in s) {
            var i = c - 'A';
            table[i]++;
            if (table[i] > max) {
                max = table[i];
            }
        }

        return max;
    }

    public int CharacterReplacement(string s, int k) {
        var max = 0;

        var subs = GenerateSubstrings(s);

        foreach (var sub in subs) {
            var mostPopularCount = GetMostPopularCount(sub);
            var countRest = sub.Length - mostPopularCount;

            if (countRest <= k) {
                max = Math.Max(max, sub.Length);
            }
        }

        return max;
    }
}
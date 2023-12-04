public class Solution {
    // кодирование
    // 0 первый символ, расстояние от первого для остальные (без abs)

    // мб 2 стороны рассмотреть

    // ["az","ba"]
    // az: z-a = 25 a-b = -1 (if < 0 then + 26 -> 25)

    // abc -> 0-1-1
    // bcd -> 0-1-1
    // xyz -> 0-1-1
    public IList<IList<string>> GroupStrings(string[] strings) {

        var table = new Dictionary<string, IList<string>>();
        foreach (var s in strings) {
            var encoded = Encode(s);
            if (!table.ContainsKey(encoded)) {
                table[encoded] = new List<string>();
            }
            table[encoded].Add(s);
        }

        return table.Values.ToList();
    }

    private string Encode(string s) {
        var sb = new StringBuilder();
        sb.Append('0');
        var prev = s[0];

        for (int i = 1; i < s.Length; i++) {
            var cur = s[i];
            int num = (cur-'a') - (prev-'a');
            if (num < 0) {
                num += 26;
            }

            sb.Append((char)num);
            prev = cur;
        }

        return sb.ToString();
    }
}
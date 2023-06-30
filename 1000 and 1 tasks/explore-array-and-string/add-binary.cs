public class Solution {
    public string AddBinary(string a, string b) {
        if (b.Length > a.Length) {
            return AddBinary(b,a);
        }

        var result = new List<int>();
        int surplus = 0;
        var min = Math.Min(a.Length, b.Length);
        for (int i = 0; i < min; i++) {
            var curA = a[a.Length -1 - i] - '0';
            var curB = b[b.Length - 1 - i] - '0';
            var res = curA + curB + surplus;
            var digit = res % 2;
            surplus = res / 2;
            result.Insert(0, digit);
        }

        for (int i = 0; i < a.Length - min; i++) {
            var curA = a[a.Length -1 - i - min ] - '0';
            var res = curA + surplus;
            var digit = res % 2;
            surplus = res / 2;
            result.Insert(0, digit);
        }

        if (surplus > 0) {
            result.Insert(0, surplus);
        }

        var sb = new StringBuilder();
        foreach (var c in result) {
            sb.Append(c);
        }

        return sb.ToString();
    }
}
public class Solution {
    // a.length >= b.length
    public string AddBinary(string a, string b) {
        if (b.Length > a.Length) {
            return AddBinary(b,a);
        }

        var minLength = Math.Min(a.Length, b.Length);
        var surplus = 0;

        var sb = new StringBuilder();

        var i = 0;

        for (i = 0; i < minLength; i++) {
            var ai = a.Length - 1 - i;
            var bi = b.Length - 1 - i;

            var aNum = a[ai] - '0';
            var bNum = b[bi] - '0';

            var res = aNum + bNum + surplus;
            sb.Insert(0, res % 2 == 0 ? '0' : '1');
            surplus = res / 2;
        }

        i = a.Length - minLength - 1;
        while (i >= 0) {

            var aNum = a[i] - '0';
            var res = aNum + surplus;
            sb.Insert(0, res % 2 == 0 ? '0' : '1');
            surplus = res / 2;

            i--;
        }

        if (surplus > 0) {
             sb.Insert(0, '1');
        }

        return sb.ToString();
    }
}
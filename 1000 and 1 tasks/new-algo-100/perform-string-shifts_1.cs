public class Solution {
    // ходит только указатель, длина надо запомнить в конце записать
    public string StringShift(string s, int[][] shift) {
        var length = s.Length;
        var i = 0;

        foreach (var curShift in shift) {
            var dir = curShift[0];
            var amount = curShift[1];

            if (dir == 0) {
                i -= amount;
            }
            else {
                i += amount;
            }
        }

        i %= length;
        if (i < 0) {
            i += length;
        }

        var sb = new StringBuilder();
        // i = длина первой части
        // length - i = начало первой части

        var j = length - i;
        while (j < length) {
            sb.Append(s[j++]);
        }

        j = i;
        var k = 0;
        while (j++ < length)
        {
            sb.Append(s[k++]);
        }

        return sb.ToString();
    }
}
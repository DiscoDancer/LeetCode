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
                // i % = length;
                // if (i < 0) {
                //     i += length;
                // }
            }
            else {
                i += amount;
                // i % = length;
            }
        }

        i %= length;
        if (i < 0) {
            i += length;
        }

        var sb1 = new StringBuilder();
        var j = i;
        var k = 0;
        while (j++ < length)
        {
            sb1.Append(s[k++]);
            
        }
        
        var sb2 = new StringBuilder();
        var m = 0;
        while (k < length)
        {
            sb2.Append(s[k++]);
        }

        return sb2.ToString() + sb1.ToString();
    }
}
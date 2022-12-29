public class Solution {
    // s = digits + #
    // 1..9 -> a..i
    // j..z -> 10# .. 26#

    /*
        Решение:
        - идем с конца
        - встретили # -> читаем еще 2 и конвертируем
        - не встретили -> сразу конвертируем
    */

    private char IntToChar(int x) {
        return (char) (x + (int)'a' - 1);
    }

    public string FreqAlphabets(string s) {
        var sb = new StringBuilder();
        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] == '#') {
                var x = s[--i] - '0';
                var xx = (s[--i] - '0') * 10;
                var num = x + xx;
                sb.Insert(0, IntToChar(num));
            }
            else {
                var x = s[i] - '0';
                sb.Insert(0, IntToChar(x));
            }
        }

        return sb.ToString();
    }
}
public class Solution {
    // для начала можно тупо за квадрат
    // ставим палочки от 1 до n-2 (точно так?)
    // и проверяем
    // Я не понял задачу, и начал искать самый большой полидром, а тут хотят не этого 
    // ---



    public int Calc1 (int startIndex, string s) {
        var a = startIndex - 1;
        var b = startIndex + 1;

        var res = 1;

        while (a >= 0 && b <= s.Length - 1) {
            if (s[a] == s[b]) {
                res+=2;
            }
            a--;
            b++;
        }

        return res;
    }

    public int Calc2 (int startIndex, string s) {
        var a = startIndex ;
        var b = startIndex + 1;

        var res = 0;

        while (a >= 0 && b <= s.Length - 1) {
            if (s[a] == s[b]) {
                res+=2;
            }
            a--;
            b++;
        }

        return res;
    }

    public int LongestPalindrome(string s) {
        var max = 0;
        for (int i = 0; i < s.Length; i++) {
            max = Math.Max(max, Calc1(i, s));
            max = Math.Max(max, Calc2(i, s));
        }

        return max;
    }
}
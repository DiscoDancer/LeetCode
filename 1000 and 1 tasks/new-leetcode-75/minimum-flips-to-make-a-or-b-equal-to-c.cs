public class Solution {
    // побитовое сравнение в лоб
    // если в c1, значит в этих двух хотябы 1
    // если в 0, значит в этих вдух все должны быть нули
    // можно список, а можно тупо с конца с идти
    public int MinFlips(int a, int b, int c) {
        var result = 0;

        while (c > 0 || a > 0 || b > 0) {
            var lastC = c % 2;
            var lastA = a % 2;
            var lastB = b % 2;

            if (lastC == 0) {
                if (lastA == 1 || lastB == 1) {
                    result += lastA + lastB ;
                }
            }
            else if (lastC == 1) {
                if (lastA == 0 && lastB == 0) {
                    result++;
                }
            }

            c = c >> 1;
            a = a >> 1;
            b = b >> 1;
        }

        return result;
    }
}
public class Solution {
    public bool IsUgly(int n) {
        var any = true;
        while (n > 0 && any) {
            any = false;
            if (n % 2 == 0) {
                any = true;
                n = n / 2;
            }
            if (n % 3 == 0) {
                any = true;
                n = n / 3;
            }
            if (n % 5 == 0) {
                any = true;
                n = n / 5;
            }
        }

        return n == 1;
    }

    // бинарный поиск
    // считать простое число
    // у меня число Х, я могу сказать, сколько до него делящихся на 2, на 3 и тд
    public int NthUglyNumber(int n) {
        var x = 1;
        var m = 1;
        while (m < n) {
            x++;
            if (IsUgly(x)) {
                m++;
            }
        }
        return x;
    }
}
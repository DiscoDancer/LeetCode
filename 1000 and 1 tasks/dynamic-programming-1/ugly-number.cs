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
}
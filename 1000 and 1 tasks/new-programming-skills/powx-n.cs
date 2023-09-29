public class Solution {
    public double MyPow(double x, long n) {
        if (n < 0) {
            return 1.0 / (MyPow(x, -n));
        }

        if (n == 0) {
            return 1;
        }
        if (n == 1) {
            return x;
        }

        if (n % 2 == 0) {
            return MyPow(x*x, n/2);
        }

        return x * MyPow(x*x, n / 2);
    }
}
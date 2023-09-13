public class Solution {
    public double MyPow2(double x, long n) {
        if (n == 0) {
            return 1;
        }
        else if (n < 0) {
            return 1 / MyPow2(x, -n);
        }

        return MyPow2(x*x, n / 2) * (n % 2 == 0 ? (long)1 : x);
    }

    public double MyPow(double x, int n) {
        return MyPow2(x, n);
    }
}
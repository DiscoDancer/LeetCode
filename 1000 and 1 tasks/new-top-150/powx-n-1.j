class Solution {
    // stack overflow
    public double myPow(double x, int n) {
        if (n < 0) {
            return 1 / myPow(x, -n);
        }
        if (n == 0) {
            return 1;
        }

        return x * myPow(x, n - 1);
    }
}
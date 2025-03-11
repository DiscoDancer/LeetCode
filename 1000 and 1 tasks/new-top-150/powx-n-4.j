class Solution {

    public double positivePow(double x, long n) {
        if (n == 0) {
            return 1;
        }
        if (n == 1) {
            return x;
        }

        var result = 1.0;
        while (n > 0) {
            if (n % 2 == 1) {
                result *= x;
            }
            x *= x;
            n /= 2;
        }

        return result;
    }

    public double myPow(double x, long n) {
        if (n < 0) {
            return 1 / positivePow(x, -n);
        }

        return positivePow(x, n);
    }
}
class Solution {
    // TL
    public double myPow(double x, int n) {
        if (n < 0) {
            return 1 / myPow(x, -n);
        }


        double result = 1;
        while (n-- > 0) {
            result *= x;
        }

        return result;
    }
}
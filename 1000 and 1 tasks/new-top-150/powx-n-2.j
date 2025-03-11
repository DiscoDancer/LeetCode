class Solution {
    public double myPow(double x, int n) {
        if (n < 0) {
            return 1 / myPow(x, -n);
        }
        if (n == 0) {
            return 1;
        }
        
        return myPow(x*x, n/2) * (n % 2 == 0 ? 1 : x);
    }
}
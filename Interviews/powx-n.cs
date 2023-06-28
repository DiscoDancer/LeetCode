public class Solution {

    // TL
    
    private double Positive(double x, int n) {
        double result = 1;
        for (int i = 0; i < n; i++) {
            result *= x;
        }

        return result;
    }

    private double Negative(double x, int n) {
        n = Math.Abs(n);
        double result = 1;
        for (int i = 0; i < n; i++) {
            result /= x;
        }

        return result;
    }

    public double MyPow(double x, int n) {
        if (n >= 0) {
            return Positive(x, n);
        }
        return Negative(x, n);
    }
}
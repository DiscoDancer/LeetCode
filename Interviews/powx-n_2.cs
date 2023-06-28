public class Solution {
    // editrorial 
    private Dictionary<(double, long), double> _memPositive = new ();
    private double Positive(double x, long n) {
        if (n == 0) {
            return 1;
        }
        if (n == 1) {
            return x;
        }
        if (_memPositive.ContainsKey((x,n))) {
            return _memPositive[(x,n)];
        }

        if (n > 0) {
            double result;
            if (n % 2 == 1) {
                result = x * Positive(x*x, (n-1) / 2);
            }
            else {
                result = Positive(x*x, n / 2);
            }
            
            _memPositive[(x,n)] = result;
            return result;
        }
        else {
            return 1.0 / Positive(x, n * (-1));
        }
    }

    public double MyPow(double x, int n) {
        if (x == 1 || x == 0) {
            return x;
        }

        return Positive(x, (long)n);
    }
}
public class Solution {
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
            var a = n / 2;
            var result = Positive(x, a) * Positive(x, n-a);
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
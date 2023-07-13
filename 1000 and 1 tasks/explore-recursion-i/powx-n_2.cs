// stack overflow
public class Solution {
    public double MyPow2(double x, long n) {
       if (n == 0) {
           return 1;
       }
       if (n == 1) {
           return x;
       }
       if (n < 0) {
           return 1.0 / MyPow2(x, (-1)*n);
       }

       return (n/2 > 0 ? MyPow2(x*x, n/2) : 1.0 ) * (n%2 == 1 ? x : 1.0);
    }

    public double MyPow(double x, int n) {
        return MyPow2(x, (long)n);
    }
}
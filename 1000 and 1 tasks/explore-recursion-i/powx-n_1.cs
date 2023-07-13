// stack overflow
public class Solution {
    public double MyPow(double x, int n) {
       if (n == 0) {
           return 1;
       }
       if (n == 1) {
           return x;
       }
       if (n < 0) {
           return 1.0 / MyPow(x, (-1)*n);
       }

       return (n/2 > 0 ? MyPow(x*x, n/2) : 1.0 ) * (n%2 == 1 ? x : 1.0);
    }
}
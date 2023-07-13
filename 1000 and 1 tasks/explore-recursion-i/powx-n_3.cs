// editorial
public class Solution {
    public double MyPow2(double x, long n) {
       if (n < 0) {
           return 1.0 / MyPow2(x, (-1)*n);
       }

       var result = 1.0;
       while (n > 0) {
           if (n % 2 == 1) {
               result *= x;
           }

           x*=x;
           n/=2;
       }

       return result;
    }

    public double MyPow(double x, int n) {
        return MyPow2(x, (long)n);
    }
}
// TL
public class Solution {
    public double MyPow(double x, int n) {
       if (n == 0) {
           return 1;
       }
       if (n < 0) {
           return 1.0 / MyPow(x, (-1)*n);
       }

       var res = 1.0;
       for (int i = 0; i < n; i++) {
           res *=x;
       }

       return res;
    }
}
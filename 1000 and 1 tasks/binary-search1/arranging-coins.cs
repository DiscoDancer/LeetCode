public class Solution {
    public int ArrangeCoins(int n) {
        var i = 1;
        while (n > 0) {
            n -= i;
            i++;
        }
        
        if (n == 0) {
            return i - 1;
        }
        return i - 2;
    }
}
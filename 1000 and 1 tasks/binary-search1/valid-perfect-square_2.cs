public class Solution {
    public bool IsPerfectSquare(long num) {
        if (num == 1) {
            return true;
        }
        if (num == 2) {
            return false;
        }
        if (num == 3) {
            return false;
        }
        
        long high = 2;
        
        while (high * high < num) {
            high *= 2;
        }
        
        // high - степень двойки, которая ^2 >= num
        
        if (high*high == num) {
            return true;
        }
        
        // low and high
        long low = high / 2;
        
        while (low <= high) {
            long m = low + (high - low)/2;
            
            if (m*m > num) {
                high = m - 1;
            }
            else if (m*m < num) {
                low = m + 1;
            } else {
                return true;
            }
        }
        
        return false;
    }
}
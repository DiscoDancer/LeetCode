public class Solution {

    // too slow
    public bool IsPerfectSquare(int num) {
        if (num == 1) {
            return true;
        }
        if (num == 2) {
            return false;
        }
        if (num == 3) {
            return false;
        }
        
        var low = 2;
        
        while (low * low < num) {
            low *= 2;
        }
        
        // low - степень двойки, которая ^2 >= num
        
        if (low*low == num) {
            return true;
        }
        
        // теперь low - степень двойки, которая ^2 > num
        // и нам надо пройти от low/2 до low
        
        for (int i = Math.Max(low / 2, 2); i <= low; i++) {
            if (i*i == num) {
                return true;
            }
        }
        
        return false;
        
        // return low*low == num;
    }
}
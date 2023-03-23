public class Solution {
    private int CountDigits(int x) {
        if (x == 0) {
            return 1;
        }

        var result = 0;

        while (x > 0) {
            x = x / 10;
            result++;
        }

        return result;
    }

    public int FindNumbers(int[] nums) {
        var result = 0;
        
        foreach (var n in nums) {
            if (CountDigits(n) % 2 == 0) {
                result++;
            }
        }

        return result;
    }
}
public class Solution {
    public string ConvertToBase7(int num) {
        if (num == 0) {
            return "0";
        }

        var minus = num < 0;
        
        var sb = new StringBuilder();
        var x = Math.Abs(num);

        while (x > 0) {
            sb.Insert(0, x % 7);
            x /= 7;
        }

        if (num < 0) {
            sb.Insert(0, '-');
        }

        return sb.ToString();
    }
}
public class Solution {
    public bool IsArmstrong(int n) {
        long sum = 0;
        var str = n.ToString();
        foreach (var c in str.ToCharArray()) {
            var digit = c - '0';
            sum += (long)Math.Pow(digit, str.Length);
            if (sum > n) {
                return false;
            }
        }

        return sum == n;
    }
}
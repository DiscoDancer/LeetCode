public class Solution {
    public int SubtractProductAndSum(int n) {
        var digits = n.ToString().ToCharArray();

        var sum = 0;
        var product = 1;
        foreach (var d in digits) {
            var c = d - '0';
            sum += c;
            product *= c;
        }

        return product - sum;
    }
}
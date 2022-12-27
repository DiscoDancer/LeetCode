public class Solution {
    public double Average(int[] salary) {
        var max = salary[0];
        var min = salary[0];
        double sum = 0;

        foreach (var s in salary) {
            max = Math.Max(max, s);
            min = Math.Min(min, s);
            sum += s;
        }

        var res = (sum - max - min) / (salary.Length - 2);
        return res;
    }
}
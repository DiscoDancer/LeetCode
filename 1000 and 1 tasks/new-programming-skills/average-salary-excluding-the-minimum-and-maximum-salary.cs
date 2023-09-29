public class Solution {
    public double Average(int[] salary) {
        long sum = 0;
        var max = salary[0];
        var min = salary[0];

        foreach (var s in salary) {
            sum += s;

            max = Math.Max(max, s);
            min = Math.Min(min, s);
        }

        return ((double)(sum-max-min)) / (salary.Length - 2);
    }
}
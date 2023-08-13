public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        var n = days.Length;
        var table = new int[n+1];

        for (var dayIndex = n-1; dayIndex >= 0; dayIndex--) {
            var d1 = table[dayIndex +1] + costs[0];

            var nextIndex = dayIndex + 1;
            while (nextIndex < n && days[nextIndex] < days[dayIndex] + 7) {
                nextIndex++;
            }
            var d7 = table[nextIndex] + costs[1];

            nextIndex = dayIndex + 1;
            while (nextIndex < n && days[nextIndex] < days[dayIndex] + 30) {
                nextIndex++;
            }
            var d30 = table[nextIndex] + costs[2];

            table[dayIndex] = Math.Min(d1,Math.Min(d7,d30));
        }

        return table[0];
    }
}
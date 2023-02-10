public class Solution {
    // naive TL
    public int[] DailyTemperatures(int[] temperatures) {
        var result = new int[temperatures.Length];
        for (int i = 0; i < temperatures.Length; i++) {
            var j = i + 1;
            while (j < temperatures.Length && temperatures[j] <= temperatures[i]) {
                j++;
            }

            if (j < temperatures.Length) {
                result[i] = j - i;
            }
        }

        return result;
    }
}
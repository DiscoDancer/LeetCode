public class Solution {
    public int HeightChecker(int[] heights) {
        var values = new int[101];

        foreach (var h in heights) {
            values[h]++;
        }

        var sorted = new int[heights.Length];
        var k = 0;
        for (int i = 1; i < 101; i++) {
            for (int j = 0; j < values[i]; j++) {
                sorted[k++] = i;
            }
        }

        var result = 0;
        for (int i = 0; i < heights.Length; i++) {
            if (sorted[i] != heights[i]) result++;
        }

        return result;
    }
}
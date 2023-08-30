public class Solution {
    public int HeightChecker(int[] heights) {
        var values = new int[101];

        foreach (var h in heights) {
            values[h]++;
        }

        var k = 0;
        var result = 0;
        for (int i = 1; i < 101; i++) {
            for (int j = 0; j < values[i]; j++) {
                if (heights[k++] != i) result++;
            }
        }

        return result;
    }
}
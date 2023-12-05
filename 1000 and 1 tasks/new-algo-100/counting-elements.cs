public class Solution {
    public int CountElements(int[] arr) {
        var table = new int[1001];
        foreach (var n in arr) {
            table[n]++;
        }

        var result = 0;
        for (int i = 0; i < 1001; i++) {
            if (table[i] > 0 && i < 1000 && table[i+1] > 0) {
                result += table[i];
            }
        }

        return result;
    }
}
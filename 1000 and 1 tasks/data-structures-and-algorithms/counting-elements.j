import java.util.Arrays;

class Solution {
    public int countElements(int[] arr) {
        var table = new int[1002];
        for (var x: arr) {
            table[x]++;
        }

        var result = 0;
        for (var x: arr) {
            if (table[x+1] > 0) {
                result++;
            }
        }

        return result;
    }
}
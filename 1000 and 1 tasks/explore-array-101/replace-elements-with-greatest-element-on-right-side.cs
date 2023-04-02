public class Solution {
    public int[] ReplaceElements(int[] arr) {
        var max = -1;
        for (int i = arr.Length - 1; i >= 0; i--) {
            var tmp = arr[i];
            arr[i] = max;
            max = Math.Max(tmp, max);
        }

        return arr;
    }
}
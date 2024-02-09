public class Solution {
    public int MissingNumber(int[] arr) {
        var sorted = arr.OrderBy(x => x).ToArray();
        

        var maxD = -1;
        var prev = sorted[0];
        // можно за 1 проход, если определить аномалию, нету аналомалия = первая пара
        for (int i = 1; i < sorted.Length; i++) {
            var cur = sorted[i];
            maxD = Math.Max(cur-prev, maxD);
            prev = cur;
        }

        prev = sorted[0];
        for (int i = 1; i < sorted.Length; i++) {
            var cur = sorted[i];
            if (cur-prev == maxD) {
                return prev + (maxD/2);
            }
            prev = cur;
        }

        return -1;
    }
}
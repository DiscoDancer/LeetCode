import java.util.Arrays;
import java.util.Comparator;

class Solution {

    public int findKthPositive(int[] arr, int k) {
        // надо начальные отдельно рассмотреть
        var beginningMissingCount = arr[0] - 1;
        if (k <= beginningMissingCount) {
            return k;
        }
        k -= beginningMissingCount;

        // конец тоже можно отдельно
        var totalLength = arr.length;
        var totalDiff = arr[totalLength - 1] - arr[0];
        var insideMissingCount = totalDiff - totalLength + 1;

        if (k > insideMissingCount) {
            k -= insideMissingCount;
            return arr[totalLength - 1] + k;
        }

        var l = 0;
        var r = arr.length - 1;
        while (l <= r) {
            var mid = l + (r - l) / 2;
            var length = r - l + 1;

            // potential base case
            if (length == 2) {
                return arr[l] + k;
            }
            var leftLength = mid - l + 1;
            var diff = arr[mid] - arr[l];
            var missingCountLeft = diff - leftLength + 1;
            if (k <= missingCountLeft) {
                r = mid;
            }
            else {
                l = mid;
                k -= missingCountLeft;
            }
        }


        return -1;
    }
}

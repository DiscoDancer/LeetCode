import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.PriorityQueue;

class Solution {

    public int hIndex(int[] citations) {
        var l = 0;
        var r = citations.length - 1;

        while (l <= r) {
            var mid = l + (r - l) / 2;
            var rightCountIncluding = citations.length - mid;
            if (citations[mid] >= rightCountIncluding && (mid == 0 || citations[mid - 1] <= rightCountIncluding)) {
                return rightCountIncluding;
            }
            if (citations[mid] < rightCountIncluding) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }

        return 0;
    }
}

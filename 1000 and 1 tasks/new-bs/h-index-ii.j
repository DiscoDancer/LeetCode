import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.PriorityQueue;

class Solution {

    public int hIndex(int[] citations) {
        for (var i = 0; i < citations.length; i++) {
            var rightCountIncluding = citations.length - i;
            if (citations[i] >= rightCountIncluding) {
                return rightCountIncluding;
            }
        }

        return 0;
    }
}

import java.util.Arrays;
import java.util.Comparator;

// see find-minimum-in-rotated-sorted-array


class Solution {
    interface ArrayReader {
        int get(int index);
    }

    private int getLastIndex(ArrayReader reader) {
        var l = 0;
        var r = 10000;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (reader.get(m) != Integer.MAX_VALUE && reader.get(m + 1) == Integer.MAX_VALUE) {
                return m;
            }
            if (reader.get(m) == Integer.MAX_VALUE) {
                r = m - 1;
            } else {
                l = m + 1;
            }
        }

        return -1;
    }

    public int search(ArrayReader reader, int target) {

        // todo find size (last index)
        var l = 0;
        var r = getLastIndex(reader);

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (reader.get(m) == target) {
                return m;
            }
            if (reader.get(m) < target) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return -1;
    }
}

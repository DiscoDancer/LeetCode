import java.util.Arrays;
import java.util.Comparator;

// see find-minimum-in-rotated-sorted-array


class Solution {
    interface ArrayReader {
        // Compares the sum of arr[l..r] with the sum of arr[x..y]
        // return 1 if sum(arr[l..r]) > sum(arr[x..y])
        // return 0 if sum(arr[l..r]) == sum(arr[x..y])
        // return -1 if sum(arr[l..r]) < sum(arr[x..y])
        public int compareSub(int l, int r, int x, int y);

        // Returns the length of the array
        public int length();
    }

    public int getIndex(ArrayReader reader) {

        // both including
        var l = 0;
        var r = reader.length() - 1;

        while (l <= r) {
            var length = r - l + 1;
            if (length == 1) {
                return l;
            }
            if (length % 2 == 1) {
                var mid = l + length / 2;
                var cmpResult = reader.compareSub(l, mid - 1, mid + 1, r);
                if (cmpResult == 0) {
                    return mid;
                }
                else if (cmpResult == 1) {
                    r = mid - 1;
                }
                else if (cmpResult == -1) {
                    l = mid + 1;
                }
            }
            else if (length % 2 == 0) {
                // 2 середины
                var mid1 = l + (r-l) / 2;
                var mid2 = mid1 + 1;
                var cmpResult = reader.compareSub(l, mid1, mid2, r);
                // они не могут быть равны
                if (cmpResult == 1) {
                    r = mid1;
                }
                else if (cmpResult == -1) {
                    l = mid2;
                }
            }
        }

        return -1;
    }
}

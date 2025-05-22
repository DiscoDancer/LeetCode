import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.PriorityQueue;

class Solution {

    public int peakIndexInMountainArray(int[] arr) {
        var l = 0;
        var r = arr.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            // peak is the first element
            if (m == 0 && arr[m] > arr[m + 1]) {
                return m;
            }
            // peak is the last element
            if (m == arr.length - 1 && arr[m] > arr[m - 1]) {
                return m;
            }
            // peak is in the middle
            if (m > 0 && arr[m] > arr[m - 1] && arr[m] > arr[m + 1] && m < arr.length - 1) {
                return m;
            }

            // они не могут быть одинаковыми, иначе все сломается
            // если слева меньше, значит там точно пика нет
            if (m == 0 || arr[m] > arr[m - 1]) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return -1;
    }
}

import java.util.*;

class Solution {


    private int FindClosestLessThanIndex(int[] arr, int x) {
        var l = 0;
        var r = arr.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            // if m is the last element or next is bigger
            if (arr[m] <= x && (m == arr.length - 1 || arr[m + 1] > x)) {
                return m;
            }
            if (arr[m] <= x) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return 0;
    }


    public List<Integer> findClosestElements(int[] arr, int k, int x) {

        // найти ближайший слева
        var closestLessThanIndex = FindClosestLessThanIndex(arr, x);
        // просто читаем с конца
        if (closestLessThanIndex == arr.length - 1) {
            var result = new ArrayList<Integer>(k);
            for (var i = arr.length - 1; i >= 0 && result.size() < k; i--) {
                result.add(0, arr[i]);
            }
            return result;
        }
        else {
            var result = new ArrayList<Integer>(k);
            // 2 указателя на 2 стороны
            var p = closestLessThanIndex;
            var q = closestLessThanIndex + 1;

            // выбираем, если есть из чего
            while (result.size() < k) {
                if (p >= 0 && q < arr.length) {
                    if (Math.abs(arr[p] - x) <= Math.abs(arr[q] - x)) {
                        result.add(0, arr[p]);
                        p--;
                    } else {
                        result.add(arr[q]);
                        q++;
                    }
                } else if (p >= 0) {
                    result.add(0, arr[p]);
                    p--;
                } else if (q < arr.length) {
                    result.add(arr[q]);
                    q++;
                }
            }

            return result;
        }
    }
}

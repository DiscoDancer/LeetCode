public class Solution {
    public bool CheckPoint(int[] arr, int i) {
        var l = i - 1;
        var r = i + 1;

        var prev = arr[i];
        while (l >= 0) {
            if (arr[l] >= prev) {
                return false;
            }
            prev = arr[l--];
        }

        prev = arr[i];
        while (r <= arr.Length - 1) {
            if (arr[r] >= prev) {
                return false;
            }
            prev = arr[r++];
        }

        return true;
    }

    public bool ValidMountainArray(int[] arr) {
        for (int i = 1; i < arr.Length - 1; i++) {
            if (CheckPoint(arr, i)) {
                return true;
            }
        }

        return false;
    }
}
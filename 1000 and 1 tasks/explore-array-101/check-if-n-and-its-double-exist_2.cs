public class Solution {
    public bool Contains(int[] arr, int x, int i) {
        var a = i;
        var b = arr.Length - 1;
        while (a <= b) {
            var m = a + (b-a)/2;
            if (arr[m] == x) {
                return true;
            }
            else if (arr[m] < x) {
                a = m + 1;
            }
            else {
                b = m - 1;
            }
        }
        return false;
    }

    public bool CheckIfExist(int[] arr) {
        arr = arr.OrderBy(x => x).ToArray();

        for (int i = 0; i < arr.Length; i++) {
            if (Contains(arr, arr[i] * 2, i + 1)) {
                return true;
            }
            if (arr[i] % 2 == 0 && Contains(arr, arr[i] / 2, i + 1)) {
                return true;
            }
        }

        return false;
    }
}
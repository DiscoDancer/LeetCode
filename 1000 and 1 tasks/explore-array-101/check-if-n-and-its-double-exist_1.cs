public class Solution {
    public bool Contains(int[] arr, int x, int i) {
        for (; i < arr.Length; i++) {
            if (arr[i] == x ) {
                return true;
            }
        }
        return false;
    }

    public bool CheckIfExist(int[] arr) {
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
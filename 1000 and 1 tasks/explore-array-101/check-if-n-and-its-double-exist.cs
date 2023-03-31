public class Solution {
    public bool Contains(int[] arr, int x, int j) {
        for (int i = 0; i < arr.Length; i++) {
            if (i != j && arr[i] == x ) {
                return true;
            }
        }
        return false;
    }

    public bool CheckIfExist(int[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            if (Contains(arr, arr[i] * 2, i)) {
                return true;
            }
        }

        return false;
    }
}
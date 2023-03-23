public class Solution {
    public void DuplicateZeros(int[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == 0) {
                var prev = 0;
                var j = i + 1;
                while (j < arr.Length) {
                    var tmp = arr[j];
                    arr[j] = prev;
                    prev = tmp;
                    j++;
                }
                i++; // иначе зациклимся
            }
        }
    }
}
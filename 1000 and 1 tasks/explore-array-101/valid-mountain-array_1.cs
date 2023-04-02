public class Solution {
    public bool ValidMountainArray(int[] arr) {
        var prev = arr[0];
        var i = 1;

        var hasAnyLess = false;
        while (i < arr.Length && arr[i] > prev) {
            prev = arr[i++];
            hasAnyLess = true;
        }

        var hasAnyBigger = false;
        while (i < arr.Length && arr[i] < prev) {
            prev = arr[i++];
            hasAnyBigger = true;
        }

        return i == arr.Length && hasAnyLess && hasAnyBigger;
    }
}
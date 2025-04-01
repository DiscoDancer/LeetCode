import java.util.*;


class Solution {

    private int[] arr;
    private int difference;
    private int max;

    private void F(int i, int prevI, int score) {
        if (i == arr.length) {
            max = Math.max(max, score);
            return;
        }

        if (prevI == -1){
            // take
            F(i + 1, i, score + 1);
            // skip
            F(i + 1, prevI, score);
        }
        else {
            // take
            if (arr[i] - arr[prevI] == difference) {
                F(i + 1, i, score + 1);
            }
            // skip
            F(i + 1, prevI, score);
        }
    }

    public int longestSubsequence(int[] arr, int difference) {

        this.arr = arr;
        this.difference = difference;

        F(0, -1, 0);

        return this.max;
    }
}

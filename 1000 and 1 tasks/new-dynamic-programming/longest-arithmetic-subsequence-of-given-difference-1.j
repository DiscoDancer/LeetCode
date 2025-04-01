import java.util.*;


class Solution {

    private int[] arr;
    private int difference;

    private int F(int i, int prevI) {
        if (i == arr.length) {
            return 0;
        }

        var take = 0;
        var skip = 0;

        if (prevI == -1){
            // take
            take = 1 + F(i + 1, i);
            // skip
            skip = F(i + 1, prevI);
        }
        else {
            // take
            if (arr[i] - arr[prevI] == difference) {
                take = 1 + F(i + 1, i);
            }
            // skip
            skip = F(i + 1, prevI);
        }

        return Math.max(take, skip);
    }

    public int longestSubsequence(int[] arr, int difference) {

        this.arr = arr;
        this.difference = difference;

        return F(0, -1);
    }
}

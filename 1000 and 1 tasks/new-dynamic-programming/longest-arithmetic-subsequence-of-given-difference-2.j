import java.util.*;


class Solution {

    // memory limit

    public int longestSubsequence(int[] arr, int difference) {
        var table = new int[arr.length + 1][arr.length + 1][2];

        for (var init = 1; init >= 0; init--) {
            for (var i = arr.length; i >= 0; i--) {
                for (var prevI = arr.length - 1; prevI >= 0; prevI--) {
                    if (i == arr.length) {
                        table[i][prevI][init] = 0;
                    } else {
                        var take = 0;
                        var skip = 0;

                        if (init == 0){
                            // take
                            take = 1 + table[i + 1][i][1];
                            // skip
                            skip = table[i + 1][prevI][0];
                        }
                        else {
                            // take
                            if (arr[i] - arr[prevI] == difference) {
                                take = 1 + table[i + 1][i][1];
                            }
                            // skip
                            skip = table[i + 1][prevI][1];
                        }

                        table[i][prevI][init] = Math.max(take, skip);
                    }
                }
            }
        }

        return table[0][0][0];
    }
}

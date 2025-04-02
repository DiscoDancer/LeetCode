class Solution {

    // TL

    public int longestSubsequence(int[] arr, int difference) {

        var max = 1;
        var table = new int[arr.length];
        for (var i = 0; i < arr.length; i++) {
            if (i == 0) {
                table[i] = 1;
            }
            else {
                table[i] = 1;
                var j = i - 1;
                while (j >= 0) {
                    if (arr[i] - arr[j] == difference) {
                        table[i] = Math.max(table[i], table[j] + 1);
                        max = Math.max(max, table[i]);
                        break;
                    }
                    j--;
                }
            }
        }

        return max;
    }
}
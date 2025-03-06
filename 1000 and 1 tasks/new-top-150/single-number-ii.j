import java.util.*;

// editorial

class Solution {

    public int singleNumber(int[] nums) {
        var arr = new int[32];

        for (var x: nums) {

            for (int i = 0; i < 32; i++) {
                // 0 or 1
                var bit = (x >> i) & 1;
                arr[31 - i] += bit;
                arr[31 - i] = arr[31 - i] % 3;
            }
        }

        var result = 0;
        for (int i = 31; i >= 0; i--) {
            if (arr[i] != 0) {
                result += 1 << 31 - i;
            }
        }

        System.out.println(Arrays.toString(arr));

        return result;
    }
}
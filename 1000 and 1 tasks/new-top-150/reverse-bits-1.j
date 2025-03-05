import java.util.*;

class Solution {

    // you need treat n as an unsigned value
    public int reverseBits(int n) {
        var result = 0;

        for (int i = 0; i < 32; i++) {
            var curBit = (n >> i) & 1;
            if (i > 0) {
                var pow2i = (int)Math.pow(2, 31-i);
                result = result | (curBit * pow2i);
            }
        }



        if ((n & 1) == 1) {
            result = result | (1 << 31);
        }

        return result;
    }
}
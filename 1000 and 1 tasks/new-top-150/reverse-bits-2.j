import java.util.*;

class Solution {

    // you need treat n as an unsigned value
    public int reverseBits(int n) {
        var result = 0;

        for (int i = 0; i < 32; i++) {
            // берем бит с конца
            var curBit = (n >> i) & 1;
            // вставляем в ноль
            result = result | (curBit << 31 - i);
        }

        return result;
    }
}
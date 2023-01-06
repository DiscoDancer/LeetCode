public class Solution {
    public uint reverseBits(uint n) {
        uint sum = 0;
        for (int i = 0; i < 32; i++) {
            uint cur = n & 1; // последний бит, дальше будет предпоследний
            sum += cur * ((uint)(1 << (31 - i)));
            n = n >> 1;
        }

        return sum;
    }
}
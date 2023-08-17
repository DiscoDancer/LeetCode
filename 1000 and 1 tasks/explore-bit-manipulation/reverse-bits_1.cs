public class Solution {
    public uint reverseBits(uint n) {
        uint result = 0;

        var x = n;
        var i = 0;
        while (x > 0) {
            if (x % 2 == 1) {
                result += ((uint)1) << 32-i -1 ;
            }
            x /= 2;
            i++;
        }

        return result;
    }
}
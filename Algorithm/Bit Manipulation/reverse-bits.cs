public class Solution {
    public uint reverseBits(uint n) {
        var power = 31;
        uint res = 0;
        
        while (n != 0) {
            res += (n & 1) << power;
            n = n >> 1;
            power--;
        }
        
        return res;
        
    }
}
import java.util.*;

class Solution {

    public int hammingWeight(int n) {

        var result = 0;

        for (var i = 0; i < 32; i++) {
            result += (n >> i) & 1;
        }

        return result;
    }
}
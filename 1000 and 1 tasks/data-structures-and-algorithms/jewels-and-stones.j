import java.util.*;


class Solution {
    public int numJewelsInStones(String jewels, String stones) {
        var bigJewels = new boolean[26];
        var smallJewels = new boolean[26];

        for (var jewel : jewels.toCharArray()) {
            if (jewel >= 'a' && jewel <= 'z') {
                smallJewels[jewel - 'a'] = true;
            }
            else {
                bigJewels[jewel - 'A'] = true;
            }
        }

        var result = 0;
        for (var stone : stones.toCharArray()) {
            if (stone >= 'a' && stone <= 'z') {
                if (smallJewels[stone - 'a']) {
                    result++;
                }
            }
            else if (bigJewels[stone - 'A']) {
                result++;
            }
        }

        return result;
    }
}
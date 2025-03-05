import java.util.*;

class Solution {

    public String addBinary(String a, String b) {

        var sb1 = new StringBuilder(a);
        var sb2 = new StringBuilder(b);

        var maxLength = Math.max(a.length(), b.length());

        var result = new StringBuilder();

        var remainder = 0;
        for (int diff = 0; diff < maxLength; diff++) {
            var i1 = sb1.length() - diff - 1;
            var i2 = sb2.length() - diff - 1;
            var char1 = i1 >= 0 ? sb1.charAt(i1) : '0';
            var char2 = i2 >= 0 ? sb2.charAt(i2) : '0';
            var cur = char1 - '0' + char2 - '0' + remainder;
            remainder = cur / 2;
            cur %= 2;
            result.insert(0, cur);
        }

        if (remainder > 0) {
            result.insert(0, remainder);
        }

        return result.toString();
    }
}
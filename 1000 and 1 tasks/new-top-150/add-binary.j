import java.util.*;

class Solution {

    public String addBinary(String a, String b) {

        var sb1 = new StringBuilder(a);
        var sb2 = new StringBuilder(b);

        // не эффективно, но зато просто

        var maxLength = Math.max(a.length(), b.length());

        while (sb1.length() < maxLength) {
            sb1.insert(0, '0');
        }
        while (sb2.length() < maxLength) {
            sb2.insert(0, '0');
        }

        var result = new StringBuilder();

        var remainder = 0;
        for (int i = maxLength - 1; i >= 0; i--) {
            var cur = sb1.charAt(i) - '0' + sb2.charAt(i) - '0' + remainder;
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
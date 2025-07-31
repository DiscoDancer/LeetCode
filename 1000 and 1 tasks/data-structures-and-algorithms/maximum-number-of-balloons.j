import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class Solution {
    public int maxNumberOfBalloons(String text) {
        var bCount = 0;
        var aCount = 0;
        var lCount = 0;
        var nCount = 0;
        var oCount = 0;

        for (var i = 0; i < text.length(); i++) {
            var ch = text.charAt(i);
            if (ch == 'b') {
                bCount++;
            }
            if (ch == 'a') {
                aCount++;
            }
            if (ch == 'o') {
                oCount++;
            }
            if (ch == 'l') {
                lCount++;
            }
            if (ch == 'n') {
                nCount++;
            }
        }

        var result = 0;

        while (bCount > 0 && aCount > 0 && lCount > 1 && oCount > 1 && nCount > 0 ) {
            bCount--;
            aCount--;
            lCount-=2;
            nCount-=1;
            oCount-=2;

            result++;
        }

        return result;
    }
}
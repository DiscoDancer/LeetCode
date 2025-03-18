import java.util.ArrayDeque;
import java.util.List;

class Solution {

    private String s1;
    private String s2;
    private String s3;

    private boolean F(int i1, int i2) {
        var i3 = i1 + i2;
        if (i1 == s1.length() && i2 == s2.length() && i3 == s3.length()) {
            return true;
        }
        if (i3 == s3.length()) {
            return false;
        }

        var result = false;

        if (i1 < s1.length() && s1.charAt(i1) == s3.charAt(i3)) {
            result  = result || F(i1 + 1, i2);
        }
        if (!result && i2 < s2.length() && s2.charAt(i2) == s3.charAt(i3)) {
            result = result || F(i1, i2 + 1);
        }

        return result;
    }

    public boolean isInterleave(String s1, String s2, String s3) {

        this.s1 = s1;
        this.s2 = s2;
        this.s3 = s3;

        return F(0, 0);
    }
}

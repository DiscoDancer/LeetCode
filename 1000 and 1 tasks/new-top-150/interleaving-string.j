import java.util.ArrayDeque;
import java.util.List;

// TL

class Solution {

    private String s1;
    private String s2;
    private String s3;

    private boolean result = false;

    private void F(int i1, int i2, int i3) {
        if (i1 == s1.length() && i2 == s2.length() && i3 == s3.length()) {
            result = true;
            return;
        }
        if (i3 == s3.length()) {
            return;
        }

        if (i1 < s1.length() && s1.charAt(i1) == s3.charAt(i3)) {
            F(i1 + 1, i2, i3 + 1);
        }
        if (i2 < s2.length() && s2.charAt(i2) == s3.charAt(i3)) {
            F(i1, i2 + 1, i3 + 1);
        }
    }

    public boolean isInterleave(String s1, String s2, String s3) {

        this.s1 = s1;
        this.s2 = s2;
        this.s3 = s3;

        F(0, 0, 0);

        return this.result;
    }
}

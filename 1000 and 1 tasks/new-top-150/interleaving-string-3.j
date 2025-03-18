class Solution {
    public boolean isInterleave(String s1, String s2, String s3) {
        var table = new boolean[s1.length() + 1][s2.length() + 1];

        for (var i1 = s1.length(); i1 >= 0; i1--) {
            for (var i2 = s2.length(); i2 >= 0; i2--) {
                var i3 = i1 + i2;
                if (i1 == s1.length() && i2 == s2.length() && i3 == s3.length()) {
                    table[i1][i2] = true;
                    continue;
                }
                if (i3 >= s3.length()) {
                    table[i1][i2] = false;
                    continue;
                }

                var result = false;

                if (i1 < s1.length() && s1.charAt(i1) == s3.charAt(i3)) {
                    result = result || table[i1 + 1][i2];
                }
                if (!result && i2 < s2.length() && s2.charAt(i2) == s3.charAt(i3)) {
                    result = result || table[i1][i2 + 1];
                }

                table[i1][i2] = result;
            }
        }

        return table[0][0];
    }
}

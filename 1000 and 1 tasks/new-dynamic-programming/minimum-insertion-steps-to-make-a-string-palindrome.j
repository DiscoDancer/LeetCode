import java.util.*;

class Solution {
    private String s;

    private Integer[][] map;

    private int F(int l, int r) {
        if (l >= r) {
            return 0;
        }

        if (map[l][r] != null) {
            return map[l][r];
        }

        // мб тут больше веток
        if (s.charAt(l) == s.charAt(r)) {
            return F(l+1, r-1);
        }
        else {
            // insert right
            // mbadm -> 0 + bad -> 1 + badb -> 1 + ad
            var insertRight = 1 + F(l+1, r);

            // insert left
            // mbadm -> 0 + bad -> 1 + dbad -> 1 + ba
            var insertLeft = 1 + F(l, r-1);

            map[l][r] = Math.min(insertRight, insertLeft);

            return map[l][r];
        }
    }

    public int minInsertions(String s) {
        var max = s.length() % 2 == 0 ? s.length() : s.length() - 1;
        max = Math.max(0, max);
        this.s = s;

        map = new Integer[s.length() + 10][s.length() + 10];

        return F(0, s.length()-1);
    }
}
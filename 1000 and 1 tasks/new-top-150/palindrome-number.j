import java.util.*;

class Solution {

    public boolean isPalindrome(int x) {

        var str = String.valueOf(x);
        var l = 0;
        var r = str.length()-1;

        while (l < r) {
            if (str.charAt(l) != str.charAt(r)) {
                return false;
            }
            l++;
            r--;
        }

        return true;
    }
}
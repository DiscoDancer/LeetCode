import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    public char nextGreatestLetter(char[] letters, char target) {

        var l = 0;
        var r = letters.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (letters[m] <= target) {
                l = m + 1;
            } else if (letters[m] > target) {
                if (m == 0 || letters[m - 1] <= target) {
                    return letters[m];
                }
                r = m - 1;
            }
        }

        return  letters[0];
    }
}

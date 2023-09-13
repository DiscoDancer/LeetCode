public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
        var l = 0;
        var r = letters.Length - 1;

        while (l <= r) {
            var m = l + (r-l)/2;
            if (letters[m] > target && (m == 0 || letters[m-1] <= target)) {
                return letters[m];
            }
            if (letters[m] <= target) {
                l = m + 1;
            }
            else {
                r = m - 1;
            }
        }

        return letters[0];
    }
}
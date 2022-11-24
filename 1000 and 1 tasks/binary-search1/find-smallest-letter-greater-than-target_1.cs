public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
        var a = 0;
        var b = letters.Length - 1;
        
        while (a <= b) {
            var m = a + (b-a)/2;
            if (letters[m] <= target) {
                a = m + 1;
            }
            else if (letters[m] > target) {
                b = m - 1;
            }
        }
        
        if (b == letters.Length - 1) {
            return letters[0];
        }
        
        return letters[b + 1];
    }
}
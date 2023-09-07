/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        var L = 1;
        var R = n;

        while (L <= R) {
            var M = L + (R-L)/2;

            if (guess(M) == 0) {
                return M;
            }
            if (guess(M) == 1) {
                L = M + 1;
            }
            else {
                R = M - 1;
            }
        }

        return -1;
    }
}
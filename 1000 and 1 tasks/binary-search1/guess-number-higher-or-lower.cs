/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    // n - верхняя граница
    // todo написать бинарный поиск
    public int GuessNumber(int n) {
        int a = 1;
        int b = n;
        
        while (a <= b) {
            var m = a + (b-a)/2;
            var res = guess(m);
            if (res == -1) {
                b = m -1;
            }
            else if (res == 1) {
                a = m + 1;
            }
            else {
                return m;
            }
        }
        
        return -1;
    }
}
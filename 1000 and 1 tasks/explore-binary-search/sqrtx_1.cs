public class Solution {
    // я хоть и сам написал, но хз, почему так
    public int MySqrt(int x) {
        long L = 0;
        long R = x;

        while (L <= R) {
            long M = L + (R-L)/2;

            if (M*M == x) {
                return (int)M;
            }
            // кого проверяем первым
            // мне нужен самый большой, из меньших
            if (M*M > x) {
                R = M -1;
            }
            else {
                L = M + 1;
            }
        }

        return (int)L -1;
    }
}
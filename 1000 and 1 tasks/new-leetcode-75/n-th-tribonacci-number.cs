public class Solution {
    public int Tribonacci(int n) {
        var n0 = 0;
        var n1 = 1;
        var n2 = 1;

        if (n == 0) {
            return 0;
        }
        if (n == 1 || n == 2) {
            return 1;
        }

        for (int i = 3; i <= n; i++) {
            var slot1 = n1;
            var slot2 = n2;

            n2 = n0 + n1 + n2;;
            n1 = slot2;
            n0 = slot1;
        }

        return n2;
    }
}
class Solution {
    public int trailingZeroes(int n) {

        var count2 = 0;
        var count5 = 0;

        for (var i = 1; i <= n; i++) {
            var i2 = i;
            while (i2 % 2 == 0) {
                i2 /= 2;
                count2++;
            }
            var i5 = i;
            while (i5 % 5 == 0) {
                i5 /= 5;
                count5++;
            }
        }

        return Math.min(count2, count5);
    }
}
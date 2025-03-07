class Solution {
    // 2ки тоже важны, но их точно больше, поэтому можно не считать
    public int trailingZeroes(int n) {
        var count5 = 0;

        for (var i = 1; i <= n; i++) {
            var i5 = i;
            while (i5 % 5 == 0) {
                i5 /= 5;
                count5++;
            }
        }

        return count5;
    }
}
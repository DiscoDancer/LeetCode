public class Solution {
    // editroail
    public int NumWays(int n, int k) {
        if (n == 1) {
            return k;
        }
        if (n == 2) {
            return k*k;
        }
        var table = new int[n+1];
        table[1] = k;
        table[2] = k * k;

        for (int i =3 ; i <= n; i++) {
            table[i] = (k-1)*table[i-1] + (k-1)*table[i-2];
        }

        return table.Last();
    }
}
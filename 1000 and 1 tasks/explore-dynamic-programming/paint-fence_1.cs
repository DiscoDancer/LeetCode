public class Solution {
    // editroail


    /*
        - Если 1 цвет зафиксирован, то 2ой может быть таким же, либо другим.
        - Если второй такой же, то 1 вариант, если другой то (k-1) вариантов
        - Ебаное дерево
    */
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
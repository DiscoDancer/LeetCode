public class Solution {
    // бинарный поиск по всем элементам первой строки = n*m*log(n) без доп памяти

    // таблица по всем элементам m*n и доп память 10K или m*n
    // важно избегать дубликатов


    public int SmallestCommonElement(int[][] mat) {
        var table = new int[10001];
        foreach (var arr in mat) {
            var prev = -1;
            foreach (var n in arr) {
                if (n != prev) {
                    table[n]++;
                }
                prev = n;
            }
        }

        for (int i = 0; i < 10001; i++) {
            if (table[i] == mat.Length) {
                return i;
            }
        }

        return -1;
    }
}
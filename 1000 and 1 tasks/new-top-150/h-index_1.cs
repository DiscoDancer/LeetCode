public class Solution {
    public int HIndex(int[] citations) {

        // таблица сверху вниз
        // почему так?
        // нам надо быстро ответить на вопрос сколько у нас чисел больше чем х
        // откуда такой вопрос, см h-index.cs

        var table = new int[1001];
        foreach (var c in citations) {
            table[c]++;
        }

        var acc = 0;
        for (int i = 1000; i >= 0; i--) {
            var old = table[i];
            table[i] += acc;
            acc += old;
        }

        // здесь, наверное, можно применить бинарный поиск, но это не улучшит ситуацию. потому что все равно выше n
        for (int i = Math.Min(citations.Length, 1000); i >= 0; i--) {
            if (table[i] >= i) {
                return i;
            }
        }
    
        return -1;
    }
}
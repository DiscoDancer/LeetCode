public class Solution {
    // в лоб квадрат = TL
    // подумать - треугольник = TL
    // в таблицу кладем баланс - профит - индекс или сколько лучше есть
    public int MaxScoreSightseeingPair(int[] values) {
        var n = values.Length;
        
        var maxMatch = Math.Max(values[0] - 2, values[1] - 1); // для 3его будет выбор пары либо 1ый, либо 2ой со штрафами
        var max = values[0] + values[1] - 1;
        
        for (int i = 2; i < n; i++) {
            max = Math.Max(max, maxMatch + values[i]);
            maxMatch = Math.Max(maxMatch - 1, values[i] - 1); // кладем сюда же 3ий
        }
        
        return max;
    }
}
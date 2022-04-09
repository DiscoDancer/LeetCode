public class Solution {
    public double Average(int[] salary) {
        // пересчитывать среднее каждый раз, ибо сумма даст переполнение
        // первый проход min, max, чтобы исключить их
        // отбросить нули
        
        var max = int.MinValue;
        var min = int.MaxValue;
        var sum = 0;
        
        for (int i = 0; i < salary.Length; i++) {
            max = Math.Max(max, salary[i]);
            min = Math.Min(min, salary[i]);
            sum += salary[i];
        }
        
        double res =  sum - max - min;
        res /= salary.Length - 2;
        
        return res;
    }
}
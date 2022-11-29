public class Solution {
    // массив квадратов, по которому бегаем 2мя указателями, можно бегать с бинарным поиском
    // второй всегда может нулем
    // квадрат - слишком медленно, оптимизируем бинарным поиском
    // тоже out of memory, можно попробовать сделать на месте
    // бинарный поиск без массива?

    // квадрат без массива
    public bool JudgeSquareSum(int cc) {
        if (cc == 0) {
            return true;
        }
        
        long c = cc;
        long square1 = 1;
        
        for (long i = 1; square1 <= c; i++) {
            square1 = i*i;
            if (square1 == c) {
                return true;
            }
            
            long diff = c - square1;
            
            long a = 1;
            long b = diff;
            
            while (a <= b) {
                long m = a + (b-a)/2;
                long product = m*m;
                if (product == diff) {
                    return true;
                }
                else if (product < diff) {
                    a = m + 1;
                } 
                else if (product > diff) {
                    b = m - 1;
                }
            }
        }
        
        return false;
    }
}
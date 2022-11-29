public class Solution {
    // массив квадратов, по которому бегаем 2мя указателями, можно бегать с бинарным поиском
    // второй всегда может нулем
    // квадрат - слишком медленно, оптимизируем бинарным поиском
    // тоже out of memory, можно попробовать сделать на месте
    // бинарный поиск без массива?

    // квадрат без массива
    public bool JudgeSquareSum(int c) {
        if (c == 0) {
            return true;
        }
        
        for (int i = 1; i <= c; i++) {
            var square1 = i*i;
            if (square1 == c) {
                return true;
            }
            
            for (int j = 1; j <= c; j++) {
                var square2 = j*j;
                var sum = square1 + square2;
                
                if (sum == c) {
                    return true;
                }
                else if (sum > c) {
                    break;
                }
            }
        }
        
        return false;
    }
}
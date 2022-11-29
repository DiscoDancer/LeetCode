public class Solution {
    // массив квадратов, по которому бегаем 2мя указателями, можно бегать с бинарным поиском
    // второй всегда может нулем
    // квадрат - слишком медленно, оптимизируем бинарным поиском
    // бинарный поиск тоже out of memory
    public bool JudgeSquareSum(int c) {
        if (c == 0) {
            return true;
        }
        
        var squares = new List<int>();
        
        for (int i = 1; i <= c; i++) {
            var square = i*i;
            if (square == c) {
                return true;
            }
            if (square < c) {
                squares.Add(square);
            }
            else {
                break;
            }
        }
        
        // у меня есть массив квадратов: x < c
        var arr = squares.ToArray();
        
        for (int i = 0; i < arr.Length; i++) {
            var diff = c - arr[i];
            var a = 0;
            var b = arr.Length - 1;
            while (a <= b) {
                var m = a + (b-a)/2;
                if (arr[m] == diff) {
                    return true;
                }
                else if (arr[m] < diff) {
                    a = m + 1;
                }
                else if (arr[m] > diff) {
                    b  = m - 1;
                }
            }
        }
        
        return false;
    }
}
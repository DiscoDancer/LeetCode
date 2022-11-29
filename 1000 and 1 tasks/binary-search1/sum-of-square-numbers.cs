public class Solution {
    // массив квадратов, по которому бегаем 2мя указателями, можно бегать с бинарным поиском
    // второй всегда может нулем
    // квадрат - слишком медленно
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
            for (int j = i; j < arr.Length; j++) {
                if (arr[i] + arr[j] == c) {
                    return true;
                }
            }
        }
        
        return false;
    }
}
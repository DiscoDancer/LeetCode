public class Solution {
    // массив квадратов, по которому бегаем 2мя указателями, можно бегать с бинарным поиском
    // второй всегда может нулем
    
    // оптимизация со словарем (только словарь)
    public bool JudgeSquareSum(int c) {
        if (c == 0) {
            return true;
        }
        
        var dic = new Dictionary<int, bool>();
        
        for (int i = 1; i <= c; i++) {
            var square = i*i;
            if (square == c) {
                return true;
            }
            if (square < c) {
                dic[square] = true;
            }
            else {
                break;
            }
        }
        
        foreach (var sq in dic.Keys) {
            var diff = c - sq;
            if (dic.ContainsKey(diff)) {
                return true;
            }
        }
        
        return false;
    }
}
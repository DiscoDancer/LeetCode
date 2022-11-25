public class Solution {
    // можно тоже решать, через прогессию. Это если вопрос, какого не хватает?
    // можно ходить туда-сюда
    // на каждой точке, я могу понять сколько пропущено за счет индекса
    
    // идет от начала к концу, ищем число, которое больше >= k
    // и тогда его оттуда одним отрицанием можно вытащить
    public int FindKthPositive(int[] arr, int k) {
        int numbersMissing;
        int diff;
        
        var a = 0;
        var b = arr.Length - 1;
        // мы двигаем указатель а каждый раз, когда он меньше
        // таким образом он будет гарантированно >= или в космосе (сильно большой)
        while (a <= b) {
            var m = a + (b-a)/2;
            var missing = arr[m] - m - 1;
            if (missing < k) {
                a = m + 1;
            }
            else if (missing >= k) { // нужно чтобы завершиться и не испортить a
                b = m - 1;
            }
        }
        
        if (a < arr.Length) {
            var cur = arr[a];
            numbersMissing =  cur - (a) - 1;
            diff = numbersMissing - k +1;
            return cur - diff;
        }
                
        // число вне массива
        numbersMissing = arr.Last() - arr.Length;
        diff = k - numbersMissing;
        return arr.Last() + diff;
    }
}
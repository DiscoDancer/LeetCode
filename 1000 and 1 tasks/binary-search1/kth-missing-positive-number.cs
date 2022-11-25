public class Solution {
    // можно тоже решать, через прогессию. Это если вопрос, какого не хватает?
    // можно ходить туда-сюда
    // на каждой точке, я могу понять сколько пропущено за счет индекса
    
    // идет от начала к концу, ищем число, которое больше >= k
    // и тогда его оттуда одним отрицанием можно вытащить
    public int FindKthPositive(int[] arr, int k) {
        int numbersMissing;
        int diff;
        for (int i = 0; i < arr.Length; i++) {
            var cur = arr[i];
            numbersMissing = cur - i - 1; // сколько пропущенно
            if (numbersMissing >= k) { // пропущенно достаточно                
                diff = numbersMissing - k +1;
                return cur - diff;
            }
        }
        
        // число вне массива
        numbersMissing = arr.Last() - arr.Length;
        diff = k - numbersMissing;
        return arr.Last() + diff;
    }
}
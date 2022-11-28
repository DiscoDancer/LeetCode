public class Solution {
    // бинарный поиск и сортировка
    
    public int BinSearch(int[] arr, int x) {
        var a = 0;
        var b = arr.Length - 1;
        
        while (a <= b) {
            var m = a + (b-a)/2;
            if (arr[m] > x) {
                b = m - 1;
            }
            else if (arr[m] < x) {
                a = m + 1;
            }
            else {
                return m;
            }
        }
        
        return -1;
    }
    
    public bool CheckIfExist(int[] arr) {
        var list = arr.ToList();
        list.Sort();
        var arrSorted = list.ToArray();
        
        var zeroesCount = arr.Count(x => x == 0);
        if (zeroesCount > 1) {
            return true;
        }
        
        foreach (var x in arrSorted) {
            if (x != 0) {
                // можно и 0.5 поискать 
                // и кеш для поиска сделать, но тогда уже в count sort перейдем
                if (BinSearch(arrSorted, x*2) != -1) {
                    return true;
                }
            }
        }
        
        return false;
    }
}
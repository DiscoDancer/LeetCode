public class Solution {
    
    public int GetRank(int x) {
        var res = 0;
        
        while (x > 0) {
            res += x & 1;
            x = x >> 1;
        }
        
        return res;
    }
    
    // n*n sort
    // can do merge sort
    public int[] SortByBits(int[] arr) {
        var sortedArr = arr.OrderBy(x => x).ToArray(); // asc
        var bits = sortedArr.Select(GetRank).ToArray(); // asc bits
        
        var res = new List<int>();
        
        for (var i = 0; i < arr.Length; i++) {
            var min = int.MaxValue;
            var minIndex = -1;
            for (var j = 0; j < arr.Length; j++) {
                if (bits[j] < min) {
                    min = bits[j];
                    minIndex = j;
                }
            }
            bits[minIndex] = int.MaxValue;
            res.Add(sortedArr[minIndex]);
        }
        
        return res.ToArray();
    }
}
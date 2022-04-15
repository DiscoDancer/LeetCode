public class Solution {
    
    public int GetRank(int x) {
        var res = 0;
        
        while (x > 0) {
            res += x & 1;
            x = x >> 1;
        }
        
        return res;
    }
    
    public int[] SortByBits(int[] arr) {
        var sortedArr = arr.OrderBy(x => x).ToArray();
        
        var table = new List<int>[32];
        
        foreach (var x in sortedArr) {
            var rank = GetRank(x);
            if (table[rank] == null) {
                table[rank] = new List<int>();
            }
            table[rank].Add(x);
        }
        
        var res = table.Where(x => x != null).SelectMany(x => x).ToArray();
        
        return res;
    }
}
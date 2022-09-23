public class Solution {
    
    // 1 hash table for squares
    // 1 hash table for numbes (check cycling)
    
    public bool IsHappy(int n) {
        if (n == 1) {
            return true;
        }
        
        var dicNumbers = new Dictionary<int, bool>();
        while (n != 1 && !dicNumbers.ContainsKey(n)) {
            dicNumbers[n] = true;
            n = (n + "").Select((x) => (int) (x - '0')).Select(x => x*x).Aggregate((x,y) => x + y);
        }
        
        return n == 1;
    }
}
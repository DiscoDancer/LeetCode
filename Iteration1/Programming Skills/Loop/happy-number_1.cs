public class Solution {
    private int GetNext(int n) {
        return (n + "").Select((x) => (int) (x - '0')).Select(x => x*x).Aggregate((x,y) => x + y);
    }
    
    public bool IsHappy(int n) {
        if (n == 1) {
            return true;
        }
        
        int next = GetNext(n);
        
        while (n != 1 && n != next) {
            n = GetNext(n);
            next = GetNext(GetNext(next));
        }
        
        return n == 1;
    }
}
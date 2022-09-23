public class Solution {
    
    private int _count = 0;
    private int _n = 0;
    private int[] _arr = new int[46];
    
    public int ff(int x) {
        if (x <= 0 ) {
            return 0;
        }
        if (_arr[x] != -1) {
            return _arr[x];
        }
        
        if (x >= 1) {
            _arr[x] = ff(x -1) + ff(x - 2);
            return _arr[x];
        }

        return 0;
    }
    
    public int ClimbStairs(int n) {
        _arr[1] = 1;
        _arr[2] = 2;
        
        for (int i = 3; i <= 45; i++) {
            _arr[i] = -1;
        }
        
        _n = n;
        
        ff(n);
        
        return _arr[n];
    }
}
public class Solution {
    private int[] _informTime;
    private List<int>[] _iManager;
    private int _res = 0;

    private int F(int node) {
        if (!_iManager[node].Any()) {
            return 0;
        }

        var max = 0;
        foreach(var c in _iManager[node]) {
            max = Math.Max(F(c), max);
        }
        return max + _informTime[node];
    }

    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        _iManager = new List<int>[n];
        for (int i = 0; i < n; i++) {
            _iManager[i] = new List<int>();
        }

        for (int i = 0; i < n; i++) {
            if (manager[i] >= 0) {
                _iManager[manager[i]].Add(i);
            }  
        }

        _informTime = informTime;
        return F(headID);
    }
}
using System.Collections.Generic;

public class Solution {
    
    private int _n;
    private int _k;
    private IList<IList<int>>  _outout = new List<IList<int>>();
    
    public void BackTrack(int first, List<int> curr) {
        if (curr.Count() == _k) {
            _outout.Add(new List<int>(curr));
            return;
        }
        
        for (int i = first; i < _n +1 ; i++) {
            curr.Add(i);
            BackTrack(i+1, curr);
            curr.RemoveAt(curr.Count() - 1);
        }
    }
    
    public IList<IList<int>> Combine(int n, int k) {        
        _n = n;
        _k = k;
        BackTrack(1, new List<int>());
        return _outout;
    }
}
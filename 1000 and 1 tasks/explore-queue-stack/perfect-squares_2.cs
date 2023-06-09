public class Solution {
    // полный перебор с меморизацией

    // проходит
    private List<int> _list = new ();
    private Dictionary<int, int> _results = new (); 

    private int F(int target) {
        if (_results.ContainsKey(target)) {
            return _results[target];
        }

        var subResult = new List<int>();
        foreach (var sq in _list) {
            if (target > sq) // не может быть равен!
            {
                subResult.Add(F(target - sq) + 1);
            }
        }

        var result = subResult.Min();
        _results[target] = result;

        return result;
    }

    public int NumSquares(int n) {
        for (int i = 1; i*i <= n; i++) {
            _results[i*i] = 1;
            _list.Add(i*i);
        }

        return F(n);
    }
}
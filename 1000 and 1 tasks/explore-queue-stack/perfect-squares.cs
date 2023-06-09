public class Solution {
    // полный перебор с меморизацией

    // слишком медленно, нет меморизации
    private Dictionary<int, int> _results = new ();
    private List<int> _list = new ();
    private int _n;
    private int _result;

    private void F(int target, int acc) {
        if (target == 0) {
            _result = Math.Min(_result, acc);
        }

        foreach (var s in _list) {
            if (target - s >= 0) {
                F(target - s, acc + 1);
            }
        }
    }

    public int NumSquares(int n) {
        // список квадратов

        for (int i = 1; i*i <= n; i++) {
            _results[i] = 1;
            _list.Add(i*i);
        }

        if (_results.ContainsKey(n)) {
            return 1;
        }

        _n = n;
        _result = n; // худший вариант все 1

        F(n, 0);

        return _result;
    }
}
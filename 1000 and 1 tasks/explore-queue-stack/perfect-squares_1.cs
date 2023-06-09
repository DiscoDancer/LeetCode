public class Solution {
    // this version can be improved and memorized

    private List<int> _list = new ();

    private int F(int target) {
        if (_list.Contains(target)) {
            return 1;
        }

        var subResult = new List<int>();
        foreach (var sq in _list) {
            if (target > sq) // не может быть равен!
            {
                subResult.Add(F(target - sq) + 1);
            }
        }

        return subResult.Min();
    }

    public int NumSquares(int n) {
        for (int i = 1; i*i <= n; i++) {
            _list.Add(i*i);
        }

        return F(n);
    }
}
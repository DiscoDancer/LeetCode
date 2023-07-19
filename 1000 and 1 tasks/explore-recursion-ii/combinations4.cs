public class Solution {
    private int _n;
    private int _k;
    private IList<IList<int>> _result = new List<IList<int>>(){};

    private void F(List<int> list) {
        if (list.Count() == _k) {
            _result.Add(list.ToList());
            return;
        }

        var start = list.Any() ? list.Last() + 1 : 1;
        for (int possibleNumber = start; possibleNumber <= _n; possibleNumber++) {
            list.Add(possibleNumber);
            F(list);
            list.Remove(possibleNumber);
        }
    }

    public IList<IList<int>> Combine(int n, int k) {
        _n = n;
        _k = k;

        F(new List<int>(){});

        return _result;
    }
}
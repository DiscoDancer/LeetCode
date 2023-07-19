public class Solution {
    private int _n;
    private int _k;
    private IList<IList<int>> _result = new List<IList<int>>(){};

    private void F(List<int> list) {
        if (list.Count() == _k) {
            _result.Add(list.ToList());
            return;
        }

        var allPossibleNumbers = new List<int>();
        var start = list.Any() ? list.Last() : 1;
        for (int i = start; i <= _n; i++) {
            if (!list.Contains(i)) {
                allPossibleNumbers.Add(i);
            }
        }

        foreach (var possibleNumber in allPossibleNumbers) {
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
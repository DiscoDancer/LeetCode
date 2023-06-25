public class TwoSum {

    private List<int> _nums = new ();
    private HashSet<int> _sums = new ();

    public TwoSum() {
    }
    
    public void Add(int number) {
        foreach (var n in _nums) {
            _sums.Add(n + number);
        }
        _nums.Add(number);
    }
    
    public bool Find(int value) {
        return _sums.Contains(value);
    }
}

/**
 * Your TwoSum object will be instantiated and called as such:
 * TwoSum obj = new TwoSum();
 * obj.Add(number);
 * bool param_2 = obj.Find(value);
 */
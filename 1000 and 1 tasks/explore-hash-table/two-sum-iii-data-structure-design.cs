public class TwoSum {

    private List<int> _nums = new ();

    public TwoSum() {
    }
    
    public void Add(int number) {
        _nums.Add(number);
    }
    
    // TL
    public bool Find(int value) {
        for (int i = 0; i < _nums.Count(); i++) {
            for (int j = i + 1; j < _nums.Count(); j++) {
                if (_nums[i] + _nums[j] == value) {
                    return true;
                }
            }
        }

        return false;
    }
}

/**
 * Your TwoSum object will be instantiated and called as such:
 * TwoSum obj = new TwoSum();
 * obj.Add(number);
 * bool param_2 = obj.Find(value);
 */
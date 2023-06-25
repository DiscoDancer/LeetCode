// editorial
public class TwoSum {

    private Dictionary<int, int> _table = new ();

    public TwoSum() {
        
    }
    
    public void Add(int number) {
        if (_table.ContainsKey(number)) {
            _table[number]++;
        }
        else {
            _table[number] = 1;
        }
    }
    
    public bool Find(int value) {
        foreach (var k in _table.Keys) {
            var complement = value - k;
            if (complement != k) {
                if (_table.ContainsKey(complement)) {
                    return true;
                }
            }
            else if (_table[k] > 1) {
                return true;
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
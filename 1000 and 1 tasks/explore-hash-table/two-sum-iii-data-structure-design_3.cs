// editorial
public class TwoSum {
    private List<int> _list = new ();
    private bool _sorted = false;

    public TwoSum() {
        
    }
    
    public void Add(int number) {
        _list.Add(number);
        _sorted = false;
    }
    
    public bool Find(int value) {
        if (!_sorted) {
            _list.Sort();
            _sorted = true;
        }

        var L = 0;
        var R = _list.Count() - 1;
        while (L < R) {
            var sum = _list[L] + _list[R];
            if (sum < value) {
                L++;
            }
            else if (sum > value) {
                R--;
            }
            else {
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
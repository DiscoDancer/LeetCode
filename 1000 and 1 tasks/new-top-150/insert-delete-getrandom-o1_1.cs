// editorial
// работает в предположении, что по индексу берем за константу
public class RandomizedSet {

    private List<int> _list = new ();
    private Dictionary<int, int> _table = new ();
    private Random _random = new ();

    public RandomizedSet() {
        
    }
    
    public bool Insert(int val) {
        if (_table.ContainsKey(val)) {
            return false;
        }

        _table[val] = _list.Count();
        _list.Add(val);

        return true;
    }
    
    public bool Remove(int val) {
        if (!_table.ContainsKey(val)) {
            return false;
        }

        var last = _list.Last();
        var indexToRemove = _table[val];
        _list[indexToRemove] = last;
        _table[last] = indexToRemove;

        _table.Remove(val);
        _list.RemoveAt(_list.Count() - 1);

        return true;
    }
    
    public int GetRandom() {
        return _list[_random.Next() % _list.Count()];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
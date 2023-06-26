public class RandomizedSet {
    // суть в том, что их нужно дергать по индексу
    // а сложность в том, что индексы редеют

    // можно перерасчитывать индексы после удаления
    private HashSet<int> _hs = new ();
    private Dictionary<int, int> _valueToIndex = new ();
    private Dictionary<int, int> _indexToValue = new ();
    private int _count = 0;

    public RandomizedSet() {
        
    }
    
    public bool Insert(int val) {
        var added = _hs.Add(val);
        if (added) {
             _valueToIndex[val] = _count;
             _indexToValue[_count] = val;
             _count++;
             return true;
        }
        return false;
    }
    
    public bool Remove(int val) {
        var removed = _hs.Remove(val);
        if (removed) {
            var index = _valueToIndex[val];
            for (int i = index + 1; i < _count; i++) {
                var v = _indexToValue[i];
                _valueToIndex[v]--;
            }
            _valueToIndex.Remove(val);

            // todo fix _indexToValue
            if (index < _count - 1) {
                var i = index;
                while (i < _count - 1) {
                    _indexToValue[i] = _indexToValue[i+1];
                    i++;
                }
            }
            _indexToValue.Remove(_count - 1);

             _count--;
            return true;
        }
        return false;
    }
    
    public int GetRandom() {
        Random rnd = new Random();
        return _indexToValue[rnd.Next() % _count];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
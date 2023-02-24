public class RandomizedSet {
    private Dictionary<int, int> _dictionary = new ();

    public RandomizedSet() {
        
    }
    
    public bool Insert(int val) {
        if (_dictionary.ContainsKey(val)) {
            return false;
        }
        _dictionary[val] = val;

        return true;
    }
    
    public bool Remove(int val) {
        if (!_dictionary.ContainsKey(val)) {
            return false;
        }
        
        _dictionary.Remove(val);
        
        return true;
    }
    
    public int GetRandom() {
        var rnd = new Random();
        var card = rnd.Next(_dictionary.Keys.Count());

        return _dictionary[_dictionary.ElementAt(card).Key];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
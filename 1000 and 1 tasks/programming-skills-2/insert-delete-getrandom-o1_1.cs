// https://leetcode.com/problems/insert-delete-getrandom-o1/editorial/
public class RandomizedSet {
    private Dictionary<int, int> _dictionary = new ();
    private List<int> _list = new ();
    private Random _rnd = new Random();

    public RandomizedSet() {
        
    }
    
    public bool Insert(int val) {
        if (_dictionary.ContainsKey(val)) {
            return false;
        }
        _dictionary[val] = _list.Count();
        _list.Add(val);

        return true;
    }
    
    public bool Remove(int val) {
        if (!_dictionary.ContainsKey(val)) {
            return false;
        }

        var index = _dictionary[val];
        var tmp = _list[index];
        _list[index] = _list.Last();

        _dictionary[_list.Last()] = index;
        _dictionary.Remove(val);
        _list.RemoveAt(_list.Count() - 1);
        
        return true;
    }
    
    public int GetRandom() {
        var card = _rnd.Next(_list.Count());

        return _list[card];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
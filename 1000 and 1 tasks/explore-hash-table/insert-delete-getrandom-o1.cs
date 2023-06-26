public class RandomizedSet {
    private HashSet<int> _hs = new ();

    public RandomizedSet() {
        
    }
    
    public bool Insert(int val) {
        return _hs.Add(val);
    }
    
    public bool Remove(int val) {
        return _hs.Remove(val);
    }
    
    public int GetRandom() {
        Random rnd = new Random();
        var arr = _hs.ToArray();
        return arr[rnd.Next() % arr.Length];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
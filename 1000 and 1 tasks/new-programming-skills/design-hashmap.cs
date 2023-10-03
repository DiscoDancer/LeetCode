public class MyHashMap {

    private const int SIZE = 100;
    private List<(int k, int v)>[] _table = new  List<(int k, int v)>[SIZE];

    public MyHashMap() {
        
    }
    
    public void Put(int key, int value) {
        var k = key % SIZE;
        if (_table[k] == null) {
            _table[k] = new ();
        }

        for (int i = 0; i < _table[k].Count; i++)
        {
            if (_table[k][i].k == key)
            {
                _table[k][i] = (key, value);
                return;
            }
        }
        
        _table[k].Add((key, value));
        
    }
    
    public int Get(int key) {
        var k = key % SIZE;
        if (_table[k] == null) {
            return -1;
        }

        foreach (var (kk,vv) in _table[k])
        {
            if (kk == key)
            {
                return vv;
            }
        }

        return -1;
    }
    
    public void Remove(int key) {
        var k = key % SIZE;
        if (_table[k] == null) {
            return;
        }

        var found = _table[k].RemoveAll(x => x.k == key);
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */
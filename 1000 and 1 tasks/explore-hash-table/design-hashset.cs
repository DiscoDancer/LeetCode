public class MyHashSet {
    private List<int>[] _buckets = new List<int>[10];

    public MyHashSet() {
        for (int i = 0; i < 10; i++) {
            _buckets[i] = new ();
        }
    }
    
    public void Add(int key) {
        if (!Contains(key)) {
            _buckets[GetBucketIndex(key)].Add(key);
        }
    }
    
    public void Remove(int key) {
        _buckets[GetBucketIndex(key)].Remove(key);
    }
    
    public bool Contains(int key) {
        return _buckets[GetBucketIndex(key)].Contains(key);
    }

    private int GetBucketIndex(int key) {
        return key % 10;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */
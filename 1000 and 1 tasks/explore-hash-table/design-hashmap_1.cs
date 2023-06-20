public class MyHashMap {
    private const int BucketsCount = 10;
    private List<(int, int)>[] _buckets = new List<(int, int)>[BucketsCount];

    public MyHashMap() {
        for (int i = 0; i < BucketsCount; i++) {
            _buckets[i] = new ();
        }
    }
    
    public void Put(int key, int value) {
        Remove(key);
        _buckets[GetBucketIndex(key)].Add((key, value));
    }
    
    public int Get(int key) {
        var bucketIndex = GetBucketIndex(key);
        foreach (var (k, v) in _buckets[bucketIndex]) {
            if (k == key) {
                return v;
            }
        }

        return -1;
    }
    
    public void Remove(int key) {
        var value = Get(key);
        if (value == -1) {
            return;
        }

        _buckets[GetBucketIndex(key)].Remove((key, value));
    }


    private int GetBucketIndex(int key) {
        return key % BucketsCount;
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */
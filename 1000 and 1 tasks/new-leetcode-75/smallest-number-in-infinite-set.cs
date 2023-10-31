public class SmallestInfiniteSet {

    private int _min;
    private int _max;
    private PriorityQueue<int, int> _pq;
    private HashSet<int> _hs;

    public SmallestInfiniteSet() {
        _min = 1;
        _max = int.MaxValue;
        _pq = new ();
        _hs = new ();
    }
    
    public int PopSmallest() {
        if (_pq.Count > 0) {
            var min = _pq.Dequeue();
            _hs.Remove(min);
            return min;
        }

        var x = _min;
        _min++;
        return x;
    }
    
    public void AddBack(int num) {
        if (num >= _min || _hs.Contains(num)) {
            return;
        }
        _hs.Add(num);
        _pq.Enqueue(num, num);
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */
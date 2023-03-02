public class MedianFinder {
    // https://leetcode.com/problems/find-median-from-data-stream/editorial/
    private PriorityQueue<int, int> _lo = new ();
    private PriorityQueue<int, int> _hi = new ();

    public MedianFinder() {
        
    }
    
    public void AddNum(int num) {
        _lo.Enqueue(num, -num);
        _hi.Enqueue(_lo.Peek(), _lo.Peek());

        _lo.Dequeue();

        if (_lo.Count < _hi.Count) {
            _lo.Enqueue(_hi.Peek(), -_hi.Peek());
            _hi.Dequeue();
        }
    }
    
    public double FindMedian() {
        return _lo.Count > _hi.Count ? _lo.Peek() : ((double) _lo.Peek() + _hi.Peek()) * 0.5;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
public class MedianFinder {

    private PriorityQueue<int, int> _minHeap = new ();

    public MedianFinder() {
        
    }
    
    public void AddNum(int num) {
        _minHeap.Enqueue(num, num);
    }
    
    // TL
    public double FindMedian() {
        var list = new List<int>();
        if (_minHeap.Count % 2 == 0) {
            var i = _minHeap.Count / 2 - 1;
            while (i > 0 && _minHeap.Count > 0) {
                list.Add(_minHeap.Dequeue());
                i--;
            }
            var a = _minHeap.Dequeue();
            var b = _minHeap.Dequeue();

            foreach (var c in list) {
                _minHeap.Enqueue(c, c);
            }
            _minHeap.Enqueue(a, a);
            _minHeap.Enqueue(b, b);

            return (a+b)/2.0;
        } else {
            var i = _minHeap.Count / 2;
            while (i > 0 && _minHeap.Count > 0) {
                list.Add(_minHeap.Dequeue());
                i--;
            }

            var a = _minHeap.Dequeue();

            foreach (var c in list) {
                _minHeap.Enqueue(c, c);
            }
            _minHeap.Enqueue(a, a);

            return a;
        }
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
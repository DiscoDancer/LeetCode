public class MedianFinder {
    private List<int> _list = new ();

    public MedianFinder() {
        
    }
    
    public void AddNum(int num) {
        var index = _list.BinarySearch(num);
        if (index < 0) index = ~index;
        _list.Insert(index, num);
    }
    
    public double FindMedian() {
        var n = _list.Count();
        if (n % 2 == 1) {
            return _list[n/2];
        }

        return (_list[n/2] + _list[n/2-1]) / 2.0;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
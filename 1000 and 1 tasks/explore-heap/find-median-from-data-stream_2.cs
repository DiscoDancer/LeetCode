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
        return (n % 2 == 1 ? _list[n / 2] : ((double) _list[n / 2 - 1] + _list[n / 2]) * 0.5);
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
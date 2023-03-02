public class MedianFinder {

    private List<int> _list = new ();

    public MedianFinder() {
        
    }
    
    public void AddNum(int num) {
        _list.Add(num);
    }
    
    // TL
    public double FindMedian() {
        var sorted = _list.OrderBy(x => x).ToArray();
        var n = sorted.Length;
        return (n % 2 == 1 ? sorted[n / 2] : ((double) sorted[n / 2 - 1] + sorted[n / 2]) * 0.5);
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
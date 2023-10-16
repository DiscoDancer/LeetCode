public class RecentCounter {

    private List<int> _calls;

    public RecentCounter() {
        _calls = new ();
    }
    
    // editorial
    public int Ping(int t) {
        _calls.Add(t);

        var timeNow = t;

        while (_calls.Any() && timeNow - _calls.First() > 3000 ) {
            _calls.RemoveAt(0);
        }

        return _calls.Count();
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */
public class RecentCounter {

    private List<int> _calls;

    public RecentCounter() {
        _calls = new ();
    }
    
    public int Ping(int t) {
        // t = time now

        _calls.Add(t);

        var timeNow = t;
        var i = _calls.Count() - 1;

        var result = 0;

        while (i >= 0 && timeNow - _calls[i] <= 3000) {
            i--;
            result++;
        }

        return result;
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */
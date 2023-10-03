public class BrowserHistory {

    private List<string> _list = new ();
    private int _index = -1;

    public BrowserHistory(string homepage) {
        _list.Add(homepage);
        _index = 0;
    }
    
    public void Visit(string url) {
        // clear forward history
        while (_list.Count() > _index + 1) {
            _list.RemoveAt(_list.Count() - 1);
        }

        _list.Add(url);
        _index++;
    }
    
    public string Back(int steps) {
        _index -= steps;
        _index = Math.Max(_index, 0);
        return _list[_index];
    }
    
    public string Forward(int steps) {
        _index += steps;
        _index = Math.Min(_index, _list.Count() - 1);
        return _list[_index];
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */
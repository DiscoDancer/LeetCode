// editorial
public class BrowserHistory {

    private Stack<string> _history;
    private Stack<string> _future;
    private string _current;

    public BrowserHistory(string homepage) {
        _history = new ();
        _future = new ();
        _current = homepage;
    }
    
    public void Visit(string url) {
        _history.Push(_current);
        _current = url;
        _future = new ();
    }
    
    public string Back(int steps) {
        while (steps > 0 && _history.Any()) {
            _future.Push(_current);
            _current = _history.Pop();
            steps--;
        }

        return _current;
    }
    
    public string Forward(int steps) {
        while (steps > 0 && _future.Any()) {
            _history.Push(_current);
            _current = _future.Pop();
            steps--;
        }

        return _current;
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */
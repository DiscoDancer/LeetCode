public class Logger {
    private Dictionary<string, int> _table = new ();

    public Logger() {
        
    }
    
    public bool ShouldPrintMessage(int timestamp, string message) {
        if (!_table.ContainsKey(message)) {
            _table[message] = timestamp;
            return true;
        }

        var diff = timestamp - _table[message];
        if (diff >= 10) {
            _table[message] = timestamp;
            return true;
        }
        return false;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */
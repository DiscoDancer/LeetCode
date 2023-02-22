public class AuthenticationManager {

    private int _timeToLive;
    private Dictionary<string, int> _table = new ();

    public AuthenticationManager(int timeToLive) {
        _timeToLive = timeToLive;
    }
    
    public void Generate(string tokenId, int currentTime) {
        _table[tokenId] = currentTime + _timeToLive;
    }
    
    public void Renew(string tokenId, int currentTime) {
        Clean(currentTime);
        if (!_table.ContainsKey(tokenId)) {
            return;
        }
        _table[tokenId] = currentTime + _timeToLive;
    }
    
    public int CountUnexpiredTokens(int currentTime) {
        Clean(currentTime);
        return _table.Keys.Count();
    }

    private void Clean(int currentTime) {
        foreach (var tokenId in _table.Keys) {
            if (_table[tokenId] <=  currentTime) {
                _table.Remove(tokenId);
            }
        }
    }
}

/**
 * Your AuthenticationManager object will be instantiated and called as such:
 * AuthenticationManager obj = new AuthenticationManager(timeToLive);
 * obj.Generate(tokenId,currentTime);
 * obj.Renew(tokenId,currentTime);
 * int param_3 = obj.CountUnexpiredTokens(currentTime);
 */
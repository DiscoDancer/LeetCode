public class Leaderboard {

    private Dictionary<int, int> _hashTable = new ();

    public Leaderboard() {
        
    }
    
    public void AddScore(int playerId, int score) {
        if (!_hashTable.ContainsKey(playerId)) {
            _hashTable[playerId] = 0;
        }
        _hashTable[playerId] += score;
    }
    
    public int Top(int K) {
        var heap = new PriorityQueue<int, int>();
        foreach (var kv in _hashTable) {
            heap.Enqueue(kv.Key, -kv.Value);
        }

        var result = 0;
        for (int i = 0; i < K; i++) {
            result += _hashTable[heap.Dequeue()];
        }

        return result;
    }
    
    public void Reset(int playerId) {
        _hashTable.Remove(playerId);
    }
}

/**
 * Your Leaderboard object will be instantiated and called as such:
 * Leaderboard obj = new Leaderboard();
 * obj.AddScore(playerId,score);
 * int param_2 = obj.Top(K);
 * obj.Reset(playerId);
 */
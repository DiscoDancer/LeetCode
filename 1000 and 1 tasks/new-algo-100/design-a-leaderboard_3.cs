// editorial
public class Leaderboard
{

    // playerId -> score
    private readonly Dictionary<int, int> _scores = new();
    // score -> count
    private readonly SortedDictionary<int, int> _sortedScores = new(Comparer<int>.Create((x,y) => y.CompareTo(x)));
    
    public Leaderboard()
    {
    }
    
    public void AddScore(int playerId, int score) {
        if (!_scores.ContainsKey(playerId))
        {
            _scores[playerId] = score;
            _sortedScores[score] = _sortedScores.GetValueOrDefault(score, 0) + 1;
        }
        else
        {
            var preScore = _scores[playerId];
            var playerCount = _sortedScores[preScore];

            if (playerCount == 1)
            {
                _sortedScores.Remove(preScore);
            }
            else
            {
                _sortedScores[preScore] = playerCount - 1;
            }
            
            var newScore = preScore + score;
            _scores[playerId] = newScore;
            _sortedScores[newScore] = _sortedScores.GetValueOrDefault(newScore, 0) + 1;
        }
    }
    
    public int Top(int K) {
        var count = 0;
        var sum = 0;

        foreach (var (key, times) in _sortedScores)
        {
            for (int i = 0; i < times; i++)
            {
                sum += key;
                count++;
                
                // Found top-K scores, break.
                if (count == K) {
                    break;
                }
            }
            
            // Found top-K scores, break.
            if (count == K) {
                break;
            }
        }
        
        return sum;
    }
    
    public void Reset(int playerId) {
        int preScore = _scores[playerId];

        _sortedScores[preScore]--;
        if (_sortedScores[preScore] == 0) {
            _sortedScores.Remove(preScore);
        }
        
        _scores.Remove(playerId);
    }
}
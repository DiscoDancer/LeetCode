public class Leaderboard
{

    private int[] _table = new int[100001];
    // can be dictionary
    private int[] _playerScore = new int[10001];

    public Leaderboard() {
        
    }
    
    public void AddScore(int playerId, int score)
    {
        var prevScore = _playerScore[playerId];
        _playerScore[playerId] += score;

        if (prevScore != 0)
        {
            _table[prevScore]--;
        }

        _table[_playerScore[playerId]]++;
    }
    
    public int Top(int K)
    {
        var sum = 0;
        var k = 0;
        for (int i = 100000; i >= 0 && k < K; i--)
        {
            for (int j = 0; j < _table[i] && k < K; j++)
            {
                sum += i;
                k++;
            }
        }

        return sum;
    }
    
    public void Reset(int playerId)
    {
        if (_playerScore[playerId] != 0)
        {
            _table[_playerScore[playerId]]--;
        }
        
        _playerScore[playerId] = 0;
    }
}
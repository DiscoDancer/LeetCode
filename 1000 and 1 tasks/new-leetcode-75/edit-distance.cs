public class Solution {
    // word1 -> word2

    private string _word1;
    private string _word2;

    private int _minScore = int.MaxValue;

    private void F(int i, int j, int score) {
        if (i == _word1.Length || j == _word2.Length) {
            // если что-то осталось, то либо удалить, либо добавить
            if (i != _word1.Length) {
                _minScore = Math.Min(_minScore, score + (_word1.Length - i));
            }
            else if (j != _word2.Length) {
                _minScore = Math.Min(_minScore, score + (_word2.Length - j));
            }
            else {
                _minScore = Math.Min(_minScore, score);
            }

            return;
        }

        if (_word1[i] == _word2[j]) {
            F(i + 1, j + 1, score);
        }
        else {
            // replace
            F(i+1, j + 1, score + 1);
            // remove
            F(i+1, j, score + 1);
            // insert
            F(i, j + 1, score + 1);
        }
    }

    public int MinDistance(string word1, string word2) {
        _word1 = word1;
        _word2 = word2;

        F(0,0, 0);

        return _minScore;
    }
}
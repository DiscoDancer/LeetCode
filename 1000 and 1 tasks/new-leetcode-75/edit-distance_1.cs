public class Solution {
    // word1 -> word2

    private string _word1;
    private string _word2;

    private int F(int i, int j) {
        if (i == _word1.Length || j == _word2.Length) {
            // если что-то осталось, то либо удалить, либо добавить
            if (i != _word1.Length) {
                return _word1.Length - i;
            }
            else if (j != _word2.Length) {
                return _word2.Length - j;
            }
            else {
                return 0;
            }
        }

        if (_word1[i] == _word2[j]) {
            return F(i + 1, j + 1);
        }
        else {
            var replace = F(i+1, j + 1) + 1;
            var remove = F(i+1, j) + 1;
            var insert = F(i, j + 1) + 1;

            return Math.Min(replace, Math.Min(remove, insert));
        }
    }

    public int MinDistance(string word1, string word2) {
        _word1 = word1;
        _word2 = word2;

        return F(0,0);
    }
}
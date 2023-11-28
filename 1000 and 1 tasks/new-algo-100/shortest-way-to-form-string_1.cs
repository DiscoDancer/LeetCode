public class Solution {
    // dp
    // trie

    private string _source;
    private string _target;

    // source[i] -> target[j]
    private int F(int i, int j, int score, bool readSomething) {
        if (i == _source.Length || j == _target.Length) {
            if (i == _source.Length) {
                // reset i
                if (readSomething) {
                    return score + F(0, j, 0, false);
                }
                // dead branch
                return int.MaxValue;
            }
            // j == _target.Length
            else {
                // finish
                // _min = Math.Min(_min, score);
                return score;
            }
        }

        if (_source[i] == _target[j]) {
            var newScore = readSomething ? score : score + 1;
            // take
            var take = F(i+1, j + 1, newScore, true);
            // skip
            var skip = F(i+1, j, score, readSomething);
            return Math.Min(take, skip);
        }
        else {
            // skip
            return F(i+1, j, score, readSomething);
        }
    }

    // still TL
    public int ShortestWay(string source, string target) {
        _source = source;
        _target = target;

        // валидация букв
        var letters = new char[26];
        foreach (var c in source) {
            letters[c-'a']++;
        }
        foreach (var c in target) {
            if (letters[c-'a'] == 0) {
                return -1;
            }
        }

        return F(0, 0, 0, false);
    }
}
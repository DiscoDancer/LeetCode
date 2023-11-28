public class Solution {
    // dp
    // trie

    private string _source;
    private string _target;

    // source[i] -> target[j]
    private int F(int i, int j, bool readSomething) {
        if (i == _source.Length || j == _target.Length) {
            if (i == _source.Length) {
                // reset i
                if (readSomething) {
                    return F(0, j, false);
                }
                // dead branch
                return int.MaxValue;
            }
            // j == _target.Length
            else {
                // finish
                return 0;
            }
        }

        if (_source[i] == _target[j]) {
            // take
            var take = F(i+1, j + 1, true) + (readSomething ? 0 : 1);
            // skip
            var skip = F(i+1, j, readSomething);
            return Math.Min(take, skip);
        }
        else {
            // skip
            return F(i+1, j, readSomething);
        }
    }

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

        return F(0, 0, false);
    }
}
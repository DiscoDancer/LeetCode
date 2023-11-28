public class Solution {
    // dp
    // trie

    private string _source;
    private string _target;
    private int?[,,] _table;

    // source[i] -> target[j]
    private int F(int i, int j, int readSomething) {
        if (_table[i,j,readSomething] != null) {
            return _table[i,j,readSomething].Value;
        }
        if (i == _source.Length || j == _target.Length) {
            if (i == _source.Length) {
                // reset i
                if (readSomething == 1) {
                    _table[i,j,readSomething] =  F(0, j, 0);
                    return _table[i,j,readSomething].Value;
                }
                // dead branch
                _table[i,j,readSomething] = int.MaxValue;
                return _table[i,j,readSomething].Value;
            }
            // j == _target.Length
            else {
                // finish
                _table[i,j,readSomething]  = 0;

                return _table[i,j,readSomething].Value;
            }
        }

        if (_source[i] == _target[j]) {
            // take
            var take = F(i+1, j + 1, 1) + (readSomething == 1 ? 0 : 1);
            // skip
            var skip = F(i+1, j, readSomething);
            _table[i,j,readSomething] = Math.Min(take, skip);
            return  _table[i,j,readSomething].Value;
        }
        else {
            // skip
            _table[i,j,readSomething] = F(i+1, j, readSomething);
            return _table[i,j,readSomething].Value;
        }
    }

    // passes
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

        _table = new int?[source.Length + 1, target.Length + 1, 2];

        return F(0, 0, 0);
    }
}
public class Solution {
    // dp
    // trie

    private int _min = int.MaxValue;
    private string _source;
    private string _target;


    // source[i] -> target[j]
    private void F(int i, int j, int score, bool readSomething) {
        // могут кончиться и source и target
        if (i == _source.Length || j == _target.Length) {
            if (i == _source.Length) {
                // reset i
                if (readSomething) {
                    F(0, j, score, false);
                }
            }
            if (j == _target.Length) {
                // finish
                _min = Math.Min(_min, score);
            }
            return;
        }

        if (_source[i] == _target[j]) {
            var newScore = readSomething ? score : score + 1;
            // take
            F(i+1, j + 1, newScore, true);
            // skip
            F(i+1, j, score, readSomething);
        }
        else {
            // skip
            F(i+1, j, score, readSomething);
        }

        // они могут быть равны, а могут быть и не равны
        // мы можем читать сразу кучу за раз
        // нужно не зациклиться
        // нужно не делать reset, если ничего не взяли (bool took smth)
        // freeread неправильно считается, он вообще не нужен
    }

    // TL
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

        F(0, 0, 0, false);

        return _min == int.MaxValue ? -1 : _min;
    }
}
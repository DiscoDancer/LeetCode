public class Solution {
    // dp

    private string _s;
    private string _t;
    private bool _result = false;

    // changes можно заменить на bool наверное
    // s[i] -> t[j]
    private void F(int i, int j, bool changes) {
        if (_result) {
            return;
        }

        if (i == _s.Length || j == _t.Length) {
            if (i == _s.Length && j == _t.Length) {
                if (changes) {
                    _result = true;
                }
            }
            else if (i == _s.Length) {
                if (!changes && j == _t.Length - 1) {
                    _result = true;
                }
            }
            else if (j == _t.Length) {
                if (!changes && i == _s.Length - 1) {
                    _result = true;
                }
            }
            return;
        }

        if (_s[i] == _t[j]) {
            F(i+1, j + 1, changes);
        }
        else if (!changes) {
            // insert
            F(i, j + 1, true);
            // delete
            F(i+1, j, true);
            // replace
            F(i+1, j + 1, true);
        }
    }

    public bool IsOneEditDistance(string s, string t) {
        if (Math.Abs(s.Length - t.Length) > 1) {
            return false;
        }

        _s = s;
        _t = t;

        F(0, 0, false);

        return _result;
    }
}
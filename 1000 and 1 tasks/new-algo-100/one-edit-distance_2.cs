public class Solution {
    private string _s;
    private string _t;

    // s[i] -> t[j]
    private bool F(int i, int j, bool changes) {
        if (i == _s.Length || j == _t.Length) {
            if (i == _s.Length && j == _t.Length) {
                if (changes) {
                    return true;
                }
            }
            else if (i == _s.Length) {
                if (!changes && j == _t.Length - 1) {
                    return true;
                }
            }
            else if (j == _t.Length) {
                if (!changes && i == _s.Length - 1) {
                    return true;
                }
            }
            return false;
        }

        if (_s[i] == _t[j]) {
            return F(i+1, j + 1, changes);
        }
        else if (!changes) {
            return 
            // insert
            F(i, j + 1, true) || 
            // delete
            F(i+1, j, true) ||
            // replace
            F(i+1, j + 1, true);
        }

        return false;
    }

    public bool IsOneEditDistance(string s, string t) {
        if (Math.Abs(s.Length - t.Length) > 1) {
            return false;
        }

        _s = s;
        _t = t;

        return F(0, 0, false);
    }
}
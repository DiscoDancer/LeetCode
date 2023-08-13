public class Solution {
    private string _s1;
    private string _s2;
    private string _s3;

    private bool?[,,] _mem;

    private bool F (int s1Index, int s2Index, int s3Index) {
        if (s1Index == _s1.Length) {
            return _s3.Substring(s3Index) == _s2.Substring(s2Index);
        }
        if (s2Index == _s2.Length) {
            return _s3.Substring(s3Index) == _s1.Substring(s1Index);
        }

        if (_mem[s1Index, s2Index, s3Index] != null) {
            return _mem[s1Index, s2Index, s3Index].Value;
        }


        var result = _s1[s1Index] == _s3[s3Index] && F(s1Index + 1, s2Index, s3Index +1)
        || _s2[s2Index] == _s3[s3Index] && F(s1Index, s2Index + 1, s3Index+1);
        _mem[s1Index, s2Index, s3Index] = result;


        return result;
    }

    // editorial
    public bool IsInterleave(string s1, string s2, string s3) {
        if (s1.Length + s2.Length != s3.Length) {
            return false;
        }

        _mem = new bool?[s1.Length+1, s2.Length + 1, s3.Length +1];


        _s1 = s1;
        _s2 = s2;
        _s3 = s3;

        return F(0,0,0);
    }
}
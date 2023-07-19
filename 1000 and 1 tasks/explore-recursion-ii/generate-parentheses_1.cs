public class Solution {
    private int _n;
    private HashSet<string> _result = new ();

    private void F(StringBuilder sb) {
        var curLength = sb.Length / 2;
        if (curLength == _n) {
            _result.Add(sb.ToString());
            return;
        }

        //insert
        for (int i = 0; i < sb.Length; i++) {
            sb.Insert(i+1, "()");
            F(sb);
            sb.Remove(i+1, 2);
        }
    }

    public IList<string> GenerateParenthesis(int n) {
        _n = n;

        var sb = new StringBuilder();
        sb.Append("()");
        F(sb);
        return _result.ToList();
    }
}
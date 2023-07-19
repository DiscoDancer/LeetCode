public class Solution {
    private int _n;
    private List<string> _result = new ();

    // смещение старта позволяет избежать одинаковых
    // я порисовал схемку и понял
    private void F(StringBuilder sb, int start) {
        if (sb.Length == _n * 2) {
            _result.Add(sb.ToString());
            return;
        }
        
        for (int i = start; i < sb.Length; i++) {
            sb.Insert(i+1, "()");
            F(sb,i+1);
            sb.Remove(i+1, 2);
        }
    }

    public IList<string> GenerateParenthesis(int n) {
        _n = n;

        var sb = new StringBuilder();
        sb.Append("()");
        F(sb, 0);
        return _result;
    }
}
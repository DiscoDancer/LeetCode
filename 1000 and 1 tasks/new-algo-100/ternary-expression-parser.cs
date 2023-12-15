public class Solution {
    public const int TFQuestion = 1;
    public const int Colon = 2;
    public const int Constant = 3;

    private void ResolveList(List<(string s, int type)> list) {
        if (list.Count() >= 4) {
                var length = list.Count();
                var d = list[length - 1];
                var cc = list[length - 2];
                var b = list[length - 3];
                var a = list[length - 4];
                if (a.type == TFQuestion && b.type == Constant && cc.type == Colon && d.type == Constant) {
                    // can be resolved
                    var subResult = a.s == "T?" ? b.s : d.s;
                    list.RemoveAt(list.Count()-1);
                    list.RemoveAt(list.Count()-1);
                    list.RemoveAt(list.Count()-1);
                    list.RemoveAt(list.Count()-1);
                    list.Add((subResult, Constant));
                    ResolveList(list);
                }
        }
    }

    public string ParseTernary(string exp) {
        var list = new List<(string s, int type)>();

        for (int i = 0; i < exp.Length; i++) {
            var c = exp[i];
            if ((c == 'T' || c == 'F') && i < exp.Length - 1 && exp[i+1] == '?') {
                list.Add((c+"?", TFQuestion));
                i++;
            }
            else if (c == ':') {
                list.Add((c + "", Colon));
            }
            else {
                list.Add((c + "", Constant));
            }

            ResolveList(list);
        }

        return list.Select(x => x.s).Aggregate((a,b) => a + b);
    }
}
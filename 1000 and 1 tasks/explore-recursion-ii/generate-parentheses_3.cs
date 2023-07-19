public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var lists = new List<List<char>>() {new List<char>() {'(', ')'}};


        for (int times = 2; times <= n; times++) {
            var newLists = new List<List<char>>();

            foreach (var list in lists) {
                for (int i = 0; i < list.Count(); i++) {
                    var copy = list.ToList();
                    copy.Insert(i+1, '(');
                    copy.Insert(i+2, ')');
                    newLists.Add(copy);
                }
            }

            lists = newLists;
        }

        var result = new HashSet<string>();
        foreach (var l in lists) {
            result.Add(new string(l.ToArray()));
        }

        return result.ToList();
    }
}
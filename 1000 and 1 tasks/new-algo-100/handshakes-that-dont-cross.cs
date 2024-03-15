public class Solution {
    private int _result = 0;
    private int _numPeople;

    private List<List<int>> DeepCopy(List<List<int>> sets)
    {
        var res = new List<List<int>>();
        foreach (var s in sets)
        {
            res.Add(s.ToList());
        }

        return res;
    }

    private string ToHash(List<(int a, int b)> s)
    {
        var sb = new StringBuilder();
        foreach (var (a,b) in s.OrderBy(x => x.a))
        {
            sb.Append($"({a};{b});");
        }

        return sb.ToString();
    }

    private HashSet<string> _resultHs = new HashSet<string>();

    // не будем проверить на % 2 == 1, потому что так не возможно получить
    private void F(List<List<int>> sets, List<(int a, int b)> s) {
        if (sets.Count == 0) {
            if (s.Count == _numPeople / 2)
            {
                _resultHs.Add(ToHash(s));
                
                _result++;
            }
            return;
        }

        foreach (var set in sets) {
            for (var i = 0; i < set.Count(); i++) {
                for (var j = i + 1; j < set.Count(); j++) {
                    var split1 = new List<int>();
                    var k = i + 1;
                    while (k < j) {
                        split1.Add(set[k++]);
                    }

                    var split2 = new List<int>();
                    k = i - 1;
                    if (k < 0)
                    {
                        k += set.Count();
                    }

                    while (k > j)
                    {
                        split2.Add(set[k--]);
                    }
                    
                    if (split1.Count % 2 == 1 || split2.Count % 2 == 1)
                    {
                        // deadend
                        continue;
                    }

                    var copy = DeepCopy(sets.Where(s => s != set).ToList());
                    if (split1.Count > 0)
                    {
                        copy.Add(split1);
                    }
                    if (split2.Count > 0)
                    {
                        copy.Add(split2);
                    }

                    var copys = s.ToList();
                    var min = Math.Min(set[i], set[j]);
                    var max = Math.Max(set[i], set[j]);
                    copys.Add((min,max));
                    F(copy, copys);
                }
            }
        }
    }

    public int NumberOfWays(int numPeople) {
        var list = new List<int>();
        _numPeople = numPeople;
        for (int i = 0; i < numPeople; i++) {
            list.Add(i);
        }

        F(new List<List<int>>() {list}, new List<(int a, int b)>());

        return _resultHs.Count;
    }
}
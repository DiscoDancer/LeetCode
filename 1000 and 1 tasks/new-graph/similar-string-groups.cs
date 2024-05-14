public class Solution {
    public class UnionFind
    {
        public int[] _rank;
        public int[] _root;
        
        
        public UnionFind(int n)
        {
            _rank = new int[n];
            _root = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                _rank[i] = 1;
                _root[i] = i;
            }
        }

        public int Find(int x)
        {
            if (_root[x] == x)
            {
                return x;
            }

            _root[x] = Find(_root[x]);
            return _root[x];
        }

        public void Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY)
            {
                return;
            }

            if (_rank[rootX] > _rank[rootY])
            {
                _root[rootY] = rootX;
            }
            else if (_rank[rootX] < _rank[rootY])
            {
                _root[rootX] = rootY;
            }
            else
            {
                _root[rootY] = rootX;
                _rank[rootX]++;
            }
        }
    }
    
    public static string GetCode(string str)
    {
        var letterCount = new int[26];
        foreach (var c in str)
        {
            letterCount[c - 'a']++;
        }

        var sb = new StringBuilder();
        for (var i = 0; i < 26; i++)
        {
            if (letterCount[i] > 0)
            {
                sb.Append($"{(char)(i + 'a')}{ (letterCount[i] == 1 ? "" : letterCount[i])}");
            }
        }

        return sb.ToString();
    }
    
    public int NumSimilarGroups(string[] strs)
    {
        // var distinctStrs = strs.Distinct().ToArray();
        var n = strs.Length;
        var uf = new UnionFind(n);

        var dictionary = new Dictionary<string, List<int>>();

        for (var i = 0; i < strs.Length; i++)
        {
            var code = GetCode(strs[i]);
            if (!dictionary.ContainsKey(code))
            {
                dictionary[code] = new();
            }
            dictionary[code].Add(i);
        }

        foreach (var groupOfSameCharactersIndexes in dictionary.Values)
        {
            for (var i = 0; i < groupOfSameCharactersIndexes.Count; i++)
            {
                for (var j = i + 1; j < groupOfSameCharactersIndexes.Count; j++)
                {
                    var diffCount = 0;
                    var index1 = groupOfSameCharactersIndexes[i];
                    var index2 = groupOfSameCharactersIndexes[j];

                    for (var si = 0; si < strs[index1].Length && diffCount < 3; si++)
                    {
                        diffCount += strs[index1][si] == strs[index2][si] ? 0 : 1;
                    }

                    if (diffCount == 0 || diffCount == 2)
                    {
                        uf.Union(index1, index2);
                    }
                }
            }
        }

        // dont forget to shrink this beach
        for (var i = 0; i < n; i++)
        {
            uf.Find(i);
        }
        
        return uf._root.Distinct().Count();
    }
}
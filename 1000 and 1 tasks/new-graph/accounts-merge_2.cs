public class Solution {
    public sealed class UnionFind
    {
        private readonly int[] _rank;
        private readonly int[] _root;
        
        public UnionFind(int n)
        {
            _rank = new int[n];
            _root = new int[n];
            
            for (var i = 0; i < n; i++)
            {
                _root[i] = i;
                _rank[i] = 1;
            }
        }

        public int Find(int x)
        {
            if (x == _root[x])
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

            if (_rank[x] > _rank[y])
            {
                _root[rootY] = rootX;
            }
            else if (_rank[x] < _rank[y])
            {
                _root[rootX] = rootY;
            }
            else
            {
                _root[rootY] = rootX;
                _rank[rootX] += 1;
            }
        }
    }

    public sealed record TrieNode()
    {
        public SortedDictionary<char, TrieNode> Children { get; } = new ();
        public List<int> AccountIndexes { get; } = new();
        public bool IsWord => AccountIndexes.Any();
    }
    
    private Dictionary<int, List<string>> _rootAccountIndexToEmailsTable = new();
    private UnionFind _uf;
    
    // Обычный DFS дает алфавитный порядок - всегда выбираем самое маленькое
    public void Traverse(TrieNode node, StringBuilder sb)
    {
        if (node.IsWord)
        {
            // не важно какой взять, берем первый
            // потому что если несколько аккаунтов указывают на один email, то они должны быть одним аккаунтом по определению
            var rootAlias = _uf.Find(node.AccountIndexes.First());
            if (!_rootAccountIndexToEmailsTable.ContainsKey(rootAlias))
            {
                _rootAccountIndexToEmailsTable[rootAlias] = new List<string>();
            }
            _rootAccountIndexToEmailsTable[rootAlias].Add(sb.ToString());
        }

        foreach (var k in node.Children.Keys)
        {
            if (node.Children[k] != null)
            {
                var length = sb.Length;
                sb.Append((char)k);
                Traverse(node.Children[k]!, sb);
                sb.Remove(length, 1);
            }
        }
    }
    
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        var n = accounts.Count;
        var root = new TrieNode();
        _uf = new UnionFind(n);

        for (var accountIndex = 0; accountIndex < n; accountIndex++)
        {
            var account = accounts[accountIndex];
            var foundOtherAccountIndexes = new List<int>();
            for (var i = 1; i < account.Count; i++)
            {
                var email = account[i];


                var cur = root;
                foreach (var c in email)
                {
                    if (!cur.Children.ContainsKey(c))
                    {
                        cur.Children[c] = new TrieNode();
                    }
                    cur = cur.Children[c];
                    foundOtherAccountIndexes.AddRange(cur.AccountIndexes);
                }
                cur.AccountIndexes.Add(accountIndex);
            }

            foreach (var foundOtherAccountIndex in foundOtherAccountIndexes)
            {
                _uf.Union(accountIndex, foundOtherAccountIndex);
            }
        }
        
        
        Traverse(root, new StringBuilder());

        var result = new List<IList<string>>();

        foreach (var rootAccountIndex in _rootAccountIndexToEmailsTable.Keys)
        {
            var list = _rootAccountIndexToEmailsTable[rootAccountIndex];
            // add name
            list.Insert(0, accounts[rootAccountIndex][0]);
            result.Add(list);
        }
        
        return result;
    }
}
public class Solution {
    public class Node
    {
        public Node[] Children { get; set; } = new Node[26];
        public int? Index { get; set; }
    }
    
    private IList<IList<int>> _result;
    private string[] _words;
    private Node _root = new Node();

    private void BuildTree()
    {
        for (int i = 0; i < _words.Length; i++)
        {
            var cur = _root;
            foreach (var c in _words[i])
            {
                if (cur.Children[c - 'a'] == null)
                {
                    cur.Children[c - 'a'] = new Node();
                }
                cur = cur.Children[c - 'a'];
            }

            cur.Index = i;
        }
    }

    private int? FindWordReverse(string s)
    {
        var cur = _root;
        for (int i = s.Length - 1; i >=0; i--)
        {
            var c = s[i];
            if (cur.Children[c - 'a'] == null)
            {
                return null;
            }

            cur = cur.Children[c - 'a'];
        }

        return cur.Index;
    }
    
    private bool IsPalindrome(string s)
    {
        var valid = true;
        var L = 0;
        var R = s.Length - 1;
        while (L < R && valid)
        {
            valid = s[L] == s[R];
            L++;
            R--;
        }

        return valid;
    }

    private string Reverse(string s)
    {
        return new string(s.ToCharArray().Reverse().ToArray());
    }
    
    private void FindRight(int i, int j)
    {
        var length1 = _words[i].Length - j;
        var length2 = j;

        var s1 = _words[i].Substring(0, length1);
        var s2 = _words[i].Substring(_words[i].Length - j, length2);

        if (!IsPalindrome(s2))
        {
            return;
        }
        
        var foundReverse = FindWordReverse(s1);
        
        if (foundReverse.HasValue && foundReverse.Value != i)
        {
            _result.Add(new List<int>() { i, foundReverse.Value });
        }
    }

    private void FindLeft(int i, int j)
    {
        var length3 = j;
        var length4 = _words[i].Length - j;

        var s3 = _words[i].Substring(0, length3);
        var s4 = _words[i].Substring(j, length4);

        if (!IsPalindrome(s3))
        {
            return;
        }
        
        var foundReverse = FindWordReverse(s4);
        if (foundReverse.HasValue && foundReverse.Value != i)
        {
            _result.Add(new List<int> { foundReverse.Value, i });
        }
    }

    public IList<IList<int>> PalindromePairs(string[] words)
    {
        _words = words;
        BuildTree();
        _result = new List<IList<int>>();

        // contains empty string
        var wordsContainsEmptyString = _root.Index != null;
        if (wordsContainsEmptyString)
        {
            var k = _root.Index!.Value;
            for (var j = 0; j < words.Length; j++)
            {
                if (k != j && IsPalindrome(words[j]))
                {
                    _result.Add(new List<int>() {k,j});
                    _result.Add(new List<int>() {j,k});
                }
            }
        }

        for (int i = 0; i < words.Length; i++)
        {
            // бьем на половинки
            for (int j = 0; j < words[i].Length; j++)
            {
                FindRight(i, j);
                
                // > 0, чтобы не было дубликатов то есть чтобы ab/ba находился 2 раза, а не 4
                if (j > 0)
                {
                    FindLeft(i,j);
                }
            }
        }
        
        return _result;
    }
}
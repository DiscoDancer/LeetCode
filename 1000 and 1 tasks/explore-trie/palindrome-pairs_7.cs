
// editorial
public class Solution {
    public class Node
    {
        public Node[] Children { get; set; } = new Node[26];
        public int? Index { get; set; }
        public List<int> PalindromePrefixRemaining { get; set; } = new List<int>();
    }
    
    private IList<IList<int>> _result;
    private string[] _words;
    private Node _root = new Node();

    private bool IsPalindrome(string s, int start = 0)
    {
        var valid = true;
        var L = start;
        var R = s.Length - 1;
        while (L < R && valid)
        {
            valid = s[L] == s[R];
            L++;
            R--;
        }

        return valid;
    }

    private void BuildTree()
    {
        for (int i = 0; i < _words.Length; i++)
        {
            var cur = _root;
            var reversedWord = new string(_words[i].Reverse().ToArray());
            for (int j = 0; j < reversedWord.Length; j++)
            {
                if (IsPalindrome(reversedWord, j))
                {
                    cur.PalindromePrefixRemaining.Add(i);
                }
                var c = reversedWord[j];
                if (cur.Children[c - 'a'] == null)
                {
                    cur.Children[c - 'a'] = new Node();
                }
                cur = cur.Children[c - 'a'];
            }

            cur.Index = i;
        }
    }

    private int? FindWord(string s)
    {
        var cur = _root;
        foreach (var c in s)
        {
            if (cur.Children[c - 'a'] == null)
            {
                return null;
            }

            cur = cur.Children[c - 'a'];
        }

        return cur.Index;
    }
    
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        _words = words;
        BuildTree();
        _result = new List<IList<int>>();
        
        for (int i = 0; i < words.Length; i++)
        {
            var cur = _root;
            for (int j = 0; j < words[i].Length; j++)
            {
                var c = words[i][j];

                if (cur.Index != null && IsPalindrome(words[i], j))
                {
                    _result.Add(new List<int>() {i, cur.Index.Value});
                }

                cur = cur.Children[c - 'a'];
                if (cur == null)
                {
                    break;
                }
            }

            if (cur == null)
            {
                continue;
            }

            if (cur.Index != null && cur.Index != i)
            {
                _result.Add(new List<int>() {i, cur.Index.Value});
            }

            foreach (var other in cur.PalindromePrefixRemaining)
            {
                _result.Add(new List<int>() {i, other});
            }
        }
        
        return _result;
    }
}
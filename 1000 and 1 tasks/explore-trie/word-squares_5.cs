// editorial
public class Solution {
    public class Node
    {
        public Node[] Children { get; set; } = new Node[26];
        public List<string> Words { get; set; } = new();
    }

    private Node _root = new Node();

    private void BuildTree(string[] words)
    {
        foreach (var word in words)
        {
            _root.Words.Add(word);

            var cur = _root;
            foreach (var c in word)
            {
                if (cur.Children[c - 'a'] == null)
                {
                    cur.Children[c - 'a'] = new Node();
                }

                cur = cur.Children[c - 'a'];
                cur.Words.Add(word);
            }
        }
    }

    private List<string> FindWords(string prefix)
    {
        var cur = _root;

        foreach (var c in prefix)
        {
            if (cur.Children[c - 'a'] == null)
            {
                return new List<string>();
            }

            cur = cur.Children[c - 'a'];
        }

        return cur.Words;
    }

    private string[] _words;
    private int N;
    private IList<IList<string>> _result = new List<IList<string>>();

    private void F(int i, List<string> list)
    {
        if (i == N)
        {
            _result.Add(list.ToList());
            return;
        }

        var prefix = new StringBuilder();
        foreach (var w in list)
        {
            prefix.Append(w[i]);
        }

        foreach (var w in FindWords(prefix.ToString()))
        {
            list.Add(w);
            F(i + 1, list);
            list.RemoveAt(list.Count - 1);
        }
    }

    public IList<IList<string>> WordSquares(string[] words)
    {
        _words = words;
        BuildTree(words);
        N = words[0].Length;

        foreach (var word in words)
        {
            var list = new List<string>() { word };
            F(1, list);
        }

        return _result;
    }
}
// passes

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

    public IList<IList<string>> WordSquares(string[] words)
    {
        BuildTree(words);
        
        var result = new List<IList<string>>();

        var options = new List<List<string>> { new() { } };

        for (int i = 0; i < words[0].Length; i++)
        {

            var newOptions = new List<List<string>>();
            foreach (var opt in options)
            {
                var sb = new StringBuilder();
                foreach (var s in opt)
                {
                    sb.Append(s[i]);
                }

                var start = sb.ToString();
                var wordsStartWithCurrentLetter = FindWords(start);

                foreach (var w in wordsStartWithCurrentLetter)
                {
                    var copy = opt.ToList();
                    copy.Add(w);
                    newOptions.Add(copy);

                    if (copy.Count == words[0].Length)
                    {
                        result.Add(copy.ToList());
                    }
                }
                    
                options = newOptions;
            }
        }

        return result;
    }
}
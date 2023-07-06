public class Solution {
    public class Node
    {
        public bool word { get; set; }
        public Node[] children { get; set; } = new Node[26];
    }

    private readonly Node _root = new();

    private string? Find(string word)
    {
        var cur = _root;
        var i = 0;
        var path = new StringBuilder();
        while (cur != null && i < word.Length)
        {
            var c = word[i];
            if (cur.children[c - 'a'] == null)
            {
                return null;
            }

            path.Append(c);
            if (cur.children[c - 'a'].word)
            {
                return path.ToString();
            }

            cur = cur.children[c - 'a'];
            i++;
        }

        return null;
    }

    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        foreach (var word in dictionary)
        {
            var cur = _root;
            foreach (var c in word)
            {
                if (cur.children[c - 'a'] == null)
                {
                    cur.children[c - 'a'] = new Node();
                }

                cur = cur.children[c - 'a'];
            }

            cur.word = true;
        }

        var sb = new StringBuilder();
        var words = sentence.Split(' ');
        for (var i = 0; i < words.Length; i++)
        {
            sb.Append(Find(words[i]) ?? words[i]);

            if (i != words.Length - 1)
            {
                sb.Append(' ');
            }
        }

        return sb.ToString();
    }
}
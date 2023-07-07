public class WordDictionary {
    
    public class Node
    {
        public bool Word { get; set; } = false;
        public Node[] Children { get; set; } = new Node[26];
    }

    private readonly Node _root = new Node();

    public WordDictionary() {
    }
    
    public void AddWord(string word)
    {
        var cur = _root;
        foreach (var c in word)
        {
            if (cur.Children[c - 'a'] == null)
            {
                cur.Children[c - 'a'] = new Node();
            }

            cur = cur.Children[c - 'a'];
        }
        cur.Word = true;
    }
    
    public bool Search(string word) {
        var queue = new Queue<(Node node, int i)>();
        queue.Enqueue((_root, 0));

        while (queue.Any())
        {
            var (node, i) = queue.Dequeue();

            // last
            if (i == word.Length - 1)
            {
                var c = word[i];
                if (c == '.' && node.Children.Any(x => x is { Word: true }) || c != '.' && node.Children[c - 'a'] != null && node.Children[c - 'a'].Word )
                {
                    return true;
                }
                continue;
            }
            
            // not last
            if (word[i] == '.')
            {
                foreach (var child in node.Children)
                {
                    if (child != null)
                    {
                        queue.Enqueue((child, i + 1));
                    }
                }
            }
            else if (node.Children[word[i]-'a'] != null)
            {
                queue.Enqueue((node.Children[word[i]-'a'], i + 1));
            }
        }


        return false;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
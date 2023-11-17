public class Solution {
    public class Node {
        public Node(bool isWord = false) {
            IsWord = isWord;
            Children = new Node[26];
            Words = new ();
        }

        public bool IsWord {get; set;}
        public Node[] Children {get; set;}
        public List<string> Words {get; set;}
    }

    private Node _root = new Node();

    private void Insert(string word) {
        var cur = _root;
        foreach (var c in word) {
            if (cur.Children[c-'a'] == null) {
                cur.Children[c-'a'] = new Node();
            }
            cur = cur.Children[c-'a'];
            cur.Words.Add(word);
        }
        cur.IsWord = true; 
    }


    // TODO не копировать строки
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        var sortedProducts = products.OrderBy(x => x).ToArray();

        foreach (var word in sortedProducts) {
            Insert(word);
        }

        var result = new List<IList<string>>();
        var cur = _root;
        var hasEnded = false;
        foreach (var c in searchWord) {
            if (hasEnded) {
                result.Add(new List<string>());
                continue;
            }
            var node = cur.Children[c-'a'];
            if (node == null) {
                hasEnded = true;
                result.Add(new List<string>());
                continue;
            }

            var words = node.Words.Take(3).ToList();
            result.Add(words);
            cur = node;
        }

        return result;
    }
}
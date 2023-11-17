public class Solution {
    public class Node {
        public Node() {
            Children = new Node[26];
            WordsIds = new ();
        }

        public Node[] Children {get; set;}
        public List<int> WordsIds {get; set;}
    }

    private Node _root = new Node();

    private void Insert(string word, int id) {
        var cur = _root;
        foreach (var c in word) {
            if (cur.Children[c-'a'] == null) {
                cur.Children[c-'a'] = new Node();
            }
            cur = cur.Children[c-'a'];
            cur.WordsIds.Add(id);
        }
    }


    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        var table = new Dictionary<string, int>();
        foreach (var p in products) {
            table[p] = table.Count();
        }

        var sortedProducts = products.OrderBy(x => x).ToArray();

        foreach (var word in sortedProducts) {
            var id = table[word];
            Insert(word, id);
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

            var wordIds = node.WordsIds.Take(3);
            var words = wordIds.Select(id => products[id]).ToList();
            result.Add(words);
            cur = node;
        }

        return result;
    }
}
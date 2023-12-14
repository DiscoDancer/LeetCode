public class Solution {
    // trie
    // обертка в b легко сделать, у меня будет просто строка s размера в true/false
    // можно сделать trie и слов, и на каждый символ начинать поиск

    public class Node {
        public Dictionary<char, Node> Children {get; set;} = new ();
        public bool IsWord {get; set;} = false;
    }

    private bool[] _state;
    private string _s;
    private Node _root = new Node();

    private void BuildTrie(string[] words) {
        foreach (var word in words) {
            var cur = _root;
            foreach (var c in word) {
                if (!cur.Children.ContainsKey(c)) {
                    cur.Children[c] = new ();
                }
                cur = cur.Children[c];
            }
            cur.IsWord = true;
        }
    }

    public string AddBoldTag(string s, string[] words)
    {
        _state = new bool[s.Length];
        _s = s;
        BuildTrie(words);

        var intervals = new List<int[]>();

        for (int beginIndex = 0; beginIndex < s.Length; beginIndex++) {
            var cur = _root;
            var endIndex = beginIndex;
            while (endIndex < s.Length && cur.Children.ContainsKey(s[endIndex])) {
                cur = cur.Children[s[endIndex]];
                if (cur.IsWord) {
                    if (!intervals.Any()) {
                        intervals.Add(new int[] {beginIndex, endIndex});
                    }
                    else {
                        var last = intervals.Last();
                        if (!(last[1] < beginIndex) || last[1] + 1 == beginIndex) {
                            last[1] = Math.Max(endIndex, last[1]);
                        }
                        else {
                            intervals.Add(new int[] {beginIndex, endIndex});
                        }
                    }
                }
                endIndex++;
            }
        }
        
        _state = new bool[s.Length];
        foreach (var interval in intervals)
        {
            var begin = interval[0];
            var end = interval[1];

            while (begin <= end)
            {
                _state[begin] = true;
                begin++;
            }
        }

        var sb = new StringBuilder();
        for (int i = 0; i < _state.Length; i++) {
            if (!_state[i]) {
                sb.Append(s[i]);
            }
            else {
                sb.Append("<b>");
                while (i < _state.Length && _state[i]) {
                    sb.Append(s[i++]);
                }
                i--;
                sb.Append("</b>");
            }
        }

        return sb.ToString();
    }
}
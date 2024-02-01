public class AutocompleteSystem
{
    // дерево, в вершине слова
    // сортируем слова после каждого ввода + изначально -> в виде таблицы (слово -> номер)
    // выдача через priority queue

    // не добавлять слово по 2 раза

    public class Node
    {
        public List<string> words { get; set; } = new();
        public Dictionary<char, Node> children { get; set; } = new();
    }

    private readonly Node _root = new ();
    private readonly Dictionary<string, int> _wordToCountTable = new();
    private StringBuilder _inputSb = new ();
    private Node _searchNodeOrDefault;
    
    private void AddWordToTrie(string sentence)
    {
        var cur = _root;
        foreach (var c in sentence)
        {
            cur.children.TryAdd(c, new Node());
            cur = cur.children[c];
            cur.words.Add(sentence);
        }
    }

    public AutocompleteSystem(string[] sentences, int[] times)
    {
        // fill tables
        for (var i = 0; i < sentences.Length; i++)
        {
            _wordToCountTable[sentences[i]] = times[i];
        }

        // build tree
        foreach (var sentence in sentences)
        {
            AddWordToTrie(sentence);
        }

        _searchNodeOrDefault = _root;
    }
    
    private void AddWord(string word)
    {
        if (!_wordToCountTable.ContainsKey(word))
        {
            _wordToCountTable[word] = 1;
            AddWordToTrie(word);
        }
        else
        {
            _wordToCountTable[word]++;
        }
    }
    
    public IList<string> Input(char c)
    {
        if (c == '#')
        {
            AddWord(_inputSb.ToString());
            
            _inputSb = new StringBuilder();
            _searchNodeOrDefault = _root;
            return new List<string>();
        }

        _inputSb.Append(c);

        if (_searchNodeOrDefault == null)
        {
            return new List<string>();
        }
        
        _searchNodeOrDefault.children.TryGetValue(c, out var childNode);
        _searchNodeOrDefault = childNode;
        if (_searchNodeOrDefault == null)
        {
            return new List<string>();
        }
        
        var words = _searchNodeOrDefault.words;
        words.Sort(Comparer<string>.Create((a, b) =>
        {
            var rateA = _wordToCountTable[a];
            var rateB = _wordToCountTable[b];
            
            if (rateA == rateB) {
                return string.Compare(a, b, StringComparison.Ordinal);
            }

            return rateB - rateA;
        }));

        return words.Take(3).ToList();
    }
}
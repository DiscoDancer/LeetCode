public class AutocompleteSystem
{
    // дерево, в вершине слова
    // сортируем слова после каждого ввода + изначально -> в виде таблицы (слово -> номер)
    // выдача через priority queue

    // не добавлять слово по 2 раза

    public class Node
    {
        public HashSet<string> words { get; set; } = new();
        public Dictionary<char, Node> children { get; set; } = new();
    }

    private readonly Node _root = new Node();
    private readonly Dictionary<string, int> _wordToCountTable = new();
    private readonly HashSet<string> _words = new();
    private Dictionary<string, int> _sortedWords;

    private void SortWords()
    {
        var table = new Dictionary<int, List<string>>();

        foreach (var word in _words)
        {
            var count = _wordToCountTable[word];
            if (!table.ContainsKey(count))
            {
                table[count] = new List<string>();
            }
            table[count].Add(word);
        }
        
        var keys = table.Keys.OrderBy(x => -x).ToArray();
        var sortedWords = new string[_words.Count];
        var i = 0;
        foreach (var k in keys)
        {
            table[k].Sort();
            foreach (var w in table[k])
            {
                sortedWords[i++] = w;
            }
        }

        var result = new Dictionary<string, int>();
        for (i = 0; i < sortedWords.Length; i++)
        {
            result[sortedWords[i]] = i;
        }

        _sortedWords = result;
    }

    private void AddWordToTree(string sentence)
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
            _words.Add(sentences[i]);
        }

        // build tree
        foreach (var sentence in sentences)
        {
            AddWordToTree(sentence);
        }

        SortWords();
    }



    private void AddWord(string word)
    {
        if (!_words.Contains(word))
        {
            _words.Add(word);
            _wordToCountTable[word] = 1;
        }
        else
        {
            _wordToCountTable[word]++;
        }

        AddWordToTree(word);
        SortWords();
    }
    
    private StringBuilder _sb = new StringBuilder();
    private Node _position = null;
    private bool _ended = false;

    public IList<string> Input(char c)
    {
        if (c == '#')
        {
            AddWord(_sb.ToString());
            
            _sb = new StringBuilder();
            _ended = false;
            _position = null;
            return new List<string>();
        }
        else
        {
            _sb.Append(c);
        }

        if (_ended)
        {
            return new List<string>();
        }

        if (_position == null)
        {
            _position = _root;
        }
        if (!_position.children.ContainsKey(c))
        {
            _ended = true;
            return new List<string>();
        }


        _position = _position.children[c];

        var queue = new PriorityQueue<string, int>();
        foreach (var word in _position.words)
        {
            queue.Enqueue(word, _sortedWords[word]);
        }

        var result = new List<string>();
        var i = 0;
        while (i < 3 && queue.Count > 0)
        {
            result.Add(queue.Dequeue());
            i++;
        }

        return result;
    }
}
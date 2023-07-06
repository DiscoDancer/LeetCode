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

    private readonly Node _root = new Node();
    private readonly Dictionary<string, int> _wordToCountTable = new();
    
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
        }

        // build tree
        foreach (var sentence in sentences)
        {
            AddWordToTree(sentence);
        }
    }



    private void AddWord(string word)
    {
        if (!_wordToCountTable.ContainsKey(word))
        {
            _wordToCountTable[word] = 1;
            AddWordToTree(word);
        }
        else
        {
            _wordToCountTable[word]++;
        }
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

        var words = _position.words;
        words.Sort((x, y) =>
        {
            var countX = _wordToCountTable[x];
            var countY = _wordToCountTable[y];

            if (countX == countY)
            {
                return x.CompareTo(y);
            }
                
            return countY - countX;
        });

        return words.Take(3).ToList();
    }
}
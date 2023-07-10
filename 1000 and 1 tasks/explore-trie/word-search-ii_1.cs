public class Solution
{
    // words -> trie
    // foreach cell find words if not used
    // remove a word from trie as an ompimization
    // вместо bool таблички int и байты
    // не аллоцировать кучу таблич
    // backtracking
    // мб path вообще не нужен?
    
    
    /*
     Roadmap:
     * build trie 
     */

    public class Node
    {
        public Node?[] Children { get; set; } = new Node[26];
        public string? Word { get; set; } = null;
    }
    
    private void BuildTrie(string[] words)
    {
        foreach (var word in words)
        {
            var cur = _root;
            foreach (var c in word)
            {
                cur.Children[c - 'a'] ??= new Node();
                cur = cur.Children[c - 'a'];
            }

            cur.Word = word;
        }
    }
    
    private Node _root = new Node();
    private List<string> _result = new List<string>();
    private int X;
    private int Y;
    private char[][] _board;

    private void Search(List<(int x, int y)> path, Node node)
    {
        if (node.Word != null)
        {
            _result.Add(node.Word);
            // удаляем слово, чтобы больше его не находить
            node.Word = null;
        }
        
        var (x, y) = path.Last();
        if (x < X - 1 && !path.Contains((x + 1, y)) && node.Children[_board[x+1][y]-'a'] != null)
        {
            path.Add((x+1,y));
            Search(path, node.Children[_board[x+1][y]-'a']!);
            path.RemoveAt(path.Count - 1);
        }
                    
        if (x > 0 && !path.Contains((x - 1, y)) && node.Children[_board[x-1][y]-'a'] != null)
        {
            path.Add((x-1,y));
            Search(path, node.Children[_board[x-1][y]-'a']!);
            path.RemoveAt(path.Count - 1);
        }
                    
        if (y < Y - 1 && !path.Contains((x, y+1)) && node.Children[_board[x][y+1]-'a'] != null)
        {
            path.Add((x,y+1));
            Search(path, node.Children[_board[x][y+1]-'a']!);
            path.RemoveAt(path.Count - 1);
        }
                    
        if (y > 0 && !path.Contains((x, y-1)) && node.Children[_board[x][y-1]-'a'] != null)
        {
            path.Add((x,y-1));
            Search(path, node.Children[_board[x][y-1]-'a']!);
            path.RemoveAt(path.Count - 1);
        }
    }
    
    public IList<string> FindWords(char[][] board, string[] words)
    {
        BuildTrie(words);

        X = board.Length;
        Y = board[0].Length;
        _board = board;
        
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                var c = board[i][j];
                if (_root.Children[c - 'a'] != null)
                {
                    Search(new List<(int x, int y)> { (i, j) }, _root.Children[c - 'a']!);
                }
            }
        }

        return _result;
    }
}
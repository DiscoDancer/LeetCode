public class Solution
{
    // good score

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

    private void Search(bool[][] visited, Node node, int x, int y)
    {
        if (node.Word != null)
        {
            _result.Add(node.Word);
            // удаляем слово, чтобы больше его не находить
            node.Word = null;
        }
        
        if (x < X - 1 && !visited[x+1][y] && node.Children[_board[x+1][y]-'a'] != null)
        {
            visited[x + 1][y] = true;
            Search(visited, node.Children[_board[x+1][y]-'a']!, x+1, y);
            visited[x + 1][y] = false;
        }
        if (x > 0 && !visited[x-1][y] && node.Children[_board[x-1][y]-'a'] != null)
        {
            visited[x - 1][y] = true;
            Search(visited, node.Children[_board[x-1][y]-'a']!, x-1, y);
            visited[x - 1][y] = false;
        }
                    
        if (y < Y - 1 && !visited[x][y+1] && node.Children[_board[x][y+1]-'a'] != null)
        {
            visited[x][y+1] = true;
            Search(visited, node.Children[_board[x][y+1]-'a']!, x, y+1);
            visited[x][y+1] = false;
        }
        if (y > 0 && !visited[x][y-1] && node.Children[_board[x][y-1]-'a'] != null)
        {
            visited[x][y-1] = true;
            Search(visited, node.Children[_board[x][y-1]-'a']!, x, y-1);
            visited[x][y-1] = false;
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
                    var visited = new bool[X][];
                    for (int k = 0; k < X; k++)
                    {
                        visited[k] = new bool[Y];
                    }
                    visited[i][j] = true;
                    
                    Search(visited, _root.Children[c - 'a']!, i, j);
                }
            }
        }

        return _result;
    }
}
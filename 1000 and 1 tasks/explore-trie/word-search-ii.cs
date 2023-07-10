public class Solution {
    public class Node
    {
        public Node?[] Children { get; set; } = new Node[26];
        public string? Word { get; set; } = null;
    }

    private Node _root = new Node();

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

    public IList<string> FindWords(char[][] board, string[] words)
    {
        BuildTrie(words);

        var X = board.Length;
        var Y = board[0].Length;
        
        var result = new List<string>();

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                var queue = new Queue<(List<(int x, int y)> path, Node node)>();
                var c = board[i][j];
                if (_root.Children[c - 'a'] != null)
                {
                    queue.Enqueue((new List<(int x, int y)> {(i,j)},_root.Children[c - 'a']!));
                }

                while (queue.Any())
                {
                    var (path, node) = queue.Dequeue();

                    // слово нашлось -> чистим ветки + бронируем ячейки
                    if (node.Word != null)
                    {
                        result.Add(node.Word);
                        // удаляем слово, чтобы больше его не находить
                        node.Word = null;
                    }

                    var (x, y) = path.Last();
                    if (x < X - 1 && !path.Contains((x + 1, y)) && node.Children[board[x+1][y]-'a'] != null)
                    {
                        var copyPath = path.ToList();
                        copyPath.Add((x+1,y));
                        queue.Enqueue((copyPath, node.Children[board[x+1][y]-'a']));
                    }
                    
                    if (x > 0 && !path.Contains((x - 1, y)) && node.Children[board[x-1][y]-'a'] != null)
                    {
                        var copyPath = path.ToList();
                        copyPath.Add((x-1,y));
                        queue.Enqueue((copyPath, node.Children[board[x-1][y]-'a']));
                    }
                    
                    if (y < Y - 1 && !path.Contains((x, y+1)) && node.Children[board[x][y+1]-'a'] != null)
                    {
                        var copyPath = path.ToList();
                        copyPath.Add((x,y+1));
                        queue.Enqueue((copyPath, node.Children[board[x][y+1]-'a']));
                    }
                    
                    if (y > 0 && !path.Contains((x, y-1)) && node.Children[board[x][y-1]-'a'] != null)
                    {
                        var copyPath = path.ToList();
                        copyPath.Add((x,y-1));
                        queue.Enqueue((copyPath, node.Children[board[x][y-1]-'a']));
                    }
                }
            }
        }

        return result;
    }
}
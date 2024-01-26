public class Solution {
    // просто добавить сверху backtracking + sort
    // наверное этого хватит
    // или heap потому что мне нужно только одно значение

    // но, там то он останавливался, значит я должен из точки, которая мне дана сделать 4 другие!
    // или нет? лучше нет

    // Console.WriteLine("a".CompareTo("b"));

    private int[][] _maze;
    private string? _resultPath = null;
    private int _resultLength = int.MaxValue;
    private int[,] _distances;
    private string?[,] _paths;
    private int[] _hole;

    private void DFS(int x0, int y0, StringBuilder sb)
    {
        var X = _maze.Length;
        var Y = _maze[0].Length;
        var maze = _maze;

        // can go down?
        if (x0 < X - 1 && maze[x0 + 1][y0] == 0)
        {
            // катимся вниз насколько это возможно
            var maxDown = x0;
            var d = 0;
            while (maxDown + 1 < X && maze[maxDown + 1][y0] == 0)
            {
                d++;
                maxDown++;
                if (maxDown == _hole[0] && y0 == _hole[1] && d + _distances[x0, y0] <= _resultLength)
                {
                    if (d + _distances[x0, y0] < _resultLength)
                    {
                        _resultLength = d + _distances[x0, y0];
                        _resultPath = sb + "d";
                    }
                    else if (_resultPath.CompareTo(sb + "d") == 1)
                    {
                        _resultPath = sb + "d";
                    }
                }
            }
            if (_distances[x0, y0] + d < _distances[maxDown, y0])
            {
                _distances[maxDown, y0] = _distances[x0, y0] + d;
                sb.Append('d');
                var newPath = sb.ToString();
                if (_paths[maxDown, y0] == null || newPath.CompareTo(_paths[maxDown, y0] ) == -1)
                {
                    _paths[maxDown, y0] = newPath;
                }
                DFS(maxDown, y0, sb);
                sb.Remove(sb.Length - 1, 1);
            }
        }
        // can go up?
        if (x0 > 0 && maze[x0 - 1][y0] == 0)
        {
            // катимся вниз насколько это возможно
            var maxUp = x0;
            var d = 0;
            while (maxUp - 1  >= 0 && maze[maxUp - 1][y0] == 0) {
                maxUp--;
                d++;
                if (maxUp == _hole[0] && y0 == _hole[1] && d + _distances[x0, y0] <= _resultLength)
                {
                    if (d + _distances[x0, y0] < _resultLength)
                    {
                        _resultLength = d + _distances[x0, y0];
                        _resultPath = sb + "u";
                    }
                    else if (_resultPath.CompareTo(sb + "u") == 1)
                    {
                        _resultPath = sb + "u";
                    }
                }
            }
            
            if (_distances[x0, y0] + d < _distances[maxUp, y0])
            {
                _distances[maxUp, y0] = _distances[x0, y0] + d;
                sb.Append('u');
                var newPath = sb.ToString();
                if (_paths[maxUp, y0] == null || newPath.CompareTo(_paths[maxUp, y0] ) == -1)
                {
                    _paths[maxUp, y0] = newPath;
                }
                DFS(maxUp, y0, sb);
                sb.Remove(sb.Length - 1, 1);
            }
        }
        // can go left
        if (y0 > 0 && maze[x0][y0-1] == 0) {
            // катимся вниз насколько это возможно
            var maxLeft = y0 ;
            var d = 0;
            while (maxLeft - 1 >= 0 && maze[x0][maxLeft - 1] == 0) {
                maxLeft--;
                d++;
                if (x0 == _hole[0] && maxLeft == _hole[1] && d + _distances[x0, y0] <= _resultLength)
                {
                    if (d + _distances[x0, y0] < _resultLength)
                    {
                        _resultLength = d + _distances[x0, y0];
                        _resultPath = sb + "l";
                    }
                    else if (_resultPath.CompareTo(sb + "l") == 1)
                    {
                        _resultPath = sb + "l";
                    }
                }
            }
            
            if (_distances[x0, y0] + d <= _distances[x0, maxLeft])
            {
                _distances[x0, maxLeft] = _distances[x0, y0] + d;
                sb.Append('l');
                var newPath = sb.ToString();
                if (_paths[x0, maxLeft] == null || newPath.CompareTo(_paths[x0, maxLeft] ) == -1)
                {
                    _paths[x0, maxLeft] = newPath;
                }
                DFS(x0, maxLeft, sb);
                sb.Remove(sb.Length - 1, 1);
            }
        }
        // can go right
        if (y0 < Y - 1 && maze[x0][y0+1] == 0) {
            // катимся вниз насколько это возможно
            var maxRight = y0;
            var d = 0;
            while (maxRight + 1 < Y && maze[x0][maxRight + 1] == 0) {
                maxRight++;
                d++;
                if (x0 == _hole[0] && maxRight == _hole[1] && d + _distances[x0, y0] <= _resultLength)
                {
                    if (d + _distances[x0, y0] < _resultLength)
                    {
                        _resultLength = d + _distances[x0, y0];
                        _resultPath = sb + "r";
                    }
                    else if (_resultPath.CompareTo(sb + "r") == 1)
                    {
                        _resultPath = sb + "r";
                    }
                }
            }
            if (_distances[x0, y0] + d <= _distances[x0, maxRight])
            {
                _distances[x0, maxRight] = _distances[x0, y0] + d;
                sb.Append('r');
                var newPath = sb.ToString();
                if (_paths[x0, maxRight] == null || newPath.CompareTo(_paths[x0, maxRight] ) == -1)
                {
                    _paths[x0, maxRight] = newPath;
                }
                DFS(x0, maxRight, sb);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }

    // wrong answer

    public string FindShortestWay(int[][] maze, int[] ball, int[] hole)
    {
        _maze = maze;
        _hole = hole;
        var X = maze.Length;
        var Y = maze[0].Length;
        _distances = new int[X, Y];
        _paths = new string[X, Y];
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                _distances[i, j] = int.MaxValue;
                _paths[i, j] = null;
            }
        }

        _distances[ball[0], ball[1]] = 0;
        _paths[ball[0], ball[1]] = "";

        DFS(ball[0], ball[1], new StringBuilder());

        return _resultPath == null ? "impossible" : _resultPath;
    }
}
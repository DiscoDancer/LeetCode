public class Solution {
    private bool _result = false;
    private int[][] _maze;
    private int[] _destination;
    private bool[,] _visited;

    private void Traverse(int x0, int y0) {
        if (_result) {
            return;
        }
        if (x0 == _destination[0] && y0 == _destination[1]) {
            _result = true;
            return;
        }

        var X = _maze.Length;
        var Y = _maze[0].Length;

        // can go down?
        if (x0 < X-1 && _maze[x0+1][y0] == 0) {
            // катимся вниз насколько это возможно
            var maxDown = x0+1;
            while (maxDown + 1  < X && _maze[maxDown + 1][y0] == 0) {
                maxDown++;
            }
            if (!_visited[maxDown, y0]) {
                _visited[maxDown, y0] = true;
                Traverse(maxDown, y0);
            }
        }
        // can go up?
        if (x0 > 0 && _maze[x0-1][y0] == 0) {
            // катимся вниз насколько это возможно
            var maxUp = x0 - 1;
            while (maxUp - 1  >= 0 && _maze[maxUp - 1][y0] == 0) {
                maxUp--;
            }
            if (!_visited[maxUp, y0]) {
                _visited[maxUp, y0] = true;
                Traverse(maxUp, y0);
            }
        }
        // can go left
        if (y0 > 0 && _maze[x0][y0-1] == 0) {
            // катимся вниз насколько это возможно
            var maxLeft = y0 - 1;
            while (maxLeft - 1 >= 0 && _maze[x0][maxLeft - 1] == 0) {
                maxLeft--;
            }
            if (!_visited[x0, maxLeft]) {
                _visited[x0, maxLeft] = true;
                Traverse(x0, maxLeft);
            }
        }
        // can go right
        if (y0 < Y - 1 && _maze[x0][y0+1] == 0) {
            // катимся вниз насколько это возможно
            var maxRight = y0 + 1;
            while (maxRight + 1 < Y && _maze[x0][maxRight + 1] == 0) {
                maxRight++;
            }
            if (!_visited[x0, maxRight]) {
                _visited[x0, maxRight] = true;
                Traverse(x0, maxRight);
            }
        }
    }

    public bool HasPath(int[][] maze, int[] start, int[] destination) {
        var X = maze.Length;
        var Y = maze[0].Length;

        _visited = new bool[X,Y];
        _maze = maze;
        _destination = destination;
        _visited[start[0], start[1]] = true;
        Traverse(start[0], start[1]);

        return _result;
    }
}
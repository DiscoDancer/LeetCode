public class Solution {
    // если ли смысл возвращаться ? на траекторию да, на начальную точку нет
    // backtracking

    private bool _result = false;
    private int[][] _maze;
    private int[] _destination;

        private void Traverse(int x0, int y0, bool[,] visited) {
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
            if (!visited[maxDown, y0]) {
                visited[maxDown, y0] = true;
                Traverse(maxDown, y0, visited);
                visited[maxDown, y0] = false;
            }
        }
        // can go up?
        if (x0 > 0 && _maze[x0-1][y0] == 0) {
            // катимся вниз насколько это возможно
            var maxUp = x0 - 1;
            while (maxUp - 1  >= 0 && _maze[maxUp - 1][y0] == 0) {
                maxUp--;
            }
            if (!visited[maxUp, y0]) {
                visited[maxUp, y0] = true;
                Traverse(maxUp, y0, visited);
                visited[maxUp, y0] = false;
            }
        }
        // can go left
        if (y0 > 0 && _maze[x0][y0-1] == 0) {
            // катимся вниз насколько это возможно
            var maxLeft = y0 - 1;
            while (maxLeft - 1 >= 0 && _maze[x0][maxLeft - 1] == 0) {
                maxLeft--;
            }
            if (!visited[x0, maxLeft]) {
                visited[x0, maxLeft] = true;
                Traverse(x0, maxLeft, visited);
                visited[x0, maxLeft] = false;
            }
        }
        // can go right
        if (y0 < Y - 1 && _maze[x0][y0+1] == 0) {
            // катимся вниз насколько это возможно
            var maxRight = y0 + 1;
            while (maxRight + 1 < Y && _maze[x0][maxRight + 1] == 0) {
                maxRight++;
            }
            if (!visited[x0, maxRight]) {
                visited[x0, maxRight] = true;
                Traverse(x0, maxRight, visited);
                visited[x0, maxRight] = false;
            }
        }
    }

    // TL
    public bool HasPath(int[][] maze, int[] start, int[] destination) {
        var X = maze.Length;
        var Y = maze[0].Length;

        var visited = new bool[X,Y];
        _maze = maze;
        _destination = destination;
        Traverse(start[0], start[1], visited);

        return _result;
    }
}
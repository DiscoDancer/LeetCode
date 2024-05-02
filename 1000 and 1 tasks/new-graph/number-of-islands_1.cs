namespace ConsoleApp1;

// списал свое старое решение

public class CurTask
{
    private static int _count = 0;

    public class UnionFind
    {
        public int[] _root;
        public int[] _rank;

        public UnionFind(char[][] grid)
        {
            _count = 0;
            var X = grid.Length;
            var Y = grid[0].Length;
            _root = new int[X * Y];
            _rank = new int[X * Y];

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        _root[i * Y + j] = i * Y + j;
                        _count++;
                    }

                    _rank[i * Y + j] = 1;
                }
            }
        }

        public int Find(int x)
        {
            if (x == _root[x])
            {
                return x;
            }

            _root[x] = Find(_root[x]);
            return _root[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX == rootY)
            {
                return;
            }

            if (_rank[x] > _rank[y])
            {
                _root[rootY] = rootX;
            }
            else if (_rank[x] < _rank[y])
            {
                _root[rootX] = rootY;
            }
            else
            {
                _root[rootY] = rootX;
                _rank[rootX] += 1;
            }

            _count--;
        }
    }

    public int NumIslands(char[][] grid)
    {
        var N = grid.Length;
        _count = N;
        var unionFind = new UnionFind(grid);
        var X = grid.Length;
        var Y = grid[0].Length;
        var visited = new bool[X][];
        visited = new bool[X][];
        for (int i = 0; i < X; i++)
        {
            visited[i] = new bool[Y];
        }

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (grid[i][j] == '1' && !visited[i][j])
                {
                    visited[i][j] = true;
                    if (i > 0 && grid[i - 1][j] == '1' && !visited[i - 1][j])
                    {
                        unionFind.Union(i * Y + j, (i - 1) * Y + j);
                    }

                    if (i < X - 1 && grid[i + 1][j] == '1' && !visited[i + 1][j])
                    {
                        unionFind.Union(i * Y + j, (i + 1) * Y + j);
                    }

                    if (j > 0 && grid[i][j - 1] == '1' && !visited[i][j - 1])
                    {
                        unionFind.Union(i * Y + j, i * Y + j - 1);
                    }

                    if (j < Y - 1 && grid[i][j + 1] == '1' && !visited[i][j + 1])
                    {
                        unionFind.Union(i * Y + j, i * Y + j + 1);
                    }
                }
            }
        }

        return _count;
    }
}
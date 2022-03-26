public class Solution {
    // we can use 1 array and replcae with -1 then check > 0
    // avoid N and M calcs
    
       public int DFS(int[][] grid, bool[][] visited, int x, int y)
    {
        if (visited[x][y])
        {
            return 0;
        }
        visited[x][y] = true;

        var ourLen = grid[x][y];  
        if (ourLen == 0)
        {
            return 0;
        }

        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;

        int X = grid.Length;
        int Y = grid[0].Length;

        if (x < X - 1)
        {
            a = DFS(grid, visited, x + 1, y);
        }
        if (x > 0)
        {
            b = DFS(grid, visited, x -1, y);
        }

        if (y < Y - 1)
        {
            c= DFS(grid, visited, x, y + 1);
        }
        if (y > 0)
        {
             d = DFS(grid, visited, x, y - 1);
        }

        return ourLen + a + b + c + d;
    }
    
    public int MaxAreaOfIsland(int[][] grid) {
        var visited = new bool[grid.Length][];
        for (int i = 0; i < grid.Length; i++) {
            visited[i] = new bool[grid[0].Length];
        }
        
        int max = 0;
        
        for (int i =0; i < grid.Length; i++) {
            for (int j =0; j < grid[0].Length; j++) {
                var res = DFS(grid, visited, i, j);
                if (res > max) max = res;
            }
        }
        
        return max;
    }
}
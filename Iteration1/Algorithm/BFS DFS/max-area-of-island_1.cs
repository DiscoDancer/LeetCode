using System.Collections.Generic;

public class Solution {
    // we can use 1 array and replcae with -1 then check > 0
    // avoid N and M calcs
    
       public int DFS(int[][] grid, bool[][] visited, int x, int y)
    {
        var l = 0;
        var stack = new Stack<int[]>();
        stack.Push(new int[] {x,y});
        visited[x][y] = true;
           
        int X = grid.Length;
        int Y = grid[0].Length;
           
        while (stack.Any()) {
            var cur = stack.Pop();
            var curX = cur[0];
            var curY = cur[1];
            
            l++;
            
            
                
                if (curX < X - 1 && !visited[curX+1][curY] && grid[curX + 1][curY] == 1)
                {
                    stack.Push(new int[] {curX+ 1, curY});
                    visited[curX + 1][curY] = true;
                }
                if (curX > 0  && !visited[curX-1][curY] && grid[curX - 1][curY] == 1)
                {
                    stack.Push(new int[] {curX- 1, curY});
                    visited[curX - 1][curY] = true;
                }
                if (curY < Y - 1 && !visited[curX][curY + 1] && grid[curX][curY + 1] == 1)
                {
                    stack.Push(new int[] {curX, curY + 1});
                    visited[curX][curY + 1] = true;
                }
                if (curY > 0 && !visited[curX][curY - 1] && grid[curX][curY - 1] == 1)
                {
                      stack.Push(new int[] {curX, curY - 1});
                    visited[curX][curY - 1] = true;
                }

        }
           
        return l;
    }
    
    public int MaxAreaOfIsland(int[][] grid) {
        var visited = new bool[grid.Length][];
        for (int i = 0; i < grid.Length; i++) {
            visited[i] = new bool[grid[0].Length];
        }
        
        int max = 0;
        
        for (int i =0; i < grid.Length; i++) {
            for (int j =0; j < grid[0].Length; j++) {
                if (grid[i][j] == 1 && !visited[i][j]) {
                    var res = DFS(grid, visited, i, j);
                    if (res > max) max = res;
                }
            }
        }
        
        return max;
    }
}
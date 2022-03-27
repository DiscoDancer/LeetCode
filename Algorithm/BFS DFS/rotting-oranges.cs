using System.Collections.Generic;
using System.Linq;


/*
    Нужна таблица свежести:
        для каждой свежей туда класть минимум через сколько заразится (минимум)
        какое дефолное значение там хранить? сейчас максимум
        
*/

public class Solution {
    
    // input is not visited rotten cell
    public void CalcFreshPath(int[][] grid, int[][] freshness, int x, int y) {        
        // чтобы по несколько раз по свежим не ходить
        var visited = new bool[grid.Length][];
        for (int i = 0; i < grid.Length; i++) {
            visited[i] = new bool[grid[0].Length];
        }
        
        // x y l
        var queue = new Queue<int[]>();
        queue.Enqueue(new int [] {x, y, 0});
        
        int X = grid.Length;
        int Y = grid[0].Length;
        
        while (queue.Any()) {
            var cur = queue.Dequeue();
            var curX = cur[0];
            var curY = cur[1];
            var curL = cur[2];
            
            if (grid[curX][curY] == 1) {
                if (curL < freshness[curX][curY]) {
                    freshness[curX][curY] = curL;
                }
            }
            
            if (curX < X -1 && grid[curX+1][curY] == 1 && !visited[curX+1][curY]) {
                queue.Enqueue(new int [] {curX + 1, curY, curL + 1});
                visited[curX + 1][curY] = true;
            }
            if (curX > 0 && grid[curX-1][curY] == 1 && !visited[curX-1][curY]) {
                queue.Enqueue(new int [] {curX - 1, curY, curL + 1});
                visited[curX - 1][curY] = true;
            }
            
            if (curY < Y -1 && grid[curX][curY + 1] == 1 && !visited[curX][curY + 1]) {
                queue.Enqueue(new int [] {curX, curY + 1, curL + 1});
                visited[curX][curY + 1] = true;
            }
            if (curY > 0 && grid[curX][curY - 1] == 1 && !visited[curX][curY - 1]) {
                queue.Enqueue(new int [] {curX, curY - 1, curL + 1});
                visited[curX][curY - 1] = true;
            }
        }
    }
    
    public int OrangesRotting(int[][] grid) {
        var freshList = new List<int[]>();
        
        var freshness = new int[grid.Length][];
        for (int i = 0; i < grid.Length; i++) {
            freshness[i] = new int[grid[0].Length];
            for (int j = 0; j < grid[0].Length; j++) {
                freshness[i][j] = int.MaxValue;
            }
        }
        
        // для зараженных пофигу на visited, мы и так не пройдем 2 раза в квардратном цикле   
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                if (grid[i][j] == 1) {
                    freshList.Add(new int[] {i,j});
                }
                else if (grid[i][j] == 2) {
                    CalcFreshPath(grid, freshness, i, j);
                }
            }
        }
        
        if (!freshList.Any()) {
            return 0;
        } else {
            var freshes = freshList
                .Select(x => freshness[x[0]][x[1]])
                .ToArray();

            if (freshes.Any(x => x == int.MaxValue))
            {
                return -1;
            }

            return freshes.Where(x => x < int.MaxValue).Max();
        }
    }
}
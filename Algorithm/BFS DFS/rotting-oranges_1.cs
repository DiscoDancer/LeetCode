using System.Collections.Generic;
using System.Linq;


/*
    Нужна таблица свежести:
        для каждой свежей туда класть минимум через сколько заразится (минимум)
        какое дефолное значение там хранить? сейчас максимум
        
*/

public class Solution {
    public int OrangesRotting(int[][] grid) {
        
        var queue = new Queue<int[]>();
        var freshCount = 0;
        
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                if (grid[i][j] == 2) {
                    queue.Enqueue(new int[] {i,j});
                } else if (grid[i][j] == 1) {
                    freshCount++;
                }
            }
        }
        
        int X = grid.Length;
        int Y = grid[0].Length;
        
        int level = 0;
        
        if (freshCount == 0) {
            return 0;
        }
        
        while (queue.Any()) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                var curX = cur[0];
                var curY = cur[1];
                
                if (curX < X -1 && grid[curX+1][curY] == 1) {
                    grid[curX+1][curY] = 2;
                    freshCount--;
                    queue.Enqueue(new int[] {curX + 1,curY});
                }
                if (curX > 0 && grid[curX-1][curY] == 1) {
                    grid[curX-1][curY] = 2;
                    freshCount--;
                    queue.Enqueue(new int[] {curX - 1,curY});
                }
                
                if (curY < Y -1 && grid[curX][curY+1] == 1) {
                    grid[curX][curY + 1] = 2;
                    freshCount--;
                    queue.Enqueue(new int[] {curX,curY + 1});
                }
                if (curY > 0 && grid[curX][curY-1] == 1) {
                    grid[curX][curY-1] = 2;
                    freshCount--;
                    queue.Enqueue(new int[] {curX,curY - 1});
                }                
            }
            level++;
        }
        
        if (freshCount > 0) {
            return -1;
        }
        
        return level - 1;
    }
}
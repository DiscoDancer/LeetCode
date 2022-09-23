using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
        int X = image.Length;
        int Y = image[0].Length;
        
        var q = new Queue<int[]>();
        q.Enqueue(new int[] {sr, sc});
        
        var startColor =  image[sr][sc];
        
        var visited = new bool[X][];
        for (int i = 0; i < X; i++) {
            visited[i] = new bool[Y];
        }
        
        while (q.Any()) {
            var p = q.Dequeue();
            var x = p[0];
            var y = p[1];
            image[x][y] = newColor;
            visited[x][y] = true;
            
            if (x < X - 1 && image[x + 1][y] == startColor && !visited[x+1][y]) {
                q.Enqueue(new int[] {x + 1, y});
            }
            if (x > 0 && image[x - 1][y] == startColor && !visited[x-1][y]) {
                q.Enqueue(new int[] {x - 1, y});
            }
            
            if (y < Y - 1 && image[x][y + 1] == startColor && !visited[x][y + 1]) {
                q.Enqueue(new int[] {x, y + 1});
            }
            if (y > 0 && image[x][y - 1] == startColor &&  !visited[x][y - 1]) {
                q.Enqueue(new int[] {x, y - 1});
            }
        }
        
        return image;
        
    } 
}
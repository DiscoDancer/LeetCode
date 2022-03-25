using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
        
        var startColor = image[sr][sc];
        if (startColor == newColor) {
            return image;
        }
        
        int X = image.Length;
        int Y = image[0].Length;
        
        var q = new Queue<int[]>();
        q.Enqueue(new int[] {sr, sc});
        
        while (q.Any()) {
            var p = q.Dequeue();
            var x = p[0];
            var y = p[1];
            image[x][y] = newColor;
            
            if (x < X - 1 && image[x + 1][y] == startColor) {
                q.Enqueue(new int[] {x + 1, y});
            }
            if (x > 0 && image[x - 1][y] == startColor) {
                q.Enqueue(new int[] {x - 1, y});
            }
            
            if (y < Y - 1 && image[x][y + 1] == startColor) {
                q.Enqueue(new int[] {x, y + 1});
            }
            if (y > 0 && image[x][y - 1] == startColor) {
                q.Enqueue(new int[] {x, y - 1});
            }
        }
        
        return image;
        
    } 
}
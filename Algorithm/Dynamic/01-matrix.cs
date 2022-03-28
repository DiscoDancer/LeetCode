using System.Collections.Generic;

public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {
        var queue = new Queue<int[]>();
        
        var distances = new int[mat.Length][];
        for (int i = 0; i < mat.Length; i++) {
            distances[i] = new int[mat[0].Length];
            for (int j = 0; j < mat[0].Length; j++) {
                if (mat[i][j] == 0) {
                    distances[i][j] = 0;
                    queue.Enqueue(new int[] {i,j});
                } else {
                    distances[i][j] = int.MaxValue;
                }
            }
        }
        
        int X = distances.Length;
        int Y = distances[0].Length;
        
        while (queue.Any()) {
            var cur = queue.Dequeue();
            var curX = cur[0];
            var curY = cur[1];
            
            if (curX < X - 1 && distances[curX + 1][curY] > distances[curX][curY] + 1) {
                distances[curX + 1][curY] = distances[curX][curY] + 1;
                queue.Enqueue(new int[] {curX + 1,curY});
            }
            if (curX > 0 && distances[curX - 1][curY] > distances[curX][curY] + 1) {
                distances[curX - 1][curY] = distances[curX][curY] + 1;
                queue.Enqueue(new int[] {curX - 1,curY});
            }
            if (curY < Y - 1 && distances[curX][curY + 1] > distances[curX][curY] + 1) {
                distances[curX][curY + 1] = distances[curX][curY] + 1;
                queue.Enqueue(new int[] {curX,curY + 1});
            }
            if (curY > 0 && distances[curX][curY-1] > distances[curX][curY] + 1) {
                distances[curX][curY - 1] = distances[curX][curY] + 1;
                queue.Enqueue(new int[] {curX,curY - 1});
            }
        }
        
        return distances;
        
    }
}
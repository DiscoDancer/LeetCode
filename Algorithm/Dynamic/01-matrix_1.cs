using System.Collections.Generic;

public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {

        
        var distances = new int[mat.Length][];
        for (int i = 0; i < mat.Length; i++) {
            distances[i] = new int[mat[0].Length];
            for (int j = 0; j < mat[0].Length; j++) {
                if (mat[i][j] == 0) {
                    distances[i][j] = 0;
                } else {
                    distances[i][j] = int.MaxValue;
                }
            }
        }
        
        int X = distances.Length;
        int Y = distances[0].Length;
        
        
        for (int i = 0; i < mat.Length; i++) {
            for (int j = 0; j < mat[0].Length; j++) {
                if (i > 0 &&  distances[i - 1][j] < int.MaxValue) {
                    distances[i][j] = Math.Min(distances[i][j], distances[i - 1][j] + 1);
                }
                if (j > 0 && distances[i][j-1] < int.MaxValue) {
                    distances[i][j] = Math.Min(distances[i][j], distances[i][j - 1] + 1);
                }

            }
        }
        
        for (int i = X - 1; i >= 0; i--) {
            for (int j =  Y - 1; j >= 0; j--) {
                if (i < X - 1 &&  distances[i + 1][j] < int.MaxValue) {
                    distances[i][j] = Math.Min(distances[i][j], distances[i + 1][j] + 1);
                }
                if (j < Y - 1 && distances[i][j+1] < int.MaxValue) {
                    distances[i][j] = Math.Min(distances[i][j], distances[i][j + 1] + 1);
                }
            }
        }
        
        
        
        return distances;
        
    }
}
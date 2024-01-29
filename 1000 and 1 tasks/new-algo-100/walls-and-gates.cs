public class Solution {
    public void WallsAndGates(int[][] rooms) {
        // find gates
        // chain update if makes better

        var X = rooms.Length;
        var Y = rooms[0].Length;

        var queue = new Queue<(int x, int y, int d)>();

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                // gate
                if (rooms[i][j] == 0) {
                    queue.Enqueue((i,j,0));
                }
            }
        }

        while (queue.Any()) {
            var (x,y,d) = queue.Dequeue();

            if (x > 0 && rooms[x-1][y] > d + 1) {
                rooms[x-1][y] = d + 1;
                queue.Enqueue((x-1,y,d+1));
            }
            if (x < X - 1 && rooms[x+1][y] > d + 1) {
                rooms[x+1][y] = d + 1;
                queue.Enqueue((x+1,y,d+1));
            }

            if (y > 0 && rooms[x][y-1] > d + 1) {
                rooms[x][y-1] = d + 1;
                queue.Enqueue((x,y-1,d+1));
            }
            if (y < Y - 1 && rooms[x][y+1] > d + 1) {
                rooms[x][y+1] = d + 1;
                queue.Enqueue((x,y+1,d+1));
            }
        }
    }
}
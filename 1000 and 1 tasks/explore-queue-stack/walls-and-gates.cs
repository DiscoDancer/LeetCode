public class Solution {
    // идем от гейтов и обновляем комнаты
    // visited ? идем если только уменьшаем
    public void WallsAndGates(int[][] rooms) {
        var X = rooms.Length;
        var Y = rooms[0].Length;
        var queue = new Queue<(int x, int y)>();

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (rooms[i][j] == 0) {
                    queue.Enqueue((i,j));
                }
            }
        }

        while (queue.Any()) {
            var size = queue.Count();
            // мне нужен тут цикл или нет, с поколениями понятно следующее расстояние
            for (int i = 0; i < size; i++) { 
                var (curX, curY) = queue.Dequeue();
                var newDistance = rooms[curX][curY] + 1;

                if (curX > 0 && rooms[curX - 1][curY] > newDistance) {
                    rooms[curX - 1][curY] = newDistance;
                    queue.Enqueue((curX - 1,curY));
                }
                if (curX < X - 1 && rooms[curX + 1][curY] > newDistance) {
                    rooms[curX + 1][curY] = newDistance;
                    queue.Enqueue((curX + 1,curY));
                }

                if (curY > 0 && rooms[curX][curY - 1] > newDistance) {
                    rooms[curX][curY - 1] = newDistance;
                    queue.Enqueue((curX,curY - 1));
                }
                if (curY < Y - 1 && rooms[curX][curY + 1] > newDistance) {
                    rooms[curX][curY + 1] = newDistance;
                    queue.Enqueue((curX,curY + 1));
                }
            }
        }
    }
}
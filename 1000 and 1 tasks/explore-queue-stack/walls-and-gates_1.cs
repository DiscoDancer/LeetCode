public class Solution
{
    // идем от гейтов и обновляем комнаты
    // нужно посещать повторно, чтобы обновлять
    public void WallsAndGates(int[][] rooms)
    {
        var X = rooms.Length;
        var Y = rooms[0].Length;
        var queue = new Queue<(int x, int y)>();

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (rooms[i][j] == 0)
                {
                    queue.Enqueue((i, j));
                }
            }
        }

        while (queue.Any())
        {
            var (curX, curY) = queue.Dequeue();
            // можно через for и поколение
            var newDistance = rooms[curX][curY] + 1;

            if (curX > 0 && rooms[curX - 1][curY] > newDistance)
            {
                rooms[curX - 1][curY] = newDistance;
                queue.Enqueue((curX - 1, curY));
            }
            if (curX < X - 1 && rooms[curX + 1][curY] > newDistance)
            {
                rooms[curX + 1][curY] = newDistance;
                queue.Enqueue((curX + 1, curY));
            }

            if (curY > 0 && rooms[curX][curY - 1] > newDistance)
            {
                rooms[curX][curY - 1] = newDistance;
                queue.Enqueue((curX, curY - 1));
            }
            if (curY < Y - 1 && rooms[curX][curY + 1] > newDistance)
            {
                rooms[curX][curY + 1] = newDistance;
                queue.Enqueue((curX, curY + 1));
            }

        }
    }
}
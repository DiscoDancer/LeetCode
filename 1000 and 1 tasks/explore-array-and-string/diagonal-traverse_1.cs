public class Solution {
    // сколько диагоналей
    // очередь с приоритетом
    // просто BFS
    // мб очередь и стек будут чередоваться;
    // level order
    public int[] FindDiagonalOrder(int[][] mat) {
        var X = mat.Length;
        var Y = mat[0].Length;

        // todo заменить на array
        var result = new List<int>();


        var queue = new Queue<(int, int)>();
        queue.Enqueue((0,0));

        var generation = 0;
        while (queue.Any()) {
            var size = queue.Count();
            // кладем в стек или в другую очередь в зависимости от уровня
            var outputQueue = new Queue<int>();
            var outputStack = new Stack<int>();
            for (int i = 0; i < size; i++) {
                // кладем в очередь соседней
                var (x, y) = queue.Dequeue();
                // нижкий нужен только для первого (видно по картинке)
                if (x < X - 1 && i == 0) {
                    queue.Enqueue((x+1, y));
                }
                if (y < Y - 1) {
                    queue.Enqueue((x, y + 1));
                }

                if (generation % 2 == 0) {
                    outputQueue.Enqueue(mat[x][y]);
                }
                else {
                    outputStack.Push(mat[x][y]);
                }    
            }

            
            // опустошаем стек или другую очередь в результат
            while (outputQueue.Any()) {
                result.Add(outputQueue.Dequeue());
            }
            while (outputStack.Any()) {
                result.Add(outputStack.Pop());
            }

            generation++;
        }

        return result.ToArray();
    }
}
// Это неверно, но попытка неплохая. Базовые кейсы проходят

public class Solution {
    // двигать квадратики, а потом сделать range queries
    // или их даже сразу проще сделать
    // это сработало бы, если бы давали матрицу

    // пусть у меня есть матрица пустая, мне надо оптимально разместить единички и потом посчитать
    // оптимально размещать подальше от пересечений (пример 1)

    // размечаю каждую клетку, сколько на нее приходится квадратов
    // потом иду по каждому квадрату и там вписываю maxOnes в приоритетом в клетки, гле меньше всего квадратов
    // доп условие за раунд нельзя ставить в один квадрат дважды

    public int MaximumNumberOfOnes(int width, int height, int sideLength, int maxOnes)
    {
        var squareCountInRow = 1 + width - sideLength;
        var squareCountInColumn = 1 + height - sideLength;
        // var squareCount = squareCountInRow * squareCountInColumn;
        
        

        var squareList = new List<(int x, int y)>();
        var x = 0;
        for (var lineIndex = 0; lineIndex < squareCountInColumn; lineIndex++)
        {   var y = 0;
            for (var columnIndex = 0; columnIndex < squareCountInRow; columnIndex++)
            {
                squareList.Add((x,y));
                y += 1;
            }
            x += 1;
        }

        var pointToSquareIndexes = new List<int>[height, width];
        
        for (int hi = 0; hi < height; hi++)
        {
            for (int wi = 0; wi < width; wi++)
            {
                pointToSquareIndexes[hi, wi] = new List<int>();

                for (int si = 0; si < squareList.Count; si++)
                {
                    var (x0, y0) = squareList[si];
                    var x1 = x0 + sideLength;
                    var y1 = y0 + sideLength;

                    if (hi >= x0 && hi < x1 && y0 <= wi && wi < y1)
                    {
                        pointToSquareIndexes[hi, wi].Add(si);
                    }
                    
                    // x line, y column
                    
                    // если точка внутри квадрата, то пишем индекс
                }
            }
        }
        
        var pqPoints = new PriorityQueue<(int x, int y), int>();
        for (int hi = 0; hi < height; hi++)
        {
            for (int wi = 0; wi < width; wi++)
            {
                pqPoints.Enqueue((hi, wi), pointToSquareIndexes[hi,wi].Count);
            }
        }

        var squareStatuses = new int[squareList.Count];
        
        // for maxOnes

        var finalMatrix = new int[height, width];

        for (int maxOne = 0; maxOne < maxOnes; maxOne++)
        {
            var newPqPoints = new PriorityQueue<(int x, int y), int>();
            while (pqPoints.Count > 0)
            {
                var (_x,_y) = pqPoints.Dequeue();
                var squareIndexes = pointToSquareIndexes[_x, _y];
                if (squareIndexes.Select(s => squareStatuses[s]).All(s => s == maxOne))
                {
                    foreach (var si in squareIndexes)
                    {
                        squareStatuses[si]++;
                    }

                    finalMatrix[_x, _y] = 1;
                }
                else
                {
                    newPqPoints.Enqueue((_x,_y), pointToSquareIndexes[_x,_y].Count);
                }
            }

            pqPoints = newPqPoints;
        }
        
        var result = 0;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                // Console.Write(finalMatrix[i,j] + " ");
                if (finalMatrix[i, j] == 1)
                {
                    result++;
                }
            }

            // Console.WriteLine();
        }

        return result;
    }
}
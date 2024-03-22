using System.Text;
using System.Text.Json;

namespace ConsoleApp1;


// обратная задача = неверный ответ

public class CurTask
{
    public int MaximumNumberOfOnes(int width, int height, int sideLength, int maxOnes)
    {
        var squareCountInRow = 1 + width - sideLength;
        var squareCountInColumn = 1 + height - sideLength;

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
                pqPoints.Enqueue((hi, wi), -pointToSquareIndexes[hi,wi].Count);
            }
        }

        var squareStatuses = new int[squareList.Count];
        Array.Fill(squareStatuses, sideLength * sideLength);
        var answer = width * height;

        var finalMatrix = new int[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                finalMatrix[i, j] = 1;
            }
        }

        var onesToRemove = sideLength * sideLength - maxOnes;
        var targetMin = sideLength * sideLength;
        for (int roundIndex = 0; roundIndex < onesToRemove; roundIndex++)
        {
            targetMin--;
            var newPqPoints = new PriorityQueue<(int x, int y), int>();
            while (pqPoints.Count > 0)
            {
                var (_x,_y) = pqPoints.Dequeue();
                var currentMin = squareStatuses.Max();
                if (currentMin > targetMin)
                {
                    var squareIndexes = pointToSquareIndexes[_x, _y];
                    foreach (var si in squareIndexes)
                    {
                        squareStatuses[si]--;
                        
                    }

                    finalMatrix[_x, _y] = 0;
                    answer--;
                }
                else
                {
                    newPqPoints.Enqueue((_x,_y), -pointToSquareIndexes[_x,_y].Count);
                }
            }
            pqPoints = newPqPoints;
        }
        
        var result = 0;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(finalMatrix[i,j] + " ");
                if (finalMatrix[i, j] == 1)
                {
                    result++;
                }
            }

            Console.WriteLine();
        }

        return answer;
    }
}
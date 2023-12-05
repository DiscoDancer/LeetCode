public class Solution {
    // бинарный поиск по всем элементам первой строки = n*m*log(n) без доп памяти

    // таблица по всем элементам m*n и доп память 10K или m*n
    // важно избегать дубликатов


    // можно с указателями, тогда нужно меньше памяти

    public int SmallestCommonElement(int[][] mat) {
        var linesCount = mat.Length;
        var columnsCount = mat[0].Length;
        var pointers = new int[linesCount];
        var maxPointer = 0;
        var maxValue = -1;
        
        while (maxPointer < columnsCount)
        {
            var countEqualsMax = 0;
            for (int lineIndex = 0; lineIndex < linesCount; lineIndex++) {
                if (pointers[lineIndex] < columnsCount)
                {
                    if (mat[lineIndex][pointers[lineIndex]] == maxValue)
                    {
                        countEqualsMax++;
                    }
                }

                while (pointers[lineIndex] < columnsCount && mat[lineIndex][pointers[lineIndex]] < maxValue) {
                    pointers[lineIndex]++;
                    maxPointer = Math.Max(maxPointer, pointers[lineIndex]);
                    if (pointers[lineIndex] < columnsCount) {
                        maxValue = Math.Max(maxValue, mat[lineIndex][pointers[lineIndex]]);
                    }
                }
                
                if (pointers[lineIndex] < columnsCount)
                {
                    maxValue = Math.Max(maxValue, mat[lineIndex][pointers[lineIndex]]);
                }
            }

            if (countEqualsMax == linesCount)
            {
                return maxValue;
            }
        }
        
        return -1;
    }
}
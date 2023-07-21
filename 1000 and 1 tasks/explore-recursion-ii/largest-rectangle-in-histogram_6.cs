public class Solution {

    // https://leetcode.com/problems/largest-rectangle-in-histogram/solutions/28902/5ms-o-n-java-solution-explained-beats-96/

    /*
        Тут прикол такой, что он заводит окрестности, которые не включаются
        то есть для 1-8-1 в окрестость 8 попадут обе 1. 
        Отсюда такая формула lessFromRight[i] - lessFromLeft[i] - 1
        Если бы мы взяли только 8 без окрестности, можно было бы считать lessFromRight[i] - lessFromLeft[i] + 1

        Ну вот и эти его окрестности позволяют включить динамическое программирование.
        Задаем базовый случай слева: lessFromLeft[0] = -1 и справа: lessFromRight[heights.Length - 1] = heights.Length;
        Отсальные случаи считаем
    */

    public int LargestRectangleArea(int[] heights) {
        var lessFromLeft = new int[heights.Length];
        var lessFromRight = new int[heights.Length];

        lessFromLeft[0] = -1;
        for (int i = 1; i < heights.Length; i++) {
            var p = i-1;
            while (p >= 0 && heights[p] >= heights[i])
            {
                p = lessFromLeft[p];
            }
            lessFromLeft[i] = p;
        }


        lessFromRight[heights.Length - 1] = heights.Length;
        for (int i = heights.Length - 2; i >= 0; i--) {
            var p = i+1;
            while (p < heights.Length && heights[p] >= heights[i]) {
                p = lessFromRight[p];
            }
            lessFromRight[i] = p;
        }


        var max = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            max = Math.Max(max, heights[i]);
            max = Math.Max(max, heights[i] * (lessFromRight[i] - lessFromLeft[i] - 1));
        }

        return max;
    }
}
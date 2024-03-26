public class Solution {
    // https://leetcode.com/problems/maximum-number-of-ones/solutions/377099/c-solution-with-explanation
    // забыли про разрезы
    // если я ставлю 1 в точку (i,j), то везде где (p % sideLength == i, q % sizeLength == j) получим 1 бесплатно.
    // не читая дальше, можно разбить точки на группы и сортировать по эффективности
    public int MaximumNumberOfOnes(int width, int height, int sideLength, int maxOnes) {
        var table = new Dictionary<(int x, int y), int>();

        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                var x = i % sideLength;
                var y = j % sideLength;

                if (!table.ContainsKey((x,y))) {
                    table[(x,y)] = 0;
                }
                table[(x,y)]++;
            }
        }

        var sortedKeys = table.Values.OrderByDescending(x => x).ToArray();
        var result = 0;
        for (int i = 0; i < maxOnes; i++) {
            result += sortedKeys[i];
        }

        return result;
    }
}
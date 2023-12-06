public class Solution {
    // можно сохранить подозрительные B
    public int FindLonelyPixel(char[][] picture) {
        var linesCount = picture.Length;
        var columnsCount = picture[0].Length;

        var lineState = new int[linesCount];
        var columnState = new int[columnsCount];

        for (int line = 0; line < picture.Length; line++) {
            for (int column = 0; column < picture[line].Length; column++) {
                if (picture[line][column] == 'B') {
                    lineState[line]++;
                    columnState[column]++;
                }
            }
        }

        var result = 0;
        for (int line = 0; line < picture.Length; line++) {
            for (int column = 0; column < picture[line].Length; column++) {
                if (picture[line][column] == 'B' && lineState[line] == 1 && columnState[column] == 1) {
                    result++;
                }
            }
        }

        return result;
    }
}
import java.util.List;

class Solution {
    public int minimumTotal(List<List<Integer>> triangle) {
        var levelCount = triangle.size();
        var table = new int[levelCount][levelCount];

        for (int j = 0; j < triangle.get(levelCount-1).size(); j++) {
            table[levelCount-1][j] = triangle.get(levelCount-1).get(j);
        }

        for (var currentLevelIndex = levelCount - 2; currentLevelIndex >= 0; currentLevelIndex--) {
            for (var intCurrentIndex = 0; intCurrentIndex < triangle.get(currentLevelIndex).size(); intCurrentIndex++) {
                table[currentLevelIndex][intCurrentIndex] = triangle.get(currentLevelIndex).get(intCurrentIndex) + Math.min(table[currentLevelIndex + 1][intCurrentIndex], table[currentLevelIndex + 1][intCurrentIndex + 1]);
            }
        }

        return table[0][0];
    }
}

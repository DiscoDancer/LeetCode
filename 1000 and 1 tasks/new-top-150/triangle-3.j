import java.util.List;

class Solution {

    private List<List<Integer>> triangle;

    private int F(int currentLevelIndex, int intCurrentIndex) {
        if (currentLevelIndex == triangle.size() - 1) {
            return triangle.get(currentLevelIndex).get(intCurrentIndex);
        }

        var optionA = F(currentLevelIndex + 1, intCurrentIndex);
        var optionB = F(currentLevelIndex + 1, intCurrentIndex + 1);

        return triangle.get(currentLevelIndex).get(intCurrentIndex) + Math.min(optionA, optionB);
    }

    public int minimumTotal(List<List<Integer>> triangle) {
        this.triangle = triangle;
        return F(0, 0);
    }
}

import java.util.List;

class Solution {

    private List<List<Integer>> triangle;

    private int F(int currentLevelIndex, int lastColumnIndex) {
        if (currentLevelIndex == triangle.size()) {
            return 0;
        }

        if (currentLevelIndex == 0) {
            return triangle.get(0).get(0) + F(1, 0);
        }

        var option1 = triangle.get(currentLevelIndex).get(lastColumnIndex + 1) +  F(currentLevelIndex + 1, lastColumnIndex + 1);
        var option2 = triangle.get(currentLevelIndex).get(lastColumnIndex) +  F(currentLevelIndex + 1, lastColumnIndex);

        return Math.min(option1, option2);
    }

    public int minimumTotal(List<List<Integer>> triangle) {
        this.triangle = triangle;

        return F(0, -1);
    }
}

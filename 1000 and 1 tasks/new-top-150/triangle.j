import java.util.List;

class Solution {

    private List<List<Integer>> triangle;
    private int min = Integer.MAX_VALUE;

    // TL

    private void F(int currentLevelIndex, int lastColumnIndex, int sum) {
        if (currentLevelIndex == triangle.size()) {
            min = Math.min(min, sum);
            return;
        }

        if (currentLevelIndex == 0) {
            F(1, 0, triangle.get(0).get(0));
            return;
        }

        F(currentLevelIndex + 1, lastColumnIndex + 1, sum + triangle.get(currentLevelIndex).get(lastColumnIndex + 1));
        F(currentLevelIndex + 1, lastColumnIndex, sum + triangle.get(currentLevelIndex).get(lastColumnIndex));
    }

    public int minimumTotal(List<List<Integer>> triangle) {
        this.triangle = triangle;

        F(0, -1, 0);

        return min;
    }
}

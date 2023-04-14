public class Solution {
    // 0 red 1 white 2 blue
    // мб посчитать
    public void SortColors(int[] nums) {
        var redCount = 0;
        var whiteCount = 0;
        var blueCount = 0;

        foreach (var num in nums) {
            if (num == 0) {
                redCount++;
            }
            else if (num == 1) {
                whiteCount++;
            }
            else if (num == 2) {
                blueCount++;
            }
        }

        var globalIndex = 0;
        var i = 0;
        while (i++ < redCount) {
            nums[globalIndex++] = 0;
        }

        i = 0;
        while (i++ < whiteCount) {
            nums[globalIndex++] = 1;
        }

        i = 0;
        while (i++ < blueCount) {
            nums[globalIndex++] = 2;
        }
    }
}
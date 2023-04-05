public class Solution {
    public int HeightChecker(int[] heights) {
        var table = new int[101];
        foreach (var h in heights) {
            table[h]++;
        }

        int result = 0;
        int curHeight = 0;

        // https://leetcode.com/problems/height-checker/solutions/300472/java-0ms-o-n-solution-no-need-to-sort/
        for (int i = 0; i < heights.Length; i++) {
            while (table[curHeight] == 0) {
                curHeight++;
            }
            
            if (curHeight != heights[i]) {
                result++;
            }
            table[curHeight]--;
        }
        
        return result;
    }
}
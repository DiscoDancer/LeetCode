import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    public int minimumTotal(List<List<Integer>> triangle) {

        var prevLine = new int[] {triangle.get(0).get(0)};
        for (var lineIndex = 1; lineIndex < triangle.size(); lineIndex++) {
            var curLine = new int[lineIndex+1];
            for (var rowIndex = 0; rowIndex < triangle.get(lineIndex).size(); rowIndex++) {
                var prevPrev = rowIndex > 0 ? prevLine[rowIndex-1] : Integer.MAX_VALUE;
                var prev = rowIndex < triangle.get(lineIndex).size() - 1 ? prevLine[rowIndex]: Integer.MAX_VALUE;
                curLine[rowIndex] = Math.min(prevPrev, prev) + triangle.get(lineIndex).get(rowIndex);
            }
            prevLine = curLine;
        }

        return Arrays.stream(prevLine).min().getAsInt();
    }
}

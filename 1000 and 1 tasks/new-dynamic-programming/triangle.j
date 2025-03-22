import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    public int minimumTotal(List<List<Integer>> triangle) {

        for (var lineIndex = 1; lineIndex < triangle.size(); lineIndex++) {
            for (var rowIndex = 0; rowIndex < triangle.get(lineIndex).size(); rowIndex++) {

                var prevPrev = rowIndex > 0 ? triangle.get(lineIndex-1).get(rowIndex-1) : Integer.MAX_VALUE;
                var prev = rowIndex < triangle.get(lineIndex).size() - 1 ? triangle.get(lineIndex-1).get(rowIndex) : Integer.MAX_VALUE;
                triangle.get(lineIndex).set(rowIndex, Math.min(prevPrev, prev) + triangle.get(lineIndex).get(rowIndex));
            }
        }

        return triangle.get(triangle.size()-1).stream().min(Integer::compare).get();
    }
}
